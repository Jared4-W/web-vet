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
    public class tbLocalidadesController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbLocalidades
        public ActionResult Index()
        {
            var tbLocalidades = db.tbLocalidades.Include(t => t.tbMunicipios);
            return View(tbLocalidades.ToList());
        }
        [HttpPost]
        public JsonResult GetMunicipios(int IdE)
        {
            var tbMunicipios = db.tbMunicipios.Where(x => x.IdEstado == IdE).OrderBy(X => X.Municipio);
            List<SelectListItem> listamunicipios = new List<SelectListItem>();

            foreach (var fila in tbMunicipios)
            {
                listamunicipios.Add(new SelectListItem
                {
                    Value = fila.IdMunicipio.ToString(),
                    Text = fila.Municipio
                }
                    );
            }
            return Json(new SelectList(listamunicipios, "Value", "Text"));
        }

        [HttpPost]
        public JsonResult GetLocalidades(int IdL)
        {
            var tbLocalidades = db.tbLocalidades.Where(z => z.IdMunicipio == IdL).OrderBy(Z => Z.Localidad);
            List<SelectListItem> listalocalidad = new List<SelectListItem>();

            foreach (var fila in tbLocalidades)
            {
                listalocalidad.Add(new SelectListItem
                {
                    Value = fila.IdLocalidad.ToString(),
                    Text = fila.Localidad
                }
                    );
            }
            return Json(new SelectList(listalocalidad, "Value", "Text"));
        }
        // GET: tbLocalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLocalidades tbLocalidades = db.tbLocalidades.Find(id);
            if (tbLocalidades == null)
            {
                return HttpNotFound();
            }
            return View(tbLocalidades);
        }

        // GET: tbLocalidades/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado");
            ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio");
            return View();
        }

        // POST: tbLocalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLocalidad,Localidad,IdMunicipio,IdEstado")] tbLocalidades tbLocalidades)
        {
            if (ModelState.IsValid)
            {
                db.tbLocalidades.Add(tbLocalidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado", tbLocalidades.tbMunicipios.IdEstado);

            ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio", tbLocalidades.IdMunicipio);
            return View(tbLocalidades);
        }

        // GET: tbLocalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLocalidades tbLocalidades = db.tbLocalidades.Find(id);
            if (tbLocalidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio", tbLocalidades.IdMunicipio);
            return View(tbLocalidades);
        }

        // POST: tbLocalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocalidad,Localidad,IdMunicipio")] tbLocalidades tbLocalidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbLocalidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio", tbLocalidades.IdMunicipio);
            return View(tbLocalidades);
        }

        // GET: tbLocalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLocalidades tbLocalidades = db.tbLocalidades.Find(id);
            if (tbLocalidades == null)
            {
                return HttpNotFound();
            }
            return View(tbLocalidades);
        }

        // POST: tbLocalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbLocalidades tbLocalidades = db.tbLocalidades.Find(id);
            db.tbLocalidades.Remove(tbLocalidades);
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
