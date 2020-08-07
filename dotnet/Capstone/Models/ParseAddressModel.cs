using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ParseAddressModel
    {

        public class Rootobject
        {
            public Result results { get; set; }
        }

        public class Result
        {
            public Geometry geometry { get; set; }
        }
        public class Geometry
        {
            public Location location { get; set; }
        }
        public class Location
        {
            public Dictionary<string, float> LatLong { get; set; }
        }



 


  

    }
}
