using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities
{
    public class Jury:IOlympiadPerson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Institution { get; set; }
        public virtual List<Visit> Visits { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
