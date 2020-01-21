using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi_TodoApi.Models
{
    public class Employee : BaseEnitiy
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
    }
}
