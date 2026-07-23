using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var existing = await _context.Students.FindAsync(student.Id);

            if (existing == null)
                return null;

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Age = student.Age;
            existing.Course = student.Course;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return false;

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
