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
    public class tbEstadosController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbEstados
        public ActionResult Index()
        {
            var tbEstados = db.tbEstados.Include(t => t.IdEstado);
            return View(db.tbEstados.ToList());
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
        // GET: tbEstados/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstados tbEstados = db.tbEstados.Find(id);
            if (tbEstados == null)
            {
                return HttpNotFound();
            }
            return View(tbEstados);
        }

        // GET: tbEstados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbEstados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstado,Estado")] tbEstados tbEstados)
        {
            if (ModelState.IsValid)
            {
                db.tbEstados.Add(tbEstados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbEstados);
        }

        // GET: tbEstados/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstados tbEstados = db.tbEstados.Find(id);
            if (tbEstados == null)
            {
                return HttpNotFound();
            }
            return View(tbEstados);
        }

        // POST: tbEstados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstado,Estado")] tbEstados tbEstados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEstados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbEstados);
        }

        // GET: tbEstados/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstados tbEstados = db.tbEstados.Find(id);
            if (tbEstados == null)
            {
                return HttpNotFound();
            }
            return View(tbEstados);
        }

        // POST: tbEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbEstados tbEstados = db.tbEstados.Find(id);
            db.tbEstados.Remove(tbEstados);
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
