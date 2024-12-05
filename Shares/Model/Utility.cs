using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Utility : IEntity
    {
        // Original properties
        private int UtilityID { get; set; }
        private string? UtilityType { get; set; }
        private double Cost { get; set; }
        private DateTime? UsageDate { get; set; }
        private int roomID;
        public int RoomID { get => roomID; set => roomID = value; }


        // Implementing applicable interface members
        public int ID { get => UtilityID; set => UtilityID = value; }
        public string Type { get => UtilityType ?? string.Empty; set => UtilityType = value; }
        public double CostPrice { get => Cost; set => Cost = value; }
        public DateTime? Start { get => UsageDate; set => UsageDate = value; }

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
            cmd.Parameters.AddWithValue("@UtilityType", UtilityType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Cost", Cost as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsageDate", UsageDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
        }
    }
}