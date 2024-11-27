namespace RRMS.Model
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public int ResidentID { get; set; }
        public string ResidentName { get; set; }  
    }
} 