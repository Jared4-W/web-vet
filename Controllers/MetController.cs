using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen1_JaredChavez.Models;
namespace Examen1_JaredChavez.Controllers
{
    public class MetController : Controller
    {
        private MascotaEntities1 db = new MascotaEntities1();
        // GET: Met
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetMunicipios(int IdE)  //metodo para obtener los municipios
        {
            var tbMunicipios = db.tbMunicipios.Where(x => x.IdEstado == IdE).OrderBy(X => X.Municipio); //Se realiza una consulta a la base de datos
            List<SelectListItem> listamunicipios = new List<SelectListItem>();                          // para obtener todos los municipios                                                    
            // se crea la lista
            foreach (var fila in tbMunicipios)//Se recorre cada fila obtenida de la consulta
            {
                listamunicipios.Add(new SelectListItem
                {                                             
                    Value = fila.IdMunicipio.ToString(),       
                    Text = fila.Municipio
                }
                    );
            }//devuelve la lista de municipios en formato JSON y al usuario le aparecera como dropdownlist
            return Json(new SelectList(listamunicipios, "Value", "Text"));
        }

        [HttpPost]
        public JsonResult GetLocalidades(int IdL)//metodo para obtener los localidades
        {
            var tbLocalidades = db.tbLocalidades.Where(z => z.IdMunicipio == IdL).OrderBy(Z => Z.Localidad);//Se realiza una consulta a la base de datos
            List<SelectListItem> listalocalidad = new List<SelectListItem>();                               // para obtener todos los municipios  
             // se crea la lista
            foreach (var fila in tbLocalidades)//Se recorre cada fila obtenida de la consulta
            {
                listalocalidad.Add(new SelectListItem
                {
                    Value = fila.IdLocalidad.ToString(),
                    Text = fila.Localidad
                }
                    );
            }//devuelve la lista de municipios en formato JSON y al usuario le aparecera como dropdownlist
            return Json(new SelectList(listalocalidad, "Value", "Text"));
        }
    }
}