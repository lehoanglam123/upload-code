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
    public class DanhmucsController : Controller
    {
        private AdminDB db = new AdminDB();

        // GET: Admin/Danhmucs
        public ActionResult Index()
        {
            return View(db.Danhmucs.ToList());
        }

        // GET: Admin/Danhmucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tendanhmuc")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Danhmucs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tendanhmuc")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            db.Danhmucs.Remove(danhmuc);
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
