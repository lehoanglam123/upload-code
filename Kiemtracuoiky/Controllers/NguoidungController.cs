using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kiemtracuoiky.Models;

namespace Kiemtracuoiky.Controllers
{
    public class NguoidungController : Controller
    {
        // GET: Nguoidung
        private UserCSDL dl = new UserCSDL();
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(string ten, string pas)
        {
            var name = ten;
            var pass = pas;
            var un = dl.Khachhangs.SingleOrDefault(k => k.Email == name && k.Matkhau == pass);
            if (un != null)
            {
                Session["User"] = un.Hoten;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng");
                return View();
            }
        }
        public ActionResult Dangky()
        {
            ViewBag.id = new SelectList(dl.Donhangs, "idKH", "idSP");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky([Bind(Include = "id,Hoten,SDT,Email,Matkhau")] Khachhang nguoidung)
        {
            if (ModelState.IsValid)
            {
                dl.Khachhangs.Add(nguoidung);
                dl.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(dl.Donhangs, "idKH", "idSP", nguoidung.id);
            return View(nguoidung);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dl.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}