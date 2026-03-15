using System.ComponentModel.DataAnnotations;

namespace GameTournamentApi.Dtos
{
    public class TournamentCreateDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int MaxPlayers { get; set; }

        [FutureOrTodayDate]
        public DateTime Date { get; set; }
    }
}