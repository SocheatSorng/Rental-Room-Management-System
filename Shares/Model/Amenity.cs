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
        public bool AmeAvail { get; set; }
        public string? AmeLoc { get; set; }
        public double AmeBP { get; set; }
        public double AmeCPR { get; set; }
        public DateTime AmeMD { get; set; }
        public string? AmeDesc { get; set; }

        // Implementing applicable interface members
        public int ID { get => AmeID; set => AmeID = value; }
        public string FirstName { get => AmeName ?? string.Empty; set => AmeName = value; }
        public bool Status { get => AmeAvail; set => AmeAvail = value; }
        public string Province { get => AmeLoc ?? string.Empty; set => AmeLoc = value; }
        public double CostPrice { get => AmeBP; set => AmeBP = value; }
        public double RentPrice { get => AmeCPR; set => AmeCPR = value; }
        public DateTime Start { get => AmeMD; set => AmeMD = value; }
        public string Description { get => AmeDesc ?? string.Empty; set => AmeDesc = value; }

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
            cmd.Parameters.AddWithValue("@AmeName", AmeName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeAvail", AmeAvail as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeLoc", AmeLoc as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeBP", AmeBP as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeCPR", AmeCPR as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeMD", AmeMD as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AmeDesc", AmeDesc as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmeID", AmeID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@AmeID", AmeID);
        }
    }
}
