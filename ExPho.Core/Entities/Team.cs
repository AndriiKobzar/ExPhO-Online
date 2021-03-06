﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPhO.Core.Entities

{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Team
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual List<Visit> Visits { get; set; }

        public double SumPoints => (from visit in Visits select visit.Mark).Sum();
    }
}

