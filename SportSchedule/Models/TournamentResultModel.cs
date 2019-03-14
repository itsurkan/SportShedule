using System.Collections.Generic;

namespace SportSchedule.Models
{
    public class TournamentResultModel
    {
        public TournamentResultModel()
        {
            TeamResult = new List<TeamResult>();
        }
        public List<TeamResult> TeamResult { get; set; }
    }
}