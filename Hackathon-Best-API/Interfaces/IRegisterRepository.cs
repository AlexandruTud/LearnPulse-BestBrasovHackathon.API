using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IRegisterRepository
    {
        Task<int> RegisterUserAsync(UserRegisterDTO userRegisterDTO);
    }
}