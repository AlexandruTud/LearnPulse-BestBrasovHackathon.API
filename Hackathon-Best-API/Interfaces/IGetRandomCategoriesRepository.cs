using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IGetRandomCategoriesRepository

    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
    }
}
