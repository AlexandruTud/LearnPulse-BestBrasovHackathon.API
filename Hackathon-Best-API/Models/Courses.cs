namespace Hackathon_Best_API.Models
{
    public class Courses
    {
        public string CourseTitle { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public DateOnly PostDate { get; set; }
        public int IdUser { get; set; }
        public string Link { get; set; }
        public string CouseLanguage { get; set; }
        public string Difficulty { get; set; }
        public int Points { get; set; }
        public string ImageURL { get; set; }
    }
}