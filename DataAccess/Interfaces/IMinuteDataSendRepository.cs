using Data_Access.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IMinuteDataSendRepository
    {
        List<MinuteDataSendDTO> GetAll();
        void Add(MinuteDataSendDTO minuteDataSendDTO);
        void Delete(MinuteDataSendDTO minuteDataSendDTO);
        void Update(MinuteDataSendDTO minuteDataSendDTO);
    }
}
