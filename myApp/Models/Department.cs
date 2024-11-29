using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace myApp.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }

        [StringLength(50)]
        public string Dname { get; set; }

        [StringLength(100)]
        public string DLocation { get; set; }

        [InverseProperty("Dept")]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}