using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public LoginRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> Login(UserLoginDTO userLogin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", userLogin.Email);
            parameters.Add("@Password", userLogin.Password);
            parameters.Add("UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("CheckLoginCredentials", parameters, commandType: System.Data.CommandType.StoredProcedure);
                int userID = parameters.Get<int>("UserID"); 
                return userID;
            }
        }
    }
}
