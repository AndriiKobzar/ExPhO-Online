using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Helpers
{
    public class JuryHelper
    {
        private ApplicationDbContext context;

        public JuryHelper()
        {
            context = new ApplicationDbContext();
        }
        public List<Jury> GetAllByOlympiad(int olympiadId)
        {
            var olympiad = new OlympiadHelper().GetById(olympiadId);
            if (olympiad!=null)
            {
                return olympiad.Juries.ToList();
            }
            throw new Exception();
        }
        public Jury GetById(int id)
        {
            return context.Juries.Where(user => user.Id == id).FirstOrDefault();
        }
        public Jury GetByEmail(string email)
        {
            return context.Juries.Where(user => user.Email == email).FirstOrDefault();
        }
        public Jury Insert(Jury jury)
        {
            context.Juries.Add(jury);
            context.SaveChanges();
            return jury;
        }
        public void PutMark(int olympiadId, int teamId, int problemId, double mark)
        {
            var olympiad = new OlympiadHelper().GetById(olympiadId);
            var team = olympiad.Teams.FirstOrDefault(t => t.Id == teamId);
            var visit = team.Visits.FirstOrDefault(v => v.Problem.Id == problemId);
            visit.Mark = mark;
            context.SaveChanges();
        }
        public List<Visit> GetSchedule(Olympiad olympiad, Jury jury)
        {
            return 
            (from visit 
            in olympiad.Schedule 
            where visit.Problem.Id==jury.Problem.Id 
            orderby visit.Time ascending 
            select visit).ToList();
        }
    }
}
