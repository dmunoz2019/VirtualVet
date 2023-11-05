using DAL.Entities;
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
    public interface IClienteService
    {
        [OperationContract]
        List<ClienteDto> GetAllClientes();

        [OperationContract]
        ClienteDto GetClienteById(int id);

        [OperationContract]
        void DeleteClienteById(int id);
        [OperationContract]
        void UpdateCliente(ClienteDto cliente);
    }


    [DataContract]
    public class ClienteDto
    {
        [DataMember]
        public string Apellido{ get; set; }

        [DataMember]
        public int ClienteId { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Telefono { get; set; }

    }


}
