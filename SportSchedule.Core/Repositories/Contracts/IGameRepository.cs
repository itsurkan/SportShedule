using System.Threading.Tasks;
using SportSchedule.Core.Models;

namespace SportSchedule.Core.Repositories.Contracts
{
    public interface IGameRepository : IDbRepository<Game>
    {
        Task<Game[]> GetTournamentGames(int tournamentId);
        Task<Game[]> GetPlayedTournamentGames(int tournamentId);
        Task<Game[]> GetPlannedTournamentGames(int tournamentId);
        Task<Game> GetGame(int homeTeamId, int guestTeamId);
    }
}
