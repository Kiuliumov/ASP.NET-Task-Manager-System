using CantinaManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CantinaManager.Data
{
    public interface IRepository
    {
        Task<User> CreateUserAsync(User user);
        
        Task<User?> GetUserByIdAsync(string userId);
        
        Task<User?> GetUserByUsernameAsync(string username);
        
        Task<List<User>> GetAllUsersAsync();
        
        Task UpdateUserAsync(User user);
        
        Task DeleteUserAsync(string userId);

        Task<UserTask> CreateTaskAsync(UserTask task);
        
        Task<UserTask?> GetTaskByIdAsync(int taskId);

        Task<List<UserTask>> GetTasksByUserIdAsync(string userId, int offset = 0, int limit = 10);

        Task UpdateTaskAsync(UserTask task);
        
        Task DeleteTaskAsync(int taskId);
    }
}
