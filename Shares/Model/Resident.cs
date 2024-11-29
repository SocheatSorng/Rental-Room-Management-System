using Microsoft.Data.SqlClient;


namespace RRMS {
    public class Resident : IEntity
    {
        public int ResID { get; set; }
        public string? ResType { get; set; }
        public string? ResFirstName { get; set; }
        public string? ResLastName { get; set; }
        public string? ResSex { get; set; }
        public DateTime ResBD { get; set; }
        public string? ResPrevHouseNo { get; set; }
        public string? ResPrevStNo { get; set; }
        public string? ResPrevCommune { get; set; }
        public string? ResPrevDistrict { get; set; }
        public string? ResPrevProvince { get; set; }
        public string? ResPerNum { get; set; }
        public string? ResConNum { get; set; }
        public DateTime ResCheckIn { get; set; }
        public DateTime ResCheckOut { get; set; }

        // Implementing interface members
        public int ID { get => ResID; set => ResID = value; }
        public string FirstName { get => ResFirstName; set => ResFirstName = value; }
        public string LastName { get => ResLastName; set => ResLastName = value; }
        public string Sex { get => ResSex; set => ResSex = value; }
        public DateTime BirthDate { get => ResBD; set => ResBD = value; }
        public string Type { get => ResType; set => ResType = value; }
        public string HouseNo { get => ResPrevHouseNo; set => ResPrevHouseNo = value; }
        public string StreetNo { get => ResPrevStNo; set => ResPrevStNo = value; }
        public string Commune { get => ResPrevCommune; set => ResPrevCommune = value; }
        public string District { get => ResPrevDistrict; set => ResPrevDistrict = value; }
        public string Province { get => ResPrevProvince; set => ResPrevProvince = value; }
        public string PersonalNumber { get => ResPerNum; set => ResPerNum = value; }
        public string ContactNumber { get => ResConNum; set => ResConNum = value; }
        public DateTime Start { get => ResCheckIn; set => ResCheckIn = value; }
        public DateTime End { get => ResCheckOut; set => ResCheckOut = value; }

        // Not applicable for Resident
        public double Salary { get => 0; set => throw new NotSupportedException(); } // Not applicable for Resident
        public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); } // Not applicable for Resident
        public bool Status { get => false; set => throw new NotSupportedException(); } // Not applicable for Resident
        public string Description { get => string.Empty; set => throw new NotSupportedException(); } // Not applicable for Resident
        public double CostPrice { get => 0; set => throw new NotSupportedException(); } // Not applicable for Resident
        public double RentPrice { get => 0; set => throw new NotSupportedException(); } // Not applicable for Resident
        public string Password { get => string.Empty; set => throw new NotSupportedException(); } // Not applicable for Resident

        public void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ResType", ResType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResName", ResFirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResSex", ResSex as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResBOD", ResBD as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevHouseNo", ResPrevHouseNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevStNo", ResPrevStNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevCommune", ResPrevCommune as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevDistrict", ResPrevDistrict as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevProvince", ResPrevProvince as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPerNum", ResPerNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResConNum", ResConNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckIn", ResCheckIn as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckOut", ResCheckOut as object ?? DBNull.Value);
        }

        public void AddParametersWithID(SqlCommand cmd)
        {
            // Assuming ResID is the identifier for the resident
            cmd.Parameters.AddWithValue("@ResID", ResID);

            // Add the rest of the parameters, similar to AddParameters
            cmd.Parameters.AddWithValue("@ResType", ResType as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResName", ResFirstName as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResSex", ResSex as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResBOD", ResBD as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevHouseNo", ResPrevHouseNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevStNo", ResPrevStNo as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevCommune", ResPrevCommune as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevDistrict", ResPrevDistrict as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPrevProvince", ResPrevProvince as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResPerNum", ResPerNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResConNum", ResConNum as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckIn", ResCheckIn as object ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResCheckOut", ResCheckOut as object ?? DBNull.Value);
        }

        public void AddOnlyIDParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ResID", ResID);
        }
    }
}
