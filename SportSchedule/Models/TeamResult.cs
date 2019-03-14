namespace SportSchedule.Models
{
    public class TeamResult
    {
        public TeamResult()
        {

        }
        public TeamResult(Team team)
        {
            Team = team;
        }
        public Team Team;
        public int GamesCount { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int Points { get; set; }
    }
}