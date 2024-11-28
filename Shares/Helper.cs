using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using RRMS;
using RRMS.Model;
using System;

namespace RRMS
{
    public static class Helper
    {
        public static string ConnectionStringKey { get; set; } = "ConnectionString";
        public static IConfiguration? Configuration { get; set; } = null;
        public static void LoadConfiguration(string jsonFile)
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile(jsonFile, optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public static SqlConnection OpenConnection()
        {
            try
            {
                string? connStr = Configuration?.GetRequiredSection(ConnectionStringKey).Value;
                var conn = new SqlConnection(connStr);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to connect to the server > {ex.Message}");
            }
        }

        #region eventhandlers
        public static event EventHandler<EntityEventArgs>? Added;
        public static event EventHandler<EntityEventArgs>? Updated;
        public static event EventHandler<EntityEventArgs>? Deleted;
        #endregion

        #region(field names)

        // Table Resident
        private const string RESIDENT_TBL_NAME = "tblResident";
        private const string RESIDENT_ID_FIELD = "ID";
        private const string RESIDENT_TYPE_FIELD = "Type";
        private const string RESIDENT_NAME_FIELD = "Name";
        private const string RESIDENT_SEX_FIELD = "Sex";
        private const string RESIDENT_BOD_FIELD = "BOD";
        private const string RESIDENT_PREV_HOUSE_NO_FIELD = "PrevHouseNo";
        private const string RESIDENT_PREV_ST_NO_FIELD = "PrevStNo";
        private const string RESIDENT_PREV_COMMUNE_FIELD = "PrevCommune";
        private const string RESIDENT_PREV_DISTRICT_FIELD = "PrevDistrict";
        private const string RESIDENT_PREV_PROVINCE_FIELD = "PrevProvince";
        private const string RESIDENT_PER_NUM_FIELD = "PerNum";
        private const string RESIDENT_CON_NUM_FIELD = "ConNum";
        private const string RESIDENT_CHECK_IN_FIELD = "CheckIn";
        private const string RESIDENT_CHECK_OUT_FIELD = "CheckOut";
        #endregion


        #region crud(residents)


        // Read all residents
        public static IEnumerable<Resident> GetAllResidents(SqlConnection conn)
        {
            List<Resident> residents = new List<Resident>();

            using (SqlCommand cmd = new SqlCommand("GetAllResidents", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal(RESIDENT_ID_FIELD));
                            string type = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                            string name = reader.IsDBNull(reader.GetOrdinal(RESIDENT_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_NAME_FIELD));
                            string sex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty: reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                            DateTime bod = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                            string prevHouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                            string prevStNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                            string prevCommune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                            string prevDistrict = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                            string perNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                            string conNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                            DateTime checkIn = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                            DateTime checkOut = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));

                            residents.Add(new Resident()
                            {
                                ResID = id,
                                ResType = type,
                                ResFirstName = name,
                                ResSex = sex,
                                ResBD = bod,
                                ResPrevHouseNo = prevHouseNo,
                                ResPrevStNo = prevStNo,
                                ResPrevCommune = prevCommune,
                                ResPrevDistrict = prevDistrict,
                                ResPerNum = perNum,
                                ResConNum = conNum,
                                ResCheckIn = checkIn,
                                ResCheckOut = checkOut
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all residents > {ex.Message}");
                }
            }

            return residents;
        }
        // Read a specified resident by ID
        public static Resident? GetResidentById(SqlConnection conn, int id)
        {
            Resident? result = null;

            using (SqlCommand cmd = new SqlCommand("GetResidentById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResID", id);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string type = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                            string name = reader.IsDBNull(reader.GetOrdinal(RESIDENT_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_NAME_FIELD));
                            string sex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                            DateTime bod = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                            string prevHouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                            string prevStNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                            string prevCommune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                            string prevDistrict = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                            string perNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                            string conNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                            DateTime checkIn = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                            DateTime checkOut = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));

                            result = new Resident()
                            {
                                ResID = id,
                                ResType = type,
                                ResFirstName = name,
                                ResSex = sex,
                                ResBD = bod,
                                ResPrevHouseNo = prevHouseNo,
                                ResPrevStNo = prevStNo,
                                ResPrevCommune = prevCommune,
                                ResPrevDistrict = prevDistrict,
                                ResPerNum = perNum,
                                ResConNum = conNum,
                                ResCheckIn = checkIn,
                                ResCheckOut = checkOut
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting resident with id, {id} > {ex.Message}");
                }
            }

