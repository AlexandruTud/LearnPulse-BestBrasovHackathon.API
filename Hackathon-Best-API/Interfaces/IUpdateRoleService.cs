using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Interfaces
{
    public interface IUpdateRoleService
    {
        Task<bool> ChangeRolesAsync(UpdateRoleRequest request);
    }
}