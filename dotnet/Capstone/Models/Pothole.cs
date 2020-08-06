using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pothole
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }
        public string DateAddedString
        {
            get
            {
                return this.DateAdded.ToString("f");
            }
        }
        public int Severity { get; set; }
        public string Description { get; set; }
        public PotholeStatus Status { get; set; }
        public Location LatLong { get; set; }

    }

    //public class Rootobject
    //{
    //    public Result[] results { get; set; }
    //}

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
        public float Latitude { get; set; }
        public float Longitude { get; set; }

    }


}
