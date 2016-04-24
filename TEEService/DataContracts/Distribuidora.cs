using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TEEService.DataContracts
{
    [DataContract]
    public class Distribuidora
    {
        [DataMember]
        public int DistribuidoraID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cnpj { get; set; }
    }
}