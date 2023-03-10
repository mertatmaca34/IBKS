using Presentation;

namespace PLC.Services
{
    public class ModsService
    {
        readonly PlcServices connection = PlcServices.Instance;

        public int GetStatus()
        {
            int status = connection.mBTagsDTO.YikamaVarMi == true ? 23
            : connection.mBTagsDTO.HaftalikYikamaVarMi == true ? 24
            : connection.mBTagsDTO.ModAutoMu == true ? 1
            : connection.mBTagsDTO.ModBakimMi == true ? 25
            : connection.mBTagsDTO.ModKalibrasyonMu == true ? 9
            : 0;

            return status;
        }
    }
}
