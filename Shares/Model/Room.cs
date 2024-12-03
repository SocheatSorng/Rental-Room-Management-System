using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Room : IEntity
    {
        // Original properties specific to Room
        public int RoomID { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public int? ResidentID { get; set; }

        // Implementing applicable IEntity properties
        public int ID { get => RoomID; set => RoomID = value; }
        public string Type { get => RoomType ?? string.Empty; set => RoomType = value; }
        public string Description { get => RoomNumber ?? string.Empty; set => RoomNumber = value; }

        // Non-applicable properties from IEntity
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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public DateTime? Start { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        // Implementing required methods from IEntity
        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomType", RoomType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResidentID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
        }
    }
}