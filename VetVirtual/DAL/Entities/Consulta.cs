using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public int? MascotaId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal? Costo { get; set; }

        // Method to call stored procedure to add a new consultation
        public static void AddNewConsulta(virtualvetEntities context, int mascotaId, DateTime fecha, string descripcion, decimal costo)
        {
            context.spAgregarConsulta(mascotaId, fecha, descripcion, costo);
        }

        // Method to call stored procedure to update an existing consultation
        public void UpdateConsulta(virtualvetEntities context)
        {
            context.spActualizarConsulta(this.ConsultaId, this.MascotaId, this.Fecha, this.Descripcion, this.Costo);
        }

        // Method to call stored procedure to delete a consultation
        public static void DeleteConsulta(virtualvetEntities context, int consultaId)
        {
            context.spEliminarConsulta(consultaId);
        }

        // Method to retrieve all consultations (assuming spObtenerConsultas_Result is a generated type for the result)
        public static ObjectResult<spObtenerConsultas_Result> GetAllConsultas(virtualvetEntities context)
        {
            return context.spObtenerConsultas();
        }
    }
}
