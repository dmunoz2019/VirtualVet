using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL; // Asegúrate de que este using apunte a la ubicación correcta de tu capa de acceso a datos.

namespace VetVirtualApi.Controllers
{
    public class MascotasController : Controller
    {
        private virtualvetEntities db = new virtualvetEntities(); // Instancia de tu contexto de Entity Framework.

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotasResults = db.spObtenerMascotas().ToList();
            var mascotasList = new List<Mascotas>(); // Renamed to avoid confusion with the Mascotas class

            foreach (var result in mascotasResults)
            {
                var mascota = new Mascotas
                {
                    MascotaId = result.MascotaId,
                    Nombre = result.Nombre,
                    Especie = result.Especie, // Assuming you have this field in the result
                    Raza = result.Raza,
                    FechaNacimiento = result.FechaNacimiento // Assuming you have this field in the result
                                                             // Make sure to map all fields that your Mascotas entity requires
                };
                mascotasList.Add(mascota);
            }

            return View(mascotasList); // Pass the mapped list to the view
        }


        // GET: Mascotas/Details/5
        public ActionResult Details(int id)
        {
            var mascota = db.Mascotas.Find(id); // Encuentra una mascota por su ID.
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // Aquí puedes agregar otros métodos para Crear, Editar, Eliminar, etc.

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); // Asegúrate de desechar el contexto para liberar recursos.
            }
            base.Dispose(disposing);
        }
    }
}
