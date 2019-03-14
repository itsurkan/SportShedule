using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportSchedule.Models
{
    public class TournamentModel
    {
        public TournamentModel()
        {
            Matches = new List<TourMatch>();
        }

        public int ID { get; set; }
        [Required]
        public string TournamentName { get; set; }
        public ICollection<TourMatch> Matches { get; set; }

        internal static TournamentModel GeterateFromView(TournamentViewModel tourView)
        {
            var tour = new TournamentModel();
            tour.TournamentName = tourView.TournamentName;
            var commands = tourView.commandsList.Split(",").Where(c => !string.IsNullOrEmpty(c)).ToList();

            if (commands.Count() % 2 != 0)
            {
                commands.Add("--none--");
            }

            var teams = commands.Select(name => new Team(name.Trim())).ToList();
            var halfCount = teams.Count / 2;

            var p1 = teams.Take(halfCount).ToList();
            var p2 = teams.Skip(halfCount).Take(halfCount).ToList();

            var matches = new List<TourMatch>();

            for (int i = 1; i < teams.Count; i++)
            {
                for (int j = 0; j < halfCount; j++)
                {
                    var match = new TourMatch();
                    match.Round = i;
                    match.Team1 = p1[j];
                    match.Team2 = p2[j];
                    matches.Add(match);
                    Shift(p1, p2);
                }
            }
            tour.Matches = matches;
            return tour;
        }
        private static void Shift(List<Team> p1, List<Team> p2)
        {
            var p1Last = p1.Last();
            var p2First = p2.First();

            p1.Remove(p1Last);
            p2.Add(p1Last);

            p2.Remove(p2First);
            p1.Insert(1, p2First);
        }


        internal IEnumerable<IGrouping<int, TourMatch>> GetShedule()
        {
            var model = new ScheduleModel();
            model.TournamentName = TournamentName;
            var rounds = Matches.GroupBy(m => m.Round);
            
            foreach (var item in rounds)
            {
                model.Rounds.AddRange(item.Select(i=>new RoundModel(item.Key )));
            }
            return rounds;
        }
    }
}
