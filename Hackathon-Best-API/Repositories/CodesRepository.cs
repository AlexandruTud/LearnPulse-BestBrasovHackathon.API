using Dapper;
using Hackathon_Best_API.Interfaces;
using Org.BouncyCastle.Crypto;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class CodesRepository : ICodesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public CodesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> GenerateCourseCodesAsync(int IdUser, int IdCourse)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", IdUser);
            parameters.Add("@IdCourse", IdCourse);
            parameters.Add("@Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("GenerateCourseCode", parameters, commandType: CommandType.StoredProcedure);
                bool result = parameters.Get<bool>("Result");
                return result;
            }
        }
        public async Task<string> GetCodeByCourseIdAsync(int IdCourse)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdCourse", IdCourse);
            parameters.Add("@Code", dbType: DbType.String, direction: ParameterDirection.Output, size: 4);

            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("GetCodeByCourseId", parameters, commandType: CommandType.StoredProcedure);
                string code = parameters.Get<string>("Code");
                return code;
            }
        }
    }
}
