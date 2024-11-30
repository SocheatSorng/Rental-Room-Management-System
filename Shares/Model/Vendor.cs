using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS.Model
{
    public class Vendor : IEntity
    {
        public int VenID { get; set; }
        public string? VenName { get; set; }
        public string? VenContact { get; set; }
        public string? VenHNo { get; set; }
        public string? VenSNo { get; set; }
        public string? VenCommune { get; set; }
        public string? VenDistrict { get; set; }
        public string? VenProvince { get; set; }
        public DateTime VenConStart { get; set; }
        public DateTime VenConEnd { get; set; }
        public bool VenStatus { get; set; }
        public string? VenDesc { get; set; }

        // IEntity interface implementation - Applicable properties
        public int ID { get => VenID; set => VenID = value; }
        public string FirstName { get => VenName; set => VenName = value; }
        public string HouseNo { get => VenHNo; set => VenHNo = value; }
        public string StreetNo { get => VenSNo; set => VenSNo = value; }
        public string Commune { get => VenCommune; set => VenCommune = value; }
        public string District { get => VenDistrict; set => VenDistrict = value; }
        public string Province { get => VenProvince; set => VenProvince = value; }
        public string ContactNumber { get => VenContact; set => VenContact = value; }
        public bool Status { get => VenStatus; set => VenStatus = value; }
        public DateTime Start { get => VenConStart; set => VenConStart = value; }
        public DateTime End { get => VenConEnd; set => VenConEnd = value; }
        public string Description { get => VenDesc ?? string.Empty; set => VenDesc = value; }

        // IEntity interface implementation - Not applicable for Vendor
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Type { get => string.Empty; set => throw new NotSupportedException(); }
        public string PersonalNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public double Salary { get => 0; set => throw new NotSupportedException(); }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@VenName", VenName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenContact", VenContact as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenHNo", VenHNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenSNo", VenSNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenCommune", VenCommune as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenDistrict", VenDistrict as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenProvince", VenProvince as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VenConStart", VenConStart);
            cmd.Parameters.AddWithValue("@VenConEnd", VenConEnd);
            cmd.Parameters.AddWithValue("@VenStatus", VenStatus);
            cmd.Parameters.AddWithValue("@VenDesc", VenDesc as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@VenID", VenID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@VenID", VenID);
        }
    }
}