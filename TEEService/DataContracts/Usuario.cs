using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TEEService.DataContracts
{
    [DataContract]
    public class Usuario
    {

        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int ClienteID { get; set; }
        [DataMember]
        public string Cpf { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Senha { get; set; }
        [DataMember]
        public bool Ativo { get; set; }
        [DataMember]
        public DateTime DataRegistro { get; set; }
        [DataMember]
        public int Tipo { get; set; }
    }
}