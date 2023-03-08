using Calibration.Models;
using PLC.Models;
using Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calibration.Services
{
    public class CalibrationService
    {
        readonly PlcServices connection = PlcServices.Instance;
        public bool isCalibrationInProgress;
        DB4DTO dB4;
        DB41DTO dB41;
        public bool StartCalibration(
            string calibrationName, string calibrationType, int calibrationTime, Label labelTimeStamp, Chart chartCalibrationSimulation)
        {
            if (!isCalibrationInProgress)
            {
                if (calibrationType == "Zero")
                {
                    isCalibrationInProgress = true;
                    StartZeroCalibration(calibrationName, calibrationTime, labelTimeStamp, chartCalibrationSimulation);
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

        public void StartZeroCalibration(string calibrationName, int calibrationTime, Label labelTimeStamp, Chart chartCalibrationSimulation)
        {
            double instantValue, refValue, tolerance = 0.10;

            AssignPLCValues();

            List<double> measValues = new List<double>();

            Thread.Sleep(2000);

            switch (calibrationName)
            {
                case "AKM":
                    instantValue = dB41.Akm;
                    refValue = 0;
                    break;
                case "KOi":
                    instantValue = dB41.Koi;
                    refValue = 0;
                    break;
                case "Ph":
                    instantValue = dB41.Ph;
                    refValue = 7;
                    break;
                case "Iletkenlik":
                    instantValue = dB41.Iletkenlik;
                    refValue = 0;
                    break;
                default:
                    instantValue = 0;
                    refValue = 0;
                    break;
            }

            System.Windows.Forms.Timer timerCalibration = new System.Windows.Forms.Timer
            {
                Interval = 1000,
                Enabled = true
            };

            timerCalibration.Tick += delegate
            {
                //Kalibrasyon süresi 0 olduğunda bitecek
                if (calibrationTime >= 0)
                {
                    labelTimeStamp.Text = calibrationTime.ToString();

                    chartCalibrationSimulation.Series["Kalibrasyon Değeri"].Points.AddXY(dB4.SystemTime.ToString("hh:mm:ss"), instantValue);
                    chartCalibrationSimulation.Series["Referans Değeri"].Points.AddXY(dB4.SystemTime.ToString("hh:mm:ss"), refValue);

                    measValues.Add(instantValue);

                    if (instantValue >= refValue / tolerance && instantValue <= refValue * tolerance)
                    {
                        chartCalibrationSimulation.Series["Kalibrasyon Değeri"].Color = Color.Lime;
                    }
                    else
                    {
                        chartCalibrationSimulation.Series["Kalibrasyon Değeri"].Color = Color.Red;
                    }
                    calibrationTime--;
                }
                else
                {
                    timerCalibration.Enabled = false;
                    MessageBox.Show("Bitti");
                    //TODO
                }
            };
        }

        public void StartSpanCalibration(int calibrationTime)
        {

        }

        public void AssignPLCValues()
        {
            //PLC Okuma ve Atama işlemlerinin arkaplanda yapılması.
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                //DB4
                byte[] buffer4 = connection.ReadData(4, 0, 12);

                if (buffer4 != null)
                {
                    dB4 = connection.AssignDB4(buffer4);

                    //EB Tags
                    byte[] bufferEBTags = connection.ReadData(0, 30);

                    EBTagsDTO eBTagsDTO = connection.AssignEBTags(bufferEBTags);

                    //DB41
                    byte[] buffer41 = connection.ReadData(41, 0, 248);

                    if (buffer41 != null)
                    {
                        dB41 = connection.AssignDB41(buffer41);
                    }
                }
            };
            bgw.RunWorkerAsync();
        }

        public void CalculateCalibrationParameters(CalibrationDTO calibrationDTO, List<double> measValues, string calibrationType)
        {
            if (calibrationType == "Zero")
            {
                calibrationDTO.ZeroDiff = calibrationDTO.ZeroMeas - calibrationDTO.ZeroRef;
                calibrationDTO.ZeroStd = CalculateStandardDeviation(measValues);
                calibrationDTO.ResultFactor = (calibrationDTO.ZeroMeas - calibrationDTO.ZeroRef) / calibrationDTO.ZeroDiff;
            }
            else
            {
                calibrationDTO.SpanDiff = calibrationDTO.SpanMeas - calibrationDTO.SpanRef;
                calibrationDTO.SpanStd = CalculateStandardDeviation(measValues);
                calibrationDTO.ResultFactor = (calibrationDTO.SpanMeas - calibrationDTO.SpanRef) / calibrationDTO.SpanDiff;
            }
        }

        public double CalculateStandardDeviation(List<double> data)
        {
            double sum = 0;
            double mean = 0;
            double stdDev = 0;

            // verilerin ortalaması hesaplanır
            for (int i = 0; i < data.Count; i++)
            {
                sum += data[i];
            }
            mean = sum / data.Count;

            // standart sapma hesaplanır
            for (int i = 0; i < data.Count; i++)
            {
                stdDev += Math.Pow(data[i] - mean, 2);
            }
            stdDev = Math.Sqrt(stdDev / (data.Count - 1));

            return stdDev;
        }
    }
}
