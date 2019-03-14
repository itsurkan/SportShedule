using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportSchedule.Models.Repository
{

    public class EFTournamentRepository : ITournamentRepository
    {
        TournamentContext _context;

        public EFTournamentRepository(TournamentContext context)
        {
            _context = context;
        }
        public Task AddTournamentAsync(TournamentModel model)
        {
            if (_context.Tournament.Any(t => t.TournamentName == model.TournamentName))
            {
                return null;
            }
            return _context.Tournament.AddAsync(model);
        }

        public async Task<TournamentModel> FindTournamentAsync(string tournamentName)
        {
            var matches = _context.Match.Where(m => m.Tournament.TournamentName == tournamentName)
                .Include(m => m.Team1)
                .Include(m => m.Team2).ToList();
            var tournament = await _context.Tournament.Where(t => t.TournamentName == tournamentName)
            .FirstOrDefaultAsync();
            return tournament;
        }

        public async Task<List<TeamResult>> GetTournamentResult(string tournamentName)
        {
            var matches = await FindMatchesByTourName(tournamentName);
            var teamsList = GetTeamsForTour(matches);

            var resultModel = new List<TeamResult>();

            foreach (var team in teamsList)
            {
                var res = new TeamResult(team);

                var points = matches.Where(t => t.Team1 == team && t.Team1Points.HasValue).Select(m => m.Team1Points).ToList();
                points.AddRange(matches.Where(t => t.Team2 == team && t.Team1Points.HasValue).Select(m => m.Team1Points == 1 ? 1 : 3 - m.Team1Points));

                res.GamesCount = points.Count();
                res.Points = points.Sum(point => { return point.HasValue ? point.Value : 0; });

                foreach (var point in points)
                {
                    res.Draw += point == 1 ? 1 : 0;
                    res.Win += point == 3 ? 1 : 0;
                    res.Lose += point == 0 ? 1 : 0;
                }
                resultModel.Add(res);
            }
            return resultModel;
        }

        private static List<Team> GetTeamsForTour(List<TourMatch> matches)
        {
            var teamsList = new List<Team>();
            foreach (var match in matches)
            {
                if (!teamsList.Contains(match.Team1))
                {
                    teamsList.Add(match.Team1);
                }
                if (!teamsList.Contains(match.Team2))
                {
                    teamsList.Add(match.Team2);
                }
            }
            return teamsList;
        }

        private Task<List<TourMatch>> FindMatchesByTourName(string name)
        {
            return _context.Match.Where(m => m.Tournament.TournamentName == name)
               .Include(m => m.Team1)
               .Include(m => m.Team2).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}