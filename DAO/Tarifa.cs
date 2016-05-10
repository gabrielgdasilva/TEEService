using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Models;
using System.Data.SqlClient;
using DAO.Utilities;
using System.Data;

namespace DAO
{
    public static class Tarifa
    {
        public static bool CadastrarTarifa(TarifaModel _Tarifa)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "tarifas" +
                                  "(" +
                                  "id_distribuidora," +
                                  "id_tipoContrato," +
                                  "id_tipoSubGrupo," +
                                  "data_referencia," +
                                  "potencia_min," +
                                  "potencia_max," +
                                  "tarifa_tusd_np," +
                                  "tarifa_tusd_fp," +
                                  "tarifa_te_np," +
                                  "tarifa_te_fp," +
                                  "tarifa_ultrapassagem_np," +
                                  "tarifa_ultrapassagem_fp," +
                                  "demanda_tusd," +
                                  "id_bandeira" +
                                  ")" +
                                  "VALUES" +
                                  "(" +
                                  "@id_distribuidora," +
                                  "@id_tipoContrato,"+
                                  "@id_tipoSubGrupo,"+
                                  "@data_referencia,"+
                                  "@potencia_min,"+
                                  "@potencia_max,"+
                                  "@tarifa_tusd_np,"+
                                  "@tarifa_tusd_fp,"+
                                  "@tarifa_te_np,"+
                                  "@tarifa_te_fp,"+
                                  "@tarifa_ultrapassagem_np,"+
                                  "@tarifa_ultrapassagem_fp,"+
                                  "@demanda_tusd,"+
                                  "@id_bandeira"+
                                  ")" +
                                  "SELECT SCOPE_IDENTITY() AS ID";
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Tarifa.DistribuidoraID;
                cmd.Parameters.Add("@id_tipoContrato", SqlDbType.Int).Value = _Tarifa.TipoContratoID;
                cmd.Parameters.Add("@id_tipoSubGrupo", SqlDbType.Int).Value = _Tarifa.TipoSubGrupoID;
                cmd.Parameters.Add("@data_referencia", SqlDbType.DateTime).Value = _Tarifa.DataReferencia;
                cmd.Parameters.Add("@potencia_min", SqlDbType.Float).Value = _Tarifa.PotenciaMin;
                cmd.Parameters.Add("@potencia_max", SqlDbType.Float).Value = _Tarifa.PotenciaMax;
                cmd.Parameters.Add("@tarifa_tusd_np", SqlDbType.Float).Value = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@tarifa_tusd_fp", SqlDbType.Float).Value = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@tarifa_te_np", SqlDbType.Float).Value = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@tarifa_te_fp", SqlDbType.Float).Value = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@tarifa_ultrapassagem_np", SqlDbType.Float).Value = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
                cmd.Parameters.Add("@tarifa_ultrapassagem_fp", SqlDbType.Float).Value = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
                cmd.Parameters.Add("@demanda_tusd", SqlDbType.Float).Value = _Tarifa.DemandaTUSD_TarifaPreco;
                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = _Tarifa.BandeiraID;

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

        public static TarifaModel DestalhesDaTarifa(int id)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText ="Select " +
                                 "t.id_tarifa,"+
                                 "t.id_distribuidora," +
                                 "t.id_tipoContrato," +
                                 "t.id_tipoSubGrupo," +
                                 "t.data_referencia," +
                                 "t.potencia_min," +
                                 "t.potencia_max," +
                                 "t.tarifa_tusd_np," +
                                 "t.tarifa_tusd_fp," +
                                 "t.tarifa_te_np," +
                                 "t.tarifa_te_fp," +
                                 "t.tarifa_ultrapassagem_np," +
                                 "t.tarifa_ultrapassagem_fp," +
                                 "t.demanda_tusd," +
                                 "t.id_bandeira" +
                                 "FROM" +
                                 "tarifas t" +
                                 "WHERE " +
                                 "t.id_tarifa = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                TarifaModel _Tarifa = new TarifaModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                 
                        _Tarifa.TarifaID = Convert.ToInt32(dr["id_tarifa"]);
                        _Tarifa.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Tarifa.TipoContratoID = Convert.ToInt32(dr["id_tipoContrato"]);
                        _Tarifa.TipoSubGrupoID = Convert.ToInt32(dr["id_tipoSubGrupo"]);
                        _Tarifa.DataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Tarifa.PotenciaMin = Convert.ToSingle(dr["potencia_min"]);
                        _Tarifa.PotenciaMax = Convert.ToSingle(dr["potencia_max"]);
                        _Tarifa.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["tarifa_tusd_np"]);
                        _Tarifa.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["tarifa_tusd_fp"]);
                        _Tarifa.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["tarifa_te_np"]);
                        _Tarifa.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["tarifa_te_fp"]);
                        _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["tarifa_ultrapassagem_np"]);
                        _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["tarifa_ultrapassagem_fp"]);
                        _Tarifa.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demanda_tusd"]);
                        _Tarifa.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);

                    }
                }
                dr.Close();
                return _Tarifa;
            }
        }

        public static List<TarifaModel> TodasTarifas()
        {
            List<TarifaModel> listaSaida = new List<TarifaModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " +
                                 "t.id_tarifa," +
                                 "t.id_distribuidora," +
                                 "t.id_tipoContrato," +
                                 "t.id_tipoSubGrupo," +
                                 "t.data_referencia," +
                                 "t.potencia_min," +
                                 "t.potencia_max," +
                                 "t.tarifa_tusd_np," +
                                 "t.tarifa_tusd_fp," +
                                 "t.tarifa_te_np," +
                                 "t.tarifa_te_fp," +
                                 "t.tarifa_ultrapassagem_np," +
                                 "t.tarifa_ultrapassagem_fp," +
                                 "t.demanda_tusd," +
                                 "t.id_bandeira " +
                                 "FROM " +
                                 "tarifas t;";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TarifaModel _Tarifa = new TarifaModel();
                        _Tarifa.TarifaID = Convert.ToInt32(dr["id_tarifa"]);
                        _Tarifa.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Tarifa.TipoContratoID = Convert.ToInt32(dr["id_tipoContrato"]);
                        _Tarifa.TipoSubGrupoID = Convert.ToInt32(dr["id_tipoSubGrupo"]);
                        _Tarifa.DataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Tarifa.PotenciaMin = Convert.ToSingle(dr["potencia_min"]);
                        _Tarifa.PotenciaMax = Convert.ToSingle(dr["potencia_max"]);
                        _Tarifa.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["tarifa_tusd_np"]);
                        _Tarifa.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["tarifa_tusd_fp"]);
                        _Tarifa.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["tarifa_te_np"]);
                        _Tarifa.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["tarifa_te_fp"]);
                        _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["tarifa_ultrapassagem_np"]);
                        _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["tarifa_ultrapassagem_fp"]);
                        _Tarifa.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demanda_tusd"]);
                        _Tarifa.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        listaSaida.Add(_Tarifa);
                    }
                }
                return listaSaida;
            }
        }

        public static bool AtualizarTarifa(TarifaModel _Tarifa)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE " +
                                  "tarifas" +
                                  "SET" +
                                  "id_tarifa = @id_tarifa, " +
                                  "id_distribuidora = @id_distribuidora," +
                                  "id_tipoContrato = @id_tipoContrato," +
                                  "id_tipoSubGrupo = @id_tipoSubGrupo," +
                                  "data_referencia = @data_referencia," +
                                  "potencia_min = @potencia_min," +
                                  "potencia_max = @potencia_max," +
                                  "tarifa_tusd_np = @tarifa_tusd_fp," +
                                  "tarifa_te_np = @tarifa_te_np," +
                                  "tarifa_te_fp = @tarifa_te_fp," +
                                  "tarifa_ultrapassagem_np = @tarifa_ultrapassagem_np," +
                                  "tarifa_ultrapassagem_fp = @tarifa_ultrapassagem_fp," +
                                  "demanda_tusd = @demanda_tusd," +
                                  "id_bandeira = @id_bandeira" +
                                  "WHERE " +
                                  "id_tarifa = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _Tarifa.TarifaID;
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Tarifa.DistribuidoraID;
                cmd.Parameters.Add("@id_tipoContrato", SqlDbType.Int).Value = _Tarifa.TipoContratoID;
                cmd.Parameters.Add("@id_tipoSubGrupo", SqlDbType.Int).Value = _Tarifa.TipoSubGrupoID;
                cmd.Parameters.Add("@data_referencia", SqlDbType.DateTime).Value = _Tarifa.DataReferencia;
                cmd.Parameters.Add("@potencia_min", SqlDbType.Float).Value = _Tarifa.PotenciaMin;
                cmd.Parameters.Add("@potencia_max", SqlDbType.Float).Value = _Tarifa.PotenciaMax;
                cmd.Parameters.Add("@tarifa_tusd_np", SqlDbType.Float).Value = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@tarifa_tusd_fp", SqlDbType.Float).Value = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@tarifa_te_np", SqlDbType.Float).Value = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@tarifa_te_fp", SqlDbType.Float).Value = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@tarifa_ultrapassagem_np", SqlDbType.Float).Value = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
                cmd.Parameters.Add("@tarifa_ultrapassagem_fp", SqlDbType.Float).Value = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
                cmd.Parameters.Add("@demanda_tusd", SqlDbType.Float).Value = _Tarifa.DemandaTUSD_TarifaPreco;
                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = _Tarifa.BandeiraID;

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

        public static bool DeletarTarifa(TarifaModel _Tarifa)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM tarifas WHERE id_tarifa = @id_tarifa";
                cmd.Parameters.Add("@id_tarifa", SqlDbType.Int).Value = _Tarifa.TarifaID;
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
