using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student> AddAsync(StudentDto dto);

        Task<Student?> UpdateAsync(int id, StudentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
