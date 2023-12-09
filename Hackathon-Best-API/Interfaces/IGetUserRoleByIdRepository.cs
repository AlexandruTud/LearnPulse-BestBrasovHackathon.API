namespace Hackathon_Best_API.Interfaces
{
    public interface IGetUserRoleByIdRepository
    {
        Task<int> GetUserRoleByIdAsync(int id);
    }
}