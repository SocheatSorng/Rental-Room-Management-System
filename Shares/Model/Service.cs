﻿using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Service : IEntity
    {
        // Original properties
        public int SerID { get; set; }
        public string? ServName { get; set; }
        public string? ServDescription { get; set; }
        public double Cost { get; set; }
        public int VenID { get; set; }
        public int RoomID { get; set; }

        // Implementing applicable interface members
        public int ID { get => SerID; set => SerID = value; }
        public string FirstName { get => ServName ?? string.Empty; set => ServName = value; }
        public string Description { get => ServDescription ?? string.Empty; set => ServDescription = value; }
        public double CostPrice { get => Cost; set => Cost = value; }

        // Not applicable properties
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
        public DateTime? Start { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", FirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", Description as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Cost", CostPrice as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VendorID", VenID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RoomID", RoomID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ServiceID", ID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ServiceID", SerID);
        }
    }
}