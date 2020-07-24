using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }
        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
