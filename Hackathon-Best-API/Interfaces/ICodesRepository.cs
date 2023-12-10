namespace Hackathon_Best_API.Interfaces
{
    public interface ICodesRepository
    {
        Task<bool> GenerateCourseCodesAsync(int IdUser, int IdCourse);
        Task<string> GetCodeByCourseIdAsync(int IdCourse);
    }
}