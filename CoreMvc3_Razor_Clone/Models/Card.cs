using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_Razor_Clone.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brief { get; set; }
        public string Photo { get; set; }
        public string WikiUrl { get; set; }
    }
}
