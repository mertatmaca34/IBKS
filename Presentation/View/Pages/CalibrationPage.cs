using Business.Interfaces;
using Business.Services;
using Calibration.Services;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Presentation.View.Pages
{

    public partial class CalibrationPage : Form
    {
        private readonly ICalibrationDTOService calibrationDTOService = new CalibrationDTOService();

        CalibrationService calibrationService = new CalibrationService();

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
                labelResultFactor,
                labelActiveCalibration
            };

            ColorStatementPanel();
        }

        private void buttonAKMZero_Click(object sender, EventArgs e)
        {
            calibrationService.StartCalibration("AKM", "Zero", 10, calibrationControls);
        }

        private void buttonPhZero_Click(object sender, EventArgs e)
        {
            calibrationService.StartCalibration("Ph", "Zero", 30, calibrationControls);
        }

        private void buttonIletkenlikZero_Click(object sender, EventArgs e)
        {
            calibrationService.StartCalibration("Iletkenlik", "Zero", 30, calibrationControls);
        }

        private void buttonKoiZero_Click(object sender, EventArgs e)
        {
            calibrationService.StartCalibration("Koi", "Zero", 10, calibrationControls);
        }

        private void ColorStatementPanel()
        {
            PanelCalibrationAkm.BackColor = CheckValidity("AKM");
            PanelCalibrationAkm.BackColor = CheckValidity("KOi");
            PanelCalibrationAkm.BackColor = CheckValidity("Ph");
            PanelCalibrationAkm.BackColor = CheckValidity("Iletkenlik");
        }

        private Color CheckValidity(string parameter)
        {
            var calibrations = calibrationDTOService.GetAll();

            var calibration = calibrations.LastOrDefault(c => c.Parameter == parameter);

            if (calibration?.IsItValid == true)
            {
                return Color.Lime;
            }
            else
            {
                return Color.Red;
            }
        }
    }
}