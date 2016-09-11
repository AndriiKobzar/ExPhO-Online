using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ExPho.Core.Context;
using ExPho.Core.Heplers;
using ExPhO.Core.Entities;
using ExPhO.Models;

namespace ExPhO.ApiControllers
{
    [Authorize(Roles = RolesHelper.ADMINISTRATOR)]
    public class AdministratorController:ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        public Olympiad GetOlympiad(int id)
        {
            var olympiad = _context.Olympiads.FirstOrDefault(o => o.Id == id);
            if (olympiad == null)
            {
                throw new HttpException(404,"Olympiad not found");
            }
            return olympiad;
        }


        [HttpPost]
        public Olympiad CreateOlympiad(OlympiadModel model)
        {
            var olympiad = new Olympiad()
            {
                Name = model.Name,
                Date = model.Date,

            };
            _context.Olympiads.Add(olympiad);
            _context.SaveChanges();
            return olympiad;
        }

        public HttpResponseMessage AddJury(int olympiadId, int juryId)
        {
            var jury = _context.Juries.FirstOrDefault(t => t.Id == juryId);
            var olympiad = _context.Olympiads.FirstOrDefault((o => o.Id == olympiadId));
            if (jury == null)
            {
                throw new HttpException(404, "Jury not found");
            }
            if (olympiad == null)
            {
                throw new HttpException(404, "Olympiad not found");
            }
            olympiad.Juries.Add(jury);
            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}