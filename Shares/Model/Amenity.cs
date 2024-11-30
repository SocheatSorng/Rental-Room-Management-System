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
        public int AmenId { get; set; }
        public string? AmenName { get; set; }
        public bool AmenAvail { get; set; }
        public string? AmenLocation { get; set; }
        public double AmenBouPri { get; set; }
        public double AmenCPR { get; set; }
        public DateTime AmenMainDate { get; set; }
        public string? AmenDesc { get; set; }

        // Implementing applicable interface members
        public int ID { get => AmenId; set => AmenId = value; }
        public string FirstName { get => AmenName ?? string.Empty; set => AmenName = value; }
        public bool Status { get => AmenAvail; set => AmenAvail = value; }
        public string Province { get => AmenLocation ?? string.Empty; set => AmenLocation = value; }
        public double CostPrice { get => AmenBouPri; set => AmenBouPri = value; }
        public double RentPrice { get => AmenCPR; set => AmenCPR = value; }
        public DateTime Start { get => AmenMainDate; set => AmenMainDate = value; }
        public string Description { get => AmenDesc ?? string.Empty; set => AmenDesc = value; }

        // Not applicable properties
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Type { get => string.Empty; set => throw new NotSupportedException(); }
        public string HouseNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string StreetNo { get => string.Empty; set => throw new NotSupportedException(); }
        public string Commune { get => string.Empty; set => throw new NotSupportedException(); }
        public string District { get => string.Empty; set => throw new NotSupportedException(); }
        public string PersonalNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public string ContactNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public double Salary { get => 0; set => throw new NotSupportedException(); }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmenName", AmenName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenAvail", AmenAvail as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenLocation", AmenLocation as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenBouPri", AmenBouPri as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenCPR", AmenCPR as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenMainDate", AmenMainDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenDesc", AmenDesc as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmenId", AmenId);
            cmd.Parameters.AddWithValue("@AmenName", AmenName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenAvail", AmenAvail as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenLocation", AmenLocation as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenBouPri", AmenBouPri as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenCPR", AmenCPR as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenMainDate", AmenMainDate as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmenDesc", AmenDesc as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmenId", AmenId);
        }
    }
}
