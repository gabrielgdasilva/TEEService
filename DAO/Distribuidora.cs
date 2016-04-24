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
    public static class Distribuidora
    {
        public static bool CadastrarDistribuidora(DistribuidoraModel _Distribuidora)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "distribuidoras" +
                                  "(" +
                                  "nome," +
                                  "cnpj_empresa"+
                                  ")" +
                                  "VALUES" +
                                  "(" +
                                  "@nome" +
                                  "@cnpj_empresa" +
                                  ")" +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = _Distribuidora.Nome;
                cmd.Parameters.Add("@cnpj_empresa", SqlDbType.VarChar).Value = _Distribuidora.Cnpj;

                //int BandeiraID = 0;
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

        public static DistribuidoraModel DetalhesDistribuidora(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                  "d.id_distribuidora," +
                                  "d.nome"+
                                  "d.cnpj_empresa" +
                                  "FROM" +
                                  "distribuidoras d" +
                                  "WHERE " +
                                  "d.id_distribuidora = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                DistribuidoraModel _Distribuidora = new DistribuidoraModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _Distribuidora.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Distribuidora.Nome = dr["nome"].ToString();
                        _Distribuidora.Cnpj = dr["cnpj_empresa"].ToString();
                    }
                }
                dr.Close();
                return _Distribuidora;
            }
        }

        public static List<DistribuidoraModel> TodasDistribuidoras()
        {
            List<DistribuidoraModel> listSaida = new List<DistribuidoraModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select d.id_distribuidora, d.nome, d.cnpj_empresa, FROM distribuidoras d";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DistribuidoraModel _Distribuidora = new DistribuidoraModel();

                        _Distribuidora.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Distribuidora.Nome = dr["nome"].ToString();
                        _Distribuidora.Cnpj = dr["cnpj_empresa"].ToString();

                        listSaida.Add(_Distribuidora);
                    }

                }
                return listSaida;
            }
        }
    }
}
