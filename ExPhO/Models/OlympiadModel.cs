using System;

namespace ExPhO.Models
{
    public class OlympiadModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    public class CreateScheduleModule
    {
        public int olympiadId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}