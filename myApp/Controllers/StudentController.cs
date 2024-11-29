using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using myApp.Repository;
using myApp.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using myApp.Services;

namespace myApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStudentService studentService;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            this.mapper = mapper;
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            IEnumerable<Student> students = await studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Post(StudentDTO studentDTO)
        {
            Student student = mapper.Map<Student>(studentDTO);
            try
            {
                bool insertState = await studentService.AddNewStudentAsync(student);
                if (!insertState)
                {
                    return BadRequest("Failed to add the student");
                }
                return CreatedAtAction(nameof(GetById), new { id = student.St_id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, StudentDTO studentDTO)
        {
            if (!ModelState.IsValid || id != studentDTO.sid)
            {
                return BadRequest("please enter valid data");
            }

            Student? student = await studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return BadRequest("no student with the provided id");
            }

            // student = mapper.Map<Student>(studentDTO); // xxxxx: because it creates new instance and ef will have two tracked objects with the same PK so it will throw error.
            mapper.Map(studentDTO, student);              // right: because it modifies the tracked instance.

            try
            {
                bool updateState = await studentService.UpdateStudentDataAsync(student);
                if (!updateState)
                {
                    return BadRequest("Failed to update student data");
                }
                return Ok("Student was updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("please enter valid data");
            }
            try
            {
                bool deleteState = await studentService.DeleteStudentByIdAsync(id);
                if (!deleteState)
                {
                    return BadRequest("No student with the provided id");
                }
                return Ok("student deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}