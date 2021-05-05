using SportSchedule.Core.Models;

namespace SportSchedule.Core.Services.Contracts
{
    public interface IGameFactory
    {
        Game CreateGame(Team home, Team guest);
    }
}
