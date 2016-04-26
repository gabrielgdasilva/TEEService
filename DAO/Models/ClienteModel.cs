using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class ClienteModel
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        
    }
}
