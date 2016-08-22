using ExPho.Core.Context;
using ExPhO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Heplers
{
    public class ApplicationUserHelper
    {
        private ApplicationDbContext context;

        public ApplicationUserHelper()
        {
            context = new ApplicationDbContext();
        }
        public ApplicationUser GetById(string id)
        {
            return context.Users.Where(user => user.Id == id).FirstOrDefault();
        }
        public ApplicationUser GetByEmail(string email)
        {
            return context.Users.Where(user => user.Email == email).FirstOrDefault();
        }
    }
}
