using SportSchedule.Core.Models;
using SportSchedule.Core.Services.Contracts;

namespace SportSchedule.Core.Services
{
    public class GameFactory : IGameFactory
    {
        public Game CreateGame(Team home, Team guest)
        {
            return new Game
            {
                GuestTeam = guest,
                HomeTeam = home,
                GuestTeamId = guest.Id,
                HomeTeamId = home.Id,
                Result = null
            };
        }
    }
}
