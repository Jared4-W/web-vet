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
    public class tbTipoPersonalsController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbTipoPersonals
        public ActionResult Index()
        {
            return View(db.tbTipoPersonal.ToList());
        }

        // GET: tbTipoPersonals/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoPersonal tbTipoPersonal = db.tbTipoPersonal.Find(id);
            if (tbTipoPersonal == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoPersonal);
        }

        // GET: tbTipoPersonals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbTipoPersonals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPer,Tipo")] tbTipoPersonal tbTipoPersonal)
        {
            if (ModelState.IsValid)
            {
                db.tbTipoPersonal.Add(tbTipoPersonal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTipoPersonal);
        }

        // GET: tbTipoPersonals/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoPersonal tbTipoPersonal = db.tbTipoPersonal.Find(id);
            if (tbTipoPersonal == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoPersonal);
        }

        // POST: tbTipoPersonals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPer,Tipo")] tbTipoPersonal tbTipoPersonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTipoPersonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbTipoPersonal);
        }

        // GET: tbTipoPersonals/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipoPersonal tbTipoPersonal = db.tbTipoPersonal.Find(id);
            if (tbTipoPersonal == null)
            {
                return HttpNotFound();
            }
            return View(tbTipoPersonal);
        }

        // POST: tbTipoPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbTipoPersonal tbTipoPersonal = db.tbTipoPersonal.Find(id);
            db.tbTipoPersonal.Remove(tbTipoPersonal);
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
