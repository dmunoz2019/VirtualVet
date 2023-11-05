using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VetVirtualWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MascotaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MascotaService.svc or MascotaService.svc.cs at the Solution Explorer and start debugging.
    public class MascotaService : IMascotaService
    {
        public void InsertMascota(MascotaDto Mascota)
        {
            using (var context = new virtualvetEntities())
            {
                context.spAgregarMascota(Mascota.ClienteId, Mascota.Nombre, Mascota.Especie, Mascota.Raza, Mascota.FechaNacimiento);
            }

        }

        void IMascotaService.DeleteMascotaById(int id)
        {
            using (var context = new virtualvetEntities())
            {
                context.spEliminarMascota(id);
            }
        }

        List<MascotaDto> IMascotaService.GetAllMascotas()
        {
            using (var context = new virtualvetEntities())
            {
                // La llamada al procedimiento almacenado retorna ObjectResult<spObtenerClientes_Result>
                var result = context.spObtenerMascotas();

                // Convierte el resultado en una lista de DTOs.
                var mascotas = result.Select(c => new MascotaDto
                {
                    MascotaId = c.MascotaId,
                    ClienteId = c.ClienteId,
                    Nombre = c.Nombre,
                    Especie = c.Especie,
                    Raza = c.Raza,
                    FechaNacimiento = c.FechaNacimiento

                }).ToList();

                return mascotas;
            }
         }

        MascotaDto IMascotaService.GetMascotaById(int id)
        {
            using (var context = new virtualvetEntities())
            {
                // La llamada al procedimiento almacenado retorna ObjectResult<spObtenerClientes_Result>
                var result = context.spObtenerMascotas();



                var mascotas = result.Select(c => new MascotaDto
                {
                    MascotaId = c.MascotaId,
                    ClienteId = c.ClienteId,
                    Nombre = c.Nombre,
                    Especie = c.Especie,
                    Raza = c.Raza,
                    FechaNacimiento = c.FechaNacimiento
                }).ToList();

                var mascota = mascotas.Where(c => c.MascotaId == id).FirstOrDefault();


                return mascota;
            }
        }

        void IMascotaService.UpdateMascota(MascotaDto Mascota)
        {

            using (var context = new virtualvetEntities())
            {
                context.spActualizarMascota(Mascota.MascotaId, Mascota.ClienteId, Mascota.Nombre, Mascota.Especie, Mascota.Raza, Mascota.FechaNacimiento);
            }
            
        }
    }



}
