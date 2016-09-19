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
    }
}
