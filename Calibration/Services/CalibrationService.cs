using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Calibration.Services
{
    public class CalibrationService
    {
        public bool isCalibrationInProgress;
        public bool StartCalibration(string calibrationType, int calibrationTime)
        {
            if(!isCalibrationInProgress)
            {


                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
