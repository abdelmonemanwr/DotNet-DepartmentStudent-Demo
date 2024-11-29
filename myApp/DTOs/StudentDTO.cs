using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace myApp.DTOs
{
    public class StudentDTO
    {
        public int sid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public int? did { get; set; }
    }
}