using Dapper;
using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Repositories
{
    public class UpdateRoleRepository : IUpdateRoleRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UpdateRoleRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> ChangeRolesAsync(UpdateRoleRequest request)
        {
            var parameters = new DynamicParameters();   
            parameters.Add("@IdUser", request.UserId);
            parameters.Add("@RoleId",request.RoleId);
            parameters.Add("Success", dbType: System.Data.DbType.Boolean, direction: System.Data.ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateUserRole", parameters, commandType: System.Data.CommandType.StoredProcedure);
                var result = parameters.Get<bool>("Success");            
                return result;
            }
        }
    }
}
