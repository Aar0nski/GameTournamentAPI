using System.ComponentModel.DataAnnotations;

namespace GameTournamentApi.Dtos
{
    public class FutureOrTodayDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date.Date >= DateTime.Today;
            }

            return false;
        }
    }
}