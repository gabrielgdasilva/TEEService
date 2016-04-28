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
    public static class Fabrica
    {
        
        public static bool CadastrarFabrica(FabricaModel _Fabrica)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "fabricas" +
                                  "(" +
                                  "id_cliente," +
                                  "cnpj_fabrica," +
                                  "endereco," +
                                  "id_distribuidora" +
                                  ")" +
                                  "VALUES" +
                                  "(" +
                                  "@id_cliente," +
                                  "@cnpj_fabrica," +
                                  "@endereco," +
                                  "@id_distribuidora" +
                                  ")" +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = _Fabrica.ClienteID;
                cmd.Parameters.Add("@cnpj_fabrica", SqlDbType.VarChar).Value = _Fabrica.Cnpj;
                cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = _Fabrica.Endereco;
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Fabrica.DistribuidoraID;

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

        public static FabricaModel DestalhesDaFabrica(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                 "f.id_fabrica," +
                                 "f.id_cliente," +
                                 "f.cnpj_fabrica," +
                                 "f.endereco," +
                                 "f.id_distribuidora" +
                                 "FROM" +
                                 "fabricas f" +
                                 "WHERE " +
                                 "f.id_fabrica = @id_fabrica";
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = id;
                FabricaModel _Fabrica = new FabricaModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _Fabrica.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Fabrica.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Fabrica.Cnpj = dr["cnpj_fabrica"].ToString();
                        _Fabrica.Endereco = dr["endereco"].ToString();
                        _Fabrica.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        
                    }
                }
                dr.Close();
                return _Fabrica;
            }
        }

        public static List<FabricaModel> TodasFabricas(int ClienteID)
        {
            List<FabricaModel> listaSaida = new List<FabricaModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                 "f.id_fabrica," +
                                 "f.id_cliente," +
                                 "f.cnpj_fabrica," +
                                 "f.endereco," +
                                 "f.id_distribuidora," +
                                 "FROM" +
                                 "fabricas f"+
                                 "WHERE"+
                                 "f.id_cliente = @id_cliente";
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = ClienteID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FabricaModel _Fabrica = new FabricaModel();
                        _Fabrica.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Fabrica.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Fabrica.Cnpj = dr["cnpj_fabrica"].ToString();
                        _Fabrica.Endereco = dr["endereco"].ToString();
                        _Fabrica.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        listaSaida.Add(_Fabrica);
                    }
                }
                return listaSaida;
            }
        }

        public static bool AtualizarFabrica(FabricaModel _Fabrica)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE " +
                                  "fabricas" +
                                  "SET" +
                                  "id_cliente = @id_cliente, " +
                                  "cnpj_fabrica = @cnpj_fabrica," +
                                  "endereco = @endereco," +
                                  "id_distribuidora = @id_distribuidora " +
                                  "WHERE "+
                                  "id_fabrica = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _Fabrica.FabricaID;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = _Fabrica.ClienteID;
                cmd.Parameters.Add("@cnpj_fabrica", SqlDbType.VarChar).Value = _Fabrica.Cnpj;
                cmd.Parameters.Add("@endereco", SqlDbType.DateTime).Value = _Fabrica.Endereco;
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Fabrica.DistribuidoraID;

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

        public static bool DeletarFabrica(FabricaModel _Fabrica)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM fabricas WHERE id_fabrica = @id_fabrica";
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = _Fabrica.FabricaID;
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
    }
}
