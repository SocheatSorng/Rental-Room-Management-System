using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Reservation : IEntity
    {
        // Original properties
        public int ReservationID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? ReservationStartDate { get; set; }
        public DateTime? ReservationEndDate { get; set; }
        public string? ReservationType { get; set; }
        public double ReservationAmount { get; set; }
        public int ResidentID { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => ReservationID; set => ReservationID = value; }
        public DateTime Booking { get => ReservationDate; set => ReservationDate = value; }
        public DateTime? Start { get => ReservationStartDate; set => ReservationStartDate = value; }
        public DateTime? End { get => ReservationEndDate; set => ReservationEndDate = value; }
        public string Description { get => ReservationType; set => ReservationType = value; }
        public double CostPrice { get => ReservationAmount; set => ReservationAmount = value; }

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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReservationDate", ReservationDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationStartDate", ReservationStartDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationEndDate", ReservationEndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationType", ReservationType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationAmount", ReservationAmount as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReserID", ReservationID);
            cmd.Parameters.AddWithValue("@ReservationDate", ReservationDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationStartDate", ReservationStartDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationEndDate", ReservationEndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationType", ReservationType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationAmount", ReservationAmount as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
        }
    }
}

