using Hackathon_Best_API.DTOs;

namespace Hackathon_Best_API.Interfaces
{
    public interface IAddCourseReviewRepository
    {
        Task<int> AddCourseReviewAsync(int IdUser, int IdCourse, int Review);
        Task<IEnumerable<CommentDTO>> GetCommentsAsync(int IdCourse);
        Task<int> AddCourseCommentAsync(int IdUser, int IdCourse, string Comment);
    }
}