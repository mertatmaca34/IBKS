using Sharp7;
using System;

namespace PLC.Utils
{
    public class Get
    {
        static public double Real(byte[] buffer, int offset, int? divider = null)
        {
            if (divider.HasValue)
            {
                return Math.Round((double)(S7.GetRealAt(buffer, offset) / divider), 2);
            }
            else
            {
                return Math.Round(S7.GetRealAt(buffer, offset), 2);
            }
        }
        static public DateTime Time(byte[] buffer, int offset)
        {
            return S7.GetDTLAt(buffer, offset);
        }
    }
}
