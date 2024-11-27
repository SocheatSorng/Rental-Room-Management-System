using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string? StaffFName {  get; set; }
        public string? StaffLName {  get; set; }
        public string? StaffSex { get; set; }
        public DateTime StaffBOD { get; set; }
        public string? StaffPosition {  get; set; }
        public string? StaffHNo { get; set; }
        public string? StaffSNo { get; set; }
        public string? StaffCommune { get; set; }
        public string? StaffDistrict { get; set; }
        public string? StaffProvince { get; set; }
        public string? StaffPerNum { get; set; }
        public double? StaffSalary { get; set; }
        public DateTime StaffHiredDate { get; set; }
        public string StaffPhoto { get; set; }
        public Boolean StaffStopped { get; set; }
    }
}
