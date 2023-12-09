using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Interfaces
{
    public interface IUpdateRoleRepository
    {
        Task<bool> ChangeRolesAsync(UpdateRoleRequest request);
    }
}