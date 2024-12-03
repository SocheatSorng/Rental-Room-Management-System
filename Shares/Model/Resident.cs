using Microsoft.Data.SqlClient;

namespace RRMS.Model
{
    public class Resident : IEntity
    {
        public int ResidentID { get; set; }
        public string? ResType { get; set; }
        public string? ResFirstName { get; set; }
        public string? ResLastName { get; set; }
        public string? ResSex { get; set; }
        public DateTime? ResBD { get; set; }  // Changed to nullable DateTime
        public string? ResPrevHouseNo { get; set; }
        public string? ResPrevStNo { get; set; }
        public string? ResPrevCommune { get; set; }
        public string? ResPrevDistrict { get; set; }
        public string? ResPrevProvince { get; set; }
        public string? ResPerNum { get; set; }
        public string? ResConNum { get; set; }
        public DateTime? ResCheckIn { get; set; }  // Changed to nullable DateTime
        public DateTime? ResCheckOut { get; set; }  // Changed to nullable DateTime

        // Implementing interface members
        public int ID { get => ResidentID; set => ResidentID = value; }
        public string FirstName { get => ResFirstName; set => ResFirstName = value; }
        public string LastName { get => ResLastName; set => ResLastName = value; }
        public string Sex { get => ResSex; set => ResSex = value; }
        public DateTime? BirthDate { get => ResBD; set => ResBD = value; }  // Changed to nullable
        public string Type { get => ResType; set => ResType = value; }
        public string HouseNo { get => ResPrevHouseNo; set => ResPrevHouseNo = value; }
        public string StreetNo { get => ResPrevStNo; set => ResPrevStNo = value; }
        public string Commune { get => ResPrevCommune; set => ResPrevCommune = value; }
        public string District { get => ResPrevDistrict; set => ResPrevDistrict = value; }
        public string Province { get => ResPrevProvince; set => ResPrevProvince = value; }
        public string PersonalNumber { get => ResPerNum; set => ResPerNum = value; }
        public string ContactNumber { get => ResConNum; set => ResConNum = value; }
        public DateTime? Start { get => ResCheckIn; set => ResCheckIn = value; }  // Changed to nullable
        public DateTime? End { get => ResCheckOut; set => ResCheckOut = value; }  // Changed to nullable

        // Not applicable for Resident
        public double Salary { get => 0; set => throw new NotSupportedException(); }
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
        public bool Status { get => false; set => throw new NotSupportedException(); }
        public string Description { get => string.Empty; set => throw new NotSupportedException(); }
        public double CostPrice { get => 0; set => throw new NotSupportedException(); }
        public double RentPrice { get => 0; set => throw new NotSupportedException(); }
        public string Password { get => string.Empty; set => throw new NotSupportedException(); }

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ResType", ResType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResFirstName", ResFirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResLastName", ResLastName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResSex", ResSex as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResBD", ResBD.HasValue ? (object)ResBD.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevHouseNo", ResPrevHouseNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevStNo", ResPrevStNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevCommune", ResPrevCommune as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevDistrict", ResPrevDistrict as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevProvince", ResPrevProvince as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPerNum", ResPerNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResConNum", ResConNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckIn", ResCheckIn.HasValue ? (object)ResCheckIn.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckOut", ResCheckOut.HasValue ? (object)ResCheckOut.Value : DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ResidentID", ID);
            AddParameters(cmd);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ResidentID", ID);
        }
    }
}