            return result;
        }

        // Create a new resident
        public static string? AddResident(SqlConnection conn, Resident resident)
        {
            using (SqlCommand cmd = new SqlCommand("AddResident", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Remove the ResidentID parameter since it's auto-generated
                cmd.Parameters.AddWithValue("@ResidentType", resident.ResType as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentName", resident.ResFirstName as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentSex", resident.ResSex as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentBOD", resident.ResBD as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentPrevHouseNo", resident.ResPrevHouseNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentPrevStNo", resident.ResPrevStNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentPrevCommune", resident.ResPrevCommune as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentPrevDistrict", resident.ResPrevDistrict as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentPerNum", resident.ResPerNum as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentConNum", resident.ResConNum as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentCheckIn", resident.ResCheckIn as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ResidentCheckOut", resident.ResCheckOut as object ?? DBNull.Value);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (resident.ResID >= 0 && resident.ResID <= 255)
                    {
                        Added?.Invoke(null, new EntityEventArgs() { ByteId = (byte)resident.ResID, Entity = EntityTypes.Residents });
                    }
                    else
                    {
                        throw new Exception($"ResidentID {resident.ResID} is out of range for ByteId.");
                    }

                    return (effected > 0) ? resident.ResID.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in adding new resident > {ex.Message}");
                }
            }
        }        // Update an existing resident
        public static bool UpdateResident(SqlConnection conn, Resident resident)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateResident", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentID", resident.ResID); // This should be set from the selected resident
                cmd.Parameters.AddWithValue("@ResidentType", string.IsNullOrEmpty(resident.ResType) ? DBNull.Value : resident.ResType);
                cmd.Parameters.AddWithValue("@ResidentName", string.IsNullOrEmpty(resident.ResFirstName) ? DBNull.Value : resident.ResFirstName);
                cmd.Parameters.AddWithValue("@ResidentSex", resident.ResSex);
                cmd.Parameters.AddWithValue("@ResidentBOD", resident.ResBD);
                cmd.Parameters.AddWithValue("@ResidentPrevHouseNo", string.IsNullOrEmpty(resident.ResPrevHouseNo) ? DBNull.Value : resident.ResPrevHouseNo);
                cmd.Parameters.AddWithValue("@ResidentPrevStNo", string.IsNullOrEmpty(resident.ResPrevStNo) ? DBNull.Value : resident.ResPrevStNo);
                cmd.Parameters.AddWithValue("@ResidentPrevCommune", string.IsNullOrEmpty(resident.ResPrevCommune) ? DBNull.Value : resident.ResPrevCommune);
                cmd.Parameters.AddWithValue("@ResidentPrevDistrict", string.IsNullOrEmpty(resident.ResPrevDistrict) ? DBNull.Value : resident.ResPrevDistrict);
                cmd.Parameters.AddWithValue("@ResidentPerNum", string.IsNullOrEmpty(resident.ResPerNum) ? DBNull.Value : resident.ResPerNum);
                cmd.Parameters.AddWithValue("@ResidentConNum", string.IsNullOrEmpty(resident.ResConNum) ? DBNull.Value : resident.ResConNum);
                cmd.Parameters.AddWithValue("@ResidentCheckIn", resident.ResCheckIn);
                cmd.Parameters.AddWithValue("@ResidentCheckOut", resident.ResCheckOut);

                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (resident.ResID >= 0 && resident.ResID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)resident.ResID, Entity = EntityTypes.Residents });
                        }
                        else
                        {
                            throw new Exception($"ResidentID {resident.ResID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }

                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in updating resident > {ex.Message}");
                }
            }
        }
        // Delete an existing resident
        public static bool DeleteResident(SqlConnection conn, int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteResident", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentID", id);
                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        // Ensure id can be safely cast to byte
                        if (id >= 0 && id <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)id, Entity = EntityTypes.Residents });
                        }
                        else
                        {
                            // Handle the case where id is out of range
                            throw new Exception($"ResidentID {id} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting a resident with id {id} > {ex.Message}");
                }
            }
        }

        // Validate Resident ID
        public static bool ValidateResidentID(SqlConnection conn, int residentID)
        {
            using (SqlCommand cmd = new SqlCommand("ValidateResidentID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentID", residentID);
                try
                {
                    int count = (int)cmd.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in validating resident id > {ex.Message}");
                }
            }
        }

        // Get Resident Name only
        public static string GetResidentNameById(SqlConnection conn, int id)
        {
            string residentName = string.Empty;

            using (SqlCommand cmd = new SqlCommand("sp_GetResidentNameById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentID", id);
                try
                {
                    // Execute the command and retrieve the resident name
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        residentName = result.ToString();
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    throw new Exception($"Error in getting resident name with id, {id} > {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    throw new Exception($"Error in getting resident name with id, {id} > {ex.Message}");
                }
            }

            return residentName;
        }
        #endregion

        #region crud(vendors)
        private const string VENDOR_TBL_NAME = "tblVendor";
        private const string VENDOR_ID_FIELD = "VendorID";
        private const string VENDOR_NAME_FIELD = "VendorName";
        private const string VENDOR_CONTACT_FIELD = "VendorContact";
        private const string VENDOR_HOUSE_NO_FIELD = "VendorHNo";
        private const string VENDOR_STREET_NO_FIELD = "VendorSNo";
        private const string VENDOR_COMMUNE_FIELD = "VendorCommune";
        private const string VENDOR_DISTRICT_FIELD = "VendorDistrict";
        private const string VENDOR_PROVINCE_FIELD = "VendorProvince";
        private const string VENDOR_CON_START_FIELD = "VendorConStart";
        private const string VENDOR_CON_END_FIELD = "VendorConEnd";
        private const string VENDOR_STATUS_FIELD = "VendorStatus";
        private const string VENDOR_DESC_FIELD = "VendorDesc";

        // Read all vendors
        public static IEnumerable<Vendor> GetAllVendors(SqlConnection conn)
        {
            List<Vendor> vendors = new List<Vendor>();

            using (SqlCommand cmd = new SqlCommand("GetAllVendors", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal(VENDOR_ID_FIELD));
                            string name = reader.IsDBNull(reader.GetOrdinal(VENDOR_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_NAME_FIELD));
                            string contact = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONTACT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_CONTACT_FIELD));
                            string houseNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_HOUSE_NO_FIELD));
                            string streetNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_STREET_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_STREET_NO_FIELD));
                            string commune = reader.IsDBNull(reader.GetOrdinal(VENDOR_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_COMMUNE_FIELD));
                            string district = reader.IsDBNull(reader.GetOrdinal(VENDOR_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DISTRICT_FIELD));
                            string province = reader.IsDBNull(reader.GetOrdinal(VENDOR_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_PROVINCE_FIELD));
                            DateTime conStart = reader.IsDBNull(reader.GetOrdinal(VENDOR_CON_START_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CON_START_FIELD));
                            DateTime conEnd = reader.IsDBNull(reader.GetOrdinal(VENDOR_CON_END_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CON_END_FIELD));
                            bool status = reader.IsDBNull(reader.GetOrdinal(VENDOR_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(VENDOR_STATUS_FIELD));
                            string desc = reader.IsDBNull(reader.GetOrdinal(VENDOR_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DESC_FIELD));

                            vendors.Add(new Vendor()
                            {
                                VendorID = id,
                                VendorName = name,
                                VendorContact = contact,
                                VendorHNo = houseNo,
                                VendorSNo = streetNo,
                                VendorCommune = commune,
                                VendorDistrict = district,
                                VendorProvince = province,
                                VendorConStart = conStart,
                                VendorConEnd = conEnd,
                                VendorStatus = status,
                                VendorDesc = desc
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all vendors > {ex.Message}");
                }
            }

            return vendors;
        }

        // Read a specified vendor by ID
        public static Vendor? GetVendorById(SqlConnection conn, int id)
        {
            Vendor? result = null;

            using (SqlCommand cmd = new SqlCommand("GetVendorById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorID", id);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.IsDBNull(reader.GetOrdinal(VENDOR_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_NAME_FIELD));
                            string contact = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONTACT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_CONTACT_FIELD));
                            string houseNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_HOUSE_NO_FIELD));
                            string streetNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_STREET_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_STREET_NO_FIELD));
                            string commune = reader.IsDBNull(reader.GetOrdinal(VENDOR_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_COMMUNE_FIELD));
                            string district = reader.IsDBNull(reader.GetOrdinal(VENDOR_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DISTRICT_FIELD));
                            string province = reader.IsDBNull(reader.GetOrdinal(VENDOR_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_PROVINCE_FIELD));
                            DateTime conStart = reader.IsDBNull(reader.GetOrdinal(VENDOR_CON_START_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CON_START_FIELD));
                            DateTime conEnd = reader.IsDBNull(reader.GetOrdinal(VENDOR_CON_END_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CON_END_FIELD));
                            bool status = reader.IsDBNull(reader.GetOrdinal(VENDOR_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(VENDOR_STATUS_FIELD));
                            string desc = reader.IsDBNull(reader.GetOrdinal(VENDOR_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DESC_FIELD));

                            result = new Vendor()
                            {
                                VendorID = id,
                                VendorName = name,
                                VendorContact = contact,
                                VendorHNo = houseNo,
                                VendorSNo = streetNo,
                                VendorCommune = commune,
                                VendorDistrict = district,
                                VendorProvince = province,
                                VendorConStart = conStart,
                                VendorConEnd = conEnd,
                                VendorStatus = status,
                                VendorDesc = desc
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting vendor with id, {id} > {ex.Message}");
                }
            }

            return result;
        }

        // Create a new vendor
        public static string? AddVendor(SqlConnection conn, Vendor vendor)
        {
            using (SqlCommand cmd = new SqlCommand("AddVendor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Remove the VendorID parameter since it's auto-generated
                cmd.Parameters.AddWithValue("@VendorName", vendor.VendorName as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorContact", vendor.VendorContact as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorHNo", vendor.VendorHNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorSNo", vendor.VendorSNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorCommune", vendor.VendorCommune as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorDistrict", vendor.VendorDistrict as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorProvince", vendor.VendorProvince as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorConStart", vendor.VendorConStart as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorConEnd", vendor.VendorConEnd as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorStatus", vendor.VendorStatus as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VendorDesc", vendor.VendorDesc as object ?? DBNull.Value);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (vendor.VendorID >= 0 && vendor.VendorID <= 255)
                    {
                        Added?.Invoke(null, new EntityEventArgs() { ByteId = (byte)vendor.VendorID, Entity = EntityTypes.Vendors });
                    }
                    else
                    {
                        throw new Exception($"VendorID {vendor.VendorID} is out of range for ByteId.");
                    }

                    return (effected > 0) ? vendor.VendorID.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in adding new vendor > {ex.Message}");
                }
            }
        }

        // Update an existing vendor
        public static bool UpdateVendor(SqlConnection conn, Vendor vendor)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateVendor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorID", vendor.VendorID); // This should be set from the selected vendor
                cmd.Parameters.AddWithValue("@VendorName", string.IsNullOrEmpty(vendor.VendorName) ? DBNull.Value : vendor.VendorName);
                cmd.Parameters.AddWithValue("@VendorContact", string.IsNullOrEmpty(vendor.VendorContact) ? DBNull.Value : vendor.VendorContact);
                cmd.Parameters.AddWithValue("@VendorHNo", string.IsNullOrEmpty(vendor.VendorHNo) ? DBNull.Value : vendor.VendorHNo);
                cmd.Parameters.AddWithValue("@VendorSNo", string.IsNullOrEmpty(vendor.VendorSNo) ? DBNull.Value : vendor.VendorSNo);
                cmd.Parameters.AddWithValue("@VendorCommune", string.IsNullOrEmpty(vendor.VendorCommune) ? DBNull.Value : vendor.VendorCommune);
                cmd.Parameters.AddWithValue("@VendorDistrict", string.IsNullOrEmpty(vendor.VendorDistrict) ? DBNull.Value : vendor.VendorDistrict);
                cmd.Parameters.AddWithValue("@VendorProvince", string.IsNullOrEmpty(vendor.VendorProvince) ? DBNull.Value : vendor.VendorProvince);
                cmd.Parameters.AddWithValue("@VendorConStart", vendor.VendorConStart);
                cmd.Parameters.AddWithValue("@VendorConEnd", vendor.VendorConEnd);
                cmd.Parameters.AddWithValue("@VendorStatus", vendor.VendorStatus);
                cmd.Parameters.AddWithValue("@VendorDesc", string.IsNullOrEmpty(vendor.VendorDesc) ? DBNull.Value : vendor.VendorDesc);

                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (vendor.VendorID >= 0 && vendor.VendorID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)vendor.VendorID, Entity = EntityTypes.Vendors });
                        }
                        else
                        {
                            throw new Exception($"VendorID {vendor.VendorID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }

                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in updating vendor > {ex.Message}");
                }
            }
        }

        // Delete an existing vendor
        public static bool DeleteVendor(SqlConnection conn, int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteVendor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorID", id);
                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        // Ensure id can be safely cast to byte
                        if (id >= 0 && id <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)id, Entity = EntityTypes.Vendors });
                        }
                        else
                        {
                            // Handle the case where id is out of range
                            throw new Exception($"VendorID {id} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting a vendor with id {id} > {ex.Message}");
                }
            }
        }

        // Validate Vendor ID
        public static bool ValidateVendorID(SqlConnection conn, int vendorID)
        {
            using (SqlCommand cmd = new SqlCommand("ValidateVendorID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorID", vendorID);
                try
                {
                    int count = (int)cmd.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in validating vendor id > {ex.Message}");
                }
            }
        }
        #endregion

        #region crud(staff)
        private const string STAFF_TBL_NAME = "tblStaff";
        private const string STAFF_ID_FIELD = "StaffId";
        private const string STAFF_FNAME_FIELD = "StaffFName";
        private const string STAFF_LNAME_FIELD = "StaffLName";
        private const string STAFF_SEX_FIELD = "StaffSex";
        private const string STAFF_BOD_FIELD = "StaffBOD";
        private const string STAFF_POSITION_FIELD = "StaffPosition";
        private const string STAFF_HNO_FIELD = "StaffHNo";
        private const string STAFF_SNO_FIELD = "StaffSNo";
        private const string STAFF_COMMUNE_FIELD = "StaffCommune";
        private const string STAFF_DISTRICT_FIELD = "StaffDistrict";
        private const string STAFF_PROVINCE_FIELD = "StaffProvince";
        private const string STAFF_PER_NUM_FIELD = "StaffPerNum";
        private const string STAFF_SALARY_FIELD = "StaffSalary";
        private const string STAFF_HIRED_DATE_FIELD = "StaffHiredDate";
        private const string STAFF_STOPPED_FIELD = "StaffStopped";

        // Read all staff members
        public static IEnumerable<Staff> GetAllStaff(SqlConnection conn)
        {
            List<Staff> staffList = new List<Staff>();

            using (SqlCommand cmd = new SqlCommand("GetAllStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal(STAFF_ID_FIELD));
                            string fName = reader.IsDBNull(reader.GetOrdinal(STAFF_FNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_FNAME_FIELD));
                            string lName = reader.IsDBNull(reader.GetOrdinal(STAFF_LNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_LNAME_FIELD));
                            string sex = reader.IsDBNull(reader.GetOrdinal(STAFF_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SEX_FIELD));
                            DateTime bod = reader.IsDBNull(reader.GetOrdinal(STAFF_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_BOD_FIELD));
                            string position = reader.IsDBNull(reader.GetOrdinal(STAFF_POSITION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_POSITION_FIELD));
                            string hNo = reader.IsDBNull(reader.GetOrdinal(STAFF_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_HNO_FIELD));
                            string sNo = reader.IsDBNull(reader.GetOrdinal(STAFF_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SNO_FIELD));
                            string commune = reader.IsDBNull(reader.GetOrdinal(STAFF_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_COMMUNE_FIELD));
                            string district = reader.IsDBNull(reader.GetOrdinal(STAFF_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_DISTRICT_FIELD));
                            string province = reader.IsDBNull(reader.GetOrdinal(STAFF_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PROVINCE_FIELD));
                            string perNum = reader.IsDBNull(reader.GetOrdinal(STAFF_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PER_NUM_FIELD));
                            double salary = reader.IsDBNull(reader.GetOrdinal(STAFF_SALARY_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(STAFF_SALARY_FIELD));
                            DateTime hiredDate = reader.IsDBNull(reader.GetOrdinal(STAFF_HIRED_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_HIRED_DATE_FIELD));
                            bool stopped = reader.GetBoolean(reader.GetOrdinal(STAFF_STOPPED_FIELD));

                            staffList.Add(new Staff()
                            {
                                StaffId = id,
                                StaffFName = fName,
                                StaffLName = lName,
                                StaffSex = sex,
                                StaffBOD = bod,
                                StaffPosition = position,
                                StaffHNo = hNo,
                                StaffSNo = sNo,
                                StaffCommune = commune,
                                StaffDistrict = district,
                                StaffProvince = province,
                                StaffPerNum = perNum,
                                StaffSalary = salary,
                                StaffHiredDate = hiredDate,
                                StaffStopped = stopped
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all staff > {ex.Message}");
                }
            }

            return staffList;
        }

        // Read a specified staff member by ID
        public static Staff? GetStaffById(SqlConnection conn, int id)
        {
            Staff? result = null;

            using (SqlCommand cmd = new SqlCommand("GetStaffById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", id);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fName = reader.IsDBNull(reader.GetOrdinal(STAFF_FNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_FNAME_FIELD));
                            string lName = reader.IsDBNull(reader.GetOrdinal(STAFF_LNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_LNAME_FIELD));
                            string sex = reader.IsDBNull(reader.GetOrdinal(STAFF_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SEX_FIELD));
                            DateTime bod = reader.IsDBNull(reader.GetOrdinal(STAFF_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_BOD_FIELD));
                            string position = reader.IsDBNull(reader.GetOrdinal(STAFF_POSITION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_POSITION_FIELD));
                            string hNo = reader.IsDBNull(reader.GetOrdinal(STAFF_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_HNO_FIELD));
                            string sNo = reader.IsDBNull(reader.GetOrdinal(STAFF_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SNO_FIELD));
                            string commune = reader.IsDBNull(reader.GetOrdinal(STAFF_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_COMMUNE_FIELD));
                            string district = reader.IsDBNull(reader.GetOrdinal(STAFF_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_DISTRICT_FIELD));
                            string province = reader.IsDBNull(reader.GetOrdinal(STAFF_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PROVINCE_FIELD));
                            string perNum = reader.IsDBNull(reader.GetOrdinal(STAFF_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PER_NUM_FIELD));
                            double salary = reader.IsDBNull(reader.GetOrdinal(STAFF_SALARY_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(STAFF_SALARY_FIELD));
                            DateTime hiredDate = reader.IsDBNull(reader.GetOrdinal(STAFF_HIRED_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_HIRED_DATE_FIELD));
                            bool stopped = reader.GetBoolean(reader.GetOrdinal(STAFF_STOPPED_FIELD));

                            result = new Staff()
                            {
                                StaffId = id,
                                StaffFName = fName,
                                StaffLName = lName,
                                StaffSex = sex,
                                StaffBOD = bod,
                                StaffPosition = position,
                                StaffHNo = hNo,
                                StaffSNo = sNo,
                                StaffCommune = commune,
                                StaffDistrict = district,
                                StaffProvince = province,
                                StaffPerNum = perNum,
                                StaffSalary = salary,
                                StaffHiredDate = hiredDate,
                                StaffStopped = stopped
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting staff with id, {id} > {ex.Message}");
                }
            }

            return result;
        }

        // Create a new staff member
        public static string? AddStaff(SqlConnection conn, Staff staff)
        {
            using (SqlCommand cmd = new SqlCommand("AddStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffFName", staff.StaffFName as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffLName", staff.StaffLName as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffSex", staff.StaffSex as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffBOD", staff.StaffBOD as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffPosition", staff.StaffPosition as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffHNo", staff.StaffHNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffSNo", staff.StaffSNo as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffCommune", staff.StaffCommune as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffDistrict", staff.StaffDistrict as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffProvince", staff.StaffProvince as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffPerNum", staff.StaffPerNum as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffSalary", staff.StaffSalary as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffHiredDate", staff.StaffHiredDate as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StaffStopped", staff.StaffStopped);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (staff.StaffId >= 0 && staff.StaffId <= 255)
                    {
                        Added?.Invoke(null, new EntityEventArgs() { ByteId = (byte)staff.StaffId, Entity = EntityTypes.Staffs });
                    }
                    else
                    {
                        throw new Exception($"StaffID {staff.StaffId} is out of range for ByteId.");
                    }

                    return (effected > 0) ? staff.StaffId.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in adding new staff > {ex.Message}");
                }
            }
        }

        // Update an existing staff member
        public static bool UpdateStaff(SqlConnection conn, Staff staff)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staff.StaffId);
                cmd.Parameters.AddWithValue("@StaffFName", string.IsNullOrEmpty(staff.StaffFName) ? DBNull.Value : staff.StaffFName);
                cmd.Parameters.AddWithValue("@StaffLName", string.IsNullOrEmpty(staff.StaffLName) ? DBNull.Value : staff.StaffLName);
                cmd.Parameters.AddWithValue("@StaffSex", staff.StaffSex);
                cmd.Parameters.AddWithValue("@StaffBOD", staff.StaffBOD);
                cmd.Parameters.AddWithValue("@StaffPosition", string.IsNullOrEmpty(staff.StaffPosition) ? DBNull.Value : staff.StaffPosition);
                cmd.Parameters.AddWithValue("@StaffHNo", string.IsNullOrEmpty(staff.StaffHNo) ? DBNull.Value : staff.StaffHNo);
                cmd.Parameters.AddWithValue("@StaffSNo", string.IsNullOrEmpty(staff.StaffSNo) ? DBNull.Value : staff.StaffSNo);
                cmd.Parameters.AddWithValue("@StaffCommune", string.IsNullOrEmpty(staff.StaffCommune) ? DBNull.Value : staff.StaffCommune);
                cmd.Parameters.AddWithValue("@StaffDistrict", string.IsNullOrEmpty(staff.StaffDistrict) ? DBNull.Value : staff.StaffDistrict);
                cmd.Parameters.AddWithValue("@StaffProvince", string.IsNullOrEmpty(staff.StaffProvince) ? DBNull.Value : staff.StaffProvince);
                cmd.Parameters.AddWithValue("@StaffPerNum", string.IsNullOrEmpty(staff.StaffPerNum) ? DBNull.Value : staff.StaffPerNum);
                cmd.Parameters.AddWithValue("@StaffSalary", staff.StaffSalary == 0 ? DBNull.Value : staff.StaffSalary);
                cmd.Parameters.AddWithValue("@StaffHiredDate", staff.StaffHiredDate);
                cmd.Parameters.AddWithValue("@StaffStopped", staff.StaffStopped);

                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (staff.StaffId >= 0 && staff.StaffId <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)staff.StaffId, Entity = EntityTypes.Staffs });
                        }
                        else
                        {
                            throw new Exception($"StaffID {staff.StaffId} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }

                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in updating staff > {ex.Message}");
                }
            }
        }

        // Delete an existing staff member
        public static bool DeleteStaff(SqlConnection conn, int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteStaff", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", id);
                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (id >= 0 && id <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)id, Entity = EntityTypes.Staffs });
                        }
                        else
                        {
                            throw new Exception($"StaffID {id} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting a staff member with id {id} > {ex.Message}");
                }
            }
        }

        // Validate Staff ID
        public static bool ValidateStaffID(SqlConnection conn, int staffID)
        {
            using (SqlCommand cmd = new SqlCommand("ValidateStaffID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                try
                {
                    int count = (int)cmd.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in validating staff id > {ex.Message}");
                }
            }
        }
        #endregion

        #region crud(amenities)
        private const string AMENITY_TBL_NAME = "tblAmenity";
        private const string AMENITY_ID_FIELD = "AmenityId";
        private const string AMENITY_NAME_FIELD = "AmenityName";
        private const string AMENITY_AVAIL_FIELD = "AmenityAvail";
        private const string AMENITY_LOCATION_FIELD = "AmenityLocation";
        private const string AMENITY_BOU_PRI_FIELD = "AmenityBouPri";
        private const string AMENITY_CPR_FIELD = "AmenityCPR";
        private const string AMENITY_MAIN_DATE_FIELD = "AmenityMainDate";
        private const string AMENITY_DESC_FIELD = "AmenityDesc";

        // Read all amenities
        public static IEnumerable<Amenity> GetAllAmenities(SqlConnection conn)
        {
            List<Amenity> amenities = new List<Amenity>();

            using (SqlCommand cmd = new SqlCommand("GetAllAmenities", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal(AMENITY_ID_FIELD));
                            string name = reader.IsDBNull(reader.GetOrdinal(AMENITY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_NAME_FIELD));
                            bool avail = reader.IsDBNull(reader.GetOrdinal(AMENITY_AVAIL_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(AMENITY_AVAIL_FIELD));
                            string location = reader.IsDBNull(reader.GetOrdinal(AMENITY_LOCATION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_LOCATION_FIELD));
                            double bouPri = reader.IsDBNull(reader.GetOrdinal(AMENITY_BOU_PRI_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_BOU_PRI_FIELD));
                            double cpr = reader.IsDBNull(reader.GetOrdinal(AMENITY_CPR_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_CPR_FIELD));
                            DateTime mainDate = reader.IsDBNull(reader.GetOrdinal(AMENITY_MAIN_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(AMENITY_MAIN_DATE_FIELD));
                            string desc = reader.IsDBNull(reader.GetOrdinal(AMENITY_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_DESC_FIELD));

                            amenities.Add(new Amenity()
                            {
                                AmenityId = id,
                                AmenityName = name,
                                AmenityAvail = avail,
                                AmenityLocation = location,
                                AmenityBouPri = bouPri,
                                AmenityCPR = cpr,
                                AmenityMainDate = mainDate,
                                AmenityDesc = desc
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all amenities > {ex.Message}");
                }
            }

            return amenities;
        }

        // Read a specified amenity by ID
        public static Amenity? GetAmenityById(SqlConnection conn, int id)
        {
            Amenity? result = null;

            using (SqlCommand cmd = new SqlCommand("GetAmenityById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmenityId", id);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.IsDBNull(reader.GetOrdinal(AMENITY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_NAME_FIELD));
                            bool avail = reader.IsDBNull(reader.GetOrdinal(AMENITY_AVAIL_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(AMENITY_AVAIL_FIELD));
                            string location = reader.IsDBNull(reader.GetOrdinal(AMENITY_LOCATION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_LOCATION_FIELD));
                            double bouPri = reader.IsDBNull(reader.GetOrdinal(AMENITY_BOU_PRI_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_BOU_PRI_FIELD));
                            double cpr = reader.IsDBNull(reader.GetOrdinal(AMENITY_CPR_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_CPR_FIELD));
                            DateTime mainDate = reader.IsDBNull(reader.GetOrdinal(AMENITY_MAIN_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(AMENITY_MAIN_DATE_FIELD));
                            string desc = reader.IsDBNull(reader.GetOrdinal(AMENITY_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_DESC_FIELD));

                            result = new Amenity()
                            {
                                AmenityId = id,
                                AmenityName = name,
                                AmenityAvail = avail,
                                AmenityLocation = location,
                                AmenityBouPri = bouPri,
                                AmenityCPR = cpr,
                                AmenityMainDate = mainDate,
                                AmenityDesc = desc
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting amenity with id, {id} > {ex.Message}");
                }
            }

            return result;
        }

        // Create a new amenity
        public static string? AddAmenity(SqlConnection conn, Amenity amenity)
        {
            using (SqlCommand cmd = new SqlCommand("AddAmenity", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmenityName", amenity.AmenityName as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AmenityAvail", amenity.AmenityAvail);
                cmd.Parameters.AddWithValue("@AmenityLocation", amenity.AmenityLocation as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AmenityBouPri", amenity.AmenityBouPri);
                cmd.Parameters.AddWithValue("@AmenityCPR", amenity.AmenityCPR);
                cmd.Parameters.AddWithValue("@AmenityMainDate", amenity.AmenityMainDate as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AmenityDesc", amenity.AmenityDesc as object ?? DBNull.Value);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (amenity.AmenityId >= 0 && amenity.AmenityId <= 255)
                    {
                        Added?.Invoke(null, new EntityEventArgs() { ByteId = (byte)amenity.AmenityId, Entity = EntityTypes.Amenities });
                    }
                    else
                    {
                        throw new Exception($"AmenityId {amenity.AmenityId} is out of range for ByteId.");
                    }

                    return (effected > 0) ? amenity.AmenityId.ToString() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in adding new amenity > {ex.Message}");
                }
            }
        }

        // Update an existing amenity
        public static bool UpdateAmenity(SqlConnection conn, Amenity amenity)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateAmenity", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmenityId", amenity.AmenityId);
                cmd.Parameters.AddWithValue("@AmenityName", string.IsNullOrEmpty(amenity.AmenityName) ? DBNull.Value : amenity.AmenityName);
                cmd.Parameters.AddWithValue("@AmenityAvail", amenity.AmenityAvail);
                cmd.Parameters.AddWithValue("@AmenityLocation", string.IsNullOrEmpty(amenity.AmenityLocation) ? DBNull.Value : amenity.AmenityLocation);
                cmd.Parameters.AddWithValue("@AmenityBouPri", amenity.AmenityBouPri);
                cmd.Parameters.AddWithValue("@AmenityCPR", amenity.AmenityCPR);
                cmd.Parameters.AddWithValue("@AmenityMainDate", amenity.AmenityMainDate);
                cmd.Parameters.AddWithValue("@AmenityDesc", string.IsNullOrEmpty(amenity.AmenityDesc) ? DBNull.Value : amenity.AmenityDesc);

                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (amenity.AmenityId >= 0 && amenity.AmenityId <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)amenity.AmenityId, Entity = EntityTypes.Amenities });
                        }
                        else
                        {
                            throw new Exception($"AmenityId {amenity.AmenityId} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }

                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in updating amenity > {ex.Message}");
                }
            }
        }

        // Delete an existing amenity
        public static bool DeleteAmenity(SqlConnection conn, int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteAmenity", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmenityId", id);
                try
                {
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        if (id >= 0 && id <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)id, Entity = EntityTypes.Amenities });
                        }
                        else
                        {
                            throw new Exception($"AmenityId {id} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting an amenity with id {id} > {ex.Message}");
                }
            }
        }

        // Validate Amenity ID
        public static bool ValidateAmenityID(SqlConnection conn, int amenityID)
        {
            using (SqlCommand cmd = new SqlCommand("ValidateAmenityID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmenityId", amenityID);
                try
                {
                    int count = (int)cmd.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in validating amenity id > {ex.Message}");
                }
            }
        }
        #endregion

        #region crud(users)
        private const string USER_TBL_NAME = "tblUser";
        private const string USER_ID_FIELD = "UserID";
        private const string USER_NAME_FIELD = "UserName";
        private const string USER_PASS_FIELD = "UserPass";
        private const string USER_STAFF_ID_FIELD = "StaffID";

        // Foreign Key Constraint Name (if needed)
        private const string FK_USER_STAFF = "FKStaffID";
        #endregion

        #region crud(feedback)
        private const string FEEDBACK_TBL_NAME = "tblFeedback";
        private const string FEEDBACK_ID_FIELD = "FeedbackID";
        private const string FEEDBACK_DATE_FIELD = "FeedbackDate";
        private const string FEEDBACK_COMMENTS_FIELD = "Comments";
        private const string FEEDBACK_RATING_FIELD = "Rating";
        private const string FEEDBACK_RESIDENT_ID_FIELD = "ResidentID";

        // Read all feedback records
        public static IEnumerable<Feedback> GetAllFeedback(SqlConnection conn)
        {
            List<Feedback> feedbacks = new List<Feedback>();

            using (SqlCommand cmd = new SqlCommand("GetAllFeedback", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal(FEEDBACK_ID_FIELD));
                            DateTime date = reader.GetDateTime(reader.GetOrdinal(FEEDBACK_DATE_FIELD));
                            string comments = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_COMMENTS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_COMMENTS_FIELD));
                            int rating = reader.GetInt32(reader.GetOrdinal(FEEDBACK_RATING_FIELD));
                            int residentId = reader.GetInt32(reader.GetOrdinal(FEEDBACK_RESIDENT_ID_FIELD));

                            feedbacks.Add(new Feedback()
                            {
                                FeedbackID = id,
                                FeedbackDate = date,
                                Comments = comments,
                                Rating = rating,
                                ResidentID = residentId
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all feedback > {ex.Message}");
                }
            }

            return feedbacks;
        }

        // Read a specified feedback by ID
        public static Feedback? GetFeedbackById(SqlConnection conn, int id)
        {
            Feedback? result = null;

            using (SqlCommand cmd = new SqlCommand("GetFeedbackById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedbackID", id);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal(FEEDBACK_DATE_FIELD));
                            string comments = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_COMMENTS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_COMMENTS_FIELD));
                            int rating = reader.GetInt32(reader.GetOrdinal(FEEDBACK_RATING_FIELD));
                            int residentId = reader.GetInt32(reader.GetOrdinal(FEEDBACK_RESIDENT_ID_FIELD));

                            result = new Feedback()
                            {
                                FeedbackID = id,
                                FeedbackDate = date,
                                Comments = comments,
                                Rating = rating,
                                ResidentID = residentId
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting feedback with id, {id} > {ex.Message}");
                }
            }

            return result;
        }

        // Create a new feedback
        public static int AddFeedback(SqlConnection conn, Feedback feedback)
        {
            using (SqlCommand cmd = new SqlCommand("AddFeedback", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Comments", feedback.Comments as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                cmd.Parameters.AddWithValue("@ResidentID", feedback.ResidentID);

                try
                {
                    conn.Open();
                    int newFeedbackId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newFeedbackId;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in adding new feedback > {ex.Message}");
                }
            }
        }

        // Update an existing feedback
        public static bool UpdateFeedback(SqlConnection conn, Feedback feedback)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateFeedback", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedbackID", feedback.FeedbackID);
                cmd.Parameters.AddWithValue("@Comments", feedback.Comments as object ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                cmd.Parameters.AddWithValue("@ResidentID", feedback.ResidentID);

                try
                {
                    conn.Open();
                    int effected = cmd.ExecuteNonQuery();
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in updating feedback > {ex.Message}");
                }
            }
        }

        // Delete an existing feedback
        public static bool DeleteFeedback(SqlConnection conn, int id)
        {
            using (SqlCommand cmd = new SqlCommand("DeleteFeedback", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedbackID", id);
                try
                {
                    conn.Open();
                    int effected = cmd.ExecuteNonQuery();
                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting feedback with id {id} > {ex.Message}");
                }
            }
        }

        // Validate Feedback ID
        public static bool ValidateFeedbackID(SqlConnection conn, int feedbackID)
        {
            using (SqlCommand cmd = new SqlCommand("ValidateFeedbackID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);
                try
                {
                    int count = (int)cmd.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in validating feedback id > {ex.Message}");
                }
            }
        }
        #endregion

        public static IEnumerable<T> GetAllEntities<T>(SqlConnection conn, string storedProcedureName) where T : IEntity, new()
        {
            List<T> entities = new List<T>();

            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T entity = new T();

                            // Populate specific fields based on the type
                            if (entity is Resident resident)
                            {
                                resident.ResID = reader.GetInt32(reader.GetOrdinal(RESIDENT_ID_FIELD));
                                resident.ResType = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                                resident.ResFirstName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_NAME_FIELD));
                                resident.ResSex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                                resident.ResBD = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                                resident.ResPrevHouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                                resident.ResPrevStNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                                resident.ResPrevCommune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                                resident.ResPrevDistrict = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                                resident.ResPrevProvince = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD));
                                resident.ResPerNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                                resident.ResConNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                                resident.ResCheckIn = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                                resident.ResCheckOut = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));

                            }
                            else if (entity is Vendor vendor)
                            {
                                vendor.VendorID = reader 
                            }

                            entities.Add(entity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting all entities > {ex.Message}", ex);
                }
            }

            return entities;
        }

        public static T? GetEntityById<T>(SqlConnection conn, int id, string storedProcedureName) where T : IEntity, new()
        {
            T? result = default;

            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResID", id); // Adjust this parameter name if needed

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new T();

                            // Populate specific fields based on the type
                            if (result is Resident resident)
                            {
                                resident.ResID = id;
                                resident.ResType = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                                resident.ResFirstName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_NAME_FIELD));
                                resident.ResSex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                                resident.ResBD = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                                resident.ResPrevHouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                                resident.ResPrevStNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                                resident.ResPrevCommune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                                resident.ResPrevDistrict = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                                resident.ResPrevProvince = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD));
                                resident.ResPerNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                                resident.ResConNum = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                                resident.ResCheckIn = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                                resident.ResCheckOut = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));
                            }
                            else if (result is Vendor vendor)
                            {
                                // Populate Vendor-specific fields here
                                // vendor.SomeVendorProperty = reader.IsDBNull(reader.GetOrdinal("SomeVendorField")) ? string.Empty : reader.GetString(reader.GetOrdinal("SomeVendorField"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in getting entity with id, {id} > {ex.Message}", ex);
                }
            }

            return result;
        }

        public static string? InsertEntity<T>(SqlConnection conn, T entity) where T : IEntity
        {
            string storedProcedureName = entity.GetSPName();

            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Use the entity to add parameters
                entity.AddParameters(cmd);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    // Handle specific logic for Resident
                    if (entity is Resident resident)
                    {
                        if (resident.ResID >= 0 && resident.ResID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs() { ByteId = (byte)resident.ResID, Entity = EntityTypes.Residents });
                        }
                        else
                        {
                            throw new Exception($"ResidentID {resident.ResID} is out of range for ByteId.");
                        }
                    }
                    // Handle specific logic for Vendor (if needed)
                    else if (entity is Vendor vendor)
                    {
                        // Similar logic for Vendor can be added here if required
                    }

                    return (effected > 0) ? (entity as dynamic).ResID.ToString() : null; // Cast to dynamic to access ResID
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in inserting entity > {ex.Message}");
                }
            }
        }
    }
}
// fsdafs

// abcdef