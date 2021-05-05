﻿using System.Collections.Generic;

namespace SportSchedule.Core.Models
{
    public class Round : IIDentifiable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
