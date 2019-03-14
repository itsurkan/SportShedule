using System;
using System.ComponentModel.DataAnnotations;

namespace SportSchedule.Models
{
    public class TourMatchViewModel
    {
        public TourMatchViewModel()
        {
        }
        public int PointsTeam1 { get; set; }
        public int PointsTeam2 { get; set; }
    }
    public class TourMatch
    {
        public TourMatch()
        {

        }

        public TourMatch(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        public int ID { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public int Round { get; set; }
        public int? Team1Points { get; set; }
        public bool IsPlayed { get; set; }
        public TournamentModel Tournament { get; set; }
        public int TournamentId { get; set; }

    }
}