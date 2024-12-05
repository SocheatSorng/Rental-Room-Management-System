using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Rent : IEntity
    {
        // Original properties
        public int RentID { get; set; }
        public DateTime? StaDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Amount { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => RentID; set => RentID = value; }
        public DateTime? Start { get => StaDate; set => StaDate = value; }
        public DateTime? End { get => EndDate; set => EndDate = value; }
        public double RentPrice { get => Amount; set => Amount = value; }

        // Not applicable properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Type { get => string.Empty; set => throw new NotSupportedException(); }
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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StartDate", StaDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", EndDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", RentPrice as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RentID", RentID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RentID", RentID);
        }
    }
}