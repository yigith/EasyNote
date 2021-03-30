using EasyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyNote.Areas.Admin.Controllers
{
    // Only users with admin role can access this controller's actions
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}