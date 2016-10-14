using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Helpers
{
    public class TeacherHelper
    {
        private ApplicationDbContext context;

        public TeacherHelper()
        {
            context = new ApplicationDbContext();
        }
        public Teacher GetById(int id)
        {
            return context.Teachers.Where(user => user.Id == id).FirstOrDefault();
        }
        public Teacher GetByEmail(string email)
        {
            return context.Teachers.Where(user => user.Email == email).FirstOrDefault();
        }
        public Teacher Insert(Teacher teacher)
        {
            if (context.Teachers.Where(t => t.Email == teacher.Email).FirstOrDefault() == null)
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
                return teacher;
            }
            throw new AlreadyExistsException("Jury already exists.");
        }
    }
}
