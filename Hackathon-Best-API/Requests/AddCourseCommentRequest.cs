namespace Hackathon_Best_API.Requests
{
    public class AddCourseCommentRequest
    {
        public int IdUser { get; set; }
        public int IdCourse { get; set; }
        public string Comment { get; set; }
    }
}