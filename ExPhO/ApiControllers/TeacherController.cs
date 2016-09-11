using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using ExPho.Core.Context;
using ExPho.Core.Heplers;
using ExPhO.Core.Entities;

namespace ExPhO.ApiControllers
{
    [Authorize(Roles = RolesHelper.TEACHER)]
    public class TeacherController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public HttpResponseMessage AddTeam(int olympiadId, TeamModel team)
        {
            var olympiad = _context.Olympiads.FirstOrDefault(o => o.Id == olympiadId);
            var _team = new Team()
            {
                Name = team.Name,
            };
            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}