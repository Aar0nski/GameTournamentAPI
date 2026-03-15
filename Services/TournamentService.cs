using GameTournamentApi.Data;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tournament>> GetAllAsync(string? search)
        {
            var query = _context.Tournaments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<bool> UpdateAsync(int id, Tournament tournament)
        {
            var existingTournament = await _context.Tournaments.FindAsync(id);

            if (existingTournament == null)
                return false;

            existingTournament.Title = tournament.Title;
            existingTournament.Description = tournament.Description;
            existingTournament.MaxPlayers = tournament.MaxPlayers;
            existingTournament.Date = tournament.Date;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
                return false;

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}