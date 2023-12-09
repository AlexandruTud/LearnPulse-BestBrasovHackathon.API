namespace Hackathon_Best_API.Interfaces
{
    public interface IGetUserRoleByIdService
    {
        Task<int> GetUserRoleByIdAsync(int id);
    }
}