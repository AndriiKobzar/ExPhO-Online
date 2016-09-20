using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public double Mark { get; set; }

        public virtual Olympiad Olympiad { get; set; }
        public virtual Team Team { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
