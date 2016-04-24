using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TEEService.DataContracts
{
    [DataContract]
    public class Conta
    {
        [DataMember]
        public DateTime dataReferencia { get; set; }
        [DataMember]
        public int TarifaID { get; set; }
        [DataMember]
        public int FabricaID { get; set; }
        [DataMember]
        public int DistribuidoraID { get; set; }
        [DataMember]
        public int TipoContratoID { get; set; }
        [DataMember]
        public int TipoSubGrupoID { get; set; }
        [DataMember]
        public float ConsumoNaPontaTUSD_Registrado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTUSD_Registrado { get; set; }
        [DataMember]
        public float ConsumoNaPontaTE_Registrado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTE_Registrado { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemNaPonta_Registrado { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemForaPonta_Registrado { get; set; }
        [DataMember]
        public float DemandaTUSD_Registrado { get; set; }
        [DataMember]
        public float ConsumoNaPontaTUSD_Contratado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTUSD_Contratado { get; set; }
        [DataMember]
        public float ConsumoNaPontaTE_Contratado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTE_Contratado { get; set; }
        [DataMember]
        public float DemandaTUSD_Contratado { get; set; }
        [DataMember]
        public float ConsumoNaPontaTUSD_Faturado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTUSD_Faturado { get; set; }
        [DataMember]
        public float ConsumoNaPontaTE_Faturado { get; set; }
        [DataMember]
        public float ConsumoForaPontaTE_Faturado { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemNaPonta_Faturado { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemForaPonta_Faturado { get; set; }
        [DataMember]
        public float DemandaTUSD_Faturado { get; set; }
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
        public float ConsumoNaPontaTUSD_Valor { get; set; }
        [DataMember]
        public float ConsumoForaPontaTUSD_Valor { get; set; }
        [DataMember]
        public float ConsumoNaPontaTE_Valor { get; set; }
        [DataMember]
        public float ConsumoForaPontaTE_Valor { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemNaPonta_Valor { get; set; }
        [DataMember]
        public float ConsumoUltrapassagemForaPonta_Valor { get; set; }
        [DataMember]
        public float DemandaTUSD_Valor { get; set; }
        [DataMember]
        public float SubTotal { get; set; }
        [DataMember]
        public float ValorTotal { get; set; }
        [DataMember]
        public int BandeiraID { get; set; }
    }
}