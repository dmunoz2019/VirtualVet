using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VetVirtualWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConsultasService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConsultasService.svc or ConsultasService.svc.cs at the Solution Explorer and start debugging.
    public class ConsultasService : IConsultasService
    {
        public void DeleteConsultaById(int id)
        {
            using (var context = new virtualvetEntities())
            {context.spEliminarConsulta(id);
            }

            }

        public List<ConsultaDto> GetAllConsultas()
        {
            using (var context = new virtualvetEntities())
            {

                var result = context.spObtenerConsultas();

                var consultas = result.Select(c => new ConsultaDto
                {
                    ConsultaID = c.ConsultaId,
                    Costo = c.Costo,
                    Descripcion = c.Descripcion,
                    Fecha = c.Fecha,
                    Mascotas = c.ConsultaId

                }).ToList();

                return consultas;


            }
        }

        ConsultaDto IConsultasService.GetConsultaById(int id)
        {
            using (var context = new virtualvetEntities())
            {
                var result = context.spObtenerConsultas();
                var consultas = result.Select(c => new ConsultaDto
                {
                    ConsultaID = c.ConsultaId,
                    Costo = c.Costo,
                    Descripcion = c.Descripcion,
                    Fecha = c.Fecha,
                    Mascotas = c.ConsultaId

                }).ToList();

                var consulta = consultas.Where(c => c.ConsultaID == id).FirstOrDefault();
                return consulta;
            }
            
        }

        void IConsultasService.UpdateConsulta(ConsultaDto consulta)
        {
            using (var context = new virtualvetEntities())
            {
                context.spActualizarConsulta(consulta.ConsultaID, consulta.Mascotas, consulta.Fecha, consulta.Descripcion, consulta.Costo);
                 
            }
          
        }
    }
}
