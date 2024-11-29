using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using myApp.Repository;
using myApp.UnitOfWorks;

namespace myApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork unit;

        public StudentService(UnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await unit.StudentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await unit.StudentRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddNewStudentAsync(Student student)
        {
            if (student.Dept_id == null)
                return false;
            student.Dept = await unit.DepartmentRepository.GetByIdAsync((int)student.Dept_id);
            await unit.StudentRepository.InsertAsync(student);
            await unit.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudentDataAsync(Student student)
        {
            if (student.Dept_id == null)
                return false;

            student.Dept = await unit.DepartmentRepository.GetByIdAsync((int)student.Dept_id);
            if (student.Dept == null)
                return false;

            // await unit.StudentRepository.AttachAsync(student);
            await unit.StudentRepository.UpdateAsync(student);
            await unit.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentByIdAsync(int id)
        {
            Student? student = await unit.StudentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return false;
            }
            await unit.StudentRepository.DeleteAsync(student);
            await unit.SaveChangesAsync();
            return true;
        }
    }
}