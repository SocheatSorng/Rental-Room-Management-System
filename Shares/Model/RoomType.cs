using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class RoomType : IEntity
    {
        // Original properties matching database table
        public int RoomTypeID { get; set; }
        public string? TypeName { get; set; }
        public decimal BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        // IEntity interface implementation
        public int ID { get => RoomTypeID; set => RoomTypeID = value; }
        public string Type { get => TypeName ?? string.Empty; set => TypeName = value; }
        public double CostPrice { get => (double)BasePrice; set => BasePrice = (decimal)value; }

        // Using existing Description property
        public string Description_ { get => Description ?? string.Empty; set => Description = value; }

        // Unused IEntity properties - implementing with default values
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
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
        public DateTime Start { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status_ { get => Status == "Active"; set => Status = value ? "Active" : "Inactive"; }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        // SqlCommand parameter methods
        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@TypeName", TypeName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BasePrice", BasePrice);
            cmd.Parameters.AddWithValue("@Description", Description as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", Status as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
        }
    }
}