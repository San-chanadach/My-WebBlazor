namespace RapidNRIMs.Model.EventRecord
{
    public class EventSumPersonalDose
    {
        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
        public string TeamOrSupportName { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public double? TotalEventPDAccumulation { get; set; }
        public string RecordEventUnitName { get; set; } = string.Empty;
        public string TotalHours { get; set; } = string.Empty;
    }
}
