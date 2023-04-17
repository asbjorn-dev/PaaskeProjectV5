using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheltermini.Shared
{
    public class Shelter
    {
        public string ShelterId { get; set; } 
        public string Name { get; set; } = "";
        public string KommuneName { get; set; } = "";
        public string Description { get; set; } = "";
        public int Capacity { get; set; } = 0;
        public string Picture { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
        public string Contact { get; set; } = "";
        public decimal longitude { get; set; } = 0;
        public decimal lat { get; set; } = 0;
    }

}
