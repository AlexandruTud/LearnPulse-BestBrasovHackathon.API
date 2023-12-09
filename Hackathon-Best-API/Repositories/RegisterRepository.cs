using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;
        public RegisterRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> RegisterUserAsync(UserRegisterDTO userRegisterDTO) { 
            var parameters = new DynamicParameters();
            parameters.Add("@Email", userRegisterDTO.Email);
            parameters.Add("@Password", userRegisterDTO.Password);
            parameters.Add("@FirstName", userRegisterDTO.FirstName);
            parameters.Add("@LastName", userRegisterDTO.LastName);
            parameters.Add("Gender", userRegisterDTO.Gender);
            parameters.Add("@UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("RegisterUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                int userID = parameters.Get<int>("UserID");
                return userID;
            }
        }
    }
}
