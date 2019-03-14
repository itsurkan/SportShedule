using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportSchedule.Models.Repository
{
    public class EFMatchRepository : IMatchRepository
    {
        TournamentContext _context;

        public EFMatchRepository(TournamentContext context)
        {
            _context = context;
        }
        public Task<TourMatch> GetMatch(int id)
        {
            return this._context.Match.FindAsync(id);
        }
        public async Task<int> SetMatchResult(int id,  int team1Points)
        {
            var match = await this._context.Match.FindAsync(id);

            if (match == null)
                return -1;

            match.Team1Points = team1Points;
            match.IsPlayed = true;

            return await _context.SaveChangesAsync();
        }

        public Task<List<TourMatch>> GetPlayedGames(string tournamentName)
        {
            return GetMatchGames(tournamentName, true);
        }

        public Task<List<TourMatch>> GetNotPlayedGames(string tournamentName)
        {
            return GetMatchGames(tournamentName, false);
        }
        private Task<List<TourMatch>> GetMatchGames(string name, bool played)
        {
            return _context.Match.Where(m => m.Tournament.TournamentName == name && m.IsPlayed == played)
                .Include(t => t.Team1)
                .Include(t => t.Team2).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}