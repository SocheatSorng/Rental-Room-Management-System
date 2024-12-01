using Microsoft.Data.SqlClient;

namespace RRMS.model
{
    public class Request : IEntity
    {
        // Original properties
        public int ReqID { get; set; }
        public DateTime ReqDate { get; set; }
        public string? Des { get; set; }
        public string? Stat { get; set; }
        public int ResID { get; set; }
        public int SerID { get; set; }
        public string? ResName { get; set; } //Firstname
        public string? SerName { get; set; } //Lastname

        // Implementing applicable interface members
        public int ID { get => ReqID; set => ReqID = value; }
        public DateTime Start { get => ReqDate; set => ReqDate = value; }
        public string Description { get => Des ?? string.Empty; set => Des = value; }
        public bool Status { get => Stat?.ToLower() == "true"; set => Stat = value.ToString(); }
        public string FirstName { get => ResName ?? string.Empty; set => ResName = value; }
        public string LastName { get => SerName ?? string.Empty; set => SerName = value; }

        // Not applicable properties
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
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReqDate", ReqDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Des", Des as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Stat", Stat as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResID", ResID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerID", SerID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResName", ResName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerName", SerName as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReqID", ReqID);
            cmd.Parameters.AddWithValue("@ReqDate", ReqDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Des", Des as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Stat", Stat as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResID", ResID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerID", SerID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResName", ResName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerName", SerName as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReqID", ReqID);
        }
    }
}