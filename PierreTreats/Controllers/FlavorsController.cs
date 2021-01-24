using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            _db.Flavors.Add(flavor)
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisFlavor = _db.Flavors
                .Include(flavor => flavor.Treats)
                .ThenInclude(join => join.Treat)
                .FirOrDefault(flavor => flavor.FlavorId == id);
            return view (thisFlavor);
        }

        public ActionResult AddTreat(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId". "TreatName");
            return View(thisFlavor);
        }
    }
}