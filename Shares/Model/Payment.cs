using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Payment : IEntity
    {
        // Core properties
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? ReservationID { get; set; }
        public int StaffID { get; set; }
        public int? UtilityID { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public bool IsSecondPaymentDone { get; set; }
        public bool IsUtilityOnly { get; set; }

        // IEntity implementation
        public int ID { get => PaymentID; set => PaymentID = value; }
        public DateTime Start { get => PaymentDate; set => PaymentDate = value; }
        public string Type { get => IsUtilityOnly ? "Utility" : "Reservation"; set { } }
        public string Description { get => $"Payment of {PaidAmount:C}"; set { } }

        // Required but unused IEntity properties
        public string FirstName { get => string.Empty; set { } }
        public string LastName { get => string.Empty; set { } }
        public string Sex { get => string.Empty; set { } }
        public DateTime BirthDate { get => DateTime.MinValue; set { } }
        public string HouseNo { get => string.Empty; set { } }
        public string StreetNo { get => string.Empty; set { } }
        public string Commune { get => string.Empty; set { } }
        public string District { get => string.Empty; set { } }
        public string Province { get => string.Empty; set { } }
        public string PersonalNumber { get => string.Empty; set { } }
        public string ContactNumber { get => string.Empty; set { } }
        public double Salary { get => 0; set { } }
        public DateTime Booking { get => DateTime.MinValue; set { } }
        public DateTime End { get => DateTime.MinValue; set { } }
        public bool Status { get => false; set { } }
        public double CostPrice { get => 0; set { } }
        public double RentPrice { get => 0; set { } }
        public string Password { get => string.Empty; set { } }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            cmd.Parameters.AddWithValue("@ReservationID", ReservationID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaffID", StaffID);
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PaidAmount", PaidAmount);
            cmd.Parameters.AddWithValue("@RemainingAmount", RemainingAmount);
            cmd.Parameters.AddWithValue("@IsSecondPaymentDone", IsSecondPaymentDone);
            cmd.Parameters.AddWithValue("@IsUtilityOnly", IsUtilityOnly);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
        }
    }
}