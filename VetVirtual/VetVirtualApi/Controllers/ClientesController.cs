using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL; // Asegúrate de que este using apunte a la ubicación correcta de tu capa de acceso a datos.

namespace VetVirtualApi.Controllers
{
    public class ClientesController : Controller
    {
        private virtualvetEntities db = new virtualvetEntities(); // Instancia de tu contexto de Entity Framework.

        // GET: Clientes
        public ActionResult Index()
        {
            var clientesResults = db.spObtenerClientes().ToList();
            var clientes = new List<Clientes>(); 
            foreach (var result in clientesResults)
            {
                var cliente = new Clientes
                {
                    ClienteId = result.ClienteId,
                    Nombre = result.Nombre,
                    Apellido = result.Apellido,
                    Telefono = result.Telefono,
                    Email = result.Email
                    };
                clientes.Add(cliente);
                }

            return View(clientes);
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
