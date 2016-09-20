using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities
{
    public class Jury
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public virtual List<Visit> Visits { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
