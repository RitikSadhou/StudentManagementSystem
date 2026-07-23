using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);

        Task<User> AddUserAsync(User user);
    }
}
