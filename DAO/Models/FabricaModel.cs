using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class FabricaModel
    {
        public int FabricaID { get; set; }
        public int ClienteID { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public int DistribuidoraID { get; set; }
        
    }
}
