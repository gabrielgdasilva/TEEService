using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class ContaModel
    {
        public DateTime dataReferencia { get; set; }
        public int TarifaID { get; set; }
        public int FabricaID { get; set; }
        public int DistribuidoraID { get; set; }
        public int TipoContratoID { get; set; }
        public int TipoSubGrupoID { get; set; }
        public float ConsumoNaPontaTUSD_Registrado { get; set; }
        public float ConsumoForaPontaTUSD_Registrado { get; set; }
        public float ConsumoNaPontaTE_Registrado { get; set; }
        public float ConsumoForaPontaTE_Registrado { get; set; }
        public float ConsumoUltrapassagemNaPonta_Registrado { get; set; }
        public float ConsumoUltrapassagemForaPonta_Registrado { get; set; }
        public float DemandaTUSD_Registrado { get; set; }
        public float ConsumoNaPontaTUSD_Contratado { get; set; }
        public float ConsumoForaPontaTUSD_Contratado { get; set; }
        public float ConsumoNaPontaTE_Contratado { get; set; }
        public float ConsumoForaPontaTE_Contratado { get; set; }
        public float DemandaTUSD_Contratado { get; set; }
        public float ConsumoNaPontaTUSD_Faturado { get; set; }
        public float ConsumoForaPontaTUSD_Faturado { get; set; }
        public float ConsumoNaPontaTE_Faturado { get; set; }
        public float ConsumoForaPontaTE_Faturado { get; set; }
        public float ConsumoUltrapassagemNaPonta_Faturado { get; set; }
        public float ConsumoUltrapassagemForaPonta_Faturado { get; set; }
        public float DemandaTUSD_Faturado { get; set; }
        public float ConsumoNaPontaTUSD_TarifaPreco { get; set; }
        public float ConsumoForaPontaTUSD_TarifaPreco { get; set; }
        public float ConsumoNaPontaTE_TarifaPreco { get; set; }
        public float ConsumoForaPontaTE_TarifaPreco { get; set; }
        public float ConsumoUltrapassagemNaPonta_TarifaPreco { get; set; }
        public float ConsumoUltrapassagemForaPonta_TarifaPreco { get; set; }
        public float DemandaTUSD_TarifaPreco { get; set; }
        public float ConsumoNaPontaTUSD_Valor { get; set; }
        public float ConsumoForaPontaTUSD_Valor { get; set; }
        public float ConsumoNaPontaTE_Valor { get; set; }
        public float ConsumoForaPontaTE_Valor { get; set; }
        public float ConsumoUltrapassagemNaPonta_Valor { get; set; }
        public float ConsumoUltrapassagemForaPonta_Valor { get; set; }
        public float DemandaTUSD_Valor { get; set; }
        public float SubTotal { get; set; }
        public float ValorTotal { get; set; }
        public int BandeiraID { get; set; }
    }
}
