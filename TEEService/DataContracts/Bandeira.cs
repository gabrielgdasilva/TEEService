using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TEEService.DataContracts
{
    [DataContract]
    public class Bandeira
    {
        [DataMember]
        public int BandeiraID { get; set; }
        [DataMember]
        public string BandeiraString { get; set; }
    }   
}