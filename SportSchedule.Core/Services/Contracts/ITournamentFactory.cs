using SportSchedule.Core.Models;

namespace SportSchedule.Core.Services.Contracts
{
    public interface ITournamentFactory
    {
        Tournament Create(string name, int teamsCount);
    }
}
