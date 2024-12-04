using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS
{
    public class Amenity : IEntity
    {
        // Original properties
        public int AmeID { get; set; }
        public string? AmeName { get; set; }
        public bool AmeAvailable { get; set; }
        public double AmeBoughtPrice { get; set; }
        public double AmeCostPerRent { get; set; }
        public DateTime? AmeMaintenanceDate { get; set; }
        public string? AmeDescription { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => AmeID; set => AmeID = value; }
        public string FirstName { get => AmeName ?? string.Empty; set => AmeName = value; }
        public double CostPrice { get => AmeBoughtPrice; set => AmeBoughtPrice= value; }
        public double RentPrice { get => AmeCostPerRent; set => AmeCostPerRent = value; }
        public DateTime? Start { get => AmeMaintenanceDate; set => AmeMaintenanceDate = value; }
        public string Description { get => AmeDescription ?? string.Empty; set => AmeDescription = value; }

        // Not applicable properties
        public bool Status { get => false; set => throw new NotSupportedException(); }
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
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", FirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BoughtPrice", CostPrice as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CostPerRent", RentPrice as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MaintenanceDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", Description as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmenityID", AmeID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmenityID", AmeID);
        }
    }
}
