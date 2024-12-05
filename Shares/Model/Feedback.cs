using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Feedback : IEntity
    {
        // Original properties
        private int FeedbackID { get; set; }
        private DateTime? FeedbackDate { get; set; }
        private string? Content { get; set; }
        private string? Comment { get; set; }
        private int residentID;

        public int ResidentID
        {
            get => residentID; 
            set => residentID = value;
        }

        // Implementing applicable interface members
        public int ID { get => FeedbackID; set => FeedbackID = value; }
        public DateTime? Start { get => FeedbackDate; set => FeedbackDate = value; }
        public string Type { get => Content ?? string.Empty; set => Content = value; }
        public string Description { get => Comment ?? string.Empty; set => Comment = value; }

        // Not applicable properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime? BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string HouseNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string StreetNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string Commune { get => string.Empty; set => throw new NotSupportedException(); }
        public string District { get => string.Empty; set => throw new NotSupportedException(); }
        public string Province { get => string.Empty; set => throw new NotSupportedException(); }
        public string PersonalNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public string ContactNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public double Salary { get => 0; set => throw new NotSupportedException(); }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedbackDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Content", Type as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Comment", Description as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedbackID", ID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedbackID", ID);
        }
    }
} 