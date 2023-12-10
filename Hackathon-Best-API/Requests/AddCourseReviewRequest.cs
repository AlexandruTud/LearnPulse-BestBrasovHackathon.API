namespace Hackathon_Best_API.Requests
{
    public class AddCourseReviewRequest
    {
        public int IdUser { get; set; }
        public int IdCourse { get; set; }
        public int Review { get; set; }
    }
}