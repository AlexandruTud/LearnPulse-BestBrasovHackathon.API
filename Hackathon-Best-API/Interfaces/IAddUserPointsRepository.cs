using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IAddUserPointsRepository
    {
        Task<int> AddUserPointsAsync(int IdUser, int Points);
        Task<IEnumerable<UserPointsDTO>> GetTopUsersAsync();
    }
}