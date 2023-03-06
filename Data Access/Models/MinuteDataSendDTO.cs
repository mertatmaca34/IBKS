using System;

namespace Data_Access.Models
{
    public class MinuteDataSendDTO
    {
        public Guid? Stationid { get; set; }
        public DateTime? Readtime { get; set; }
        public string SoftwareVersion { get; set; }
        public int? Period { get; set; }
        public double? AkisHizi { get; set; }
        public int? AkisHiziStatus { get; set; }
        public double? AKM { get; set; }
        public int? AKMStatus { get; set; }
        public double? CozunmusOksijen { get; set; }
        public int? CozunmusOksijenStatus { get; set; }
        public double? Debi { get; set; }
        public int? DebiStatus { get; set; }
        public double? DesarjDebi { get; set; }
        public int? DesarjDebiStatus { get; set; }
        public double? HariciDebi { get; set; }
        public int? HariciDebiStatus { get; set; }
        public double? HariciDebi2 { get; set; }
        public int? HariciDebi2Status { get; set; }
        public double? KOi { get; set; }
        public int? KOiStatus { get; set; }
        public double? Ph { get; set; }
        public int? PhStatus { get; set; }
        public double? Sicaklik { get; set; }
        public int? SicaklikStatus { get; set; }
        public double? Iletkenlik { get; set; }
        public int? IletkenlikStatus { get; set; }
    }
}
