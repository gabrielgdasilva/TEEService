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
    public static class Bandeira
    {
        public static bool CadastrarBandeira(BandeiraModel _Bandeira)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "bandeiras "+
                                  "("+
                                  "string_bandeira"+
                                  ") "+
                                  "VALUES "+
                                  "("+
                                  "@string_bandeira"+
                                  ") "+
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@string_bandeira", SqlDbType.VarChar).Value = _Bandeira.BandeiraString;
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

        public static BandeiraModel DetalhesBandeira(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "b.id_bandeira," +
                                  "b.string_bandeira " +
                                  "FROM " +
                                  "bandeiras b " +
                                  "WHERE " +
                                  "b.id_bandeira = @id_bandeira";
                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = id;
                BandeiraModel _Bandeira = new BandeiraModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _Bandeira.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        _Bandeira.BandeiraString = dr["string_bandeira"].ToString();
                    }
                }
                dr.Close();
                return _Bandeira;
            }
        }

        public static List<BandeiraModel> TodasBandeiras()
        {
            List<BandeiraModel> listSaida = new List<BandeiraModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select b.id_bandeira, b.string_bandeira FROM bandeiras b";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BandeiraModel _Bandeira = new BandeiraModel();
                        _Bandeira.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        _Bandeira.BandeiraString = dr["string_bandeira"].ToString();
                        listSaida.Add(_Bandeira);
                    }
                   
                }
                return listSaida;
            }
        }

    }
}
