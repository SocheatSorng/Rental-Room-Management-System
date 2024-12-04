using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Request : IEntity
    {
        // Original properties
        public int RequestID { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? RequestDescription { get; set; }
        public string? RequestStatus { get; set; }
        public int ResidentID { get; set; }
        public int ServiceID { get; set; }

        // Implementing applicable interface members
        public int ID { get => RequestID; set => RequestID = value; }
        public DateTime? Start { get => RequestDate; set => RequestDate = value; }
        public string Description { get => RequestDescription ?? string.Empty; set => RequestDescription = value; }
        public bool Status { get => RequestStatus?.ToLower() == "true"; set => RequestStatus = value.ToString(); }

        // Not applicable properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime? BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
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
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RequestDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RequestDescription", RequestDescription as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", RequestStatus as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ServiceID", ServiceID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RequestDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RequestDescription", Description as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", Status as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ServiceID", ServiceID as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RequestID", RequestID);
        }
    }
}