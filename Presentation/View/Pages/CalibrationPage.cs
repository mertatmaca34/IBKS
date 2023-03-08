using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calibration.Services;

namespace Presentation.View.Pages
{
    
    public partial class CalibrationPage : Form
    {
        public CalibrationPage()
        {
            InitializeComponent();
        }

        private void buttonAKMZero_Click(object sender, EventArgs e)
        {
            CalibrationService calibrationService = new CalibrationService();
            calibrationService.StartCalibration("AKM", "Zero", 10, labelTimeRemain, chartCalibrationSimulation);
        }
    }
}
