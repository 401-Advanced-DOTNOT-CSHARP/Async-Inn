using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  StretAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  PhoneNumber { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}
