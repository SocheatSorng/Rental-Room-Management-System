using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Rent : IEntity
    {
        // Original properties
        public int RenID { get; set; }
        public DateTime StaDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RenAmount { get; set; }
        public int ResiID { get; set; }
        public int RoomID { get; set; }
        public string? ResiName { get; set; }
        public string? RoomNum { get; set; }

        // Implementing applicable interface members
        public int ID { get => RenID; set => RenID = value; }
        public DateTime Start { get => StaDate; set => StaDate = value; }
        public DateTime End { get => EndDate; set => EndDate = value; }
        public double RentPrice { get => (double)RenAmount; set => RenAmount = (decimal)value; }
        public string FirstName { get => ResiName ?? string.Empty; set => ResiName = value; }
        public string Type { get => RoomNum ?? string.Empty; set => RoomNum = value; }

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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StaDate", StaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RenAmount", RenAmount as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomNum", RoomNum as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RenID", RenID);
            cmd.Parameters.AddWithValue("@StaDate", StaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RenAmount", RenAmount as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomNum", RoomNum as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RenID", RenID);
        }
    }
}