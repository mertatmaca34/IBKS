using PLC.Interfaces;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Models
{
    static public class PlcObject
    {
        public static S7Client Client { get; set; }
        public static int PlcResult { get; set; }
    }
}
