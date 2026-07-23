using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Student> AddAsync(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            return await _repository.AddAsync(student);
        }

        public async Task<Student?> UpdateAsync(int id, StudentDto dto)
        {
            var student = new Student
            {
                Id = id,
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course
            };

            return await _repository.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
