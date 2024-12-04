using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Staff : IEntity
    {
        public int StaffID { get; set; }
        public string? StaFName { get; set; }
        public string? StaLName { get; set; }
        public string? StaSex { get; set; }
        public DateTime? StaBD { get; set; }
        public string? StaPosition { get; set; }
        public string? StaHNo { get; set; }
        public string? StaSNo { get; set; }
        public string? StaCommune { get; set; }
        public string? StaDistrict { get; set; }
        public string? StaProvince { get; set; }
        public string? StaPerNum { get; set; }
        public double StaSalary { get; set; }
        public DateTime? StaHiredDate { get; set; }
        public DateTime? StaStopped { get; set; }

        // IEntity implementation
        public int ID { get => StaffID; set => StaffID = value; }
        public string FirstName { get => StaFName ?? string.Empty; set => StaFName = value; }
        public string LastName { get => StaLName ?? string.Empty; set => StaLName = value; }
        public string Sex { get => StaSex ?? string.Empty; set => StaSex = value; }
        public DateTime? BirthDate { get => StaBD ?? DateTime.MinValue; set => StaBD = value; }
        public string Type { get => StaPosition ?? string.Empty; set => StaPosition = value; }
        public string HouseNo { get => StaHNo ?? string.Empty; set => StaHNo = value; }
        public string StreetNo { get => StaSNo ?? string.Empty; set => StaSNo = value; }
        public string Commune { get => StaCommune ?? string.Empty; set => StaCommune = value; }
        public string District { get => StaDistrict ?? string.Empty; set => StaDistrict = value; }
        public string Province { get => StaProvince ?? string.Empty; set => StaProvince = value; }
        public string PersonalNumber { get => StaPerNum ?? string.Empty; set => StaPerNum = value; }
        public string ContactNumber { get => string.Empty; set => throw new NotSupportedException(); }
        public double Salary { get => StaSalary; set => StaSalary = value; }
        public DateTime? Start { get => StaHiredDate ?? DateTime.MinValue; set => StaHiredDate = value; }
        public DateTime? End { get => StaStopped ?? DateTime.MinValue; set => StaStopped = value; }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StaFirstName", StaFName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaLastName", StaLName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaSex", StaSex as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaBD", StaBD.HasValue ? (object)StaBD.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@StaPosition", StaPosition as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaHouseNo", StaHNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaStreetNo", StaSNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaCommune", StaCommune as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaDistrict", StaDistrict as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaProvince", StaProvince as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaPerNum", StaPerNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaSalary", StaSalary);
            cmd.Parameters.AddWithValue("@StaHiredDate", StaHiredDate.HasValue ? (object)StaHiredDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@StaStopped", StaStopped.HasValue ? (object)StaStopped.Value : DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StaffID", StaffID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StaffID", StaffID);
        }
    }
}