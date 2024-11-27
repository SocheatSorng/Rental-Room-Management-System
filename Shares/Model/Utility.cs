namespace RRMS.Model
{
    public class Utility
    {
        public int UtilityID { get; set; }
        public string UtilityType { get; set; }
        public decimal Cost { get; set; }
        public DateTime UsageDate { get; set; }
        public int RoomID { get; set; }
    }
} 