using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Models;
using System.Data.SqlClient;
using System.Data;
using DAO.Utilities;

namespace DAO
{
    public static class TipoContrato
    {
        public static bool CadastrarContrato(TipoContratoModel _TipoContrato)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "tipos_contrato" +
                                  "(" +
                                  "string_tipocontrato" +
                                  ")" +
                                  "VALUES" +
                                  "(" +
                                  "@string_tipocontrato" +
                                  ")" +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@string_tipocontrato", SqlDbType.VarChar).Value = _TipoContrato.TipoContratoString;
                
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

        public static TipoContratoModel DetalhesContrato(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                  "c.id_tipocontrato,"+
                                  "c.string_tipocontrato" +
                                  "FROM" +
                                  "tipos_contrato c" +
                                  "WHERE " +
                                  "c.id_tipocontrato = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                TipoContratoModel _TipoContrato = new TipoContratoModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _TipoContrato.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _TipoContrato.TipoContratoString = dr["string_tipocontrato"].ToString();
                    }
                }
                dr.Close();
                return _TipoContrato;
            }
        }

        public static List<TipoContratoModel> TodosContratos()
        {
            List<TipoContratoModel> listSaida = new List<TipoContratoModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select c.id_tipocontrato, c.string_tipocontrato FROM tipos_contrato c";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TipoContratoModel _Contrato = new TipoContratoModel();
                        _Contrato.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Contrato.TipoContratoString = dr["string_tipocontrato"].ToString();
                        listSaida.Add(_Contrato);
                    }

                }
                return listSaida;
            }
        }
    }
}
