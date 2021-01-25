using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using PierreTreats.Models;

namespace PierreTreats.Controllers
{
    public class FlavorsController: Controller
    {
        private readonly PierreTreatsContext _db;

        public FlavorsController(PierreTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flavor> flavorList = _db.Flavors.ToList();
            return View(flavorList);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisFlavor = _db.Flavors
                .Include(flavor => flavor.Treats)
                .ThenInclude(join => join.Treat)
                .FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [Authorize]
        public ActionResult AddTreat(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
            return View(thisFlavor);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddTreat(Flavor flavor, int TreatId)
        {
            if (TreatId != 0)
            {
                var returnedJoin = _db.TreatFlavor
                    .Any(join => join.TreatId == TreatId && join.FlavorId == flavor.FlavorId);
                if (!returnedJoin)
                {
                    _db.TreatFlavor.Add(new TreatFlavor () { TreatId = TreatId, FlavorId = flavor.FlavorId });
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = flavor.FlavorId });
        }
    }
}