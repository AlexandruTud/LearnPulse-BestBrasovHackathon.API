using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IRegisterService
    {
        Task<int> RegisterUserAsync(UserRegisterDTO userRegister);
    }
}