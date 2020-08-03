using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PotholeStatus
    {
        public bool Reported { get; set; } = true;
        public bool InProgress { get; set; } = false;
        public bool Repaired { get; set; } = false;
    }
}
