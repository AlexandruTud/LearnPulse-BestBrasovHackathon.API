
using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class GetUserByIdRepository : IGetUserByIdRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public GetUserByIdRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<UserDTO> GetUserByIdAsync(int IdUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            using (var connection = dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserDTO>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
