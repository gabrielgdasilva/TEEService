using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class TarifaModel
    {
        public int TarifaID { get; set; }
        public int DistribuidoraID { get; set; }
        public int TipoContratoID { get; set; }
        public int TipoSubGrupoID { get; set; }
        public DateTime DataReferencia { get; set; }
        public float PotenciaMin { get; set; }
        public float PotenciaMax { get; set; }
        public float ConsumoNaPontaTUSD_TarifaPreco { get; set; }
        public float ConsumoForaPontaTUSD_TarifaPreco { get; set; }
        public float ConsumoNaPontaTE_TarifaPreco { get; set; }
        public float ConsumoForaPontaTE_TarifaPreco { get; set; }
        public float ConsumoUltrapassagemNaPonta_TarifaPreco { get; set; }
        public float ConsumoUltrapassagemForaPonta_TarifaPreco { get; set; }
        public float DemandaTUSD_TarifaPreco { get; set; }
        public int BandeiraID { get; set; }
    }
}
