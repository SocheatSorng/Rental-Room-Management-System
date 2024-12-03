using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS.Model
{
    public class User : IEntity
    {
        // Original properties
        public int UseId { get; set; }
        public string? UseName { get; set; }
        public string? UsePassword { get; set; }
        public string? UsePosition { get; set; }

        // Implementing applicable interface members
        public int ID { get => UseId; set => UseId = value; }
        public string FirstName { get => UseName ?? string.Empty; set => UseName = value; }
        public string Password { get => UsePassword ?? string.Empty; set => UsePassword = value; }
        public string Type { get => UsePosition ?? string.Empty; set => UsePosition = value; }

        // Not applicable properties
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
        public DateTime? Start { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public DateTime? End { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UseName", UseName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsePassword", UsePassword as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsePosition", UsePosition as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UseId", UseId);
            cmd.Parameters.AddWithValue("@UseName", UseName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsePassword", UsePassword as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UsePosition", UsePosition as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UseId", UseId);
        }
    }
}