using Calibration.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.View.Pages
{

    public partial class CalibrationPage : Form
    {
        readonly List<Control> calibrationControls;
        public CalibrationPage()
        {
            InitializeComponent();

            calibrationControls = new List<Control>
            {
                labelTimeRemain,
                chartCalibrationSimulation,
                labelZeroRef,
                labelZeroMeas,
                labelZeroDiff,
                labelZeroStd,
                labelSpanRef,
                labelSpanMeas,
                labelSpanDiff,
                labelSpanStd,
                labelResultFactor
            };
        }

        private void buttonAKMZero_Click(object sender, EventArgs e)
        {
            CalibrationService calibrationService = new CalibrationService();
            calibrationService.StartCalibration("AKM", "Zero", 10, calibrationControls);
        }

        private void buttonPhZero_Click(object sender, EventArgs e)
        {
            CalibrationService calibrationService = new CalibrationService();
            calibrationService.StartCalibration("Ph", "Zero", 30, calibrationControls);
        }

        private void buttonIletkenlikZero_Click(object sender, EventArgs e)
        {
            CalibrationService calibrationService = new CalibrationService();
            calibrationService.StartCalibration("Iletkenlik", "Zero", 30, calibrationControls);
        }
    }
}
