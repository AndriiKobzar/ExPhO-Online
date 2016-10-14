using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Helpers
{
    public class LearnerHelper
    {
        private ApplicationDbContext context;

        public LearnerHelper()
        {
            context = new ApplicationDbContext();
        }
        public Learner GetById(int id)
        {
            return context.Learners.Where(user => user.Id == id).FirstOrDefault();
        }
        public Learner GetByEmail(string email)
        {
            return context.Learners.Where(user => user.Email == email).FirstOrDefault();
        }
        public Learner Insert(Learner learner)
        {
            if (context.Learners.Where(l => l.Email == learner.Email).FirstOrDefault() == null)
            {
                context.Learners.Add(learner);
                context.SaveChanges();
                return learner;
            }
            throw new AlreadyExistsException("Learner already exists");
        }
    }
}
