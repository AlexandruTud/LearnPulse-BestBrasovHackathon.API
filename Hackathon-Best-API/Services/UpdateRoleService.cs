using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Services
{
    public class UpdateRoleService : IUpdateRoleService
    {
        private readonly IUpdateRoleRepository _updateRoleRepository;
        public UpdateRoleService(IUpdateRoleRepository updateRoleRepository)
        {
            _updateRoleRepository = updateRoleRepository;
        }
        public async Task<bool> ChangeRolesAsync(UpdateRoleRequest request)
        {
            return await _updateRoleRepository.ChangeRolesAsync(request);
        }
    }
}
