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
    public static class Simulacao
    {

        public static bool GerarSimulacao(int fabricaID)
        {
            //chamar todos tipos de contrato
            
            List<TipoContratoModel> Contratos = new List<TipoContratoModel>();
            Contratos = TipoContrato.TodosContratos();

            List<TarifaModel> Tarifas = new List<TarifaModel>();
            Tarifas = Tarifa.TodasTarifas();

            List<ContaModel> ContasDaFabrica = new List<ContaModel>();
            ContasDaFabrica = Conta.TodasContas(fabricaID);

            DateTime HoraDaSimulacao = DateTime.Now;

            //Deleta simulações anteriores
            bool jaTemSimulacao = false;
            
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
                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = fabricaID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    jaTemSimulacao = true;
                }
            }
            //Deleta após verificar que já tem registros
            if (jaTemSimulacao)
            {
                try
                {
                    using (SqlConnection cnn = Conexoes.ConexaoSQL())
                    {
                        SqlCommand cmd = new SqlCommand();
                        cnn.Open();
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE " +
                                          "FROM simulacoes s " +
                                          "WHERE s.id_fabrica = @id_fabrica";
                        cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = fabricaID;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            try
            {
                foreach (var item in Contratos)
                {
                    TarifaModel tarifaDaSimulacao = new TarifaModel();

                    tarifaDaSimulacao = (TarifaModel)Tarifas.Select(x => x).Where(x => x.TipoContratoID == item.TipoContratoID);

                    foreach (var itensContas in ContasDaFabrica)
                    {
                        if (item.TipoContratoID != itensContas.TipoContratoID)
                        {
                            SimulacaoModel simulacao = new SimulacaoModel();

                            //Obtendo os dados simulados de preços de tarifas
                            simulacao.DataDaSimulacao = HoraDaSimulacao;
                            simulacao.TipoContratoID = itensContas.TipoContratoID;
                            simulacao.TipoContratoDestinoID = item.TipoContratoID;
                            simulacao.TarifaDestinoID = Convert.ToInt32(Tarifas.Select(x => x.TarifaID));
                            simulacao.ConsumoNaPontaTUSD_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoNaPontaTUSD_TarifaPreco));
                            simulacao.ConsumoForaPontaTUSD_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoForaPontaTUSD_TarifaPreco));
                            simulacao.ConsumoNaPontaTE_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoNaPontaTE_TarifaPreco));
                            simulacao.ConsumoForaPontaTE_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoForaPontaTE_TarifaPreco));
                            simulacao.ConsumoUltrapassagemNaPonta_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoUltrapassagemNaPonta_TarifaPreco));
                            simulacao.ConsumoUltrapassagemForaPonta_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.ConsumoUltrapassagemForaPonta_TarifaPreco));
                            simulacao.DemandaTUSD_TarifaPreco = Convert.ToSingle(Tarifas.Select(x => x.DemandaTUSD_TarifaPreco));

                            //Calculando o novo valor de acordo com as tarifas simuladas
                            simulacao.ConsumoNaPontaTUSD_Valor = itensContas.ConsumoNaPontaTUSD_Faturado * simulacao.ConsumoNaPontaTUSD_TarifaPreco;
                            simulacao.ConsumoForaPontaTUSD_Valor = itensContas.ConsumoForaPontaTUSD_Faturado * simulacao.ConsumoForaPontaTUSD_TarifaPreco;
                            simulacao.ConsumoNaPontaTE_Valor = itensContas.ConsumoNaPontaTE_Faturado * simulacao.ConsumoNaPontaTE_TarifaPreco;
                            simulacao.ConsumoForaPontaTE_Valor = itensContas.ConsumoForaPontaTE_Faturado * simulacao.ConsumoForaPontaTE_TarifaPreco;
                            simulacao.ConsumoUltrapassagemNaPonta_Valor = itensContas.ConsumoUltrapassagemNaPonta_Faturado * simulacao.ConsumoUltrapassagemNaPonta_TarifaPreco;
                            simulacao.ConsumoUltrapassagemForaPonta_Valor = itensContas.ConsumoUltrapassagemForaPonta_Faturado * simulacao.ConsumoUltrapassagemForaPonta_TarifaPreco;
                            simulacao.DemandaTUSD_Valor = itensContas.DemandaTUSD_Faturado * simulacao.DemandaTUSD_TarifaPreco;

                            //Novo Subtotal e novo Total
                            simulacao.SubTotal = simulacao.ConsumoNaPontaTUSD_Valor +
                                                 simulacao.ConsumoForaPontaTUSD_Valor +
                                                 simulacao.ConsumoNaPontaTE_Valor +
                                                 simulacao.ConsumoForaPontaTE_Valor +
                                                 simulacao.ConsumoUltrapassagemNaPonta_Valor +
                                                 simulacao.ConsumoUltrapassagemForaPonta_Valor +
                                                 simulacao.DemandaTUSD_Valor;

                            simulacao.ValorTotal = simulacao.SubTotal;

                            

                            // persistencia dos dados simulados
                            using (SqlConnection cnn = Conexoes.ConexaoSQL())
                            {
                                cnn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = cnn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "INSERT INTO " +
                                                  "simulacoes" +
                                                  "(" +
                                                  "data_simulacao, " +
                                                  "data_referencia," +
                                                  "id_tarifa_origem," +
                                                  "id_tarifa_destino," +
                                                  "id_fabrica," +
                                                  "id_distribuidora," +
                                                  "id_tipocontrato," +
                                                  "id_tiposubGrupo," +
                                                  "id_bandeira," +
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
                                                  "id_tipocontrato_destino" +
                                                  ")" +
                                                  "VALUES" +
                                                  "(" +
                                                  "@data_referencia," +
                                                  "@id_tarifa," +
                                                  "@id_fabrica," +
                                                  "@id_distribuidora," +
                                                  "@id_tipocontrato," +
                                                  "@id_tiposubGrupo," +
                                                  "@id_bandeira" +
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
                                                  "@id_tipocontrato_destino" +
                                                  ")" +
                                                  "SELECT SCOPE_IDENTITY() AS ID";
                                cmd.Parameters.Add("@data_simulacao", SqlDbType.DateTime).Value = simulacao.DataDaSimulacao;
                                cmd.Parameters.Add("@data_referencia", SqlDbType.DateTime).Value = itensContas.dataReferencia;
                                cmd.Parameters.Add("@id_tarifa_origem", SqlDbType.Int).Value = itensContas.TarifaID;
                                cmd.Parameters.Add("@id_tarifa_destino", SqlDbType.Int).Value = simulacao.TarifaDestinoID;
                                cmd.Parameters.Add("@id_fabrica", SqlDbType.Int).Value = itensContas.FabricaID;
                                cmd.Parameters.Add("@id_distribuidora", SqlDbType.Int).Value = itensContas.DistribuidoraID;
                                cmd.Parameters.Add("@id_tipocontrato", SqlDbType.Int).Value = itensContas.TipoContratoID;
                                cmd.Parameters.Add("@id_tiposubGrupo", SqlDbType.Int).Value = itensContas.TipoSubGrupoID;
                                cmd.Parameters.Add("@id_bandeira", SqlDbType.Int).Value = itensContas.BandeiraID;
                                cmd.Parameters.Add("@consumoNaPontaTUSD_Registrado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTUSD_Registrado;
                                cmd.Parameters.Add("@consumoForaPontaTUSD_Registrado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTUSD_Registrado;
                                cmd.Parameters.Add("@consumoNaPontaTE_Registrado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTE_Registrado;
                                cmd.Parameters.Add("@consumoForaPontaTE_Registrado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTE_Registrado;
                                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Registrado", SqlDbType.Float).Value = itensContas.ConsumoUltrapassagemNaPonta_Registrado;
                                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Registrado", SqlDbType.Float).Value = itensContas.ConsumoUltrapassagemForaPonta_Registrado;
                                cmd.Parameters.Add("@demandaTUSD_Registrado", SqlDbType.Float).Value = itensContas.DemandaTUSD_Registrado;
                                cmd.Parameters.Add("@consumoNaPontaTUSD_Contratado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTUSD_Contratado;
                                cmd.Parameters.Add("@consumoForaPontaTUSD_Contratado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTUSD_Contratado;
                                cmd.Parameters.Add("@consumoNaPontaTE_Contratado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTE_Contratado;
                                cmd.Parameters.Add("@consumoForaPontaTE_Contratado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTE_Contratado;
                                cmd.Parameters.Add("@demandaTUSD_Contratado", SqlDbType.Float).Value = itensContas.DemandaTUSD_Contratado;
                                cmd.Parameters.Add("@consumoNaPontaTUSD_Faturado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTUSD_Faturado;
                                cmd.Parameters.Add("@consumoForaPontaTUSD_Faturado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTUSD_Faturado;
                                cmd.Parameters.Add("@consumoNaPontaTE_Faturado", SqlDbType.Float).Value = itensContas.ConsumoNaPontaTE_Faturado;
                                cmd.Parameters.Add("@consumoForaPontaTE_Faturado", SqlDbType.Float).Value = itensContas.ConsumoForaPontaTE_Faturado;
                                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Faturado", SqlDbType.Float).Value = itensContas.ConsumoUltrapassagemNaPonta_Faturado;
                                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Faturado", SqlDbType.Float).Value = itensContas.ConsumoUltrapassagemForaPonta_Faturado;
                                cmd.Parameters.Add("@demandaTUSD_Faturado", SqlDbType.Float).Value = itensContas.DemandaTUSD_Faturado;
                                cmd.Parameters.Add("@consumoNaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoNaPontaTUSD_TarifaPreco;
                                cmd.Parameters.Add("@consumoForaPontaTUSD_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoForaPontaTUSD_TarifaPreco;
                                cmd.Parameters.Add("@consumoNaPontaTE_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoNaPontaTE_TarifaPreco;
                                cmd.Parameters.Add("@consumoForaPontaTE_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoForaPontaTE_TarifaPreco;
                                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoUltrapassagemNaPonta_TarifaPreco;
                                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_TarifaPreco", SqlDbType.Float).Value = simulacao.ConsumoUltrapassagemForaPonta_TarifaPreco;
                                cmd.Parameters.Add("@demandaTUSD_TarifaPreco", SqlDbType.Float).Value = simulacao.DemandaTUSD_TarifaPreco;
                                cmd.Parameters.Add("@consumoNaPontaTUSD_Valor", SqlDbType.Float).Value = simulacao.ConsumoNaPontaTUSD_Valor;
                                cmd.Parameters.Add("@consumoForaPontaTUSD_Valor", SqlDbType.Float).Value = simulacao.ConsumoForaPontaTUSD_Valor;
                                cmd.Parameters.Add("@consumoNaPontaTE_Valor", SqlDbType.Float).Value = simulacao.ConsumoNaPontaTE_Valor;
                                cmd.Parameters.Add("@consumoForaPontaTE_Valor", SqlDbType.Float).Value = simulacao.ConsumoForaPontaTE_Valor;
                                cmd.Parameters.Add("@consumoUltrapassagemNaPonta_Valor", SqlDbType.Float).Value = simulacao.ConsumoUltrapassagemNaPonta_Valor;
                                cmd.Parameters.Add("@consumoUltrapassagemForaPonta_Valor", SqlDbType.Float).Value = simulacao.ConsumoUltrapassagemForaPonta_Valor;
                                cmd.Parameters.Add("@demandaTUSD_Valor", SqlDbType.Float).Value = simulacao.DemandaTUSD_Valor;
                                cmd.Parameters.Add("@subTotal", SqlDbType.Float).Value = simulacao.SubTotal;
                                cmd.Parameters.Add("@valorTotal", SqlDbType.Float).Value = simulacao.ValorTotal;
                                cmd.Parameters.Add("@id_tipocontrato_destino", SqlDbType.Int).Value = simulacao.TipoContratoDestinoID;

                                cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


          
        }
    }
}
