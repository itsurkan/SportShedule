using System.ComponentModel.DataAnnotations;

namespace SportSchedule.Models
{
    public class Team
    {
        public Team()
        {

        }
        public Team(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}