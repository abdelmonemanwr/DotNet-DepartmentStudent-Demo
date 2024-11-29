using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace myApp.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() { }
        public ITIContext(DbContextOptions<ITIContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        internal object Entry<T>()
        {
            throw new NotImplementedException();
        }
    }
}