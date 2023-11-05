using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VetVirtualWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : IClienteService
    {
        public void DeleteClienteById(int id)
        {
            using (var context = new virtualvetEntities())
            {
                context.spEliminarCliente(id);
            }

            }

        public ClienteDto GetClienteById(int id)
        {
            // Vamos a usar el mismo procedimiento almacenado que usamos en GetAllClientes pero mediante un filtro.

            using (var context = new virtualvetEntities())
            {
                // La llamada al procedimiento almacenado retorna ObjectResult<spObtenerClientes_Result>
                var result = context.spObtenerClientes();

                // Convierte el resultado en una lista de DTOs.
                var clientes = result.Select(c => new ClienteDto
                {
                    Apellido = c.Apellido,
                    ClienteId = c.ClienteId,
                    Email = c.Email,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono

                }).ToList();

                // Filtra la lista de clientes por el id.
                var cliente = clientes.Where(c => c.ClienteId == id).FirstOrDefault();

                return cliente;
            }
        }

        public void UpdateCliente(ClienteDto cliente)
        {
            using (var context = new virtualvetEntities())
            {
                context.spActualizarCliente(cliente.ClienteId, cliente.Nombre, cliente.Apellido, cliente.Telefono, cliente.Email);
            }

        }
    

        List<ClienteDto> IClienteService.GetAllClientes()
        {

            using (var context = new virtualvetEntities())
            {
                // La llamada al procedimiento almacenado retorna ObjectResult<spObtenerClientes_Result>
                var result = context.spObtenerClientes();

                // Convierte el resultado en una lista de DTOs.
                var clientes = result.Select(c => new ClienteDto
                {
                    Apellido = c.Apellido,
                    ClienteId = c.ClienteId,
                    Email = c.Email,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono

                }).ToList();

                return clientes;
            }
        }
    }
}
