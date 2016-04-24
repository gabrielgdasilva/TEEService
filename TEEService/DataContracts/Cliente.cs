using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TEEService.DataContracts
{   
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int ClienteID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cnpj { get; set; }
        [DataMember]
        public string RazaoSocial { get; set; }
        [DataMember]
        public string Endereco { get; set; }
    }
}