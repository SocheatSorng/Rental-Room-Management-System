using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }
        public Boolean AmenityAvail { get; set; }
        public string AmenityLocation { get; set; }
        public double AmenityBouPri { get; set; }
        public double AmenityCPR {  get; set; }
        public DateTime AmenityMainDate { get; set; }
        public string AmenityDesc { get; set; }
    }
}
