using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
    private readonly INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
        _notesRepository = notesRepository;

        }

        [HttpGet]
        [Route("GetNotes")]
        public async Task<IEnumerable<Notes>> GetNotes(int IdUser)
        {
            var result = await _notesRepository.GetNotesAsync(IdUser);
            return result;

        }
    }
}
