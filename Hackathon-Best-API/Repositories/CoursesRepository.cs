using Dapper;
using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.DTOs;
using System.Data;
using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public CoursesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<CoursesDTO>> GetAllPublicCoursesAsync()
        {
            using (var connection =  _dbConnectionFactory.ConnectToDataBase())
            {
                  var result = await connection.QueryAsync<CoursesDTO>("GetPublicCoursesWithDetails", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<CoursesDTO>> GetCoursesByTitleAsync(string Title)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TitleSequence", Title);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<CoursesDTO>("SearchCoursesByTitle", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<bool> InsertCoursesAsync(CoursesRequest coursesRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CourseTitle", coursesRequest.CourseTitle);
            parameters.Add("@Duration", coursesRequest.Duration);
            parameters.Add("@Description", coursesRequest.Description);
            parameters.Add("@CategoryName", coursesRequest.CategoryName);
            parameters.Add("@PostDate", coursesRequest.PostDate = DateTime.Now);
            parameters.Add("@IdUser", coursesRequest.IdUser);
            parameters.Add("@Link", coursesRequest.Link);
            parameters.Add("@CourseLanguage", coursesRequest.CourseLanguage);
            parameters.Add("@Difficulty", coursesRequest.Difficulty);
            parameters.Add("@Points", coursesRequest.Points);
            parameters.Add("@ImageURL", coursesRequest.ImageURL);
            parameters.Add("@IsPublic", coursesRequest.isPublic ? 1 : 0, dbType: DbType.Int32);
            parameters.Add("Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("InsertCourse", parameters, commandType: CommandType.StoredProcedure);
                var success = parameters.Get<bool>("Success");
                return success;
            }
        }
    }
}
