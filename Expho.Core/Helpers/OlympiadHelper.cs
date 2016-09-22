using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Heplers
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
            olympiad.Visits.Clear();

            var rnd = new Random();
            var sortedTeams = olympiad.Teams.ToList().OrderBy(s=>rnd.Next());
            var sortedProblems = olympiad.Tasks.ToList().OrderBy(s=>rnd.Next());

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
                        }
                        olympiad.Visits.Add(visit);
                        currentTime.AddMinutes(visitDuration);
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
                        }
                        olympiad.Visits.Add(visit);
                        currentTime.AddMinutes(visitDuration);
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

        public void PutMark(int olympiadId, int teamId, int problemId, double mark)
        {
            var olympiad = this.GetById(olympiadId);
            var team = olympiad.Teams.FirstOrDefault(t=>t.Id==teamId);
            var visit = team.Visits.FirstOrDefault(v=>v.Problem.Id==problemId);
            visit.Mark = mark;
            context.SaveChanges();
        }

        private List<DateTime> GenerateTimes(DateTime start, DateTime end, int count)
        {
            var duration = (start-end).Minutes/count;
            for (int i = 0; i < count; i++)
            {
                yield return start.AddMinutes(i*duration);
            }
            
        }

        private void CycleMove(IList collection)
        {
            throw new NotImplementedException();
        }
    }
}