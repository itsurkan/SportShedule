using System.Collections.Generic;

namespace SportSchedule.Core.Models
{
    public class Tournament : IIDentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
