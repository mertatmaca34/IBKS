using Presentation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calibration.Services
{
    public class CalibrationService
    {
        readonly PlcServices connection = PlcServices.Instance;

        public bool isCalibrationInProgress;
        public bool StartCalibration(string calibrationType,
                                     int calibrationTime,
                                     Label labelTimeStamp,
                                     Chart chartCalibrationSimulation,
                                     double instantValue,
                                     double refValue)
        {
            if (!isCalibrationInProgress)
            {
                if (calibrationType == "Zero")
                {
                    StartZeroCalibration(calibrationTime, labelTimeStamp, chartCalibrationSimulation);
                }
                else
                {
                    StartSpanCalibration(calibrationTime);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartZeroCalibration(int calibrationTime, Label labelTimeStamp, Chart chartCalibrationSimulation)
        {
            Timer timerCalibration = new Timer
            {
                Interval = 1000,
                Enabled = true,
            };

            timerCalibration.Tick += delegate
            {
                //Kalibrasyon süresi 0 olduğunda bitecek
                if(calibrationTime > 0)
                {
                    labelTimeStamp.Text = calibrationTime.ToString();

                    chartCalibrationSimulation.Series["Kalibrasyon Değeri"].Points.AddXY()
                }
            };

        }

        public void StartSpanCalibration(int calibrationTime)
        {

        }
    }
}
