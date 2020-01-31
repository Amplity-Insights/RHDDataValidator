using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace RHDBatchChecker
{
	public partial class MainForm : Form
	{
		BindingList<ValidationStep> validationSteps = null;
		const int VALIDATION_STEP_VERIFY_PARENT_FOLDER_NAME = 1;
		const int VALIDATION_STEP_VERIFY_METADATA_FILE = 2;
		const int VALIDATION_STEP_VERIFY_STATE_NAMES = 3;
		const int VALIDATION_STEP_VERIFY_ZIP_FILE_INTEGRITY = 4;
		const int VALIDATION_STEP_VERIFY_FOLDERS_EXIST = 5;
		const int VALIDATION_STEP_VERIFY_ENCRYPTION = 6;

		const string METADATA_FILE_NAME = "metadata.csv";

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Initialize
			validationSteps = new BindingList<ValidationStep>();
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_PARENT_FOLDER_NAME, ValidationStepDescription = "Parent folder correctly named", Status = ValidationStepStatus.NOT_VALIDATED });
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_METADATA_FILE, ValidationStepDescription = "Checking metadata.csv", Status = ValidationStepStatus.NOT_VALIDATED });
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_STATE_NAMES, ValidationStepDescription = "Verify state names", Status = ValidationStepStatus.NOT_VALIDATED });
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_ZIP_FILE_INTEGRITY, ValidationStepDescription = "Zip file integrity", Status = ValidationStepStatus.NOT_VALIDATED });
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_FOLDERS_EXIST, ValidationStepDescription = "All folders exist", Status = ValidationStepStatus.NOT_VALIDATED });
			validationSteps.Add(new ValidationStep() { ValidationStepID = VALIDATION_STEP_VERIFY_ENCRYPTION, ValidationStepDescription = "Text files are encrypted", Status = ValidationStepStatus.NOT_VALIDATED });
			dataGridView.DataSource = validationSteps;
		}

		private void btnValidate_Click(object sender, EventArgs e)
		{
			btnValidate.Enabled = false;
			Validate();
			btnValidate.Enabled = true;
		}

		private void Validate()
		{
			DirectoryInfo folder = new DirectoryInfo(txtDataSource.Text);

			ValidationStep step = null;

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_PARENT_FOLDER_NAME).FirstOrDefault();
			try
			{
				VerifyParentFolderName(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_METADATA_FILE).FirstOrDefault();
			try
			{
				VerifyMetadataFile(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_STATE_NAMES).FirstOrDefault();
			try
			{
				VerifyStateNames(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_ZIP_FILE_INTEGRITY).FirstOrDefault();
			try
			{
				VerifyZipFileIntegrity(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_FOLDERS_EXIST).FirstOrDefault();
			try
			{
				VerifyFoldersExist(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}

			step = validationSteps.Where(l => l.ValidationStepID == VALIDATION_STEP_VERIFY_ENCRYPTION).FirstOrDefault();
			try
			{
				VerifyFileEncryption(folder);
				step.Status = ValidationStepStatus.PASSED;
			}
			catch (ValidationException ex)
			{
				step.Status = ValidationStepStatus.FAILED;
				step.ValidationStepStatusMessage = ex.Message;
				return;
			}
		}

		private void btnChooseFolder_Click(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtDataSource.Text = folderBrowserDialog.SelectedPath;
			}

			dataGridView.Visible = true;
			btnValidate.Enabled = true;

			foreach (ValidationStep step in validationSteps)
			{
				step.Status = ValidationStepStatus.NOT_VALIDATED;
				step.ValidationStepStatusMessage = string.Empty;
			}
		}

		private void VerifyParentFolderName(DirectoryInfo directory)
		{
			try
			{
				DateTime.ParseExact(directory.Name, "yyyy_MM", CultureInfo.InvariantCulture);
			}
			catch(FormatException ex)
			{
				throw new ValidationException("Parent folder name '" + directory.Name + "' incorrectly named");
			}
		}

		private void VerifyMetadataFile(DirectoryInfo directory)
		{
			string metadataFilePath = Path.Combine(directory.FullName, METADATA_FILE_NAME);

			if (File.Exists(metadataFilePath))
			{
				return;
			}
			else
			{
				throw new ValidationException("Cannot find metadata.csv");
			}
		}

		private void VerifyStateNames(DirectoryInfo directory)
		{
			string metadataFilePath = Path.Combine(directory.FullName, METADATA_FILE_NAME);

			List<string> stateNames = new List<string>();
			foreach (string stateName in PH18DataValidator.Properties.Resources.state_names.Split('\n'))
				stateNames.Add(stateName.TrimEnd('\r'));

			using (TextFieldParser csvReader = new TextFieldParser(metadataFilePath))
			{
				csvReader.SetDelimiters(new string[] { "," });
				csvReader.HasFieldsEnclosedInQuotes = true;

				int lineNumber = 1;
				while (!csvReader.EndOfData)
				{
					string[] fieldData = csvReader.ReadFields();
					if (lineNumber != 0) // ignore header row
					{
						string stateName = fieldData[2];
						if(stateName == string.Empty)
							throw new ValidationException("Line " + lineNumber + " in metadata: missing state");

						if (!stateNames.Contains(stateName))
							throw new ValidationException(stateName + " is not a valid state");
					}
					lineNumber++;
				}
			}
		}

		private void VerifyZipFileIntegrity(DirectoryInfo directory)
		{
			foreach (FileInfo file in directory.GetFiles())
			{
				if (file.Extension == ".zip")
				{
					try
					{
						using (ZipArchive zipFile = ZipFile.OpenRead(file.FullName))
						{
							var entries = zipFile.Entries;
						}
					}
					catch (InvalidDataException)
					{
						throw new ValidationException(file.Name + "is not a valid zip file");
					}
				}
			}
		}

		private void VerifyFoldersExist(DirectoryInfo directory)
		{
			string metadataFilePath = Path.Combine(directory.FullName, METADATA_FILE_NAME);
			if (File.Exists(metadataFilePath))
			{
				string batchName = directory.Name;

				string csvData = File.ReadAllText(metadataFilePath);

				int rowNum = 1;
				foreach (string row in csvData.Split('\n'))
				{
					if (rowNum != 1 && !string.IsNullOrEmpty(row))
					{
						string relativePath = row.Split(',')[0];
						string zipFileName = null;
						if (relativePath.StartsWith("/"))
						{
							zipFileName = batchName + ".zip"; // there should be only 1 zip file called <batch_name>.zip
						}
						else if (relativePath.Contains("/"))
						{
							zipFileName = relativePath.Substring(0, relativePath.IndexOf("/")) + ".zip"; // there are multiple zip files each containing sub-folders
						}
						else
						{
							zipFileName = relativePath + ".zip"; // multiple zip files
						}

						string zipFilePath = Path.Combine(directory.FullName, zipFileName);

						if (!File.Exists(zipFilePath))
						{
							throw new ValidationException(zipFilePath + " does not exist");
						}
						else if (relativePath.Contains("/"))
						{
							// we need to check that the subfolders are contained within the zip file
							bool folderFoundWithinZipFile = false;

							using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
							{
								foreach (ZipArchiveEntry entry in archive.Entries)
								{
									if (entry.FullName.StartsWith(relativePath.TrimStart('/') + "/"))
									{
										folderFoundWithinZipFile = true;
										break;
									}
								}
							}

							if (!folderFoundWithinZipFile)
								throw new ValidationException("Could not find path " + relativePath + " within file " + zipFilePath);
						}
					}
					rowNum++;
				}
			}
		}

		private void VerifyFileEncryption(DirectoryInfo directory)
		{
			foreach (FileInfo file in directory.GetFiles())
			{
				if (file.Extension == ".zip")
				{
					try
					{
						using (ZipArchive zipFile = ZipFile.OpenRead(file.FullName))
						{
							foreach (ZipArchiveEntry entry in zipFile.Entries)
							{
								if (entry.FullName.EndsWith(".txt"))
								{
									using (var stream = entry.Open())
									{
										StreamReader reader = new StreamReader(stream);
										string text = reader.ReadLine();
										if (Regex.Match(text, @"^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)?").Success)
											break;
										else
											throw new ValidationException("File " + entry.FullName + " not encrypted in " + file.FullName);

									}
								}
							}
						}
					}
					catch (InvalidDataException)
					{
						throw new ValidationException(file.Name + " is not a valid zip file");
					}
				}
			}
		}
	}
}
