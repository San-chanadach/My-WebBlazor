namespace RapidNRIMs.Model.Authencations
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
