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
    public static class TipoSubGrupo
    {
        public static bool CadastrarSubGrupo(TipoSubGrupoModel _SubGrupo)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "tipos_subgrupo " +
                                  "(" +
                                  "string_tiposubgrupo" +
                                  ") " +
                                  "VALUES " +
                                  "(" +
                                  "@string_tiposubgrupo" +
                                  ") " +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@string_tiposubgrupo", SqlDbType.VarChar).Value = _SubGrupo.TipoSubGrupoString;
                
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

        public static TipoSubGrupoModel DetalhesSubGrupo(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "g.id_tiposubgrupo," +
                                  "g.string_tiposubgrupo " +
                                  "FROM " +
                                  "tipos_subgrupo g " +
                                  "WHERE " +
                                  "g.id_tiposubgrupo = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                TipoSubGrupoModel _SubGrupo = new TipoSubGrupoModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _SubGrupo.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubgrupo"]);
                        _SubGrupo.TipoSubGrupoString = dr["string_tiposubgrupo"].ToString();
                    }
                }
                dr.Close();
                return _SubGrupo;
            }
        }

        public static List<TipoSubGrupoModel> TodosSubGrupos()
        {
            List<TipoSubGrupoModel> listSaida = new List<TipoSubGrupoModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select g.id_tiposubgrupo, g.string_tiposubgrupo FROM tipos_subgrupo g";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TipoSubGrupoModel _SubGrupo = new TipoSubGrupoModel();
                        _SubGrupo.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubgrupo"]);
                        _SubGrupo.TipoSubGrupoString = dr["string_tiposubgrupo"].ToString();
                        listSaida.Add(_SubGrupo);
                    }

                }
                return listSaida;
            }
        }
    }
}
