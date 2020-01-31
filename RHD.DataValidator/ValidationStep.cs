using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RHDBatchChecker
{
	public class ValidationStep: INotifyPropertyChanged
	{
		private ValidationStepStatus status;
		private string validationStepMessage;
		public event PropertyChangedEventHandler PropertyChanged;
		public int ValidationStepID { get; set; }
		public string ValidationStepDescription { get; set; }

		public ValidationStepStatus Status
		{
			get { return status; }
			set { status = value;  OnPropertyChanged(); OnPropertyChanged("StatusImage"); }
		}
		public string ValidationStepStatusMessage
		{
			get { return validationStepMessage; }
			set
			{
				validationStepMessage = value;
				OnPropertyChanged();
			}
		}
		public Image StatusImage
		{
			get
			{
				switch (Status)
				{
					case ValidationStepStatus.PASSED:
						return PH18DataValidator.Properties.Resources.greentick;
					case ValidationStepStatus.FAILED:
						return PH18DataValidator.Properties.Resources.redcross;
					default:
						Bitmap bmp = new Bitmap(78, 78);
						using (Graphics gr = Graphics.FromImage(bmp))
						{
							gr.Clear(Color.FromKnownColor(KnownColor.Window));
							return bmp;
						}
				}
			}
		}

		// Create the OnPropertyChanged method to raise the event
		// The calling member's name will be used as the parameter.
		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}

	public enum ValidationStepStatus
	{
		NOT_VALIDATED = 0,
		PASSED = 1,
		FAILED = 2
	}
}
