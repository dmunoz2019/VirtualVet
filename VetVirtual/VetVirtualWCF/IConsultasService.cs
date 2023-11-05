using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VetVirtualWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClienteService" in both code and config file together.
    [ServiceContract]
    public interface IConsultasService
    {
        [OperationContract]
        List<ConsultaDto> GetAllConsultas();

        [OperationContract]
        ConsultaDto GetConsultaById(int id);

        [OperationContract]
        void DeleteConsultaById(int id);
        [OperationContract]
        void UpdateConsulta(ConsultaDto cliente);
    }


    [DataContract]
    public class ConsultaDto
    {
    
        [DataMember]
        public int ConsultaID { get; set; }
        [DataMember]
        public decimal? Costo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public int? Mascotas { get; set; }

    }

}
