using Business.Interfaces;
using Data_Access.Models;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MinuteDataSendService : IMinuteDataSendService
    {
        IMinuteDataSendRepository MinuteDataSendRepository = new MinuteDataSendRepository();
        public void Add(MinuteDataSendDTO minuteDataSendDTO)
        {
            throw new NotImplementedException();
        }

        public Array GetAll()
        {
            var minuteDataSendDTOs = MinuteDataSendRepository.GetAll();

            return minuteDataSendDTOs.ToArray();
        }
    }
}
