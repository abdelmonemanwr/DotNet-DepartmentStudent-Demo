using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace myApp.Models
{
    public class Student
    {
        [Key]
        public int St_id { get; set; }
        [MinLength(5), MaxLength(50)]
        public string St_name { get; set; }
        public int St_age { get; set; }

        [MinLength(5), MaxLength(50)]
        public string St_address { get; set; }

        [ForeignKey("Dept")]
        public int? Dept_id { get; set; }

        [InverseProperty("Students")]
        public virtual Department Dept { get; set; }
    }
}