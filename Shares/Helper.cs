using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
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
        private const string RESIDENT_ID_FIELD = "ResidentID";
        private const string RESIDENT_TYPE_FIELD = "Type";
        private const string RESIDENT_FIRSTNAME_FIELD = "FirstName";
        private const string RESIDENT_LASTNAME_FIELD = "LastName";
        private const string RESIDENT_SEX_FIELD = "Sex";
        private const string RESIDENT_BOD_FIELD = "BD";
        private const string RESIDENT_PREV_HOUSE_NO_FIELD = "PrevHouseNo";
        private const string RESIDENT_PREV_ST_NO_FIELD = "PrevStNo";
        private const string RESIDENT_PREV_COMMUNE_FIELD = "PrevCommune";
        private const string RESIDENT_PREV_DISTRICT_FIELD = "PrevDistrict";
        private const string RESIDENT_PREV_PROVINCE_FIELD = "PrevProvince";
        private const string RESIDENT_PER_NUM_FIELD = "PerNum";
        private const string RESIDENT_CON_NUM_FIELD = "ConNum";
        private const string RESIDENT_CHECK_IN_FIELD = "CheckIn";
        private const string RESIDENT_CHECK_OUT_FIELD = "CheckOut";

        // Table Vendor
        private const string VENDOR_TBL_NAME = "tblVendor";
        private const string VENDOR_ID_FIELD = "VendorID";
        private const string VENDOR_NAME_FIELD = "Name";
        private const string VENDER_CONTACT_FIELD = "Contact";
        private const string VENDOR_HNO_FIELD = "HouseNo";
        private const string VENDOR_SNO_FIELD = "StreetNo";
        private const string VENDOR_COMMUNE_FIELD = "Commune";
        private const string VENDOR_DISTRICT_FIELD = "District";
        private const string VENDOR_PROVINCE_FIELD = "Province";
        private const string VENDOR_CONSTART_FIELD = "ContractStart";
        private const string VENDOR_CONEND_FIELD = "ContractEnd";
        private const string VENDOR_STATUS_FIELD = "Status";
        private const string VENDOR_DESC_FIELD = "Description";

        // Table STAFF
        private const string STAFF_TBL_NAME = "tblStaff";
        private const string STAFF_ID_FIELD = "StaffID";
        private const string STAFF_FNAME_FIELD = "FirstName";
        private const string STAFF_LNAME_FIELD = "LastName";
        private const string STAFF_SEX_FIELD = "Sex";
        private const string STAFF_BD_FIELD = "BirthDate";
        private const string STAFF_POSITION_FIELD = "Position";
        private const string STAFF_HNO_FIELD = "HouseNo";
        private const string STAFF_SNO_FIELD = "StreetNo";
        private const string STAFF_COMMUNE_FIELD = "Commune";
        private const string STAFF_DISTRICT_FIELD = "District";
        private const string STAFF_PROVINCE_FIELD = "Province";
        private const string STAFF_PERNUM_FIELD = "PersonalNumber";
        private const string STAFF_SALARY_FIELD = "Salary";
        private const string STAFF_HIREDDATE_FIELD = "StartDate";
        private const string STAFF_STOPPED_FIELD = "StoppedDate";

        // Table RoomType
        private const string ROOMTYPE_TBL_NAME = "tblRoomType";
        private const string ROOMTYPE_ID_FIELD = "RoomTypeID";
        private const string ROOMTYPE_NAME_FIELD = "TypeName";
        private const string ROOMTYPE_BASEPRICE_FIELD = "BasePrice";
        private const string ROOMTYPE_DESCRIPTION_FIELD = "Description";
        private const string ROOMTYPE_CAPACITY_FIELD = "Capacity";

        // Table leaseagreement
        private const string leaseagreement_TBL_NAME = "tblLeaseAgreement";
        private const string LEASEAGREEMENT_LESAEAGREEMENTID_FIELD = "LeaseAgreementID";
        private const string LEASEAGREEMENT_STARTDATE_FIELD = "StartDate";
        private const string LEASEAGREEMENT_ENDDATE_FIELD = "EndDate";
        private const string LEASEAGREEMENT_TERMSANDCONDITIONS_FIELD = "TermsAndConditions";
        private const string LEASEAGREEMENT_RESIDENTID_FIELD = "ResidentID"; //FK

        // Table Policy
        private const string POLICY_TBL_NAME = "tblPolicy";
        private const string POLICY_POLICYID_FIELD = "PolicyID";
        private const string POLICY_NAME_FIELD = "Name";
        private const string POLICY_DESRIPTION_FIELD = "PolicyDescription";
        private const string POLICY_CREATEDATE_FIELD = "CreatedDate";
        private const string POLICY_UPDATEDATE_FIELD = "UpdatedDate";
        private const string POLICY_RESIDENTID_FIELD = "ResidentID"; //FK
        private const string POLICY_STAFFID_FIELD = "StaffID";

        // Table Amenity
        private const string AMENITY_TBL_NAME = "tblAmenity";
        private const string AMENITY_ID_FIELD = "AmenityID";
        private const string AMENITY_NAME_FIELD = "Name";
        private const string AMENITY_BOUGHTPRICE_FIELD = "BoughtPrice";
        private const string AMENITY_COSTPERRENT_FIELD = "CostPerRent";
        private const string AMENITY_MAINTENANCEDATE_FIELD = "MaintenanceDate";
        private const string AMENITY_DESCRIPTION_FIELD = "Description";
        private const string AMENITY_ROOMID_FIELD = "RoomID";

        // Table Feedback
        private const string FEEDBACK_TBL_NAME = "tblFeedback";
        private const string FEEDBACK_ID_FIELD = "FeedbackID";
        private const string FEEDBACK_DATE_FIELD = "FeedbackDate";
        private const string FEEDBACK_CONTENT_FIELD = "Content";
        private const string FEEDBACK_COMMENT_FIELD = "Comment";
        private const string FEEDBACK_RESIDENTID_FIELD = "ResidentID"; //FK

        // Table Room
        private const string ROOM_TBL_NAME = "tblRoom";
        private const string ROOM_ID_FIELD = "RoomID";
        private const string ROOM_NUMBER_FIELD = "RoomNumber";
        private const string ROOM_RESIDENTID_FIELD = "ResidentID";
        private const string ROOM_ROOMTYPEID_FIELD = "RoomTypeID";
        private const string ROOM_STATUS_FIELD = "Status";

        // Table User
        private const string USER_TBL_NAME = "tblUser";
        private const string USER_USERID_FIELD = "UserID";
        private const string USER_NAME_FIELD = "Name";
        private const string USER_PASS_FIELD = "Pass";
        private const string USER_STAFFID_FIELD = "StaffID"; //FK

        // Table Utility
        private const string UTILITY_TBL_NAME = "tblUtility";
        private const string UTILITY_UTILITYID_FIELD = "UtilityID";
        private const string UTILITY_TYPE_FIELD = "UtilityType";
        private const string UTILITY_COST_FIELD = "Cost";
        private const string UTILITY_USAGEDATE_FIELD = "UsageDate";
        private const string UTILITY_ROOMID_FIELD = "RoomID"; //FK

        // Table Service
        private const string SERVICE_TBL_NAME = "tblService";
        private const string SERVICE_SERVICEID_FIELD = "ServiceID";
        private const string SERVICE_NAME_FIELD = "ServiceName";
        private const string SERVICE_DESCRIPTION_FIELD = "ServiceDescription";
        private const string SERVICE_COST_FIELD = "ServiceCost";
        private const string SERVICE_VENDORID_FIELD = "VendorID";
        private const string SERVICE_ROOMID_FIELD = "RoomID";

        // Table Reservation

        private const string RESERVATION_RESERVATIONID_FIELD = "ReservationID";
        private const string RESERVATION_DATE_FIELD = "ReservationDate";
        private const string RESERVATION_STARTDATE_FIELD = "StartDate";
        private const string RESERVATION_ENDDATE_FIELD = "EndDate";
        private const string RESERVATION_STATUS_FIELD = "Status";
        private const string RESERVATION_RESIDENTID_FIELD = "ResidentID";
        private const string RESERVATION_ROOMID_FIELD = "RoomID";

        // Table Request

        private const string REQUEST_TBL_NAME = "tblRequest";
        private const string REQUEST_REQUESTID_FIELD = "RequestID";
        private const string REQUEST_DATE_FIELD = "RequestDate";
        private const string REQUEST_DESCRIPTION_FIELD = "RequestDescription";
        private const string REQUEST_STATUS_FIELD = "RequestStatus";
        private const string REQUEST_RESIDENTID_FIELD = "ResidentID";
        private const string REQUEST_SERVICEID_FIELD = "ServiceID";

        // Table Rent

        private const string RENT_TBL_NAME = "tblRent";
        private const string RENT_RENTID_FIELD = "RentID";
        private const string RENT_STARTDATE_FIELD = "StartDate";
        private const string RENT_ENDDATE_FIELD = "EndDate";
        private const string RENT_AMOUNT_FIELD = "Amount";
        private const string RENT_ROOMID_FIELD = "RoomID";

        // Table Payment

        private const string PAYMENT_TBL_NAME = "tblPayment";
        private const string PAYMENT_ID_FIELD = "PaymentID";
        private const string PAYMENT_DATE_FIELD = "PaymentDate";
        private const string PAYMENT_RESERVATIONID_FIELD = "ReservationID";
        private const string PAYMENT_STAFFID_FIELD = "StaffID";
        private const string PAYMENT_UTILITYID_FIELD = "UtilityID";
        private const string PAYMENT_SERVICEID_FIELD = "ServiceID";
        private const string PAYMENT_PAID_AMOUNT_FIELD = "PaidAmount";
        private const string PAYMENT_REMAINING_AMOUNT_FIELD = "RemainingAmount";
        private const string PAYMENT_IS_SECOND_PAYMENT_FIELD = "IsSecondPaymentDone";
        private const string PAYMENT_IS_UTILITY_ONLY_FIELD = "IsUtilityOnly";


        // Table Invoice
        private const string INVOICE_TBL_NAME = "tblInvoice";
        private const string INVOICE_ID_FIELD = "InvoiceID";
        private const string INVOICE_NO_FIELD = "InvoiceNo";
        private const string INVOICE_DATE_FIELD = "InvoiceDate";
        private const string INVOICE_PAYMENTID_FIELD = "PaymentID";
        private const string INVOICE_STATUS_FIELD = "Status";
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
                                resident.ID = reader.GetInt32(reader.GetOrdinal(RESIDENT_ID_FIELD));
                                resident.Type = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                                resident.FirstName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_FIRSTNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_FIRSTNAME_FIELD));
                                resident.LastName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_LASTNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_LASTNAME_FIELD));
                                resident.Sex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                                resident.BirthDate = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                                resident.HouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                                resident.StreetNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                                resident.Commune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                                resident.District = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                                resident.Province = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD));
                                resident.PersonalNumber = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                                resident.ContactNumber = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                                resident.ResCheckIn = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                                resident.ResCheckOut = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));
                            }
                            else if (entity is Vendor vendor)
                            {
                                vendor.ID = reader.GetInt32(reader.GetOrdinal(VENDOR_ID_FIELD));
                                vendor.FirstName = reader.IsDBNull(reader.GetOrdinal(VENDOR_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_NAME_FIELD));
                                vendor.ContactNumber = reader.IsDBNull(reader.GetOrdinal(VENDER_CONTACT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDER_CONTACT_FIELD));
                                vendor.HouseNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_HNO_FIELD));
                                vendor.StreetNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_SNO_FIELD));
                                vendor.Commune = reader.IsDBNull(reader.GetOrdinal(VENDOR_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_COMMUNE_FIELD));
                                vendor.District = reader.IsDBNull(reader.GetOrdinal(VENDOR_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DISTRICT_FIELD));
                                vendor.Province = reader.IsDBNull(reader.GetOrdinal(VENDOR_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_PROVINCE_FIELD));
                                vendor.Start = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONSTART_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CONSTART_FIELD));
                                vendor.End = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONEND_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CONEND_FIELD));
                                vendor.Status = reader.IsDBNull(reader.GetOrdinal(VENDOR_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(VENDOR_STATUS_FIELD));
                                vendor.Description = reader.IsDBNull(reader.GetOrdinal(VENDOR_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DESC_FIELD));
                            }
                            else if (entity is Staff staff)
                            {
                                staff.ID = reader.GetInt32(reader.GetOrdinal(STAFF_ID_FIELD));
                                staff.FirstName = reader.IsDBNull(reader.GetOrdinal(STAFF_FNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_FNAME_FIELD));
                                staff.LastName = reader.IsDBNull(reader.GetOrdinal(STAFF_LNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_LNAME_FIELD));
                                staff.Sex = reader.IsDBNull(reader.GetOrdinal(STAFF_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SEX_FIELD));
                                staff.BirthDate = reader.IsDBNull(reader.GetOrdinal(STAFF_BD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_BD_FIELD));
                                staff.Type = reader.IsDBNull(reader.GetOrdinal(STAFF_POSITION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_POSITION_FIELD));
                                staff.HouseNo = reader.IsDBNull(reader.GetOrdinal(STAFF_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_HNO_FIELD));
                                staff.StreetNo = reader.IsDBNull(reader.GetOrdinal(STAFF_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SNO_FIELD));
                                staff.Commune = reader.IsDBNull(reader.GetOrdinal(STAFF_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_COMMUNE_FIELD));
                                staff.District = reader.IsDBNull(reader.GetOrdinal(STAFF_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_DISTRICT_FIELD));
                                staff.Province = reader.IsDBNull(reader.GetOrdinal(STAFF_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PROVINCE_FIELD));
                                staff.PersonalNumber = reader.IsDBNull(reader.GetOrdinal(STAFF_PERNUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PERNUM_FIELD));
                                staff.Salary = reader.IsDBNull(reader.GetOrdinal(STAFF_SALARY_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(STAFF_SALARY_FIELD));
                                staff.Start = reader.IsDBNull(reader.GetOrdinal(STAFF_HIREDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_HIREDDATE_FIELD));
                                staff.End = reader.IsDBNull(reader.GetOrdinal(STAFF_STOPPED_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_STOPPED_FIELD));
                            }

                            else if(entity is RoomType roomType)
                            {
                                roomType.ID = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOMTYPE_ID_FIELD));
                                roomType.Type = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(ROOMTYPE_NAME_FIELD));
                                roomType.Description = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(ROOMTYPE_DESCRIPTION_FIELD));
                                roomType.CostPrice = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_BASEPRICE_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(ROOMTYPE_BASEPRICE_FIELD));
                                roomType.RoomTypeCapacity = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_CAPACITY_FIELD)) ? 0: reader.GetInt32(reader.GetOrdinal(ROOMTYPE_CAPACITY_FIELD));
                            }
                            else if (entity is LeaseAgreement leaseagreement)
                            {
                                leaseagreement.ID = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_LESAEAGREEMENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(LEASEAGREEMENT_LESAEAGREEMENTID_FIELD));
                                leaseagreement.Start = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_STARTDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(LEASEAGREEMENT_STARTDATE_FIELD));
                                leaseagreement.End = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_ENDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(LEASEAGREEMENT_ENDDATE_FIELD));
                                leaseagreement.Description = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_TERMSANDCONDITIONS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(LEASEAGREEMENT_TERMSANDCONDITIONS_FIELD));
                                leaseagreement.ResID = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(LEASEAGREEMENT_RESIDENTID_FIELD));
                            }
                            else if (entity is Policy policy)
                            {
                                policy.ID = reader.IsDBNull(reader.GetOrdinal(POLICY_POLICYID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(POLICY_POLICYID_FIELD));
                                policy.FirstName = reader.IsDBNull(reader.GetOrdinal(POLICY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(POLICY_NAME_FIELD));
                                policy.Description = reader.IsDBNull(reader.GetOrdinal(POLICY_DESRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(POLICY_DESRIPTION_FIELD));
                                policy.Start = reader.IsDBNull(reader.GetOrdinal(POLICY_CREATEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(POLICY_CREATEDATE_FIELD));
                                policy.End = reader.IsDBNull(reader.GetOrdinal(POLICY_UPDATEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(POLICY_UPDATEDATE_FIELD));
                                policy.ResidentID = reader.IsDBNull(reader.GetOrdinal(POLICY_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(POLICY_RESIDENTID_FIELD));
                                policy.StaffID = reader.IsDBNull(reader.GetOrdinal(POLICY_STAFFID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(POLICY_STAFFID_FIELD));
                            }
                            else if (entity is Room room)
                            {
                                room.ID = reader.IsDBNull(reader.GetOrdinal(ROOM_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_ID_FIELD));
                                room.Description = reader.IsDBNull(reader.GetOrdinal(ROOM_NUMBER_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(ROOM_NUMBER_FIELD));
                                room.ResidentID = reader.IsDBNull(reader.GetOrdinal(ROOM_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_RESIDENTID_FIELD));
                                room.RoomTypeID = reader.IsDBNull(reader.GetOrdinal(ROOM_ROOMTYPEID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_ROOMTYPEID_FIELD));
                                room.Status = reader.IsDBNull(reader.GetOrdinal(ROOM_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(ROOM_STATUS_FIELD));
                            }
                            else if (entity is Amenity amenity)
                            {
                                amenity.ID = reader.IsDBNull(reader.GetOrdinal(AMENITY_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(AMENITY_ID_FIELD));
                                amenity.FirstName = reader.IsDBNull(reader.GetOrdinal(AMENITY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_NAME_FIELD));
                                amenity.CostPrice = reader.IsDBNull(reader.GetOrdinal(AMENITY_BOUGHTPRICE_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_BOUGHTPRICE_FIELD));
                                amenity.RentPrice = reader.IsDBNull(reader.GetOrdinal(AMENITY_COSTPERRENT_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_COSTPERRENT_FIELD));
                                amenity.Start = reader.IsDBNull(reader.GetOrdinal(AMENITY_MAINTENANCEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(AMENITY_MAINTENANCEDATE_FIELD));
                                amenity.Description = reader.IsDBNull(reader.GetOrdinal(AMENITY_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_DESCRIPTION_FIELD));
                                amenity.RoomID = reader.IsDBNull(reader.GetOrdinal(AMENITY_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(AMENITY_ROOMID_FIELD));
                            }
                            else if (entity is Feedback feedback)
                            {
                                feedback.ID = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(FEEDBACK_ID_FIELD));
                                feedback.Start = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(FEEDBACK_DATE_FIELD));
                                feedback.Type = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_CONTENT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_CONTENT_FIELD));
                                feedback.Description = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_COMMENT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_COMMENT_FIELD));
                                feedback.ResidentID = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(FEEDBACK_RESIDENTID_FIELD));
                            }
                            else if (entity is Service service)
                            {
                                service.ID = reader.GetInt32(reader.GetOrdinal(SERVICE_SERVICEID_FIELD));
                                service.FirstName = reader.IsDBNull(reader.GetOrdinal(SERVICE_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(SERVICE_NAME_FIELD));
                                service.Description = reader.IsDBNull(reader.GetOrdinal(SERVICE_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(SERVICE_DESCRIPTION_FIELD));
                                service.CostPrice = reader.IsDBNull(reader.GetOrdinal(SERVICE_COST_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(SERVICE_COST_FIELD));
                                service.VendorID = reader.IsDBNull(reader.GetOrdinal(SERVICE_VENDORID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(SERVICE_VENDORID_FIELD));
                                service.RoomID = reader.IsDBNull(reader.GetOrdinal(SERVICE_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(SERVICE_ROOMID_FIELD));
                            }
                            else if (entity is Utility utility)
                            {
                                utility.ID = reader.IsDBNull(reader.GetOrdinal(UTILITY_UTILITYID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(UTILITY_UTILITYID_FIELD));
                                utility.Type = reader.IsDBNull(reader.GetOrdinal(UTILITY_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(UTILITY_TYPE_FIELD));
                                utility.CostPrice = reader.IsDBNull(reader.GetOrdinal(UTILITY_COST_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(UTILITY_COST_FIELD));
                                utility.Start = reader.IsDBNull(reader.GetOrdinal(UTILITY_USAGEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(UTILITY_USAGEDATE_FIELD));
                                utility.RoomID = reader.IsDBNull(reader.GetOrdinal(UTILITY_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(UTILITY_ROOMID_FIELD));
                            }
                            else if (entity is Reservation reservation)
                            {
                                reservation.ID = reader.GetInt32(reader.GetOrdinal(RESERVATION_RESERVATIONID_FIELD));
                                reservation.ReservationDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_DATE_FIELD)) ?
                                    DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESERVATION_DATE_FIELD));
                                reservation.StartDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_STARTDATE_FIELD)) ?
                                    null : reader.GetDateTime(reader.GetOrdinal(RESERVATION_STARTDATE_FIELD));
                                reservation.EndDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_ENDDATE_FIELD)) ?
                                    null : reader.GetDateTime(reader.GetOrdinal(RESERVATION_ENDDATE_FIELD));
                                reservation._Status = reader.IsDBNull(reader.GetOrdinal(RESERVATION_STATUS_FIELD)) ?
                                    string.Empty : reader.GetString(reader.GetOrdinal(RESERVATION_STATUS_FIELD));
                                reservation.ResidentID = reader.IsDBNull(reader.GetOrdinal(RESERVATION_RESIDENTID_FIELD)) ?
                                    0 : reader.GetInt32(reader.GetOrdinal(RESERVATION_RESIDENTID_FIELD));
                                reservation.RoomID = reader.IsDBNull(reader.GetOrdinal(RESERVATION_ROOMID_FIELD)) ?
                                    0 : reader.GetInt32(reader.GetOrdinal(RESERVATION_ROOMID_FIELD));
                            }
                            else if (entity is Request request)
                            {
                                request.ID = reader.IsDBNull(reader.GetOrdinal(REQUEST_REQUESTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(REQUEST_REQUESTID_FIELD));
                                request.Start = reader.IsDBNull(reader.GetOrdinal(REQUEST_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(REQUEST_DATE_FIELD));
                                request.Description = reader.IsDBNull(reader.GetOrdinal(REQUEST_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(REQUEST_DESCRIPTION_FIELD));
                                request.Type = reader.IsDBNull(reader.GetOrdinal(REQUEST_STATUS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(REQUEST_STATUS_FIELD));
                                request.ResidentID = reader.IsDBNull(reader.GetOrdinal(REQUEST_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(REQUEST_RESIDENTID_FIELD));
                                request.ServiceID = reader.IsDBNull(reader.GetOrdinal(REQUEST_SERVICEID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(REQUEST_SERVICEID_FIELD));
                            }
                            else if (entity is Rent rent)
                            {
                                rent.ID = reader.IsDBNull(reader.GetOrdinal(RENT_RENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(RENT_RENTID_FIELD));
                                rent.Start = reader.IsDBNull(reader.GetOrdinal(RENT_STARTDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RENT_STARTDATE_FIELD));
                                rent.End = reader.IsDBNull(reader.GetOrdinal(RENT_ENDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RENT_ENDDATE_FIELD));
                                rent.RentPrice = reader.IsDBNull(reader.GetOrdinal(RENT_AMOUNT_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(RENT_AMOUNT_FIELD));
                                rent.RoomID = reader.IsDBNull(reader.GetOrdinal(RENT_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(RENT_ROOMID_FIELD));
                            }
                            else if (entity is Payment payment)
                            {
                                payment.ID = reader.GetInt32(reader.GetOrdinal(PAYMENT_ID_FIELD));
                                payment.PaymentDate = reader.GetDateTime(reader.GetOrdinal(PAYMENT_DATE_FIELD));
                                payment.ReservationID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_RESERVATIONID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_RESERVATIONID_FIELD));
                                payment.StaffID = reader.GetInt32(reader.GetOrdinal(PAYMENT_STAFFID_FIELD));
                                payment.UtilityID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_UTILITYID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_UTILITYID_FIELD));
                                payment.ServiceID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_SERVICEID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_SERVICEID_FIELD));
                                payment.PaidAmount = reader.GetDecimal(reader.GetOrdinal(PAYMENT_PAID_AMOUNT_FIELD));
                                payment.RemainingAmount = reader.GetDecimal(reader.GetOrdinal(PAYMENT_REMAINING_AMOUNT_FIELD));
                                payment.IsSecondPaymentDone = reader.GetBoolean(reader.GetOrdinal(PAYMENT_IS_SECOND_PAYMENT_FIELD));
                                payment.IsUtilityOnly = reader.GetBoolean(reader.GetOrdinal(PAYMENT_IS_UTILITY_ONLY_FIELD));
                            }
                            else if (entity is Invoice invoice)
                            {
                                invoice.ID = reader.IsDBNull(reader.GetOrdinal(INVOICE_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(INVOICE_ID_FIELD));
                                invoice.InvoiceNo = reader.IsDBNull(reader.GetOrdinal(INVOICE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(INVOICE_NO_FIELD));
                                invoice.InvoiceDate = reader.IsDBNull(reader.GetOrdinal(INVOICE_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(INVOICE_DATE_FIELD));
                                invoice.PaymentID = reader.IsDBNull(reader.GetOrdinal(INVOICE_PAYMENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(INVOICE_PAYMENTID_FIELD));
                                invoice._Status = reader.IsDBNull(reader.GetOrdinal(INVOICE_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(INVOICE_STATUS_FIELD));
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

                // Set the parameter name based on the type of T
                string parameterName = typeof(T) == typeof(Resident) ? "@ResidentID" :
                          typeof(T) == typeof(Vendor) ? "@VendorID" :
                          typeof(T) == typeof(Staff) ? "@StaffID" :
                          typeof(T) == typeof(Amenity) ? "@AmenityID" :
                          typeof(T) == typeof(Feedback) ? "@FeedbackID" :
                          typeof(T) == typeof(LeaseAgreement) ? "LeaseAgreementID" :
                          typeof(T) == typeof(Policy) ? "PolicyID" :
                          typeof(T) == typeof(Rent) ? "RentID" :
                          typeof(T) == typeof(Request) ? "RequestID" :
                          typeof(T) == typeof(Reservation) ? "ReservationID" :
                          typeof(T) == typeof(Service) ? "ServiceID" :
                          typeof(T) == typeof(Utility) ? "UtilityID" :
                          typeof(T) == typeof(Room) ? "RoomID" :
                          typeof(T) == typeof(Payment) ? "PaymentID" :
                          typeof(T) == typeof(RoomType) ? "RoomTypeID" :
                          typeof(T) == typeof(Invoice) ? "Invoices" :
                          throw new ArgumentException($"Unsupported entity type: {typeof(T).Name}");
                cmd.Parameters.AddWithValue(parameterName, id);

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
                                resident.ID = id;
                                resident.Type = reader.IsDBNull(reader.GetOrdinal(RESIDENT_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_TYPE_FIELD));
                                resident.FirstName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_FIRSTNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_FIRSTNAME_FIELD));
                                resident.LastName = reader.IsDBNull(reader.GetOrdinal(RESIDENT_LASTNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_LASTNAME_FIELD));
                                resident.Sex = reader.IsDBNull(reader.GetOrdinal(RESIDENT_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_SEX_FIELD));
                                resident.BirthDate = reader.IsDBNull(reader.GetOrdinal(RESIDENT_BOD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_BOD_FIELD));
                                resident.HouseNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_HOUSE_NO_FIELD));
                                resident.StreetNo = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_ST_NO_FIELD));
                                resident.Commune = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_COMMUNE_FIELD));
                                resident.District = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_DISTRICT_FIELD));
                                resident.Province = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PREV_PROVINCE_FIELD));
                                resident.PersonalNumber = reader.IsDBNull(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_PER_NUM_FIELD));
                                resident.ContactNumber = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(RESIDENT_CON_NUM_FIELD));
                                resident.Start = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_IN_FIELD));
                                resident.End = reader.IsDBNull(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESIDENT_CHECK_OUT_FIELD));
                            }
                            else if (result is Vendor vendor)
                            {
                                vendor.ID = id;
                                vendor.FirstName = reader.IsDBNull(reader.GetOrdinal(VENDOR_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_NAME_FIELD));
                                vendor.ContactNumber = reader.IsDBNull(reader.GetOrdinal(VENDER_CONTACT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDER_CONTACT_FIELD));
                                vendor.HouseNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_HNO_FIELD));
                                vendor.StreetNo = reader.IsDBNull(reader.GetOrdinal(VENDOR_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_SNO_FIELD));
                                vendor.Commune = reader.IsDBNull(reader.GetOrdinal(VENDOR_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_COMMUNE_FIELD));
                                vendor.District = reader.IsDBNull(reader.GetOrdinal(VENDOR_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DISTRICT_FIELD));
                                vendor.Province = reader.IsDBNull(reader.GetOrdinal(VENDOR_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_PROVINCE_FIELD));
                                vendor.Start = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONSTART_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CONSTART_FIELD));
                                vendor.End = reader.IsDBNull(reader.GetOrdinal(VENDOR_CONEND_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(VENDOR_CONEND_FIELD));
                                vendor.Status = reader.IsDBNull(reader.GetOrdinal(VENDOR_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(VENDOR_STATUS_FIELD));
                                vendor.Description = reader.IsDBNull(reader.GetOrdinal(VENDOR_DESC_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(VENDOR_DESC_FIELD));
                            }
                            else if (result is Staff staff) 
                            {
                                staff.ID = id;
                                staff.FirstName = reader.IsDBNull(reader.GetOrdinal(STAFF_FNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_FNAME_FIELD));
                                staff.LastName = reader.IsDBNull(reader.GetOrdinal(STAFF_LNAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_LNAME_FIELD));
                                staff.Sex = reader.IsDBNull(reader.GetOrdinal(STAFF_SEX_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SEX_FIELD));
                                staff.BirthDate = reader.IsDBNull(reader.GetOrdinal(STAFF_BD_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_BD_FIELD));
                                staff.Type = reader.IsDBNull(reader.GetOrdinal(STAFF_POSITION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_POSITION_FIELD));
                                staff.HouseNo = reader.IsDBNull(reader.GetOrdinal(STAFF_HNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_HNO_FIELD));
                                staff.StreetNo = reader.IsDBNull(reader.GetOrdinal(STAFF_SNO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_SNO_FIELD));
                                staff.Commune = reader.IsDBNull(reader.GetOrdinal(STAFF_COMMUNE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_COMMUNE_FIELD));
                                staff.District = reader.IsDBNull(reader.GetOrdinal(STAFF_DISTRICT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_DISTRICT_FIELD));
                                staff.Province = reader.IsDBNull(reader.GetOrdinal(STAFF_PROVINCE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PROVINCE_FIELD));
                                staff.PersonalNumber = reader.IsDBNull(reader.GetOrdinal(STAFF_PERNUM_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(STAFF_PERNUM_FIELD));
                                staff.Salary = reader.IsDBNull(reader.GetOrdinal(STAFF_SALARY_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(STAFF_SALARY_FIELD));
                                staff.Start = reader.IsDBNull(reader.GetOrdinal(STAFF_HIREDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_HIREDDATE_FIELD));
                                staff.End = reader.IsDBNull(reader.GetOrdinal(STAFF_STOPPED_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(STAFF_STOPPED_FIELD));
                            }
                            else if (result is RoomType roomType)
                            {
                                roomType.ID = id;
                                roomType.Description = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(ROOMTYPE_DESCRIPTION_FIELD));
                                roomType.CostPrice = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_BASEPRICE_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(ROOMTYPE_BASEPRICE_FIELD));
                                roomType.RoomTypeCapacity = reader.IsDBNull(reader.GetOrdinal(ROOMTYPE_CAPACITY_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOMTYPE_CAPACITY_FIELD));
                            }
                            else if (result is LeaseAgreement leaseagreement)
                            {
                                leaseagreement.ID = id;
                                leaseagreement.Start = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_STARTDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(LEASEAGREEMENT_STARTDATE_FIELD));
                                leaseagreement.End = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_ENDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(LEASEAGREEMENT_ENDDATE_FIELD));
                                leaseagreement.Description = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_TERMSANDCONDITIONS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(LEASEAGREEMENT_TERMSANDCONDITIONS_FIELD));
                                leaseagreement.ResID = reader.IsDBNull(reader.GetOrdinal(LEASEAGREEMENT_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(LEASEAGREEMENT_RESIDENTID_FIELD));
                            }
                            else if (result is Policy policy)
                            {
                                policy.ID = id;
                                policy.FirstName = reader.IsDBNull(reader.GetOrdinal(POLICY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(POLICY_NAME_FIELD));
                                policy.Description = reader.IsDBNull(reader.GetOrdinal(POLICY_DESRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(POLICY_DESRIPTION_FIELD));
                                policy.Start = reader.IsDBNull(reader.GetOrdinal(POLICY_CREATEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(POLICY_CREATEDATE_FIELD));
                                policy.End = reader.IsDBNull(reader.GetOrdinal(POLICY_UPDATEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(POLICY_UPDATEDATE_FIELD));
                                policy.ResidentID = reader.IsDBNull(reader.GetOrdinal(POLICY_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(POLICY_RESIDENTID_FIELD));
                                policy.StaffID = reader.IsDBNull(reader.GetOrdinal(POLICY_STAFFID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(POLICY_STAFFID_FIELD));
                            }
                            else if (result is Room room)
                            {
                                room.ID = reader.IsDBNull(reader.GetOrdinal(ROOM_ID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_ID_FIELD));
                                room.Description = reader.IsDBNull(reader.GetOrdinal(ROOM_NUMBER_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(ROOM_NUMBER_FIELD));
                                room.ResidentID = reader.IsDBNull(reader.GetOrdinal(ROOM_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_RESIDENTID_FIELD));
                                room.RoomTypeID = reader.IsDBNull(reader.GetOrdinal(ROOM_ROOMTYPEID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(ROOM_ROOMTYPEID_FIELD));
                                room.Status = reader.IsDBNull(reader.GetOrdinal(ROOM_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(ROOM_STATUS_FIELD));
                            }
                            else if (result is Amenity amenity)
                            {
                                amenity.ID = id;
                                amenity.FirstName = reader.IsDBNull(reader.GetOrdinal(AMENITY_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_NAME_FIELD));
                                amenity.CostPrice = reader.IsDBNull(reader.GetOrdinal(AMENITY_BOUGHTPRICE_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_BOUGHTPRICE_FIELD));
                                amenity.RentPrice = reader.IsDBNull(reader.GetOrdinal(AMENITY_COSTPERRENT_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(AMENITY_COSTPERRENT_FIELD));
                                amenity.Start = reader.IsDBNull(reader.GetOrdinal(AMENITY_MAINTENANCEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(AMENITY_MAINTENANCEDATE_FIELD));
                                amenity.Description = reader.IsDBNull(reader.GetOrdinal(AMENITY_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(AMENITY_DESCRIPTION_FIELD));
                                amenity.RoomID = reader.IsDBNull(reader.GetOrdinal(AMENITY_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(AMENITY_ROOMID_FIELD));
                            }
                            else if (result is Feedback feedback)
                            {
                                feedback.ID = id;
                                feedback.Start = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(FEEDBACK_DATE_FIELD));
                                feedback.Type = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_CONTENT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_CONTENT_FIELD));
                                feedback.Description = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_COMMENT_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(FEEDBACK_COMMENT_FIELD));
                                feedback.ResidentID = reader.IsDBNull(reader.GetOrdinal(FEEDBACK_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(FEEDBACK_RESIDENTID_FIELD));
                            }

                            else if (result is Service service)
                            {
                                service.ID = id;
                                service.FirstName = reader.IsDBNull(reader.GetOrdinal(SERVICE_NAME_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(SERVICE_NAME_FIELD));
                                service.Description = reader.IsDBNull(reader.GetOrdinal(SERVICE_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(SERVICE_DESCRIPTION_FIELD));
                                service.CostPrice = reader.IsDBNull(reader.GetOrdinal(SERVICE_COST_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(SERVICE_COST_FIELD));
                                service.VendorID = reader.IsDBNull(reader.GetOrdinal(SERVICE_VENDORID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(SERVICE_VENDORID_FIELD));
                                service.RoomID = reader.IsDBNull(reader.GetOrdinal(SERVICE_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(SERVICE_ROOMID_FIELD));
                            }
                            else if (result is Utility utility)
                            {
                                utility.ID = id;
                                utility.Type = reader.IsDBNull(reader.GetOrdinal(UTILITY_TYPE_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(UTILITY_TYPE_FIELD));
                                utility.CostPrice = reader.IsDBNull(reader.GetOrdinal(UTILITY_COST_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(UTILITY_COST_FIELD));
                                utility.Start = reader.IsDBNull(reader.GetOrdinal(UTILITY_USAGEDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(UTILITY_USAGEDATE_FIELD));
                                utility.RoomID = reader.IsDBNull(reader.GetOrdinal(UTILITY_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(UTILITY_ROOMID_FIELD));
                            }
                            else if (result is Reservation reservation)
                            {
                                reservation.ID = id;
                                reservation.ReservationDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_DATE_FIELD)) ?
                                    DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RESERVATION_DATE_FIELD));
                                reservation.StartDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_STARTDATE_FIELD)) ?
                                    null : reader.GetDateTime(reader.GetOrdinal(RESERVATION_STARTDATE_FIELD));
                                reservation.EndDate = reader.IsDBNull(reader.GetOrdinal(RESERVATION_ENDDATE_FIELD)) ?
                                    null : reader.GetDateTime(reader.GetOrdinal(RESERVATION_ENDDATE_FIELD));
                                reservation._Status = reader.IsDBNull(reader.GetOrdinal(RESERVATION_STATUS_FIELD)) ?
                                    string.Empty : reader.GetString(reader.GetOrdinal(RESERVATION_STATUS_FIELD));
                                reservation.ResidentID = reader.IsDBNull(reader.GetOrdinal(RESERVATION_RESIDENTID_FIELD)) ?
                                    0 : reader.GetInt32(reader.GetOrdinal(RESERVATION_RESIDENTID_FIELD));
                                reservation.RoomID = reader.IsDBNull(reader.GetOrdinal(RESERVATION_ROOMID_FIELD)) ?
                                    0 : reader.GetInt32(reader.GetOrdinal(RESERVATION_ROOMID_FIELD));
                            }
                            else if (result is Request request)
                            {
                                request.ID = id;
                                request.Start = reader.IsDBNull(reader.GetOrdinal(REQUEST_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(REQUEST_DATE_FIELD));
                                request.Description = reader.IsDBNull(reader.GetOrdinal(REQUEST_DESCRIPTION_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(REQUEST_DESCRIPTION_FIELD));
                                request.Type = reader.IsDBNull(reader.GetOrdinal(REQUEST_STATUS_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(REQUEST_STATUS_FIELD));
                                request.ResidentID = reader.IsDBNull(reader.GetOrdinal(REQUEST_RESIDENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(REQUEST_RESIDENTID_FIELD));
                                request.ServiceID = reader.IsDBNull(reader.GetOrdinal(REQUEST_SERVICEID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(REQUEST_SERVICEID_FIELD));
                            }
                            else if (result is Rent rent)
                            {
                                rent.ID = id;
                                rent.Start = reader.IsDBNull(reader.GetOrdinal(RENT_STARTDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RENT_STARTDATE_FIELD));
                                rent.End = reader.IsDBNull(reader.GetOrdinal(RENT_ENDDATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(RENT_ENDDATE_FIELD));
                                rent.RentPrice = reader.IsDBNull(reader.GetOrdinal(RENT_AMOUNT_FIELD)) ? 0 : reader.GetDouble(reader.GetOrdinal(RENT_AMOUNT_FIELD));
                                rent.RoomID = reader.IsDBNull(reader.GetOrdinal(RENT_ROOMID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(RENT_ROOMID_FIELD));
                            }

                            else if (result is Payment payment)
                            {
                                payment.ID = id;
                                payment.PaymentDate = reader.GetDateTime(reader.GetOrdinal(PAYMENT_DATE_FIELD));
                                payment.ReservationID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_RESERVATIONID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_RESERVATIONID_FIELD));
                                payment.StaffID = reader.GetInt32(reader.GetOrdinal(PAYMENT_STAFFID_FIELD));
                                payment.UtilityID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_UTILITYID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_UTILITYID_FIELD));
                                payment.ServiceID = reader.IsDBNull(reader.GetOrdinal(PAYMENT_SERVICEID_FIELD)) ?
                                    null : reader.GetInt32(reader.GetOrdinal(PAYMENT_SERVICEID_FIELD));
                                payment.PaidAmount = reader.GetDecimal(reader.GetOrdinal(PAYMENT_PAID_AMOUNT_FIELD));
                                payment.RemainingAmount = reader.GetDecimal(reader.GetOrdinal(PAYMENT_REMAINING_AMOUNT_FIELD));
                                payment.IsSecondPaymentDone = reader.GetBoolean(reader.GetOrdinal(PAYMENT_IS_SECOND_PAYMENT_FIELD));
                                payment.IsUtilityOnly = reader.GetBoolean(reader.GetOrdinal(PAYMENT_IS_UTILITY_ONLY_FIELD));
                            }
                            else if (result is Invoice invoice)
                            {
                                invoice.ID = id;
                                invoice.InvoiceID = reader.IsDBNull(reader.GetOrdinal(INVOICE_NO_FIELD)) ? string.Empty : reader.GetString(reader.GetOrdinal(INVOICE_NO_FIELD));
                                invoice.InvoiceDate = reader.IsDBNull(reader.GetOrdinal(INVOICE_DATE_FIELD)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(INVOICE_DATE_FIELD));
                                invoice.PaymentID = reader.IsDBNull(reader.GetOrdinal(INVOICE_PAYMENTID_FIELD)) ? 0 : reader.GetInt32(reader.GetOrdinal(INVOICE_PAYMENTID_FIELD));
                                invoice._Status = reader.IsDBNull(reader.GetOrdinal(INVOICE_STATUS_FIELD)) ? false : reader.GetBoolean(reader.GetOrdinal(INVOICE_STATUS_FIELD));
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

        public static string? InsertEntity<T>(SqlConnection conn, T entity, string storedProcedureName) where T : IEntity
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                entity.AddParameters(cmd);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (effected <= 0)
                        return null;

                    // Handle different entity types
                    string? entityId = null;
                    if (entity is Resident resident)
                    {
                        if (resident.ID >= 0 && resident.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)resident.ID,
                                Entity = EntityTypes.Residents
                            });
                            entityId = resident.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Resident ID {resident.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Vendor vendor)
                    {
                        if (vendor.VenID >= 0 && vendor.VenID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)vendor.VenID,
                                Entity = EntityTypes.Vendors
                            });
                            entityId = vendor.VenID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Vendor ID {vendor.VenID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Staff staff)
                    {
                        if (staff.ID >= 0 && staff.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)staff.ID,
                                Entity = EntityTypes.Staffs
                            });
                            entityId = staff.ID.ToString();
                        }
                    }
                    else if (entity is RoomType roomType)
                    {
                        if(roomType.ID >= 0 &&  roomType.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)roomType.ID,
                                Entity = EntityTypes.RoomTypes
                            });
                        }
                    }
                    else if (entity is LeaseAgreement leaseAgreement)
                    {
                        if (leaseAgreement.ID >= 0 && leaseAgreement.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)leaseAgreement.ID,
                                Entity = EntityTypes.LeaseAgreements
                            });
                            entityId = leaseAgreement.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"LeaseAgreement ID {leaseAgreement.ID} is out of range for ByteId.");
                        }
                    }
                    else if(entity is Room room)
                    {
                        if(room.ID > 0 && room.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)room.ID,
                                Entity = EntityTypes.Rooms
                            });
                            entityId = room.ID.ToString();
                        }
                    }
                    else if(entity is Amenity amenity)
                    {
                        if (amenity.ID >= 0 && amenity.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs() 
                            { 
                                ByteId = (byte)amenity.ID,
                                Entity = EntityTypes.Amenitys
                             });
                            entityId = amenity.ID.ToString();
                        }
                    }
                    else if (entity is Feedback feedback)
                    {
                        if(feedback.ID >= 0 &&  feedback.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)feedback.ID,
                                Entity = EntityTypes.Feedbacks
                            });
                            entityId = feedback.ID.ToString();
                        }
                    }
                    else if (entity is Service service)
                    {
                        if (service.ID >= 0 && service.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)service.ID,
                                Entity = EntityTypes.Services
                            });
                            entityId = service.ID.ToString();
                        }
                    }
                    else if (entity is Utility utility)
                    {
                        if (utility.ID >= 0 && utility.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)utility.ID,
                                Entity = EntityTypes.Utilitys
                            });
                            entityId = utility.ID.ToString();
                        }
                    }
                    else if (entity is Reservation reservation)
                    {
                        if (reservation.ID >= 0 && reservation.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)reservation.ID,
                                Entity = EntityTypes.Reservations
                            });
                            entityId = reservation.ID.ToString();
                        }
                    }
                    else if (entity is Request request)
                    {
                        if (request.ID >= 0 && request.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)request.ID,
                                Entity = EntityTypes.Requests
                            });
                            entityId = request.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Request ID {request.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Rent rent)
                    {
                        if (rent.ID >= 0 && rent.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)rent.ID,
                                Entity = EntityTypes.Rents
                            });
                            entityId = rent.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Rent ID {rent.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Policy policy)
                    {
                        if (policy.ID >= 0 && policy.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs()
                            {
                                ByteId = (byte)policy.ID,
                                Entity = EntityTypes.Policys
                            });
                            entityId = policy.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Policy ID {policy.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Payment payment)
                    {
                        if (payment.ID >= 0 && payment.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)payment.ID,
                                Entity = EntityTypes.Payments
                            });
                            entityId = payment.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Payment ID {payment.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Invoice invoice)
                    {
                        if (invoice.ID >= 0 && invoice.ID <= 255)
                        {
                            Added?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)invoice.ID,
                                Entity = EntityTypes.Invoices
                            });
                            entityId = invoice.ID.ToString();
                        }
                        else
                        {
                            throw new Exception($"Invoice ID {invoice.ID} is out of range for ByteId.");
                        }
                    }


                    // Add other entity type handling here if needed
                    else
                    {
                        // For any other entity types that might be added in the future
                        // You might want to implement a common interface method to get the ID
                        // or handle them specifically like above
                        throw new NotSupportedException($"Entity type {entity.GetType().Name} is not supported.");
                    }

                    return entityId;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in inserting entity > {ex.Message}");
                }
            }
        }

        public static bool UpdateEntity<T>(SqlConnection conn, T entity, string storedProcedureName) where T : IEntity
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Use the entity to add parameters
                entity.AddParametersWithID(cmd);

                try
                {
                    int affectedRows = cmd.ExecuteNonQuery();

                    if (entity is Resident resident)
                    {
                        if (resident.ID >= 0 && resident.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)resident.ID, Entity = EntityTypes.Residents });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(resident.ID), "Resident ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Vendor vendor)
                    {
                        if (vendor.VenID >= 0 && vendor.VenID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)vendor.VenID, Entity = EntityTypes.Vendors });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(vendor.VenID), "Vendor ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Staff staff)
                    {
                        if (staff.ID >= 0 && staff.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)staff.ID, Entity = EntityTypes.Staffs });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(staff.ID), "Staff ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is RoomType roomType)
                    {
                        if (roomType.ID >= 0 && roomType.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)roomType.ID, Entity = EntityTypes.RoomTypes });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(roomType.ID), "RoomType ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Room room)
                    {
                        if (room.ID >= 0 && room.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)room.ID, Entity = EntityTypes.Rooms });
                        }
                    }
                    else if (entity is LeaseAgreement leaseAgreement)
                    {
                        if (leaseAgreement.ID >= 0 && leaseAgreement.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)leaseAgreement.ID, Entity = EntityTypes.LeaseAgreements });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(leaseAgreement.ID), "LeaseAgreement ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Amenity amenity)
                    {
                        if(amenity.ID >= 0 && amenity.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId= (byte)amenity.ID, Entity = EntityTypes.Amenitys });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(amenity.ID), "Amenity ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Feedback feedback)
                    {
                        if(feedback.ID >= 0 &&  feedback.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)feedback.ID, Entity = EntityTypes.Feedbacks });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(feedback.ID), "Feedback ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Service service)
                    {
                        if (service.ID >= 0 && service.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)service.ID, Entity = EntityTypes.Services });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(service.ID), "Service ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Utility utility)
                    {
                        if (utility.ID >= 0 && utility.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)utility.ID, Entity = EntityTypes.Utilitys });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(utility.ID), "Utility ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Reservation reservation)
                    {
                        if (reservation.ID >= 0 && reservation.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)reservation.ID, Entity = EntityTypes.Reservations });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(reservation.ID), "Reservation ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Request request)
                    {
                        if (request.ID >= 0 && request.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)request.ID, Entity = EntityTypes.Requests });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(request.ID), "Request ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Rent rent)
                    {
                        if (rent.ID >= 0 && rent.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)rent.ID, Entity = EntityTypes.Rents });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(rent.ID), "Rent ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Policy policy)
                    {
                        if (policy.ID >= 0 && policy.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs() { ByteId = (byte)policy.ID, Entity = EntityTypes.Policys });
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(policy.ID), "Policy ID must be between 0 and 255.");
                        }
                    }
                    else if (entity is Payment payment)
                    {
                        if (payment.ID >= 0 && payment.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)payment.ID,
                                Entity = EntityTypes.Payments
                            });
                        }
                        else
                        {
                            throw new Exception($"Payment ID {payment.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Invoice invoice)
                    {
                        if (invoice.ID >= 0 && invoice.ID <= 255)
                        {
                            Updated?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)invoice.ID,
                                Entity = EntityTypes.Invoices
                            });
                        }
                        else
                        {
                            throw new Exception($"Invoice ID {invoice.ID} is out of range for ByteId.");
                        }
                    }

                    else
                    {
                        throw new NotSupportedException($"Entity type {entity.GetType().Name} is not supported for updates.");
                    }
                    return affectedRows > 0; // Return true if at least one row was affected
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while updating entity: {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to update entity of type {typeof(T).Name}: {ex.Message}", ex);
                }
            }
        }

        public static bool DeleteEntity<T>(SqlConnection conn, T entity, string storedProcedureName) where T : IEntity
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Use the entity to add parameters
                entity.AddParametersWithID(cmd);

                try
                {
                    int effected = cmd.ExecuteNonQuery();

                    if (entity is Resident resident)
                    {
                        if (resident.ID >= 0 && resident.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)resident.ID, Entity = EntityTypes.Residents });
                        }
                        else
                        {
                            throw new Exception($"ResidentID {resident.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Vendor vendor)
                    {
                        if (vendor.VenID >= 0 && vendor.VenID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)vendor.VenID, Entity = EntityTypes.Vendors });
                        }
                        else
                        {
                            throw new Exception($"Vendor ID {vendor.VenID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Staff staff)
                    {
                        if (staff.ID >= 0 && staff.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)staff.ID, Entity = EntityTypes.Staffs });
                        }
                        else
                        {
                            throw new Exception($"Vendor ID {staff.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is RoomType roomType)
                    {
                        if (roomType.ID >= 0 && roomType.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)roomType.ID, Entity = EntityTypes.RoomTypes });
                        }
                        else
                        {
                            throw new Exception($"Room ID {roomType.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Room room)
                    {
                        if(room.ID >= 0 && room.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)room.ID, Entity = EntityTypes.RoomTypes });
                        }
                    }
                    else if (entity is LeaseAgreement leaseAgreement)
                    {
                        if (leaseAgreement.ID >= 0 && leaseAgreement.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)leaseAgreement.ID, Entity = EntityTypes.LeaseAgreements });
                        }
                        else
                        {
                            throw new Exception($"LeaseAgreement ID {leaseAgreement.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Amenity amenity)
                    {
                        if (amenity.ID >= 0 && amenity.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)amenity.ID, Entity = EntityTypes.Amenitys });
                        }
                        else
                        {
                            throw new Exception($"Amenity ID {amenity.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Feedback feedback)
                    {
                        if (feedback.ID >= 0 && feedback.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)feedback.ID, Entity = EntityTypes.Feedbacks });
                        }
                        else
                        {
                            throw new Exception($"Feedback ID {feedback.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Service service)
                    {
                        if (service.ID >= 0 && service.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)service.ID, Entity = EntityTypes.Services });
                        }
                        else
                        {
                            throw new Exception($"Service ID {service.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Utility utility)
                    {
                        if (utility.ID >= 0 && utility.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)utility.ID, Entity = EntityTypes.Utilitys });
                        }
                        else
                        {
                            throw new Exception($"Utility ID {utility.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Reservation reservation)
                    {
                        if (reservation.ID >= 0 && reservation.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)reservation.ID, Entity = EntityTypes.Reservations });
                        }
                        else
                        {
                            throw new Exception($"Reservation ID {reservation.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Request request)
                    {
                        if (request.ID >= 0 && request.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)request.ID, Entity = EntityTypes.Requests });
                        }
                        else
                        {
                            throw new Exception($"Request ID {request.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Rent rent)
                    {
                        if (rent.ID >= 0 && rent.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)rent.ID, Entity = EntityTypes.Rents });
                        }
                        else
                        {
                            throw new Exception($"Rent ID {rent.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Policy policy)
                    {
                        if (policy.ID >= 0 && policy.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs() { ByteId = (byte)policy.ID, Entity = EntityTypes.Policys });
                        }
                        else
                        {
                            throw new Exception($"Policy ID {policy.ID} is out of range for ByteId. It must be between 0 and 255.");
                        }
                    }
                    else if (entity is Payment payment)
                    {
                        if (payment.ID >= 0 && payment.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)payment.ID,
                                Entity = EntityTypes.Payments
                            });
                        }
                        else
                        {
                            throw new Exception($"Payment ID {payment.ID} is out of range for ByteId.");
                        }
                    }
                    else if (entity is Invoice invoice)
                    {
                        if (invoice.ID >= 0 && invoice.ID <= 255)
                        {
                            Deleted?.Invoke(null, new EntityEventArgs
                            {
                                ByteId = (byte)invoice.ID,
                                Entity = EntityTypes.Invoices
                            });
                        }
                        else
                        {
                            throw new Exception($"Invoice ID {invoice.ID} is out of range for ByteId.");
                        }
                    }

                    return (effected > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed in deleting entity > {ex.Message}");
                }
            }
        }
    }
}