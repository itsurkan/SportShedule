using System;
using System.Linq;
using SportSchedule.Core.Models;
using SportSchedule.Core.Services.Contracts;

namespace SportSchedule.Core.Services
{
    public class TournamentFactory : ITournamentFactory
    {
        public Tournament Create(string name, int teamsCount)
        {
            if (teamsCount < 2)
            {
                throw new ArgumentException("Need more commands", nameof(teamsCount));
            }

            var tournament = new Tournament
            {
                Teams = Enumerable.Range(1, teamsCount)
                    .Select(x => new Team { Name = $"team{x}" })
                    .ToArray(),
                Name = string.IsNullOrEmpty(name) 
                    ? Guid.NewGuid().ToString() 
                    : name
            };

            return tournament;
        }
    }
}
