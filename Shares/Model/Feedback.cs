using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Feedback : IEntity
    {
        // Original properties
        public int FeedID { get; set; }
        public DateTime FeedDate { get; set; }
        public string? Comments { get; set; }
        public int ResiID { get; set; }
        public string? ResiName { get; set; }

        // Implementing applicable interface members
        public int ID { get => FeedID; set => FeedID = value; }
        public DateTime Start { get => FeedDate; set => FeedDate = value; }
        public string Description { get => Comments ?? string.Empty; set => Comments = value; }
        public string FirstName { get => ResiName ?? string.Empty; set => ResiName = value; }

        // Not applicable properties
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Type { get => string.Empty; set => throw new NotSupportedException(); }
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
            cmd.Parameters.AddWithValue("@FeedDate", FeedDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Comments", Comments as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedID", FeedID);
            cmd.Parameters.AddWithValue("@FeedDate", FeedDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Comments", Comments as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FeedID", FeedID);
        }
    }
} 