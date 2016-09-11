using System.Collections.Generic;
using System.Linq;
using ExPho.Core.Context;
using ExPhO.Core.Entities;

namespace ExPho.Core.Heplers
{
    public class TeamHelper
    {
        private ApplicationDbContext _context;

        public TeamHelper()
        {
            _context = new ApplicationDbContext();
        }

        public Team GetById(int id)
        {
            return _context.Teams.FirstOrDefault(t=>t.Id==id);
        }

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public List<Team> GetAllForOlympiad(int id)
        {
            return _context.Teams.Where(t => t.Olympiad.Id == id).ToList();
        }
    }
}