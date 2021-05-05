using SportSchedule.Core.Models;

namespace SportSchedule.Core.Services.Contracts
{
    public interface IGameResultFactory
    {
        GameResult Create(Game game, int homeResult, int guestResult);
    }
}
