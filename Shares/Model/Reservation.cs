using Microsoft.Data.SqlClient;

namespace RRMS {
    public class Reservation : IEntity
    {
        // Original properties
        public int ReserID { get; set; }
        public DateTime ReserDate { get; set; }
        public DateTime StaDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Stat { get; set; }
        public int ResiID { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => ReserID; set => ReserID = value; }
        public DateTime Booking { get => ReserDate; set => ReserDate = value; }
        public DateTime Start { get => StaDate; set => StaDate = value; }
        public DateTime End { get => EndDate; set => EndDate = value; }
        public bool Status { get => Stat?.ToLower() == "true"; set => Stat = value.ToString(); }

        // Not applicable properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
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
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReserDate", ReserDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaDate", StaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Stat", Stat as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReserID", ReserID);
            cmd.Parameters.AddWithValue("@ReserDate", ReserDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaDate", StaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Stat", Stat as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReserID", ReserID);
        }
    }
}

