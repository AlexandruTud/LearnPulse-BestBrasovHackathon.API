using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;

namespace Hackathon_Best_API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<int> Login(UserLoginDTO userLogin)
        {
            return await _loginRepository.Login(userLogin);
        }
    }
}
