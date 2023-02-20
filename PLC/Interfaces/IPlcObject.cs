using PLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Interfaces
{
    internal interface IPlcObject
    {
        PlcObject plcObject { get; }
    }
}
