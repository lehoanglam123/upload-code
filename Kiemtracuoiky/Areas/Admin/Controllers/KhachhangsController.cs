using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kiemtracuoiky.Areas.Admin.Data;

namespace Kiemtracuoiky.Areas.Admin.Controllers
{
    public class KhachhangsController : Controller
    {
        private AdminDB db = new AdminDB();

        // GET: Admin/Khachhangs
        public ActionResult Index()
        {
            var khachhangs = db.Khachhangs.Include(k => k.Donhang);
            return View(khachhangs.ToList());
        }

        // GET: Admin/Khachhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Donhangs, "idKH", "idSP");
            return View();
        }

        // POST: Admin/Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Hoten,SDT,Email,Matkhau")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Donhangs, "idKH", "idSP", khachhang.id);
            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Donhangs, "idKH", "idSP", khachhang.id);
            return View(khachhang);
        }

        // POST: Admin/Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Hoten,SDT,Email,Matkhau")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Donhangs, "idKH", "idSP", khachhang.id);
            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: Admin/Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khachhang khachhang = db.Khachhangs.Find(id);
            db.Khachhangs.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
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
