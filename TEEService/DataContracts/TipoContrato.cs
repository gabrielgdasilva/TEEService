using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TEEService.DataContracts
{   
    [DataContract]
    public class TipoContrato
    {   
        [DataMember]
        public int TipoContratoID { get; set; }
        [DataMember]
        public string TipoContratoString { get; set; }
    }
}