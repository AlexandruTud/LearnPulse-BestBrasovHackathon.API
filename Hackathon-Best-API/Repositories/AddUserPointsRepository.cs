using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class AddUserPointsRepository : IAddUserPointsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public AddUserPointsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddUserPointsAsync(int IdUser, int Points)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            parameters.Add("@PointsEarned", Points);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("AddUserPoints", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<UserPointsDTO>> GetTopUsersAsync()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<UserPointsDTO>("GetTopUsers", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
