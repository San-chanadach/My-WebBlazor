using System.Text.Json.Serialization;
using RapidNRIMs.Model.Authencations;

namespace RapidNRIMs.Model.EventRecord
{
    public class EventPersonalDose
    {
        public int EventPDId { get; set; }
        public int? EventId { get; set; }
        public int? ProjectId { get; set; }
        public Guid? EventPDUserName { get; set; }
        public int? EventPDSupportId { get; set; }
        public string EventPDInstumentName { get; set; } = string.Empty;
        public double? EventPDAccumulation { get; set; }
        public int? EventPDAccumulationUnit { get; set; }
        public DateTime? EventPDDate { get; set; }
        public Guid? OriginalEventPDUserName { get; set; }
        public string OriginalEventPDInstumentName { get; set; } = string.Empty;
        public double? OriginalEventPDAccumulation { get; set; }  
        public int? OriginalEventPDSupportId { get; set; }   
        public int? PositionId {  get; set; }  
        public bool IsTeam { get; set; }

    }
}
