using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen1_JaredChavez.Models;

namespace Examen1_JaredChavez.Controllers
{
    public class tbAreasController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbAreas
        public ActionResult Index()
        {
            return View(db.tbAreas.ToList());
        }

        // GET: tbAreas/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAreas tbAreas = db.tbAreas.Find(id);
            if (tbAreas == null)
            {
                return HttpNotFound();
            }
            return View(tbAreas);
        }

        // GET: tbAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArea,Area,Ubicacion")] tbAreas tbAreas)
        {
            if (ModelState.IsValid)
            {
                db.tbAreas.Add(tbAreas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAreas);
        }

        // GET: tbAreas/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAreas tbAreas = db.tbAreas.Find(id);
            if (tbAreas == null)
            {
                return HttpNotFound();
            }
            return View(tbAreas);
        }

        // POST: tbAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArea,Area,Ubicacion")] tbAreas tbAreas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAreas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbAreas);
        }

        // GET: tbAreas/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAreas tbAreas = db.tbAreas.Find(id);
            if (tbAreas == null)
            {
                return HttpNotFound();
            }
            return View(tbAreas);
        }

        // POST: tbAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbAreas tbAreas = db.tbAreas.Find(id);
            db.tbAreas.Remove(tbAreas);
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
