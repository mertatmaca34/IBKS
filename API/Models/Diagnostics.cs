using System;

namespace API.Models
{
    public class Diagnostics
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public Guid stationId { get; set; }
        public string details { get; set; }
        public int? diagnosticTypeNo { get; set; }
    }
}
