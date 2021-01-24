using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;

namespace PieereTreats.Controllers
{
  public class HomeController : Controller
  {
      private readonly PierreTreatsContext _db;

      public HomeController(PierreTreatsContext db)
      {
          _db = db;
      }

      public ActionResult Index()
      {
          ViewBag.Treats = _db.Treats;
          ViewBag.Flavors = _db.Flavors;
          return View();
      }
  }
}