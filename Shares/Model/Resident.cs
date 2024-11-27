namespace RRMS
{
    public class Resident
    {
        public int ResidentID { get; set; } 
        public string? ResidentType { get; set; }
        public string? ResidentName { get; set; }
        public string? Sex { get; set; }
        public DateTime ResBOD { get; set; } // Resident Birth Date
        public string? PrevHouseNo {  get; set; } //Resident Previous House No
        public string? PrevStNo { get; set; } //Resident Previous Street No
        public string? PrevCommune { get; set; } //Resident Previous Commune
        public string? PrevDistrict { get; set; } //Resident Previous District
        public string? ResPerNum { get; set; } //Resident Personal Number
        public string? ResConNum { get; set; } //Resident Contact Number
        public DateTime CheckIn { get; set; } //Resident Check In Date
        public DateTime CheckOut { get; set; } //Resident Check Out Date

    }
} 