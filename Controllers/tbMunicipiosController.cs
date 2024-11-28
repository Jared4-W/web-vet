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
    public class tbMunicipiosController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbMunicipios
        public ActionResult Index()
        {
            var tbMunicipios = db.tbMunicipios.Include(t => t.tbEstados);
            return View(tbMunicipios.ToList());
        }

        // GET: tbMunicipios/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // GET: tbMunicipios/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado");
            return View();
        }

        // POST: tbMunicipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMunicipio,Municipio,IdEstado")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.tbMunicipios.Add(tbMunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado", tbMunicipios.IdEstado);
            return View(tbMunicipios);
        }

        // GET: tbMunicipios/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado", tbMunicipios.IdEstado);
            return View(tbMunicipios);
        }

        // POST: tbMunicipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMunicipio,Municipio,IdEstado")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado", tbMunicipios.IdEstado);
            return View(tbMunicipios);
        }

        // GET: tbMunicipios/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // POST: tbMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            db.tbMunicipios.Remove(tbMunicipios);
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
