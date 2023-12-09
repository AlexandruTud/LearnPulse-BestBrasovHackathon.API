using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface ILoginService
    {
        Task<int> Login(UserLoginDTO userLogin);
    }
}