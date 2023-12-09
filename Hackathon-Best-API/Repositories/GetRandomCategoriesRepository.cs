using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using System.Data;

namespace Hackathon_Best_API.Repositories
{
    public class GetRandomCategoriesRepository : IGetRandomCategoriesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetRandomCategoriesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                 
                var result = await connection.QueryAsync<CategoryDTO>("GetRandomCategories", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
