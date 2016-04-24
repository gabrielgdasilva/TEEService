using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class UsuarioModel
    {
        public string Email { get; set; }
        public int ClienteID { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Tipo { get; set; }
        
    }
}
