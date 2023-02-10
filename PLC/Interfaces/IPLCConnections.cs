using Sharp7;

namespace PLC.Interfaces
{
    public interface IPLCConnections
    {
        S7Client Connect(int res);
    }
}
