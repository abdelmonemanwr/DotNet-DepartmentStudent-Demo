using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myApp.Models;
using myApp.Repository;
using myApp.UnitOfWorks;

namespace myApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly UnitOfWork unit;

        public DepartmentService(UnitOfWork unit)
        {
            this.unit = unit;
        }
    }
}