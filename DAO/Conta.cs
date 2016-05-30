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
    public static class Conta
    {
        public static bool CadastrarConta(ContaModel _Conta)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "contas" +
                                  "(" +
                                  "data_referencia," +
                                  "id_tarifa," +
                                  "id_fabrica," +
                                  "id_distribuidora," +
                                  "id_tipocontrato," +
                                  "id_tiposubGrupo," +
                                  "consumoNaPontaTUSD_Registrado," +
                                  "consumoForaPontaTUSD_Registrado," +
                                  "consumoNaPontaTE_Registrado," +
                                  "consumoForaPontaTE_Registrado," +
                                  "consumoUltrapassagemNaPonta_Registrado," +
                                  "consumoUltrapassagemForaPonta_Registrado," +
                                  "demandaTUSD_Registrado," +
                                  "consumoNaPontaTUSD_Contratado," +
                                  "consumoForaPontaTUSD_Contratado," +
                                  "consumoNaPontaTE_Contratado," +
                                  "consumoForaPontaTE_Contratado," +
                                  "demandaTUSD_Contratado," +
                                  "consumoNaPontaTUSD_Faturado," +
                                  "consumoForaPontaTUSD_Faturado," +
                                  "consumoNaPontaTE_Faturado," +
                                  "consumoForaPontaTE_Faturado," +
                                  "consumoUltrapassagemNaPonta_Faturado," +
                                  "consumoUltrapassagemForaPonta_Faturado," +
                                  "demandaTUSD_Faturado," +
                                  "consumoNaPontaTUSD_TarifaPreco," +
                                  "consumoForaPontaTUSD_TarifaPreco," +
                                  "consumoNaPontaTE_TarifaPreco," +
                                  "consumoForaPontaTE_TarifaPreco," +
                                  "consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "demandaTUSD_TarifaPreco," +
                                  "consumoNaPontaTUSD_Valor," +
                                  "consumoForaPontaTUSD_Valor," +
                                  "consumoNaPontaTE_Valor," +
                                  "consumoForaPontaTE_Valor," +
                                  "consumoUltrapassagemNaPonta_Valor," +
                                  "consumoUltrapassagemForaPonta_Valor," +
                                  "demandaTUSD_Valor," +
                                  "subTotal," +
                                  "valorTotal," +
                                  "id_bandeira" +
                                  ")" +
                                  "VALUES " +
                                  "(" +
                                  "@data_referencia," +
                                  "@id_tarifa," +
                                  "@id_fabrica," +
                                  "@id_distribuidora," +
                                  "@id_tipocontrato," +
                                  "@id_tiposubGrupo," +
                                  "@consumoNaPontaTUSD_Registrado," +
                                  "@consumoForaPontaTUSD_Registrado," +
                                  "@consumoNaPontaTE_Registrado," +
                                  "@consumoForaPontaTE_Registrado," +
                                  "@consumoUltrapassagemNaPonta_Registrado," +
                                  "@consumoUltrapassagemForaPonta_Registrado," +
                                  "@demandaTUSD_Registrado," +
                                  "@consumoNaPontaTUSD_Contratado," +
                                  "@consumoForaPontaTUSD_Contratado," +
                                  "@consumoNaPontaTE_Contratado," +
                                  "@consumoForaPontaTE_Contratado," +
                                  "@demandaTUSD_Contratado," +
                                  "@consumoNaPontaTUSD_Faturado," +
                                  "@consumoForaPontaTUSD_Faturado," +
                                  "@consumoNaPontaTE_Faturado," +
                                  "@consumoForaPontaTE_Faturado," +
                                  "@consumoUltrapassagemNaPonta_Faturado," +
                                  "@consumoUltrapassagemForaPonta_Faturado," +
                                  "@demandaTUSD_Faturado," +
                                  "@consumoNaPontaTUSD_TarifaPreco," +
                                  "@consumoForaPontaTUSD_TarifaPreco," +
                                  "@consumoNaPontaTE_TarifaPreco," +
                                  "@consumoForaPontaTE_TarifaPreco," +
                                  "@consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "@consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "@demandaTUSD_TarifaPreco," +
                                  "@consumoNaPontaTUSD_Valor," +
                                  "@consumoForaPontaTUSD_Valor," +
                                  "@consumoNaPontaTE_Valor," +
                                  "@consumoForaPontaTE_Valor," +
                                  "@consumoUltrapassagemNaPonta_Valor," +
                                  "@consumoUltrapassagemForaPonta_Valor," +
                                  "@demandaTUSD_Valor," +
                                  "@subTotal," +
                                  "@valorTotal," +
                                  "@id_bandeira" +
                                  ") ";
                cmd.Parameters.Add("@data_referencia", SqlDbType.DateTime).Value = _Conta.dataReferencia;
                cmd.Parameters.Add("@id_tarifa", SqlDbType.Int).Value = _Conta.TarifaID;
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = _Conta.FabricaID;
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Conta.DistribuidoraID;
                cmd.Parameters.Add("@id_tipocontrato", SqlDbType.Int).Value = _Conta.TipoContratoID;
                cmd.Parameters.Add("@id_tiposubGrupo", SqlDbType.Int).Value = _Conta.TipoSubGrupoID;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Registrado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Registrado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Registrado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Registrado;
                cmd.Parameters.Add("@consumoNaPontaTE_Registrado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Registrado;
                cmd.Parameters.Add("@consumoForaPontaTE_Registrado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Registrado;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Registrado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Registrado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
                cmd.Parameters.Add("@demandaTUSD_Registrado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Registrado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Contratado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Contratado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Contratado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Contratado;
                cmd.Parameters.Add("@consumoNaPontaTE_Contratado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Contratado;
                cmd.Parameters.Add("@consumoForaPontaTE_Contratado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Contratado;
                cmd.Parameters.Add("@demandaTUSD_Contratado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Contratado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Faturado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Faturado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Faturado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Faturado;
                cmd.Parameters.Add("@consumoNaPontaTE_Faturado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Faturado;
                cmd.Parameters.Add("@consumoForaPontaTE_Faturado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Faturado;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Faturado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Faturado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
                cmd.Parameters.Add("@demandaTUSD_Faturado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Faturado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoForaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoNaPontaTE_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@consumoForaPontaTE_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
                cmd.Parameters.Add("@demandaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.DemandaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Valor", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Valor;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Valor", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Valor;
                cmd.Parameters.Add("@consumoNaPontaTE_Valor", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Valor;
                cmd.Parameters.Add("@consumoForaPontaTE_Valor", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Valor;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Valor", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Valor;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Valor", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Valor;
                cmd.Parameters.Add("@demandaTUSD_Valor", SqlDbType.Float).Value = _Conta.DemandaTUSD_Valor;
                cmd.Parameters.Add("@subTotal", SqlDbType.Float).Value = _Conta.SubTotal;
                cmd.Parameters.Add("@valorTotal", SqlDbType.Float).Value = _Conta.ValorTotal;
                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = _Conta.BandeiraID;

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

        

        public static ContaModel DestalhesDaConta(DateTime dataReferencia, int FabricaID)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "c.data_referencia," +
                                  "c.id_tarifa," +
                                  "c.id_fabrica," +
                                  "c.id_distribuidora," +
                                  "c.id_tipocontrato," +
                                  "c.id_tiposubGrupo," +
                                  "c.consumoNaPontaTUSD_Registrado," +
                                  "c.consumoForaPontaTUSD_Registrado," +
                                  "c.consumoNaPontaTE_Registrado," +
                                  "c.consumoForaPontaTE_Registrado," +
                                  "c.consumoUltrapassagemNaPonta_Registrado," +
                                  "c.consumoUltrapassagemForaPonta_Registrado," +
                                  "c.demandaTUSD_Registrado," +
                                  "c.consumoNaPontaTUSD_Contratado," +
                                  "c.consumoForaPontaTUSD_Contratado," +
                                  "c.consumoNaPontaTE_Contratado," +
                                  "c.consumoForaPontaTE_Contratado," +
                                  "c.demandaTUSD_Contratado," +
                                  "c.consumoNaPontaTUSD_Faturado," +
                                  "c.consumoForaPontaTUSD_Faturado," +
                                  "c.consumoNaPontaTE_Faturado," +
                                  "c.consumoForaPontaTE_Faturado," +
                                  "c.consumoUltrapassagemNaPonta_Faturado," +
                                  "c.consumoUltrapassagemForaPonta_Faturado," +
                                  "c.demandaTUSD_Faturado," +
                                  "c.consumoNaPontaTUSD_TarifaPreco," +
                                  "c.consumoForaPontaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTE_TarifaPreco," +
                                  "c.consumoForaPontaTE_TarifaPreco," +
                                  "c.consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "c.consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "c.demandaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTUSD_Valor," +
                                  "c.consumoForaPontaTUSD_Valor," +
                                  "c.consumoNaPontaTE_Valor," +
                                  "c.consumoForaPontaTE_Valor," +
                                  "c.consumoUltrapassagemNaPonta_Valor," +
                                  "c.consumoUltrapassagemForaPonta_Valor," +
                                  "c.demandaTUSD_Valor," +
                                  "c.subTotal," +
                                  "c.valorTotal," +
                                  "c.id_bandeira " +
                                 "FROM " +
                                 "contas c " +
                                 "WHERE " +
                                 "c.id_fabrica = @id_fabrica AND"+
                                 "(c.data_referencia BETWEEN @data_referencia1 AND @data_referencia2)";
                cmd.Parameters.Add("@data_referencia1", SqlDbType.DateTime).Value = dataReferencia;
                cmd.Parameters.Add("@data_referencia2", SqlDbType.DateTime).Value = dataReferencia.AddDays(1);
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = FabricaID;
                ContaModel _Conta = new ContaModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _Conta.dataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Conta.TarifaID = Convert.ToInt32(dr["id_tarifa"]);
                        _Conta.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Conta.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Conta.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Conta.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubGrupo"]);
                        _Conta.ConsumoNaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoNaPontaTUSD_Registrado"]);
                        _Conta.ConsumoForaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoForaPontaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTE_Registrado = Convert.ToSingle(dr["consumoNaPontaTE_Registrado"]);
                        _Conta.ConsumoForaPontaTE_Registrado = Convert.ToSingle(dr["consumoForaPontaTE_Registrado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Registrado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Registrado"]);
                        _Conta.DemandaTUSD_Registrado = Convert.ToSingle(dr["demandaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoNaPontaTUSD_Contratado"]);
                        _Conta.ConsumoForaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoForaPontaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTE_Contratado = Convert.ToSingle(dr["consumoNaPontaTE_Contratado"]);
                        _Conta.ConsumoForaPontaTE_Contratado = Convert.ToSingle(dr["consumoForaPontaTE_Contratado"]);
                        _Conta.DemandaTUSD_Contratado = Convert.ToSingle(dr["demandaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoNaPontaTUSD_Faturado"]);
                        _Conta.ConsumoForaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoForaPontaTUSD_Faturado"]);
                        _Conta.ConsumoNaPontaTE_Faturado = Convert.ToSingle(dr["consumoNaPontaTE_Faturado"]);
                        _Conta.ConsumoForaPontaTE_Faturado = Convert.ToSingle(dr["consumoForaPontaTE_Faturado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Faturado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Faturado"]);
                        _Conta.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToInt32(dr["consumoNaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoNaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_TarifaPreco"]);
                        _Conta.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demandaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTUSD_Valor = Convert.ToSingle(dr["consumoNaPontaTUSD_Valor"]);
                        _Conta.ConsumoForaPontaTUSD_Valor = Convert.ToSingle(dr["consumoForaPontaTUSD_Valor"]);
                        _Conta.ConsumoNaPontaTE_Valor = Convert.ToSingle(dr["consumoNaPontaTE_Valor"]);
                        _Conta.ConsumoForaPontaTE_Valor = Convert.ToSingle(dr["consumoForaPontaTE_Valor"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Valor"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Valor"]);
                        _Conta.DemandaTUSD_Valor = Convert.ToSingle(dr["demandaTUSD_Valor"]);
                        _Conta.SubTotal = Convert.ToSingle(dr["subTotal"]);
                        _Conta.ValorTotal = Convert.ToSingle(dr["valorTotal"]);
                        _Conta.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);

                    }
                }
                dr.Close();
                return _Conta;
            }
        }

        public static List<ContaModel> TodasContas(int FabricaID)
        {
            List<ContaModel> listaSaida = new List<ContaModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "c.data_referencia," +
                                  "c.id_tarifa," +
                                  "c.id_fabrica," +
                                  "c.id_distribuidora," +
                                  "c.id_tipocontrato," +
                                  "c.id_tiposubGrupo," +
                                  "c.consumoNaPontaTUSD_Registrado," +
                                  "c.consumoForaPontaTUSD_Registrado," +
                                  "c.consumoNaPontaTE_Registrado," +
                                  "c.consumoForaPontaTE_Registrado," +
                                  "c.consumoUltrapassagemNaPonta_Registrado," +
                                  "c.consumoUltrapassagemForaPonta_Registrado," +
                                  "c.demandaTUSD_Registrado," +
                                  "c.consumoNaPontaTUSD_Contratado," +
                                  "c.consumoForaPontaTUSD_Contratado," +
                                  "c.consumoNaPontaTE_Contratado," +
                                  "c.consumoForaPontaTE_Contratado," +
                                  "c.demandaTUSD_Contratado," +
                                  "c.consumoNaPontaTUSD_Faturado," +
                                  "c.consumoForaPontaTUSD_Faturado," +
                                  "c.consumoNaPontaTE_Faturado," +
                                  "c.consumoForaPontaTE_Faturado," +
                                  "c.consumoUltrapassagemNaPonta_Faturado," +
                                  "c.consumoUltrapassagemForaPonta_Faturado," +
                                  "c.demandaTUSD_Faturado," +
                                  "c.consumoNaPontaTUSD_TarifaPreco," +
                                  "c.consumoForaPontaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTE_TarifaPreco," +
                                  "c.consumoForaPontaTE_TarifaPreco," +
                                  "c.consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "c.consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "c.demandaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTUSD_Valor," +
                                  "c.consumoForaPontaTUSD_Valor," +
                                  "c.consumoNaPontaTE_Valor," +
                                  "c.consumoForaPontaTE_Valor," +
                                  "c.consumoUltrapassagemNaPonta_Valor," +
                                  "c.consumoUltrapassagemForaPonta_Valor," +
                                  "c.demandaTUSD_Valor," +
                                  "c.subTotal," +
                                  "c.valorTotal," +
                                  "c.id_bandeira " +
                                 "FROM " +
                                 "contas c "+
                                 "WHERE "+
                                 "c.id_fabrica = @id_fabrica;";
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = FabricaID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ContaModel _Conta = new ContaModel();
                        _Conta.dataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Conta.TarifaID = Convert.ToInt32(dr["id_tarifa"]);
                        _Conta.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Conta.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Conta.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Conta.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubGrupo"]);
                        _Conta.ConsumoNaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoNaPontaTUSD_Registrado"]);
                        _Conta.ConsumoForaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoForaPontaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTE_Registrado = Convert.ToSingle(dr["consumoNaPontaTE_Registrado"]);
                        _Conta.ConsumoForaPontaTE_Registrado = Convert.ToSingle(dr["consumoForaPontaTE_Registrado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Registrado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Registrado"]);
                        _Conta.DemandaTUSD_Registrado = Convert.ToSingle(dr["demandaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoNaPontaTUSD_Contratado"]);
                        _Conta.ConsumoForaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoForaPontaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTE_Contratado = Convert.ToSingle(dr["consumoNaPontaTE_Contratado"]);
                        _Conta.ConsumoForaPontaTE_Contratado = Convert.ToSingle(dr["consumoForaPontaTE_Contratado"]);
                        _Conta.DemandaTUSD_Contratado = Convert.ToSingle(dr["demandaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoNaPontaTUSD_Faturado"]);
                        _Conta.ConsumoForaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoForaPontaTUSD_Faturado"]);
                        _Conta.ConsumoNaPontaTE_Faturado = Convert.ToSingle(dr["consumoNaPontaTE_Faturado"]);
                        _Conta.ConsumoForaPontaTE_Faturado = Convert.ToSingle(dr["consumoForaPontaTE_Faturado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Faturado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Faturado"]);
                        _Conta.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToInt32(dr["consumoNaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoNaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_TarifaPreco"]);
                        _Conta.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demandaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTUSD_Valor = Convert.ToSingle(dr["consumoNaPontaTUSD_Valor"]);
                        _Conta.ConsumoForaPontaTUSD_Valor = Convert.ToSingle(dr["consumoForaPontaTUSD_Valor"]);
                        _Conta.ConsumoNaPontaTE_Valor = Convert.ToSingle(dr["consumoNaPontaTE_Valor"]);
                        _Conta.ConsumoForaPontaTE_Valor = Convert.ToSingle(dr["consumoForaPontaTE_Valor"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Valor"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Valor"]);
                        _Conta.DemandaTUSD_Valor = Convert.ToSingle(dr["demandaTUSD_Valor"]);
                        _Conta.SubTotal = Convert.ToSingle(dr["subTotal"]);
                        _Conta.ValorTotal = Convert.ToSingle(dr["valorTotal"]);
                        _Conta.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        listaSaida.Add(_Conta);
                    }
                }
                return listaSaida;
            }
        }

        public static List<ContaModel> ConsultaEntreDatas(DateTime dataReferencia1, 
                                                          DateTime dataReferencia2, 
                                                          int FabricaID)
        {
            List<ContaModel> listaSaida = new List<ContaModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "c.data_referencia," +
                                  "c.id_tarifa," +
                                  "c.id_fabrica," +
                                  "c.id_distribuidora," +
                                  "c.id_tipocontrato," +
                                  "c.id_tiposubGrupo," +
                                  "c.consumoNaPontaTUSD_Registrado," +
                                  "c.consumoForaPontaTUSD_Registrado," +
                                  "c.consumoNaPontaTE_Registrado," +
                                  "c.consumoForaPontaTE_Registrado," +
                                  "c.consumoUltrapassagemNaPonta_Registrado," +
                                  "c.consumoUltrapassagemForaPonta_Registrado," +
                                  "c.demandaTUSD_Registrado," +
                                  "c.consumoNaPontaTUSD_Contratado," +
                                  "c.consumoForaPontaTUSD_Contratado," +
                                  "c.consumoNaPontaTE_Contratado," +
                                  "c.consumoForaPontaTE_Contratado," +
                                  "c.demandaTUSD_Contratado," +
                                  "c.consumoNaPontaTUSD_Faturado," +
                                  "c.consumoForaPontaTUSD_Faturado," +
                                  "c.consumoNaPontaTE_Faturado," +
                                  "c.consumoForaPontaTE_Faturado," +
                                  "c.consumoUltrapassagemNaPonta_Faturado," +
                                  "c.consumoUltrapassagemForaPonta_Faturado," +
                                  "c.demandaTUSD_Faturado," +
                                  "c.consumoNaPontaTUSD_TarifaPreco," +
                                  "c.consumoForaPontaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTE_TarifaPreco," +
                                  "c.consumoForaPontaTE_TarifaPreco," +
                                  "c.consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "c.consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "c.demandaTUSD_TarifaPreco," +
                                  "c.consumoNaPontaTUSD_Valor," +
                                  "c.consumoForaPontaTUSD_Valor," +
                                  "c.consumoNaPontaTE_Valor," +
                                  "c.consumoForaPontaTE_Valor," +
                                  "c.consumoUltrapassagemNaPonta_Valor," +
                                  "c.consumoUltrapassagemForaPonta_Valor," +
                                  "c.demandaTUSD_Valor," +
                                  "c.subTotal," +
                                  "c.valorTotal," +
                                  "c.id_bandeira " +
                                 "FROM " +
                                 "contas c " +
                                 "WHERE " +
                                 "c.id_fabrica = @id_fabrica AND"+
                                 "(c.data_referencia BETWEEN @data_referencia1 AND @data_referencia2)";
                cmd.Parameters.Add("@data_referencia1", SqlDbType.DateTime).Value = dataReferencia1;
                cmd.Parameters.Add("@data_referencia2", SqlDbType.DateTime).Value = dataReferencia2;
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = FabricaID;
                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ContaModel _Conta = new ContaModel();
                        _Conta.dataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Conta.TarifaID = Convert.ToInt32(dr["id_tarifa"]);
                        _Conta.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Conta.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Conta.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Conta.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubGrupo"]);
                        _Conta.ConsumoNaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoNaPontaTUSD_Registrado"]);
                        _Conta.ConsumoForaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoForaPontaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTE_Registrado = Convert.ToSingle(dr["consumoNaPontaTE_Registrado"]);
                        _Conta.ConsumoForaPontaTE_Registrado = Convert.ToSingle(dr["consumoForaPontaTE_Registrado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Registrado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Registrado"]);
                        _Conta.DemandaTUSD_Registrado = Convert.ToSingle(dr["demandaTUSD_Registrado"]);
                        _Conta.ConsumoNaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoNaPontaTUSD_Contratado"]);
                        _Conta.ConsumoForaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoForaPontaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTE_Contratado = Convert.ToSingle(dr["consumoNaPontaTE_Contratado"]);
                        _Conta.ConsumoForaPontaTE_Contratado = Convert.ToSingle(dr["consumoForaPontaTE_Contratado"]);
                        _Conta.DemandaTUSD_Contratado = Convert.ToSingle(dr["demandaTUSD_Contratado"]);
                        _Conta.ConsumoNaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoNaPontaTUSD_Faturado"]);
                        _Conta.ConsumoForaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoForaPontaTUSD_Faturado"]);
                        _Conta.ConsumoNaPontaTE_Faturado = Convert.ToSingle(dr["consumoNaPontaTE_Faturado"]);
                        _Conta.ConsumoForaPontaTE_Faturado = Convert.ToSingle(dr["consumoForaPontaTE_Faturado"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Faturado"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Faturado"]);
                        _Conta.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToInt32(dr["consumoNaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoNaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTE_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_TarifaPreco"]);
                        _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_TarifaPreco"]);
                        _Conta.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demandaTUSD_TarifaPreco"]);
                        _Conta.ConsumoNaPontaTUSD_Valor = Convert.ToSingle(dr["consumoNaPontaTUSD_Valor"]);
                        _Conta.ConsumoForaPontaTUSD_Valor = Convert.ToSingle(dr["consumoForaPontaTUSD_Valor"]);
                        _Conta.ConsumoNaPontaTE_Valor = Convert.ToSingle(dr["consumoNaPontaTE_Valor"]);
                        _Conta.ConsumoForaPontaTE_Valor = Convert.ToSingle(dr["consumoForaPontaTE_Valor"]);
                        _Conta.ConsumoUltrapassagemNaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Valor"]);
                        _Conta.ConsumoUltrapassagemForaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Valor"]);
                        _Conta.DemandaTUSD_Valor = Convert.ToSingle(dr["demandaTUSD_Valor"]);
                        _Conta.SubTotal = Convert.ToSingle(dr["subTotal"]);
                        _Conta.ValorTotal = Convert.ToSingle(dr["valorTotal"]);
                        _Conta.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        listaSaida.Add(_Conta);

                    }
                }
                dr.Close();
                return listaSaida;
            }
        }

        public static bool AtualizarConta(ContaModel _Conta)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE " +
                                  "contas " +
                                  "SET " +
                                  "id_tarifa = @id_tarifa," +
                                  "id_distribuidora = @id_distribuidora," +
                                  "id_tipocontrato = @id_tipocontrato," +
                                  "id_tiposubGrupo = @id_tiposubGrupo," +
                                  "consumoNaPontaTUSD_Registrado = @consumoNaPontaTUSD_Registrado," +
                                  "consumoForaPontaTUSD_Registrado = @consumoForaPontaTUSD_Registrado," +
                                  "consumoNaPontaTE_Registrado = @consumoNaPontaTE_Registrado," +
                                  "consumoForaPontaTE_Registrado = @consumoForaPontaTE_Registrado," +
                                  "consumoUltrapassagemNaPonta_Registrado = @consumoUltrapassagemNaPonta_Registrado," +
                                  "consumoUltrapassagemForaPonta_Registrado = @consumoUltrapassagemForaPonta_Registrado," +
                                  "demandaTUSD_Registrado = @demandaTUSD_Registrado," +
                                  "consumoNaPontaTUSD_Contratado = @consumoNaPontaTUSD_Contratado," +
                                  "consumoForaPontaTUSD_Contratado = @consumoForaPontaTUSD_Contratado," +
                                  "consumoNaPontaTE_Contratado = @consumoNaPontaTE_Contratado," +
                                  "consumoForaPontaTE_Contratado = @consumoForaPontaTE_Contratado," +
                                  "demandaTUSD_Contratado = @demandaTUSD_Contratado," +
                                  "consumoNaPontaTUSD_Faturado = @consumoNaPontaTUSD_Faturado," +
                                  "consumoForaPontaTUSD_Faturado = @consumoForaPontaTUSD_Faturado," +
                                  "consumoNaPontaTE_Faturado = @consumoNaPontaTE_Faturado," +
                                  "consumoForaPontaTE_Faturado = @consumoForaPontaTE_Faturado," +
                                  "consumoUltrapassagemNaPonta_Faturado = @consumoUltrapassagemNaPonta_Faturado," +
                                  "consumoUltrapassagemForaPonta_Faturado = @consumoUltrapassagemForaPonta_Faturado," +
                                  "demandaTUSD_Faturado = @demandaTUSD_Faturado," +
                                  "consumoNaPontaTUSD_TarifaPreco = @consumoNaPontaTUSD_TarifaPreco," +
                                  "consumoForaPontaTUSD_TarifaPreco = @consumoForaPontaTUSD_TarifaPreco," +
                                  "consumoNaPontaTE_TarifaPreco = @consumoNaPontaTE_TarifaPreco," +
                                  "consumoForaPontaTE_TarifaPreco = @consumoForaPontaTE_TarifaPreco," +
                                  "consumoUltrapassagemNaPonta_TarifaPreco = @consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "consumoUltrapassagemForaPonta_TarifaPreco = @consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "demandaTUSD_TarifaPreco = @demandaTUSD_TarifaPreco," +
                                  "consumoNaPontaTUSD_Valor = @consumoNaPontaTUSD_Valor," +
                                  "consumoForaPontaTUSD_Valor = @consumoForaPontaTUSD_Valor," +
                                  "consumoNaPontaTE_Valor = @consumoNaPontaTE_Valor," +
                                  "consumoForaPontaTE_Valor = @consumoForaPontaTE_Valor," +
                                  "consumoUltrapassagemNaPonta_Valor = @consumoUltrapassagemNaPonta_Valor," +
                                  "consumoUltrapassagemForaPonta_Valor = @consumoUltrapassagemForaPonta_Valor," +
                                  "demandaTUSD_Valor = @demandaTUSD_Valor," +
                                  "subTotal = @subTotal," +
                                  "valorTotal = @valorTotal," +
                                  "id_bandeira = @id_bandeira " +
                                  "WHERE " +
                                  "id_fabrica = @id_fabrica AND " +
                                  "data_referencia = @data_referencia";
                cmd.Parameters.Add("@data_referencia", SqlDbType.DateTime).Value = _Conta.dataReferencia;
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = _Conta.FabricaID;

                cmd.Parameters.Add("@id_tarifa", SqlDbType.Int).Value = _Conta.TarifaID;
                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = _Conta.DistribuidoraID;
                cmd.Parameters.Add("@id_tipocontrato", SqlDbType.Int).Value = _Conta.TipoContratoID;
                cmd.Parameters.Add("@id_tiposubGrupo", SqlDbType.Int).Value = _Conta.TipoSubGrupoID;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Registrado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Registrado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Registrado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Registrado;
                cmd.Parameters.Add("@consumoNaPontaTE_Registrado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Registrado;
                cmd.Parameters.Add("@consumoForaPontaTE_Registrado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Registrado;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Registrado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Registrado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
                cmd.Parameters.Add("@demandaTUSD_Registrado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Registrado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Contratado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Contratado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Contratado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Contratado;
                cmd.Parameters.Add("@consumoNaPontaTE_Contratado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Contratado;
                cmd.Parameters.Add("@consumoForaPontaTE_Contratado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Contratado;
                cmd.Parameters.Add("@demandaTUSD_Contratado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Contratado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Faturado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Faturado;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Faturado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Faturado;
                cmd.Parameters.Add("@consumoNaPontaTE_Faturado", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Faturado;
                cmd.Parameters.Add("@consumoForaPontaTE_Faturado", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Faturado;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Faturado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Faturado", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
                cmd.Parameters.Add("@demandaTUSD_Faturado", SqlDbType.Float).Value = _Conta.DemandaTUSD_Faturado;
                cmd.Parameters.Add("@consumoNaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoForaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoNaPontaTE_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@consumoForaPontaTE_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_TarifaPreco;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_TarifaPreco", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
                cmd.Parameters.Add("@demandaTUSD_TarifaPreco", SqlDbType.Float).Value = _Conta.DemandaTUSD_TarifaPreco;
                cmd.Parameters.Add("@consumoNaPontaTUSD_Valor", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTUSD_Valor;
                cmd.Parameters.Add("@consumoForaPontaTUSD_Valor", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTUSD_Valor;
                cmd.Parameters.Add("@consumoNaPontaTE_Valor", SqlDbType.Float).Value = _Conta.ConsumoNaPontaTE_Valor;
                cmd.Parameters.Add("@consumoForaPontaTE_Valor", SqlDbType.Float).Value = _Conta.ConsumoForaPontaTE_Valor;
                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Valor", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemNaPonta_Valor;
                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Valor", SqlDbType.Float).Value = _Conta.ConsumoUltrapassagemForaPonta_Valor;
                cmd.Parameters.Add("@demandaTUSD_Valor", SqlDbType.Float).Value = _Conta.DemandaTUSD_Valor;
                cmd.Parameters.Add("@subTotal", SqlDbType.Float).Value = _Conta.SubTotal;
                cmd.Parameters.Add("@valorTotal", SqlDbType.Float).Value = _Conta.ValorTotal;
                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = _Conta.BandeiraID;

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    //throw;
                    return false;
                }
            }
        }

        public static bool DeletarConta(ContaModel _Conta)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM contas WHERE id_fabrica = @id_fabrica AND "+
                    "(data_referencia BETWEEN @data_referencia1 AND @data_referencia2)"; ;
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = _Conta.FabricaID;
                cmd.Parameters.Add("@data_referencia1", SqlDbType.DateTime).Value = _Conta.dataReferencia;
                cmd.Parameters.Add("@data_referencia2", SqlDbType.DateTime).Value = _Conta.dataReferencia.AddDays(1);
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
