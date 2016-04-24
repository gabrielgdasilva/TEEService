using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TEEService.DataContracts
{
    [DataContract]
    public class Tarifa
    {
        [DataMember]
        public int TarifaID { get; set; }
        [DataMember]
        public int DistribuidoraID { get; set; }
        [DataMember]
        public int TipoContratoID { get; set; }
        [DataMember]
        public int TipoSubGrupoID { get; set; }
        [DataMember]
        public DateTime DataReferencia { get; set; }
        [DataMember]
        public float PotenciaMin { get; set; }
        [DataMember]
        public float PotenciaMax { get; set; }
        [DataMember]
        public float ConsumoNaPontaTUSD_TarifaPreco { get; set; }
        [DataMember]
        public float ConsumoForaPontaTUSD_TarifaPreco { get; set; }
        [DataMember]
        public float ConsumoNaPontaTE_TarifaPreco { get; set; }
        [DataMember]
        public float ConsumoForaPontaTE_TarifaPreco { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemNaPonta_TarifaPreco { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemForaPonta_TarifaPreco { get; set; }
        [DataMember]
        public float DemandaTUSD_TarifaPreco { get; set; }
        [DataMember]
        public int BandeiraID { get; set; }
    }
}