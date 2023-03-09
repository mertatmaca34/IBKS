using Business.Interfaces;
using Business.Services;
using DataAccess.Models;
using Presentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calibration.Services
{
    public class CalibrationService
    {
        private readonly ICalibrationDTOService calibrationDTOService = new CalibrationDTOService();
        private readonly PlcServices connection = PlcServices.Instance;
        public bool isCalibrationInProgress;
        CalibrationDTO calibrationDTO = new CalibrationDTO();
        readonly double tolerance = 0.10;

        public void StartCalibration(
            string calibrationName, string calibrationType, int calibrationTime, List<Control> controls)
        {
            if (!isCalibrationInProgress)
            {
                if (calibrationType == "Zero")
                {
                    isCalibrationInProgress = true;
                    StartZeroCalibration(calibrationName, calibrationTime, controls);
                }
                else
                {
                    isCalibrationInProgress = true;
                    StartSpanCalibration(calibrationName, calibrationTime, controls);
                }
            }
            else
            {
                return;
                //TODO
            }
        }

        public void StartZeroCalibration(string calibrationName, int calibrationTime, List<Control> controls)
        {
            List<double> measValues = new List<double>();

            Control labelTimeStamp = controls.FirstOrDefault(c => c.Name == "labelTimeRemain");
            Control chartCalibrationSimulation = controls.FirstOrDefault(c => c.Name == "chartCalibrationSimulation");
            Control labelActiveCalibration = controls.FirstOrDefault(c => c.Name == "labelActiveCalibration");

            calibrationDTO.TimeStamp = connection.dB4DTO.SystemTime;

            switch (calibrationName)
            {
                case "AKM":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Akm;
                    calibrationDTO.ZeroRef = 0;
                    calibrationDTO.Parameter = "AKM";
                    labelActiveCalibration.Text = "Aktif Kalibrasyon: AKM";
                    break;
                case "KOi":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Koi;
                    calibrationDTO.ZeroRef = 0;
                    calibrationDTO.Parameter = "KOi";
                    labelActiveCalibration.Text = "Aktif Kalibrasyon: KOi";
                    break;
                case "Ph":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Ph;
                    calibrationDTO.ZeroRef = 7;
                    calibrationDTO.Parameter = "Ph";
                    labelActiveCalibration.Text = "Aktif Kalibrasyon: pH";
                    break;
                case "Iletkenlik":
                    calibrationDTO.ZeroMeas = connection.dB41DTO.Iletkenlik;
                    calibrationDTO.ZeroRef = 0;
                    calibrationDTO.Parameter = "Iletkenlik";
                    labelActiveCalibration.Text = "Aktif Kalibrasyon: İletkenlik";
                    break;
                default:
                    calibrationDTO.ZeroMeas = 0;
                    calibrationDTO.ZeroRef = 0;
                    break;
            }

            Timer timerCalibration = new Timer
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

                    CalculateCalibrationParameters(measValues, "Zero");
                    AssignLabels(controls);

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

                    isCalibrationInProgress = false;

                    //TODO Kalibrasyon sonucunu gönder

                    (chartCalibrationSimulation as Chart).Series["Kalibrasyon Değeri"].Points.Clear();
                    (chartCalibrationSimulation as Chart).Series["Referans Değeri"].Points.Clear();
                    labelTimeStamp.Text = "Kalan Süre:";
                    labelActiveCalibration.Text = "Aktif Kalibrasyon: -";

                    //Kalibrasyonu kaydet
                    calibrationDTOService.Add(calibrationDTO);

                    //Nesneyi resetle
                    calibrationDTO = new CalibrationDTO();

                    //Label'lardaki değerleri resetle
                    AssignLabels(controls);
                }
            };

        }

        public void StartSpanCalibration(string calibrationName, int calibrationTime, List<Control> controls)
        {
            List<double> measValues = new List<double>();

            Control labelTimeStamp = controls.FirstOrDefault(c => c.Name == "labelTimeRemain");
            Control chartCalibrationSimulation = controls.FirstOrDefault(c => c.Name == "chartCalibrationSimulation");

            switch (calibrationName)
            {
                case "Ph":
                    calibrationDTO.ZeroMeas = calibrationDTO.ZeroMeas;
                    calibrationDTO.ZeroRef = 7;
                    calibrationDTO.SpanMeas = connection.dB41DTO.Ph;
                    calibrationDTO.SpanRef = 10;
                    break;
                case "Iletkenlik":
                    calibrationDTO.ZeroMeas = calibrationDTO.ZeroMeas;
                    calibrationDTO.ZeroRef = 0;
                    calibrationDTO.SpanMeas = connection.dB41DTO.Iletkenlik;
                    calibrationDTO.SpanRef = 1413;
                    break;
                default:
                    calibrationDTO.ZeroMeas = 0;
                    calibrationDTO.ZeroRef = 0;
                    calibrationDTO.SpanMeas = 0;
                    calibrationDTO.SpanRef = 0;
                    break;
            }

            Timer timerCalibration = new Timer
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

                    CalculateCalibrationParameters(measValues, "Zero");
                    AssignLabels(controls);

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
            isCalibrationInProgress = false;
        }

        public void CalculateCalibrationParameters(List<double> measValues, string calibrationType)
        {
            if (calibrationType == "Zero")
            {
                calibrationDTO.ZeroDiff = Math.Round(calibrationDTO.ZeroMeas - calibrationDTO.ZeroRef, 2);
                calibrationDTO.ZeroStd = Math.Round(CalculateStandardDeviation(measValues), 2);
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
            double mean;
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
        public void AssignLabels(List<Control> controls)
        {
            Control labelZeroRef = controls.FirstOrDefault(c => c.Name == "labelZeroRef");
            Control labelZeroMeas = controls.FirstOrDefault(c => c.Name == "labelZeroMeas");
            Control labelZeroDiff = controls.FirstOrDefault(c => c.Name == "labelZeroDiff");
            Control labelZeroStd = controls.FirstOrDefault(c => c.Name == "labelZeroStd");
            Control labelSpanRef = controls.FirstOrDefault(c => c.Name == "labelSpanRef");
            Control labelSpanMeas = controls.FirstOrDefault(c => c.Name == "labelSpanMeas");
            Control labelSpanDiff = controls.FirstOrDefault(c => c.Name == "labelSpanDiff");
            Control labelSpanStd = controls.FirstOrDefault(c => c.Name == "labelSpanStd");
            Control labelResultFactor = controls.FirstOrDefault(c => c.Name == "labelResultFactor");
            Control labelActiveCalibration = controls.FirstOrDefault(c => c.Name == "labelActiveCalibration");

            labelZeroRef.Text = calibrationDTO.ZeroRef.ToString();
            labelZeroMeas.Text = calibrationDTO.ZeroMeas.ToString();
            labelZeroDiff.Text = calibrationDTO.ZeroDiff.ToString();
            labelZeroStd.Text = calibrationDTO.ZeroStd.ToString();
            labelSpanRef.Text = calibrationDTO.SpanRef.ToString();
            labelSpanMeas.Text = calibrationDTO.SpanMeas.ToString();
            labelSpanDiff.Text = calibrationDTO.SpanDiff.ToString();
            labelSpanStd.Text = calibrationDTO.SpanStd.ToString();
            labelResultFactor.Text = calibrationDTO.ResultFactor.ToString();
        }
    }
}
