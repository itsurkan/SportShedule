using System.Collections.Generic;

namespace SportSchedule.Models
{
    internal class ScheduleModel
    {
        public ScheduleModel()
        {
            Rounds = new List<RoundModel>();
        }
        public string TournamentName { get; set; }
        public List<RoundModel> Rounds { get; set; }
    }

    internal class RoundModel
    {
        public RoundModel(int round)
        {
            Round = round;
        }
        public int Round { get; set; }
        public List<Team> Teams { get; set; }
    }
}