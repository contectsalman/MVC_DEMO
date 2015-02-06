using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bootstrapsdemo;

namespace Bootstrapsdemo.Controllers
{
    [Authorize]
   
    public class DeptartmentController : Controller
    {
        private firmEntities db = new firmEntities();

        [Authorize(Roles="V,A")]
        public ActionResult Index()
        {
        
            return View(db.tbl_dept.ToList());
        }

        // GET: Deptartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dept tbl_dept = db.tbl_dept.Find(id);
            if (tbl_dept == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dept);
        }
        [Authorize(Roles = "A")]
        // GET: Deptartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deptartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Did,D_Name,HOD,Gender")] tbl_dept tbl_dept)
        {
            if (ModelState.IsValid)
            {
                db.tbl_dept.Add(tbl_dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_dept);
        }

        // GET: Deptartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dept tbl_dept = db.tbl_dept.Find(id);
            if (tbl_dept == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dept);
        }

        // POST: Deptartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Did,D_Name,HOD,Gender")] tbl_dept tbl_dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_dept);
        }

        // GET: Deptartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dept tbl_dept = db.tbl_dept.Find(id);
            if (tbl_dept == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dept);
        }

        // POST: Deptartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_dept tbl_dept = db.tbl_dept.Find(id);
            db.tbl_dept.Remove(tbl_dept);
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
