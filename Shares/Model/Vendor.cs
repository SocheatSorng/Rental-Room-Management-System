using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS.Model
{
    public class Vendor
    {
        public int VenID { get; set; }
        public string VenName { get; set; }
        public string VenContact {  get; set; }
        public string VenHNo { get; set; }
        public string VenSNo { get; set; }
        public string VenCommune { get; set; }
        public string VenDistrict { get; set; }
        public string VenProvince { get; set; }
        public DateTime VenConStart { get; set; }
        public DateTime VenConEnd {  get; set; }
        public Boolean VenStatus { get; set; }
        public string VenDesc { get; set; }
    }
}
