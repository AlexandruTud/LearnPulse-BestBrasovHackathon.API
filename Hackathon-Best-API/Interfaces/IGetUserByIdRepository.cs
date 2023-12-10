using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IGetUserByIdRepository
    {
        Task<UserDTO> GetUserByIdAsync(int IdUser);
    }
}