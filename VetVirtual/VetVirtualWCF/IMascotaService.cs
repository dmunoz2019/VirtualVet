using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VetVirtualWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMascotaService" in both code and config file together.
    [ServiceContract]
    public interface IMascotaService
    {
        [OperationContract]
        List<MascotaDto> GetAllMascotas();

        [OperationContract]
        MascotaDto GetMascotaById(int id);

        [OperationContract]
        void DeleteMascotaById(int id);
        [OperationContract]
        void UpdateMascota(MascotaDto Mascota);

        [OperationContract]
        void InsertMascota(MascotaDto Mascota);
    }

    [DataContract]
    public class MascotaDto
    {
        [DataMember]
        public int MascotaId { get; set; }
        [DataMember]
        public int? ClienteId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Especie { get; set; }
        [DataMember]
        public string Raza { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
    }
}
