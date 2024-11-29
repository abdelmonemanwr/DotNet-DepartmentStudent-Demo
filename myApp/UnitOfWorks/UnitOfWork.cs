using myApp.Models;
using myApp.Repository;

namespace myApp.UnitOfWorks
{
    public class UnitOfWork
    {
        private readonly ITIContext db;

        private GenericRepository<Student> studentRepository;
        public GenericRepository<Student> StudentRepository { get => (studentRepository == null) ? studentRepository = new GenericRepository<Student>(db) : studentRepository; }

        private GenericRepository<Department> departmentRepository;
        public GenericRepository<Department> DepartmentRepository { get => (departmentRepository == null) ? departmentRepository = new GenericRepository<Department>(db) : departmentRepository; }

        public UnitOfWork(ITIContext db)
        {
            this.db = db;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
