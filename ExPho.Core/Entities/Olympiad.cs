using System;
using System.Collections.Generic;

namespace ExPhO.Core.Entities
{
    public class Olympiad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Team> Teams { get; set; }
        public virtual List<Jury> Juries { get; set; }
        public virtual List<Visit> Schedule { get; set; }
    }
}