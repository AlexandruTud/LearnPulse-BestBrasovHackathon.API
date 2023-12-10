namespace Hackathon_Best_API.Requests
{
    public class CoursesRequest
    {
        public string IdCourse { get; set; }
        public string CourseTitle { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime PostDate { get; set; }
        public int IdUser { get; set; }
        public string Link { get; set; }
        public string CourseLanguage { get; set; }
        public string Difficulty { get; set; }
        public int Points { get; set; }
        public string ImageURL { get; set; }
        public bool isPublic { get; set; }
    }
}
