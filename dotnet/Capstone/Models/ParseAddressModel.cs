using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ParseAddressModel
    {
        public List<Result> results { get; set; }
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
        public float Lat { get; set; }
        public float Lng { get; set; }
    }








}
//
