using ExPho.Core.Heplers;
using ExPhO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExPho.Core.Context;
using ExPhO.Core.Entities;

namespace ExPhO.Controllers
{
    [Authorize(Roles = RolesHelper.ADMINISTRATOR)]
    public class AdministratorController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateOlympiad(OlympiadModel model)
        {
            var olympiad = new Olympiad()
            {
                Name = model.Name,
                Date = model.Date,

            };
            _context.Olympiads.Add(olympiad);
            _context.SaveChanges();
            return Json(olympiad);
        }
    }
}