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
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> UserExistsAsync(string userId);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string userId);
        
        Task<UserTask> CreateTaskAsync(UserTask task);
        Task<UserTask?> GetTaskByIdAsync(int taskId);
        Task<List<UserTask>> GetAllTasksAsync();
        Task<List<UserTask>> GetTasksByUserIdAsync(
            string userId,
            int offset = 0,
            int limit = 10
        );
        Task<int> GetTaskCountByUserIdAsync(string userId);
        Task UpdateTaskAsync(UserTask task);
        Task DeleteTaskAsync(int taskId);
        Task DeleteAllTasksForUserAsync(string userId);
        
        Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken token);
        Task<RefreshToken?> GetRefreshTokenAsync(string token);
        Task<List<RefreshToken>> GetRefreshTokensByUserIdAsync(string userId);
        Task<bool> IsRefreshTokenValidAsync(string token);
        Task RevokeRefreshTokenAsync(string token);
        Task RevokeAllRefreshTokensForUserAsync(string userId);
        Task DeleteExpiredRefreshTokensAsync();
        Task SaveChangesAsync();
    }
}