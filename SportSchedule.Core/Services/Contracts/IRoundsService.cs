using SportSchedule.Core.Models;

namespace SportSchedule.Core.Services.Contracts
{
    public interface IRoundsService
    {
        Round[] CreateRoundsPerTournament(Tournament tournament);
    }
}
