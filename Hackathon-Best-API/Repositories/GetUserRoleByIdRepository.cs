using Dapper;
using Hackathon_Best_API.Infrastructure;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class GetUserRoleByIdRepository : IGetUserRoleByIdRepository
    { 
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetUserRoleByIdRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> GetUserRoleByIdAsync(int id)
        {
            using(var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdUser", id);
                parameters.Add("UserRole", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("GetUserRoleById", parameters, commandType: System.Data.CommandType.StoredProcedure);
                var userRoleID = parameters.Get<int>("UserRole");
                return userRoleID;
            }
        }
    }
}
