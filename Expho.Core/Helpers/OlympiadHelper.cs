using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Helpers
{
    public class OlympiadHelper
    {
        private ApplicationDbContext context;

        public OlympiadHelper()
        {
            context = new ApplicationDbContext();
        }
        public Olympiad GetById(int id)
        {
            return context.Olympiads.Where(user => user.Id == id).FirstOrDefault();
        }

        public Olympiad Insert(Olympiad olympiad)
        {
            context.Olympiads.Add(olympiad);
            context.SaveChanges();
            return olympiad;
        }

        public List<Visit> GenerateSchedule(Olympiad olympiad, DateTime start, DateTime end)
        {         
            olympiad.Schedule.Clear();

            var rnd = new Random();
            var sortedTeams = olympiad.Teams.OrderBy(s=>rnd.Next()).ToList();
            var sortedProblems = olympiad.Problems.OrderBy(s=>rnd.Next()).ToList();

            var duration = (start-end).Minutes/Math.Max(sortedTeams.Count, sortedProblems.Count);

            var currentTime = start;
            var counter = 0;
            if (sortedProblems.Count>=sortedTeams.Count)
            {
                foreach (var team in sortedTeams)
                {
                    currentTime = start.AddMinutes(duration*counter);   
                    foreach (var problem in sortedProblems)
                    {
                        var visit = new Visit()
                        {
                            Olympiad = olympiad,
                            Team = team,
                            Problem = problem,
                            Time = currentTime
                        };
                        olympiad.Schedule.Add(visit);
                        currentTime.AddMinutes(duration);
                        if (currentTime>=end)
                        {
                            currentTime = start;
                        }
                    }
                    counter++;
                }
            }
            else
            {
                foreach (var problem in sortedProblems)
                {
                    currentTime = start.AddMinutes(duration*counter);   
                    foreach (var team in sortedTeams)
                    {
                        var visit = new Visit()
                        {
                            Olympiad = olympiad,
                            Team = team,
                            Problem = problem,
                            Time = currentTime
                        };
                        olympiad.Schedule.Add(visit);
                        currentTime.AddMinutes(duration);
                        if (currentTime>=end)
                        {
                            currentTime = start;
                        }
                    }
                    counter++;
                }
            }
            context.SaveChanges();
            return olympiad.Schedule;
        }
    }
}