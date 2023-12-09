using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;

namespace Hackathon_Best_API.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public async Task<int> RegisterUserAsync(UserRegisterDTO userRegister)
        {
            return await _registerRepository.RegisterUserAsync(userRegister);
        }
    }
}
