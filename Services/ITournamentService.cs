using GameTournamentApi.Models;

namespace GameTournamentApi.Services
{
    public interface ITournamentService
    {
        Task<List<Tournament>> GetAllAsync(string? search);
        Task<Tournament?> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<bool> UpdateAsync(int id, Tournament tournament);
        Task<bool> DeleteAsync(int id);
    }
}