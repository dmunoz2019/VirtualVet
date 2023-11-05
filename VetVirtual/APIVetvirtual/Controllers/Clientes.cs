using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL; // Include your data access layer namespace here
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace APIVetvirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly virtualvetEntities _context; // Assuming virtualvetEntities is your DbContext

        public ClientesController(virtualvetEntities context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            var results = _context.spObtenerClientes();

            var clientes = results.Select(c => new Clientes
            {
                Apellido = c.Apellido,
                ClienteId = c.ClienteId,
                Email = c.Email,
                Nombre = c.Nombre,
                Telefono = c.Telefono

            }).ToList();

            return Task.FromResult<ActionResult<IEnumerable<Clientes>>>(clientes);


        }

    }
    }
