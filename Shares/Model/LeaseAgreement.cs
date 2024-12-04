using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    using Microsoft.Data.SqlClient;

    public class LeaseAgreement : IEntity
    {
        // Original properties
        public int LeaseAgreementID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal MonthRent { get; set; }
        public string? TermsAndCondi { get; set; }
        public int ResID { get; set; }

        // Implementing applicable interface members
        public int ID { get => LeaseAgreementID; set => LeaseAgreementID = value; }
        public DateTime? Start { get => StartDate; set => StartDate = value; }
        public DateTime? End { get => EndDate; set => EndDate = value; }
        public double RentPrice { get => (double)MonthRent; set => MonthRent = (decimal)value; }
        public string Description { get => TermsAndCondi ?? string.Empty; set => TermsAndCondi = value; }

        // Not applicable properties
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
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
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StartDate", Start as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EndDate", End as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TermsAndConditions", Description as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResidentID", ResID as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@LeaseAgreementID", LeaseAgreementID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@LeaseAgreementID", LeaseAgreementID);
        }
    }
} 