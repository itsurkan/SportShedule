using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportSchedule.Models.Repository
{
    public interface ITournamentRepository
    {
        Task AddTournamentAsync(TournamentModel model);
        Task<TournamentModel> FindTournamentAsync(string tournamentName);
        Task<List<TeamResult>> GetTournamentResult(string tournamentName);
        Task SaveChangesAsync();
    }
}