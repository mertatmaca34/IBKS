using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class GetLastData
    {
        public Guid StationId { get; set; }
        public int Period { get; set; }
    }
}
