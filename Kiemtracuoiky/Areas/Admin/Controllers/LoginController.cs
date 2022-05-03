using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kiemtracuoiky.Areas.Admin.Data;

namespace Kiemtracuoiky.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private AdminDB db = new AdminDB();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var tendn = email;
            var matkhau = password;
            var kh = db.QTVs.SingleOrDefault(s => s.Email == tendn && s.Matkhau == matkhau);
            if (kh != null)
            {
                Session["admin"] = kh.Hoten;
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng.");
                return View();
            }              
        }
        public ActionResult registration()
        {
            return View();
        }
        
    }
}