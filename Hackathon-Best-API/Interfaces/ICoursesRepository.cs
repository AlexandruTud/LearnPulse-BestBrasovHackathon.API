using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Interfaces
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<CoursesDTO>> GetAllPublicCoursesAsync();
        Task<IEnumerable<CoursesDTO>> GetCoursesByTitleAsync(string Title);
        Task<bool> InsertCoursesAsync(CoursesRequest coursesRequest);
    }
}