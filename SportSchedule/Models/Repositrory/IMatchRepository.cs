using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportSchedule.Models.Repository
{
    public interface IMatchRepository
    {
        Task<int> SetMatchResult(int id, int team1Points);
        Task<TourMatch> GetMatch(int id);
        Task SaveChangesAsync();
        Task<List<TourMatch>> GetPlayedGames(string tournamentName);
        Task<List<TourMatch>> GetNotPlayedGames(string tournamentName);
    }
}