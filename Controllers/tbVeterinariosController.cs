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
    public class tbVeterinariosController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();

        // GET: tbVeterinarios
        public ActionResult Index()
        {
            var tbVeterinarios = db.tbVeterinarios.Include(t => t.tbAreas).Include(t => t.tbLocalidades).Include(t => t.tbTipoPersonal);
            return View(tbVeterinarios.ToList());
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

        // GET: tbVeterinarios/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbVeterinarios tbVeterinarios = db.tbVeterinarios.Find(id);
            if (tbVeterinarios == null)
            {
                return HttpNotFound();
            }
            return View(tbVeterinarios);
        }

        // GET: tbVeterinarios/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado");
            ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio");
            ViewBag.IdArea = new SelectList(db.tbAreas, "IdArea", "Area");
            ViewBag.IdLocalidad = new SelectList(db.tbLocalidades, "IdLocalidad", "Localidad");
            ViewBag.IdTipoPer = new SelectList(db.tbTipoPersonal, "IdTipoPer", "Tipo");
            return View();
        }

        // POST: tbVeterinarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVet,Nombre,ApellidoPaterno,ApellidoMaterno,Calle,NumExt,NumInt,CodigoPostal,IdEstado,IdMunicipio,IdLocalidad,NSS,CURP,Telefono,SueldoXDia,TarjetaCredito,IdTipoPer,IdArea")] tbVeterinarios tbVeterinarios)
        {
            if (ModelState.IsValid)
            {
                db.tbVeterinarios.Add(tbVeterinarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArea = new SelectList(db.tbAreas, "IdArea", "Area"); //, tbVeterinarios.IdArea
            ViewBag.IdEstado = new SelectList(db.tbEstados, "IdEstado", "Estado"); //, tbVeterinarios.tbLocalidades.tbMunicipios.IdEstado
            //ViewBag.IdMunicipio = new SelectList(db.tbMunicipios, "IdMunicipio", "Municipio", tbVeterinarios.tbLocalidades.IdMunicipio);
            //ViewBag.IdLocalidad = new SelectList(db.tbLocalidades, "IdLocalidad", "Localidad", tbVeterinarios.IdLocalidad);
            ViewBag.IdTipoPer = new SelectList(db.tbTipoPersonal, "IdTipoPer", "Tipo", tbVeterinarios.IdTipoPer);
            return View(tbVeterinarios);
        }

        // GET: tbVeterinarios/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbVeterinarios tbVeterinarios = db.tbVeterinarios.Find(id);
            if (tbVeterinarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArea = new SelectList(db.tbAreas, "IdArea", "Area", tbVeterinarios.IdArea);
            ViewBag.IdLocalidad = new SelectList(db.tbLocalidades, "IdLocalidad", "Localidad", tbVeterinarios.IdLocalidad);
            ViewBag.IdTipoPer = new SelectList(db.tbTipoPersonal, "IdTipoPer", "Tipo", tbVeterinarios.IdTipoPer);
            return View(tbVeterinarios);
        }

        // POST: tbVeterinarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVet,Nombre,ApellidoPaterno,ApellidoMaterno,Calle,NumExt,NumInt,CodigoPostal,IdLocalidad,NSS,CURP,Telefono,SueldoXDia,TarjetaCredito,IdTipoPer,IdArea")] tbVeterinarios tbVeterinarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbVeterinarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArea = new SelectList(db.tbAreas, "IdArea", "Area", tbVeterinarios.IdArea);
            ViewBag.IdLocalidad = new SelectList(db.tbLocalidades, "IdLocalidad", "Localidad", tbVeterinarios.IdLocalidad);
            ViewBag.IdTipoPer = new SelectList(db.tbTipoPersonal, "IdTipoPer", "Tipo", tbVeterinarios.IdTipoPer);
            return View(tbVeterinarios);
        }

        // GET: tbVeterinarios/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbVeterinarios tbVeterinarios = db.tbVeterinarios.Find(id);
            if (tbVeterinarios == null)
            {
                return HttpNotFound();
            }
            return View(tbVeterinarios);
        }

        // POST: tbVeterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbVeterinarios tbVeterinarios = db.tbVeterinarios.Find(id);
            db.tbVeterinarios.Remove(tbVeterinarios);
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
