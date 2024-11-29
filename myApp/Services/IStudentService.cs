using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myApp.Models;

namespace myApp.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();

        public Task<Student?> GetStudentByIdAsync(int id);

        public Task<bool> AddNewStudentAsync(Student student);

        public Task<bool> UpdateStudentDataAsync(Student student);

        public Task<bool> DeleteStudentByIdAsync(int id);
    }
}