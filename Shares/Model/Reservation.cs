using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Reservation : IEntity
    {
        // Core properties
        public int ReservationID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? _Status { get; set; }
        public int ResidentID { get; set; }
        public int RoomID { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }

        // IEntity implementation
        public int ID { get => ReservationID; set => ReservationID = value; }
        public DateTime Booking { get => ReservationDate; set => ReservationDate = value; }
        public DateTime? Start { get => StartDate; set => StartDate = value; }
        public DateTime? End { get => EndDate; set => EndDate = value; }
        public string Description { get => _Status ?? string.Empty; set => _Status = value; }
        public double CostPrice { get => (double)PaidAmount; set => PaidAmount = (decimal)value; }

        // Not applicable IEntity properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime? BirthDate { get => null; set => throw new NotSupportedException(); }
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
            cmd.Parameters.AddWithValue("@ReservationDate", ReservationDate);
            cmd.Parameters.AddWithValue("@StartDate", StartDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", _Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@PaidAmount", PaidAmount);
            cmd.Parameters.AddWithValue("@RemainingAmount", RemainingAmount);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ReservationID", ReservationID);
        }
    }
}