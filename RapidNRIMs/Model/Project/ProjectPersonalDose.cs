namespace RapidNRIMs.Model.Project
{
    public class ProjectPersonalDose
    {
        public int ProjectPersonalDoseID { get; set; }
        public int ProjectID { get; set; }
        public Guid? UserID { get; set; }
        public int? SupportTeamID { get; set; } 
        public double PersonalDose { get; set; }
        public int PersonalDoseUnitID { get; set; }
        public string PersonalDoseInstrumentName { get; set; } = string.Empty;
        public int? OriginalPersonalDose { get; set; }
        public DateTime PersonalDoseDate { get; set; }
        public bool? IsTeam { get; set;}
    }
}
