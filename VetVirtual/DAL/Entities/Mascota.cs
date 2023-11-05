using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Mascota
    {
        public int MascotaId { get; set; }
        public int? ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        // Method to call stored procedure to add a new pet
        public static void AddNewMascota(virtualvetEntities context, int clienteId, string nombre, string especie, string raza, DateTime fechaNacimiento)
        {
            context.spAgregarMascota(clienteId, nombre, especie, raza, fechaNacimiento);
        }

        // Method to call stored procedure to update an existing pet
        public void UpdateMascota(virtualvetEntities context)
        {
            context.spActualizarMascota(this.MascotaId, this.ClienteId, this.Nombre, this.Especie, this.Raza, this.FechaNacimiento);
        }

        // Method to call stored procedure to delete a pet
        public static void DeleteMascota(virtualvetEntities context, int mascotaId)
        {
            context.spEliminarMascota(mascotaId);
        }

        // Method to retrieve all pets (assuming spObtenerMascotas_Result is a generated type for the result)
        public static ObjectResult<spObtenerMascotas_Result> GetAllMascotas(virtualvetEntities context)
        {
            return context.spObtenerMascotas();
        }
    }
}
