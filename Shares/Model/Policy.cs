namespace RRMS.Model
{
    public class Policy
    {
        public int PolicyID { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ResidentID { get; set; }
        public string ResidentName { get; set; }  
    }
} 