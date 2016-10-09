using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities
{
    public class Learner:IOlympiadPerson
    {
        public int Id { get; set; }
        public int Form { get; set; }
        public virtual Team Team { get; set; }
    }
}
