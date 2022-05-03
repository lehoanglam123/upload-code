using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kiemtracuoiky.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }   
    }
}