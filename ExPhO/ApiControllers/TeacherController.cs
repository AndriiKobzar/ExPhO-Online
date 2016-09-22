using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using ExPho.Core.Context;
using ExPho.Core.Heplers;
using ExPhO.Core.Entities;
using ExPhO.Utils;

namespace ExPhO.ApiControllers
{
    [Authorize(Roles = RolesHelper.TEACHER)]
    public class TeacherController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        const int maxTeamSize = 6;
        [HttpPost]
        public HttpResponseMessage AddTeam(int olympiadId, TeamModel team)
        {
            var olympiad = _context.Olympiads.FirstOrDefault(o => o.Id == olympiadId);
            if(team.Members!=null && team.Members.Count != 0 && team.Members.Count <= maxTeamSize)
            {
                team.Members.ForEach((learner) =>
                {
                    ApplicationUser user = new ApplicationUser() { };
                    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateAsync(user, PasswordUtil.GeneratePassword());
                });
            }
            var _team = new Team()
            {
                Name = team.Name,
            };
            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        public HttpResponseMessage AddTeamMember(int teamId, LearnerModel model)
        {
            new TeamHelper().GetById(teamId).Learners.Add(new Learner());
            _context.SaveSchanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}