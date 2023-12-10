using Dapper;
using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Models;
using Hackathon_Best_API.Requests;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Hackathon_Best_API.Repositories
{
    public class NotesRepository : INotesRepository
    { 
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public NotesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<Notes>> GetNotesAsync (int IdUser)
        {
            
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdUser", IdUser);
                var result = await connection.QueryAsync<Notes>("GetUserNotes", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }   
        }
        public async Task<int> InsertNoteAsync(NoteDTO noteDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", noteDTO.IdUser);
            parameters.Add("@NoteTitle", noteDTO.NoteTitle);
            parameters.Add("@NoteText", noteDTO.NoteText);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertUserNote", parameters, commandType: System.Data.CommandType.StoredProcedure);
                int success = parameters.Get<int>("Success");
                return success;
            }
        }
        public async Task<int> UpdateNoteAsync(NotesRequest notesRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NoteId", notesRequest.IdNote);
            parameters.Add("@NewNoteTitle", notesRequest.NewNoteTitle);
            parameters.Add("@NewNoteText", notesRequest.NewNoteText);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateUserNote", parameters, commandType: System.Data.CommandType.StoredProcedure);
                int success = parameters.Get<int>("Success");
                return success;
            }

        }
        public async Task<int> DeleteNoteAsync(int IdNote)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdNote", IdNote);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteNote", parameters, commandType: System.Data.CommandType.StoredProcedure);
                int success = parameters.Get<int>("Success");
                return success;
            }
        }
    }
}
