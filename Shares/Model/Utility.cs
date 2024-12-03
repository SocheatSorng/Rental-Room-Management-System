using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Utility : IEntity
    {
        // Original properties
        public int UtilID { get; set; }
        public string? UtilType { get; set; }
        public decimal Cost { get; set; }
        public DateTime? UsaDate { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => UtilID; set => UtilID = value; }
        public string Type { get => UtilType ?? string.Empty; set => UtilType = value; }
        public double CostPrice { get => (double)Cost; set => Cost = (decimal)value; }
        public DateTime? Start { get => UsaDate; set => UsaDate = value; }

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
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UtilType", UtilType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Cost", Cost as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsaDate", UsaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UtilID", UtilID);
            cmd.Parameters.AddWithValue("@UtilType", UtilType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Cost", Cost as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsaDate", UsaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UtilID", UtilID);
        }
    }
}