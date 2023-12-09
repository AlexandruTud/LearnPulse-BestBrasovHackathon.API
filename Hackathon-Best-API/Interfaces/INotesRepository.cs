using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Models;
using Hackathon_Best_API.Requests;

namespace Hackathon_Best_API.Interfaces
{
    public interface INotesRepository
    {
       
        Task<IEnumerable<Notes>> GetNotesAsync(int idUser);
        Task<int> InsertNoteAsync(NoteDTO noteDTO);
        Task<int> UpdateNoteAsync(NotesRequest notesRequest);
    }
}