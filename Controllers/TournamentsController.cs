using GameTournamentApi.Dtos;
using GameTournamentApi.Models;
using GameTournamentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TournamentResponseDto>>> GetAll([FromQuery] string? search)
        {
            var tournaments = await _tournamentService.GetAllAsync(search);

            var response = tournaments.Select(t => new TournamentResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                MaxPlayers = t.MaxPlayers,
                Date = t.Date
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentResponseDto>> GetById(int id)
        {
            var tournament = await _tournamentService.GetByIdAsync(id);

            if (tournament == null)
                return NotFound();

            var response = new TournamentResponseDto
            {
                Id = tournament.Id,
                Title = tournament.Title,
                Description = tournament.Description,
                MaxPlayers = tournament.MaxPlayers,
                Date = tournament.Date
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TournamentResponseDto>> Create(TournamentCreateDto dto)
        {
            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var createdTournament = await _tournamentService.CreateAsync(tournament);

            var response = new TournamentResponseDto
            {
                Id = createdTournament.Id,
                Title = createdTournament.Title,
                Description = createdTournament.Description,
                MaxPlayers = createdTournament.MaxPlayers,
                Date = createdTournament.Date
            };

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TournamentUpdateDto dto)
        {
            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var updated = await _tournamentService.UpdateAsync(id, tournament);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tournamentService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}