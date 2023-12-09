using System.Data;

namespace Hackathon_Best_API.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection ConnectToDataBase();
    }
}