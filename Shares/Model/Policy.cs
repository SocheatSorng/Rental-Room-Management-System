using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Policy : IEntity
    {
        // Original properties
        public int PolicyID { get; set; }
        public string? Name { get; set; }
        public string? PolicyDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ResidentID { get; set; }
        public int StaffID { get; set; }

        // Implementing applicable interface members
        public int ID { get => PolicyID; set => PolicyID = value; }
        public string FirstName { get => Name ?? string.Empty; set => Name = value; }
        public string Description { get => PolicyDescription ?? string.Empty; set => PolicyDescription = value; }
        public DateTime? Start { get => CreatedDate; set => CreatedDate = value; }
        public DateTime? End { get => UpdatedDate; set => UpdatedDate = value; }

        // Not applicable properties
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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", FirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", PolicyDescription as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedDate", End as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaffID", StaffID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PolicyID", PolicyID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PolicyID", PolicyID);
        }
    }
}