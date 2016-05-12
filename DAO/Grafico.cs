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
    public static class Grafico
    {
        public static List<GraficoModel> DadosParaGrafico(int FabricaID)
        {
            List<GraficoModel> listaSaida = new List<GraficoModel>();
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
                                 "c.id_fabrica = @id_fabrica";
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = FabricaID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GraficoModel _Conta = new GraficoModel();
                        _Conta.DataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Conta.DataDaSimulacao = Convert.ToDateTime(dr["data_referencia"]);
                        _Conta.TarifaOrigemID = Convert.ToInt32(dr["id_tarifa"]);
                        _Conta.TarifaDestinoID = Convert.ToInt32(dr["id_tarifa"]);
                        _Conta.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Conta.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Conta.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Conta.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubGrupo"]);
                        _Conta.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
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
                        _Conta.TipoContratoDestinoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        listaSaida.Add(_Conta);
                    }
                }
            }

            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                  "s.data_simulacao," +
                                  "s.data_referencia," +
                                  "s.id_tarifa_origem," +
                                  "s.id_tarifa_destino," +
                                  "s.id_fabrica," +
                                  "s.id_distribuidora," +
                                  "s.id_tipocontrato," +
                                  "s.id_tiposubGrupo," +
                                  "s.id_bandeira," +
                                  "s.consumoNaPontaTUSD_Registrado," +
                                  "s.consumoForaPontaTUSD_Registrado," +
                                  "s.consumoNaPontaTE_Registrado," +
                                  "s.consumoForaPontaTE_Registrado," +
                                  "s.consumoUltrapassagemNaPonta_Registrado," +
                                  "s.consumoUltrapassagemForaPonta_Registrado," +
                                  "s.demandaTUSD_Registrado," +
                                  "s.consumoNaPontaTUSD_Contratado," +
                                  "s.consumoForaPontaTUSD_Contratado," +
                                  "s.consumoNaPontaTE_Contratado," +
                                  "s.consumoForaPontaTE_Contratado," +
                                  "s.demandaTUSD_Contratado," +
                                  "s.consumoNaPontaTUSD_Faturado," +
                                  "s.consumoForaPontaTUSD_Faturado," +
                                  "s.consumoNaPontaTE_Faturado," +
                                  "s.consumoForaPontaTE_Faturado," +
                                  "s.consumoUltrapassagemNaPonta_Faturado," +
                                  "s.consumoUltrapassagemForaPonta_Faturado," +
                                  "s.demandaTUSD_Faturado," +
                                  "s.consumoNaPontaTUSD_TarifaPreco," +
                                  "s.consumoForaPontaTUSD_TarifaPreco," +
                                  "s.consumoNaPontaTE_TarifaPreco," +
                                  "s.consumoForaPontaTE_TarifaPreco," +
                                  "s.consumoUltrapassagemNaPonta_TarifaPreco," +
                                  "s.consumoUltrapassagemForaPonta_TarifaPreco," +
                                  "s.demandaTUSD_TarifaPreco," +
                                  "s.consumoNaPontaTUSD_Valor," +
                                  "s.consumoForaPontaTUSD_Valor," +
                                  "s.consumoNaPontaTE_Valor," +
                                  "s.consumoForaPontaTE_Valor," +
                                  "s.consumoUltrapassagemNaPonta_Valor," +
                                  "s.consumoUltrapassagemForaPonta_Valor," +
                                  "s.demandaTUSD_Valor," +
                                  "s.subTotal," +
                                  "s.valorTotal," +
                                  "s.id_tipocontrato_destino " +
                                 "FROM " +
                                 "simulacoes s " +
                                 "WHERE " +
                                 "s.id_fabrica = @id_fabrica";
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = FabricaID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GraficoModel _Simulacao = new GraficoModel();
                        _Simulacao.DataDaSimulacao = Convert.ToDateTime(dr["data_simulacao"]);
                        _Simulacao.DataReferencia = Convert.ToDateTime(dr["data_referencia"]);
                        _Simulacao.TarifaOrigemID = Convert.ToInt32(dr["id_tarifa_origem"]);
                        _Simulacao.TarifaDestinoID = Convert.ToInt32(dr["id_tarifa_destino"]);
                        _Simulacao.FabricaID = Convert.ToInt32(dr["id_fabrica"]);
                        _Simulacao.DistribuidoraID = Convert.ToInt32(dr["id_distribuidora"]);
                        _Simulacao.TipoContratoID = Convert.ToInt32(dr["id_tipocontrato"]);
                        _Simulacao.TipoSubGrupoID = Convert.ToInt32(dr["id_tiposubGrupo"]);
                        _Simulacao.BandeiraID = Convert.ToInt32(dr["id_bandeira"]);
                        _Simulacao.ConsumoNaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoNaPontaTUSD_Registrado"]);
                        _Simulacao.ConsumoForaPontaTUSD_Registrado = Convert.ToSingle(dr["consumoForaPontaTUSD_Registrado"]);
                        _Simulacao.ConsumoNaPontaTE_Registrado = Convert.ToSingle(dr["consumoNaPontaTE_Registrado"]);
                        _Simulacao.ConsumoForaPontaTE_Registrado = Convert.ToSingle(dr["consumoForaPontaTE_Registrado"]);
                        _Simulacao.ConsumoUltrapassagemNaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Registrado"]);
                        _Simulacao.ConsumoUltrapassagemForaPonta_Registrado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Registrado"]);
                        _Simulacao.DemandaTUSD_Registrado = Convert.ToSingle(dr["demandaTUSD_Registrado"]);
                        _Simulacao.ConsumoNaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoNaPontaTUSD_Contratado"]);
                        _Simulacao.ConsumoForaPontaTUSD_Contratado = Convert.ToSingle(dr["consumoForaPontaTUSD_Contratado"]);
                        _Simulacao.ConsumoNaPontaTE_Contratado = Convert.ToSingle(dr["consumoNaPontaTE_Contratado"]);
                        _Simulacao.ConsumoForaPontaTE_Contratado = Convert.ToSingle(dr["consumoForaPontaTE_Contratado"]);
                        _Simulacao.DemandaTUSD_Contratado = Convert.ToSingle(dr["demandaTUSD_Contratado"]);
                        _Simulacao.ConsumoNaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoNaPontaTUSD_Faturado"]);
                        _Simulacao.ConsumoForaPontaTUSD_Faturado = Convert.ToSingle(dr["consumoForaPontaTUSD_Faturado"]);
                        _Simulacao.ConsumoNaPontaTE_Faturado = Convert.ToSingle(dr["consumoNaPontaTE_Faturado"]);
                        _Simulacao.ConsumoForaPontaTE_Faturado = Convert.ToSingle(dr["consumoForaPontaTE_Faturado"]);
                        _Simulacao.ConsumoUltrapassagemNaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Faturado"]);
                        _Simulacao.ConsumoUltrapassagemForaPonta_Faturado = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Faturado"]);
                        _Simulacao.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToInt32(dr["consumoNaPontaTUSD_TarifaPreco"]);
                        _Simulacao.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTUSD_TarifaPreco"]);
                        _Simulacao.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoNaPontaTE_TarifaPreco"]);
                        _Simulacao.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(dr["consumoForaPontaTE_TarifaPreco"]);
                        _Simulacao.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_TarifaPreco"]);
                        _Simulacao.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_TarifaPreco"]);
                        _Simulacao.DemandaTUSD_TarifaPreco = Convert.ToSingle(dr["demandaTUSD_TarifaPreco"]);
                        _Simulacao.ConsumoNaPontaTUSD_Valor = Convert.ToSingle(dr["consumoNaPontaTUSD_Valor"]);
                        _Simulacao.ConsumoForaPontaTUSD_Valor = Convert.ToSingle(dr["consumoForaPontaTUSD_Valor"]);
                        _Simulacao.ConsumoNaPontaTE_Valor = Convert.ToSingle(dr["consumoNaPontaTE_Valor"]);
                        _Simulacao.ConsumoForaPontaTE_Valor = Convert.ToSingle(dr["consumoForaPontaTE_Valor"]);
                        _Simulacao.ConsumoUltrapassagemNaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemNaPonta_Valor"]);
                        _Simulacao.ConsumoUltrapassagemForaPonta_Valor = Convert.ToSingle(dr["consumoUltrapassagemForaPonta_Valor"]);
                        _Simulacao.DemandaTUSD_Valor = Convert.ToSingle(dr["demandaTUSD_Valor"]);
                        _Simulacao.SubTotal = Convert.ToSingle(dr["subTotal"]);
                        _Simulacao.ValorTotal = Convert.ToSingle(dr["valorTotal"]);
                        _Simulacao.TipoContratoDestinoID = Convert.ToInt32(dr["id_tipocontrato_destino"]);
                        listaSaida.Add(_Simulacao);
                    }
                }
            }
            return listaSaida;
        }
    }
}
