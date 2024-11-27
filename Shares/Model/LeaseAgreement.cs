namespace RRMS.Model
{
    public class LeaseAgreement
    {
        public int LeaseAgreementID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public string TermsAndConditions { get; set; }
        public int ResidentID { get; set; }
        public string ResidentName { get; set; }  
    }
} 