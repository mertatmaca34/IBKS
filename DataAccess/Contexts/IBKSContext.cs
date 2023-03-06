using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Contexts
{
    public class IBKSContext: DbContext
    {
        public DbSet<MinuteDataSendDTO> minuteDataSendDTOs { get; set; }
    }
}
