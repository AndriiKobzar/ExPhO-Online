using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities
{
    public class Team
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public virtual Olympiad Olympiad { get; set; }
        public virtual List<Learner> Learners { get; set; }
        public virtual List<Visit> Visits { get; set; }


        public double SumPoints => (from visit in Visits select visit.Mark).Sum();
    }
}

