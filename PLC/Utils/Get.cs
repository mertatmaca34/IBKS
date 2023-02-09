using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Utils
{
    internal class Get
    {
        static internal double Real(byte[] buffer, int offset)
        {
            return Math.Round(S7.GetRealAt(buffer, offset), 2);
        }
    }
}
