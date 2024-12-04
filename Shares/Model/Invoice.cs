using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Invoice : IEntity
    {
        // Primary properties matching table structure
        public int InvoiceID { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int PaymentID { get; set; }

        // Additional properties for display (from joins)
        public decimal Amount { get; private set; }
        public string? ResidentName { get; private set; }
        public string? StaffName { get; private set; }

        // Implementing IEntity interface
        public int ID { get => InvoiceID; set => InvoiceID = value; }
        public string Type { get => InvoiceNo ?? string.Empty; set => InvoiceNo = value; }
        public DateTime? Start { get => InvoiceDate; set => InvoiceDate = value; }

        // Not used but required by interface
        public string FirstName { get => string.Empty; set => throw new NotSupportedException(); }
        public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
        public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
        public DateTime? BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
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
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);
        }
    }
}