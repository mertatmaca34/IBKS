using Calibration.Models;
using PLC.Models;
using Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calibration.Services
{
    public class CalibrationService
    {
        readonly PlcServices connection = PlcServices.Instance;
        public bool isCalibrationInProgress;
        public CalibrationDTO StartCalibration(
            string calibrationName, string calibrationType, int calibrationTime, List<Control> controls)
        {
            CalibrationDTO calibrationDTO = new CalibrationDTO();
            if (!isCalibrationInProgress)
            {
                if (calibrationType == "Zero")
                {
                    isCalibrationInProgress = true;
                    StartZeroCalibration(calibrationName, calibrationTime, controls);
                }
                else
                {
                    StartSpanCalibration(calibrationTime);
                }

            }
            else
            {
                //TODO
            }
            return calibrationDTO;
        }

        public void StartZeroCalibration(string calibrationName, int calibrationTime, List<Control> controls)
        {
            CalibrationDTO calibrationDTO = new CalibrationDTO();

            double tolerance = 0.10;

            List<double> measValues = new List<double>();

            Control labelTimeStamp = controls.FirstOrDefault(c => c.Name == "labelTimeRemain");
            Control chartCalibrationSimulation = controls.FirstOrDefault(c => c.Name == "chartCalibrationSimulation");

            Thread.Sleep(2000);

            switch (calibrationName)
            {
                case "AKM":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Akm;
                    calibrationDTO.ZeroRef = 0;
                    break;
                case "KOi":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Koi;
                    calibrationDTO.ZeroRef = 0;
                    break;
                case "Ph":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Ph;
                    calibrationDTO.ZeroRef = 7;
                    break;
                case "Iletkenlik":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Iletkenlik;
                    calibrationDTO.ZeroRef = 0;
                    break;
                default:
                    calibrationDTO.ZeroMeas = 0;
                    calibrationDTO.ZeroRef = 0;
                    break;
            }

            System.Windows.Forms.Timer timerCalibration = new System.Windows.Forms.Timer
            {
                Interval = 1000,
                Enabled = true
            };

            timerCalibration.Tick += delegate
            {
                calibrationDTO.ZeroMeas = connection.dB41DTO.Iletkenlik;

                //Kalibrasyon süresi 0 olduğunda bitecek
                if (calibrationTime >= 0)
                {
                    labelTimeStamp.Text = calibrationTime.ToString();

                    (chartCalibrationSimulation as Chart).Series["Kalibrasyon Değeri"].Points.AddXY(connection.dB4DTO.SystemTime.ToString("hh:mm:ss"), calibrationDTO.ZeroMeas);
                    (chartCalibrationSimulation as Chart).Series["Referans Değeri"].Points.AddXY(connection.dB4DTO.SystemTime.ToString("hh:mm:ss"), calibrationDTO.ZeroRef);

                    measValues.Add(calibrationDTO.ZeroMeas);

                    CalculateCalibrationParameters(calibrationDTO, measValues, "Zero");
                    AssignLabels(controls, calibrationDTO);

                    if (calibrationDTO.ZeroMeas >= calibrationDTO.ZeroRef / tolerance && calibrationDTO.ZeroMeas <= calibrationDTO.ZeroRef * tolerance)
                    {
                        (chartCalibrationSimulation as Chart).Series["Kalibrasyon Değeri"].Color = Color.Lime;
                    }
                    else
                    {
                        (chartCalibrationSimulation as Chart).Series["Kalibrasyon Değeri"].Color = Color.Red;
                    }
                    calibrationTime--;
                }
                else
                {
                    timerCalibration.Enabled = false;
                }
            };
        }

        public void StartSpanCalibration(int calibrationTime)
        {

        }

        public void CalculateCalibrationParameters(CalibrationDTO calibrationDTO, List<double> measValues, string calibrationType)
        {
            if (calibrationType == "Zero")
            {
                calibrationDTO.ZeroDiff = Math.Round(calibrationDTO.ZeroMeas - calibrationDTO.ZeroRef,2);
                calibrationDTO.ZeroStd = Math.Round(CalculateStandardDeviation(measValues),2);
                calibrationDTO.ResultFactor = Math.Round((calibrationDTO.ZeroMeas - calibrationDTO.ZeroRef) / calibrationDTO.ZeroDiff, 2);
            }
            else
            {
                calibrationDTO.SpanDiff = Math.Round(calibrationDTO.SpanMeas - calibrationDTO.SpanRef, 2);
                calibrationDTO.SpanStd = Math.Round(CalculateStandardDeviation(measValues), 2);
                calibrationDTO.ResultFactor = Math.Round((calibrationDTO.SpanMeas - calibrationDTO.SpanRef) / calibrationDTO.SpanDiff, 2);
            }
        }

        public double CalculateStandardDeviation(List<double> data)
        {
            double sum = 0;
            double mean = 0;
            double stdDev = 0;

            if (!data.Any())
            {
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
            else
            {
                return stdDev;
            }
        }
        public void AssignLabels(List<Control> controls, CalibrationDTO calibrationDTO)
        {
            Control labelZeroRef = controls.Where(c => c.Name == "labelZeroRef").FirstOrDefault();
            Control labelZeroMeas = controls.Where(c => c.Name == "labelZeroMeas").FirstOrDefault();
            Control labelZeroDiff = controls.Where(c => c.Name == "labelZeroDiff").FirstOrDefault();
            Control labelZeroStd = controls.Where(c => c.Name == "labelZeroStd").FirstOrDefault();
            Control labelSpanRef = controls.Where(c => c.Name == "labelSpanRef").FirstOrDefault();
            Control labelSpanMeas = controls.Where(c => c.Name == "labelSpanMeas").FirstOrDefault();
            Control labelSpanDiff = controls.Where(c => c.Name == "labelSpanDiff").FirstOrDefault();
            Control labelSpanStd = controls.Where(c => c.Name == "labelSpanStd").FirstOrDefault();
            Control labelResultFactor = controls.Where(c => c.Name == "labelResultFactor").FirstOrDefault();

            labelZeroRef.Text = calibrationDTO.ZeroRef.ToString();
            labelZeroMeas.Text = calibrationDTO.ZeroMeas.ToString();
            labelZeroDiff.Text = calibrationDTO.ZeroDiff.ToString();
            labelZeroStd.Text = calibrationDTO.ZeroStd.ToString();
            labelSpanRef.Text = calibrationDTO.SpanRef.ToString();
            labelSpanMeas.Text = calibrationDTO.SpanMeas.ToString();
            labelSpanDiff.Text = calibrationDTO.SpanDiff.ToString();
            labelSpanStd.Text = calibrationDTO?.SpanStd.ToString();
            labelResultFactor.Text = calibrationDTO?.ResultFactor.ToString();
        }
    }
}
