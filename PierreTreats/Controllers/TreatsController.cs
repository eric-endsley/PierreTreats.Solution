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
    public class TreatsController : Controller
    {
        private readonly PierreTreatsContext _db;

        public TreatsController(PierreTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Treat> treatList = _db.Treats.ToList();
            return View(treatList);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
          
        }

        public ActionResult Details(int id)
        {
            var thisTreat = _db.Treats
                .Include(treat => treat.Flavors)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize]
        public ActionResult AddFlavor(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorId)
        {
            if (FlavorId != 0)
            {
                var returnedJoin = _db.TreatFlavor
                    .Any(join => join.FlavorId == FlavorId && join.TreatId == treat.TreatId);
                if (!returnedJoin)
                {
                    _db.TreatFlavor.Add(new TreatFlavor () { TreatId = treat.TreatId, FlavorId = FlavorId });
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = treat.TreatId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}