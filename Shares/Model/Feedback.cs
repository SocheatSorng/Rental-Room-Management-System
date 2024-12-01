using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Feedback : IEntity
    {
        // Original properties
        public int FeedID { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public string? Comment { get; set; }
        public int ResID { get; set; }
        public string? ResName { get; set; }

        // Implementing applicable interface members
        public int ID { get => FeedID; set => FeedID = value; }
        public DateTime Start { get => Date; set => Date = value; }
        public string Type { get => Content ?? string.Empty; set => Content = value; }
        public string Description { get => Comment ?? string.Empty; set => Comment = value; }
        public string FirstName { get => ResName ?? string.Empty; set => ResName = value; }

        // Not applicable properties
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string HouseNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string StreetNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string Commune { get => string.Empty; set => throw new NotSupportedException(); }
        public string District { get => string.Empty; set => throw new NotSupportedException(); }
        public string Province { get => string.Empty; set => throw new NotSupportedException(); }
        public string PersonalNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public string ContactNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public double Salary { get => 0; set => throw new NotSupportedException(); }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Date", Date as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Content", Content as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Comment", Comment as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResID", ResID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResName", ResName as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedID", FeedID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedID", FeedID);
        }
    }
} 