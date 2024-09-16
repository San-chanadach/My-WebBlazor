namespace RapidNRIMs.Model.PersonalDose
{
    public class PersonalDose
    {
        public int PersonalDoseID { get; set; }
        public Guid? UserID { get; set; }
        public int? UserSupportTeamID { get; set; }
        public DateTime StartDatetime { get; set; } = DateTime.Now;
        public DateTime EndDatetime { get; set; } = DateTime.Now;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateRegister {  get; set; }
        public string? LocationName { get; set; }
        public string? InstrumentName { get; set; }
        public double DoseAccumulation { get; set; }
        public int? DoseAccumulationUnit { get; set; }
        public string TotalHour { get; set; } = string.Empty;
        public int? FromEventPersonalDose { get; set; }
        public int? FromProjectPersonalDose { get; set; }
        public string PositionTeam { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public Guid? OriginalUserID { get; set; }
        public int? OriginalSupportID { get; set; }
    }
}
