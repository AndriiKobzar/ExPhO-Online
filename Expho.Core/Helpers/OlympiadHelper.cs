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

        public void GenerateSchedule(Olympiad olympiad, DateTime start, DateTime end)
        {
            foreach (var team in olympiad.Teams)
            {
                foreach (var problem in olympiad.Problems)
                {
                    var visit = new Visit()
                    {

                    }
                }
            }
            throw new NotImplementedException();
        }

        public void PutMark(int olympiadId, int teamId, int problemId, double mark)
        {
            var olympiad = this.GetById(olympiadId);
            var team = olympiad.Teams.FirstOrDefault(t=>t.Id==teamId);
            var visit = team.Visits.FirstOrDefault(v=>v.Problem.Id==problemId);
            visit.Mark = mark;
            context.SaveChanges();
        }
    }
}
