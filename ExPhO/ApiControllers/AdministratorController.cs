using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ExPho.Core.Context;
using ExPho.Core.Helpers;
using ExPhO.Core.Entities;
using ExPhO.Models;
using System.Collections.Generic;
using System;

namespace ExPhO.ApiControllers
{
    [Authorize(Roles = RolesHelper.ADMINISTRATOR)]
    public class AdministratorController:ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        OlympiadHelper helper = new OlympiadHelper();
        [HttpGet]
        public Olympiad GetOlympiad(int id)
        {
            var olympiad = helper.GetById(id);
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
        [HttpGet]
        public List<Visit> GetSchedule(int olympiadId)
        {
            return helper.GetById(olympiadId).Schedule.ToList();
        }
        [HttpPost]
        public List<Visit> CreateSchedule(CreateScheduleModel model)
        {
            var olympiad=helper.GetById(model.olympiadId);
            if (olympiad==null)
            {
                throw new HttpException(404, "Olympiad not found");
            }
            return helper.GenerateSchedule(olympiad, model.start, model.end);
        }
    }

    public class CreateScheduleModel
    {
        public int olympiadId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}