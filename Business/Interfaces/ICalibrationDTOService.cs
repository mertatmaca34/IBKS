using DataAccess.Models;
using System;

namespace Business.Interfaces
{
    public interface ICalibrationDTOService
    {
        Array GetAll();
        void Add(CalibrationDTO calibrationDTO);
    }
}
