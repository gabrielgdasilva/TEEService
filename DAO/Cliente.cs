using DAO.Models;
using DAO.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class Cliente
    {
        //Chamada no banco de dados para buscar detalhes de um cliente 
        public static ClienteModel DetalhesCliente(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                  "c.id_cliente," +
                                  "c.nome," +
                                  "c.cnpj_empresa," +
                                  "c.razao_social," +
                                  "c.endereco," +
                                  "FROM" +
                                  "clientes c" +
                                  "WHERE" +
                                  "c.id = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                ClienteModel _Cliente = new ClienteModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {  
                        _Cliente.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Cliente.Nome = dr["nome"].ToString();
                        _Cliente.Cnpj = dr["cnpj_empresa"].ToString();
                        _Cliente.RazaoSocial = dr["razao_social"].ToString();
                        _Cliente.Endereco = dr["endereco"].ToString();
                    }
                }
                dr.Close();
                return _Cliente;
            }
        }

        //Chamada ao banco de dados para cadastrar um cliente
        public static bool CadastrarCliente(ClienteModel _Cliente)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "   clientes " +
                                  "(" +
                                  "   nome, " +
                                  "   cnpj_empresa, " +
                                  "   razao_social, " +
                                  "   endereco " +
                                  ")" +
                                  "VALUES " +
                                  "(" +
                                  "   @nome, " +
                                  "   @cnpj_empresa, " +
                                  "   @razao_social, " +
                                  "   @endereco " +
                                  ")" +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = _Cliente.Nome;
                cmd.Parameters.Add("@cnpj_empresa", SqlDbType.VarChar).Value = _Cliente.Cnpj;
                cmd.Parameters.Add("@razao_social", SqlDbType.DateTime).Value = _Cliente.RazaoSocial;
                cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = _Cliente.Endereco;


                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    return false; 
                }
            }
        }


        public static bool AtualizarCliente(ClienteModel _Cliente)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE " +
                                  "   clientes " +
                                  "SET " +
                                  "   nome = @nome, " +
                                  "   cnpj_empresa = @cnpj_empresa, " +
                                  "   razao_social = @razao_social, " +
                                  "   endereco = @endereco " +
                                  "WHERE " +
                                  "   id_cliente = @id";

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _Cliente.ClienteID;
                cmd.Parameters.Add("@id_cliente", SqlDbType.VarChar).Value = _Cliente.Nome;
                cmd.Parameters.Add("@cnpj_empresa", SqlDbType.VarChar).Value = _Cliente.Cnpj;
                cmd.Parameters.Add("@razao_social", SqlDbType.DateTime).Value = _Cliente.RazaoSocial;
                cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = _Cliente.Endereco;

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    //throw;
                    return false;
                }

            }

        }

    }
}
