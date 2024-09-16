using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public string LocationCity { get; set; }

        public decimal Cost { get; set; } // Changed to decimal for currency handling

        public int Capacity { get; set; }

    }
}
