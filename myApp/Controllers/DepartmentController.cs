using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using myApp.Repository;

namespace myApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly GenericRepository<Department> departmentRepository;
        private readonly IMapper mapper;

        public DepartmentController(GenericRepository<Department> departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }




    }
}