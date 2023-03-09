using Business.Interfaces;
using Data_Access.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using PLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CalibrationDTOService : ICalibrationDTOService
    {
        readonly ICalibrationRepository calibrationRepository = new CalibrationRepository();

        public void Add(CalibrationDTO calibrationDTO)
        {
            calibrationRepository.Add(calibrationDTO);
        }

        List<CalibrationDTO> ICalibrationDTOService.GetAll()
        {
            var calibrationDTOs = calibrationRepository.GetAll();
            return calibrationDTOs;
        }
    }
}
