using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class AddCourseReviewRepository : IAddCourseReviewRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddCourseReviewRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddCourseReviewAsync(int IdUser, int IdCourse, int Review)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            parameters.Add("@IdCourse", IdCourse);
            parameters.Add("@Rating", Review);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("InsertCourseRating", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<CommentDTO>> GetCommentsAsync(int IdCourse)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdCourse", IdCourse);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<CommentDTO>("GetCourseComments", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> AddCourseCommentAsync(int IdUser, int IdCourse, string Comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            parameters.Add("@IdCourse", IdCourse);
            parameters.Add("@CommentText", Comment);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("InsertCourseComment", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
