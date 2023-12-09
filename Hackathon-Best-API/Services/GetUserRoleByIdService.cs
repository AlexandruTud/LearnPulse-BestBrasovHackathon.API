using Hackathon_Best_API.Interfaces;

namespace Hackathon_Best_API.Services
{
    public class GetUserRoleByIdService : IGetUserRoleByIdService
    {
        private readonly IGetUserRoleByIdRepository _getUserRoleByIdRepository;

        public GetUserRoleByIdService(IGetUserRoleByIdRepository getUserRoleByIdRepository)
        {
            _getUserRoleByIdRepository = getUserRoleByIdRepository;
        }

        public async Task<int> GetUserRoleByIdAsync(int id)
        {
            return await _getUserRoleByIdRepository.GetUserRoleByIdAsync(id);
        }
    }
}
