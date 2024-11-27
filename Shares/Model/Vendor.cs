using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS.Model
{
    public class Vendor
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorContact {  get; set; }
        public string VendorHNo { get; set; }
        public string VendorSNo { get; set; }
        public string VendorCommune { get; set; }
        public string VendorDistrict { get; set; }
        public string VendorProvince { get; set; }
        public DateTime VendorConStart { get; set; }
        public DateTime VendorConEnd {  get; set; }
        public Boolean VendorStatus { get; set; }
        public string VendorDesc { get; set; }
    }
}
