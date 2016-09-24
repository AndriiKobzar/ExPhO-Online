using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using ExPho.Core.Context;
using ExPho.Core.Helpers;
using ExPhO.Core.Entities;

namespace ExPhO.ApiControllers
{
    public class TeamController:ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        TeamHelper _helper = new TeamHelper();
        public Team GetTeam(int id)
        {
            var team = _helper.GetById(id);
            if (team == null)
            {
                throw new HttpException(404, "Team not found");
            }
            return team;
        }

        public List<Team> GetAllTeams(int olympiadId)
        {
            return _helper.GetAllForOlympiad(olympiadId);
        }
    }

    public class TeamModel
    {
        public string Name { get; set; }
        public string School { get; set; }
        public int TeacherId { get; set; }
        public int OlympiadId { get; set; }
        public List<LearnerModel> Members { get; set; }
    }

    public class LearnerModel
    {
        public string Name { get; set; }
        public int Form { get; set; }
        public string Email { get; set; }
    }
}