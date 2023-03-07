﻿using Data_Access.Models;
using PLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMinuteDataSendService
    {
        Array GetAll();
        void Add(DB41DTO dB41DTO, DateTime systemTime);
    }
}
