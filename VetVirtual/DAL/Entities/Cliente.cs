using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

// Entities/Cliente.cs
namespace DAL.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Method to call stored procedure to add a new client
        public static void AddNewCliente(virtualvetEntities context, string nombre, string apellido, string telefono, string email)
        {
            context.spAgregarCliente(nombre, apellido, telefono, email);
        }

        // Method to call stored procedure to update an existing client
        public void UpdateCliente(virtualvetEntities context)
        {
            context.spActualizarCliente(this.ClienteId, this.Nombre, this.Apellido, this.Telefono, this.Email);
        }

        // Method to call stored procedure to delete a client
        public static void DeleteCliente(virtualvetEntities context, int clienteId)
        {
            context.spEliminarCliente(clienteId);
        }

        // Method to retrieve all clients (assuming spObtenerClientes_Result is a generated type for the result)
        public static ObjectResult<spObtenerClientes_Result> GetAllClientes(virtualvetEntities context)
        {
            return context.spObtenerClientes();
        }
    }
}
