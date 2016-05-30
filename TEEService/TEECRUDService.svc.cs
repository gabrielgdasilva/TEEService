using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TEEService.DataContracts;

namespace TEEService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior]
    public class Service1 : ITEECRUDService
    {
        

        //----------------------------Bandeira-------------------------------------------
        [OperationBehavior]
        public Bandeira DetalhesBandeira(int id)
        {
            DAO.Models.BandeiraModel _BandeiraDAO = DAO.Bandeira.DetalhesBandeira(id);
            Bandeira bandeira = new Bandeira();
            bandeira.BandeiraID = _BandeiraDAO.BandeiraID;
            bandeira.BandeiraString = _BandeiraDAO.BandeiraString;

            return bandeira;
        }

        [OperationBehavior]
        public bool CadastrarBandeira(Bandeira bandeira)
        {
            DAO.Models.BandeiraModel _Bandeira = new DAO.Models.BandeiraModel();
            _Bandeira.BandeiraID = bandeira.BandeiraID;
            _Bandeira.BandeiraString = bandeira.BandeiraString;

            if (DAO.Bandeira.CadastrarBandeira(_Bandeira))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public List<Bandeira> TodasBandeiras()
        {
            List<DAO.Models.BandeiraModel> ListBandeiraDAO = DAO.Bandeira.TodasBandeiras();
            List<Bandeira> listBandeira = new List<Bandeira>();
            foreach (var item in ListBandeiraDAO)
            {
                Bandeira bandeira = new Bandeira();
                bandeira.BandeiraID = item.BandeiraID;
                bandeira.BandeiraString = item.BandeiraString;
                listBandeira.Add(bandeira);
            }
            return listBandeira;
        }
        //----------------------------Cliente---------------------------------------------------
        [OperationBehavior]
        public Cliente DetalhesCliente(int id)
        {
            DAO.Models.ClienteModel _clienteDAO = DAO.Cliente.DetalhesCliente(id);
            Cliente cliente = new Cliente();
            cliente.ClienteID = _clienteDAO.ClienteID;
            cliente.Nome = _clienteDAO.Nome;
            cliente.Cnpj = _clienteDAO.Cnpj;
            cliente.RazaoSocial = _clienteDAO.RazaoSocial;
            cliente.Endereco = _clienteDAO.Endereco;

            return cliente;
        }

        [OperationBehavior]
        public bool CadastrarCliente(Cliente _cliente)
        {
            DAO.Models.ClienteModel clienteDAO = new DAO.Models.ClienteModel();
            clienteDAO.ClienteID = _cliente.ClienteID;
            clienteDAO.Nome = _cliente.Nome;
            clienteDAO.Cnpj = _cliente.Cnpj;
            clienteDAO.RazaoSocial = _cliente.RazaoSocial;
            clienteDAO.Endereco = _cliente.Endereco;


            if (DAO.Cliente.CadastrarCliente(clienteDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public bool AtualizarCliente(Cliente _cliente)
        {
            DAO.Models.ClienteModel clienteDAO = new DAO.Models.ClienteModel();
            clienteDAO.ClienteID = _cliente.ClienteID;
            clienteDAO.Nome = _cliente.Nome;
            clienteDAO.Cnpj = _cliente.Cnpj;
            clienteDAO.RazaoSocial = _cliente.RazaoSocial;
            clienteDAO.Endereco = _cliente.Endereco;


            if (DAO.Cliente.AtualizarCliente(clienteDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //----------------------------Fabrica-----------------------------------------------
        [OperationBehavior]
        public bool CadastrarFabrica(Fabrica _fabrica)
        {
            DAO.Models.FabricaModel fabricaDAO = new DAO.Models.FabricaModel();
            fabricaDAO.FabricaID = _fabrica.FabricaID;
            fabricaDAO.ClienteID = _fabrica.ClienteID;
            fabricaDAO.Cnpj = _fabrica.Cnpj;
            fabricaDAO.Endereco = _fabrica.Endereco;
            fabricaDAO.DistribuidoraID = _fabrica.DistribuidoraID;

            if (DAO.Fabrica.CadastrarFabrica(fabricaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public bool AtualizarFabrica(Fabrica _fabrica)
        {
            DAO.Models.FabricaModel fabricaDAO = new DAO.Models.FabricaModel();
            fabricaDAO.FabricaID = _fabrica.FabricaID;
            fabricaDAO.ClienteID = _fabrica.ClienteID;
            fabricaDAO.Cnpj = _fabrica.Cnpj;
            fabricaDAO.Endereco = _fabrica.Endereco;
            fabricaDAO.DistribuidoraID = _fabrica.DistribuidoraID;

            if (DAO.Fabrica.AtualizarFabrica(fabricaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public Fabrica DestalhesDaFabrica(int id)
        {
            DAO.Models.FabricaModel _FabricaDAO = DAO.Fabrica.DestalhesDaFabrica(id);
            Fabrica fabrica = new Fabrica();
            fabrica.FabricaID = _FabricaDAO.FabricaID;
            fabrica.ClienteID = _FabricaDAO.ClienteID;
            fabrica.Cnpj = _FabricaDAO.Cnpj;
            fabrica.Endereco = _FabricaDAO.Endereco;
            fabrica.DistribuidoraID = _FabricaDAO.DistribuidoraID;

            return fabrica;
        }

        [OperationBehavior]
        public List<Fabrica> TodasFabricas(int ClienteID)
        {
            List<DAO.Models.FabricaModel> ListFabricaDAO = DAO.Fabrica.TodasFabricas(ClienteID);
            List<Fabrica> listaFabricas = new List<Fabrica>();
            foreach (var item in ListFabricaDAO)
            {
                Fabrica fabrica = new Fabrica();
                fabrica.FabricaID = item.FabricaID;
                fabrica.ClienteID = item.ClienteID;
                fabrica.Cnpj = item.Cnpj;
                fabrica.Endereco = item.Endereco;
                fabrica.DistribuidoraID = item.DistribuidoraID;
                listaFabricas.Add(fabrica);
            }
            return listaFabricas;
        }
        //Deleção de Fabrica
        [OperationBehavior]
        public bool DeletarFabrica(Fabrica _fabrica)
        {
            DAO.Models.FabricaModel fabricaDAO = new DAO.Models.FabricaModel();
            fabricaDAO.FabricaID = _fabrica.FabricaID;
            fabricaDAO.ClienteID = _fabrica.ClienteID;
            fabricaDAO.Cnpj = _fabrica.Cnpj;
            fabricaDAO.Endereco = _fabrica.Endereco;
            fabricaDAO.DistribuidoraID = _fabrica.DistribuidoraID;

            if (DAO.Fabrica.DeletarFabrica(fabricaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------Tipo de Contrato-----------------------------------------------------
        [OperationBehavior]
        public bool CadastrarContrato(TipoContrato _TipoContrato)
        {
            DAO.Models.TipoContratoModel _ContratoDAO = new DAO.Models.TipoContratoModel();
            _ContratoDAO.TipoContratoID = _TipoContrato.TipoContratoID;
            _ContratoDAO.TipoContratoString = _TipoContrato.TipoContratoString;

            if (DAO.TipoContrato.CadastrarContrato(_ContratoDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public TipoContrato DetalhesContrato(int id)
        {
            DAO.Models.TipoContratoModel _ContratoDAO = DAO.TipoContrato.DetalhesContrato(id);
            TipoContrato tipoContrato = new TipoContrato();
            tipoContrato.TipoContratoID = _ContratoDAO.TipoContratoID;
            tipoContrato.TipoContratoString = _ContratoDAO.TipoContratoString;

            return tipoContrato;
        }

        [OperationBehavior]
        public List<TipoContrato> TodosContratos()
        {
            List<DAO.Models.TipoContratoModel> ListContratoDAO = DAO.TipoContrato.TodosContratos();
            List<TipoContrato> listContrato = new List<TipoContrato>();
            foreach (var item in ListContratoDAO)
            {
                TipoContrato tipoContrato = new TipoContrato();
                tipoContrato.TipoContratoID = item.TipoContratoID;
                tipoContrato.TipoContratoString = item.TipoContratoString;
                listContrato.Add(tipoContrato);
            }
            return listContrato;
        }

        //----------------------------Distribuidora--------------------------------------------------------
        [OperationBehavior]
        public bool CadastrarDistribuidora(Distribuidora _Distribuidora)
        {
            DAO.Models.DistribuidoraModel _DistribuidoraDAO = new DAO.Models.DistribuidoraModel();
            _DistribuidoraDAO.DistribuidoraID = _Distribuidora.DistribuidoraID;
            _DistribuidoraDAO.Nome = _Distribuidora.Nome;
            _DistribuidoraDAO.Cnpj = _Distribuidora.Cnpj;

            if (DAO.Distribuidora.CadastrarDistribuidora(_DistribuidoraDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public Distribuidora DetalhesDistribuidora(int id)
        {
            DAO.Models.DistribuidoraModel _DistribuidoraDAO = DAO.Distribuidora.DetalhesDistribuidora(id);
            Distribuidora distribuidora = new Distribuidora();
            distribuidora.DistribuidoraID = _DistribuidoraDAO.DistribuidoraID;
            distribuidora.Nome = _DistribuidoraDAO.Nome;
            distribuidora.Cnpj = _DistribuidoraDAO.Cnpj;

            return distribuidora;
        }

        [OperationBehavior]
        public List<Distribuidora> TodasDistribuidoras()
        {
            List<DAO.Models.DistribuidoraModel> ListDistribuidoraDAO = DAO.Distribuidora.TodasDistribuidoras();
            List<Distribuidora> listDistribuidora = new List<Distribuidora>();
            foreach (var item in ListDistribuidoraDAO)
            {
                Distribuidora distribuidora = new Distribuidora();
                distribuidora.DistribuidoraID = item.DistribuidoraID;
                distribuidora.Nome = item.Nome;
                distribuidora.Cnpj = item.Cnpj;
                listDistribuidora.Add(distribuidora);
            }
            return listDistribuidora;
        }
        //----------------------------Tipo de SubGrupo-----------------------------------------------------

        public bool CadastrarSubGrupo(TipoSubGrupo _SubGrupo)
        {
            DAO.Models.TipoSubGrupoModel _SubGrupoDAO = new DAO.Models.TipoSubGrupoModel();
            _SubGrupoDAO.TipoSubGrupoID = _SubGrupo.TipoSubGrupoID;
            _SubGrupoDAO.TipoSubGrupoString = _SubGrupo.TipoSubGrupoString;

            if (DAO.TipoSubGrupo.CadastrarSubGrupo(_SubGrupoDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public TipoSubGrupo DetalhesSubGrupo(int id)
        {
            DAO.Models.TipoSubGrupoModel _SubGrupoDAO = DAO.TipoSubGrupo.DetalhesSubGrupo(id);
            TipoSubGrupo SubGrupo = new TipoSubGrupo();
            SubGrupo.TipoSubGrupoID = _SubGrupoDAO.TipoSubGrupoID;
            SubGrupo.TipoSubGrupoString = _SubGrupoDAO.TipoSubGrupoString;

            return SubGrupo;
        }

        public List<TipoSubGrupo> TodosSubGrupos()
        {
            List<DAO.Models.TipoSubGrupoModel> ListSubGrupoDAO = DAO.TipoSubGrupo.TodosSubGrupos();
            List<TipoSubGrupo> ListSubGrupo = new List<TipoSubGrupo>();
            foreach (var item in ListSubGrupoDAO)
            {
                TipoSubGrupo SubGrupo = new TipoSubGrupo();
                SubGrupo.TipoSubGrupoID = item.TipoSubGrupoID;
                SubGrupo.TipoSubGrupoString = item.TipoSubGrupoString;
                ListSubGrupo.Add(SubGrupo);
            }
            return ListSubGrupo;
        }

        //----------------------------Tarifa------------------------------------------------------------
        [OperationBehavior]
        public bool CadastrarTarifa(Tarifa _Tarifa)
        {
            DAO.Models.TarifaModel tarifaDAO = new DAO.Models.TarifaModel();
            tarifaDAO.DistribuidoraID = _Tarifa.DistribuidoraID;
            tarifaDAO.TipoContratoID = _Tarifa.TipoContratoID;
            tarifaDAO.TipoSubGrupoID = _Tarifa.TipoSubGrupoID;
            tarifaDAO.DataReferencia = _Tarifa.DataReferencia;
            tarifaDAO.PotenciaMin = _Tarifa.PotenciaMin;
            tarifaDAO.PotenciaMax = _Tarifa.PotenciaMax;
            tarifaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoNaPontaTE_TarifaPreco = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTE_TarifaPreco = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaDAO.DemandaTUSD_TarifaPreco = _Tarifa.DemandaTUSD_TarifaPreco;
            tarifaDAO.BandeiraID = _Tarifa.BandeiraID;

            if (DAO.Tarifa.CadastrarTarifa(tarifaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public Tarifa DestalhesDaTarifa(int id)
        {
            DAO.Models.TarifaModel _TarifaDAO = DAO.Tarifa.DestalhesDaTarifa(id);
            Tarifa tarifa = new Tarifa();
            tarifa.TarifaID = _TarifaDAO.TarifaID;
            tarifa.DistribuidoraID = _TarifaDAO.DistribuidoraID;
            tarifa.TipoContratoID = _TarifaDAO.TipoContratoID;
            tarifa.TipoSubGrupoID = _TarifaDAO.TipoSubGrupoID;
            tarifa.DataReferencia = _TarifaDAO.DataReferencia;
            tarifa.PotenciaMin = _TarifaDAO.PotenciaMin;
            tarifa.PotenciaMax = _TarifaDAO.PotenciaMax;
            tarifa.ConsumoNaPontaTUSD_TarifaPreco = _TarifaDAO.ConsumoNaPontaTUSD_TarifaPreco;
            tarifa.ConsumoForaPontaTUSD_TarifaPreco = _TarifaDAO.ConsumoForaPontaTUSD_TarifaPreco;
            tarifa.ConsumoNaPontaTE_TarifaPreco = _TarifaDAO.ConsumoNaPontaTE_TarifaPreco;
            tarifa.ConsumoForaPontaTE_TarifaPreco = _TarifaDAO.ConsumoForaPontaTE_TarifaPreco;
            tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = _TarifaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = _TarifaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifa.DemandaTUSD_TarifaPreco = _TarifaDAO.DemandaTUSD_TarifaPreco;
            tarifa.BandeiraID = _TarifaDAO.BandeiraID;


            return tarifa;
        }

        [OperationBehavior]
        public List<Tarifa> TodasTarifas()
        {
            List<DAO.Models.TarifaModel> ListTarifaDAO = DAO.Tarifa.TodasTarifas();
            List<Tarifa> listaTarifas = new List<Tarifa>();
            foreach (var item in ListTarifaDAO)
            {
                Tarifa tarifa = new Tarifa();
                tarifa.TarifaID = item.TarifaID;
                tarifa.DistribuidoraID = item.DistribuidoraID;
                tarifa.TipoContratoID = item.TipoContratoID;
                tarifa.TipoSubGrupoID = item.TipoSubGrupoID;
                tarifa.DataReferencia = item.DataReferencia;
                tarifa.PotenciaMin = item.PotenciaMin;
                tarifa.PotenciaMax = item.PotenciaMax;
                tarifa.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                tarifa.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                tarifa.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                tarifa.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                tarifa.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                tarifa.BandeiraID = item.BandeiraID;
                listaTarifas.Add(tarifa);
            }
            return listaTarifas;
        }

        [OperationBehavior]
        public bool AtualizarTarifa(Tarifa _Tarifa)
        {

            DAO.Models.TarifaModel tarifaDAO = new DAO.Models.TarifaModel();
            tarifaDAO.TarifaID = _Tarifa.TarifaID;
            tarifaDAO.DistribuidoraID = _Tarifa.DistribuidoraID;
            tarifaDAO.TipoContratoID = _Tarifa.TipoContratoID;
            tarifaDAO.TipoSubGrupoID = _Tarifa.TipoSubGrupoID;
            tarifaDAO.DataReferencia = _Tarifa.DataReferencia;
            tarifaDAO.PotenciaMin = _Tarifa.PotenciaMin;
            tarifaDAO.PotenciaMax = _Tarifa.PotenciaMax;
            tarifaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoNaPontaTE_TarifaPreco = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTE_TarifaPreco = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaDAO.DemandaTUSD_TarifaPreco = _Tarifa.DemandaTUSD_TarifaPreco;
            tarifaDAO.BandeiraID = _Tarifa.BandeiraID;

            if (DAO.Tarifa.AtualizarTarifa(tarifaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [OperationBehavior]
        public bool DeletarTarifa(Tarifa _Tarifa)
        {
            DAO.Models.TarifaModel tarifaDAO = new DAO.Models.TarifaModel();
            tarifaDAO.DistribuidoraID = _Tarifa.DistribuidoraID;
            tarifaDAO.TipoContratoID = _Tarifa.TipoContratoID;
            tarifaDAO.TipoSubGrupoID = _Tarifa.TipoSubGrupoID;
            tarifaDAO.DataReferencia = _Tarifa.DataReferencia;
            tarifaDAO.PotenciaMin = _Tarifa.PotenciaMin;
            tarifaDAO.PotenciaMax = _Tarifa.PotenciaMax;
            tarifaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaDAO.ConsumoNaPontaTE_TarifaPreco = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoForaPontaTE_TarifaPreco = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaDAO.DemandaTUSD_TarifaPreco = _Tarifa.DemandaTUSD_TarifaPreco;
            tarifaDAO.BandeiraID = _Tarifa.BandeiraID;

            if (DAO.Tarifa.DeletarTarifa(tarifaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------Usuario------------------------------------------------------------

        public bool CadastrarUsuario(Usuario _Usuario)
        {
            DAO.Models.UsuarioModel usuarioDAO = new DAO.Models.UsuarioModel();
            usuarioDAO.Email = _Usuario.Email;
            usuarioDAO.ClienteID = _Usuario.ClienteID;
            usuarioDAO.Cpf = _Usuario.Cpf;
            usuarioDAO.Nome = _Usuario.Nome;
            usuarioDAO.Senha = _Usuario.Senha;
            usuarioDAO.Ativo = _Usuario.Ativo;
            usuarioDAO.DataRegistro = _Usuario.DataRegistro;
            usuarioDAO.Tipo = _Usuario.Tipo;
            

            if (DAO.Usuario.CadastrarUsuario(usuarioDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario VerificaAutenticacao(string email, string senha)
        {
            DAO.Models.UsuarioModel _UsuarioDAO = DAO.Usuario.VerificaAutenticacao(email);

            if (_UsuarioDAO != null)
            {
                Usuario usuario = new Usuario();
                usuario.Email = _UsuarioDAO.Email;
                usuario.ClienteID = _UsuarioDAO.ClienteID;
                usuario.Cpf = _UsuarioDAO.Cpf;
                usuario.Nome = _UsuarioDAO.Nome;
                usuario.Senha = _UsuarioDAO.Senha;
                usuario.Ativo = _UsuarioDAO.Ativo;
                usuario.DataRegistro = _UsuarioDAO.DataRegistro;
                usuario.Tipo = _UsuarioDAO.Tipo;

                if (senha == usuario.Senha)
                {
                    return usuario;
                }
                else
                {
                    
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Usuario DestalhesDoUsuario(string email)
        {
            DAO.Models.UsuarioModel _UsuarioDAO = DAO.Usuario.DestalhesDoUsuario(email);
            Usuario usuario = new Usuario();
            usuario.Email = _UsuarioDAO.Email;
            usuario.ClienteID = _UsuarioDAO.ClienteID;
            usuario.Cpf = _UsuarioDAO.Cpf;
            usuario.Nome = _UsuarioDAO.Nome;
            usuario.Senha = _UsuarioDAO.Senha;
            usuario.Ativo = _UsuarioDAO.Ativo;
            usuario.DataRegistro = _UsuarioDAO.DataRegistro;
            usuario.Tipo = _UsuarioDAO.Tipo;

            return usuario;
        }

        public bool AtualizarUsuario(Usuario _Usuario)
        {
            DAO.Models.UsuarioModel usuarioDAO = new DAO.Models.UsuarioModel();
            usuarioDAO.Email = _Usuario.Email;
            usuarioDAO.ClienteID = _Usuario.ClienteID;
            usuarioDAO.Cpf = _Usuario.Cpf;
            usuarioDAO.Nome = _Usuario.Nome;
            usuarioDAO.Senha = _Usuario.Senha;
            usuarioDAO.Ativo = _Usuario.Ativo;
            usuarioDAO.DataRegistro = _Usuario.DataRegistro;
            usuarioDAO.Tipo = _Usuario.Tipo;


            if (DAO.Usuario.AtualizarUsuario(usuarioDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletarUsuario(Usuario _Usuario)
        {
            DAO.Models.UsuarioModel usuarioDAO = new DAO.Models.UsuarioModel();
            usuarioDAO.Email = _Usuario.Email;
            usuarioDAO.ClienteID = _Usuario.ClienteID;
            usuarioDAO.Cpf = _Usuario.Cpf;
            usuarioDAO.Nome = _Usuario.Nome;
            usuarioDAO.Senha = _Usuario.Senha;
            usuarioDAO.Ativo = _Usuario.Ativo;
            usuarioDAO.DataRegistro = _Usuario.DataRegistro;
            usuarioDAO.Tipo = _Usuario.Tipo;


            if (DAO.Usuario.DeletarUsuario(usuarioDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Usuario> ListarUsuarios(int ID)
        {

            List<DAO.Models.UsuarioModel> ListUsuarioModel = DAO.Usuario.TodosUsuarios(ID);
            List<Usuario> ListaUsuarios = new List<Usuario>();
            foreach (var item in ListUsuarioModel)
            {
                Usuario usuario = new Usuario();
                usuario.Email = item.Email;
                usuario.ClienteID = item.ClienteID;
                usuario.Cpf = item.Cpf;
                usuario.Nome = item.Nome;
                usuario.Senha = item.Senha;
                usuario.Ativo = item.Ativo;
                usuario.DataRegistro = item.DataRegistro;
                usuario.Tipo = item.Tipo;
                ListaUsuarios.Add(usuario);
            }
            return ListaUsuarios;
        }


        //----------------------------Conta------------------------------------------------------------
        public bool CadastrarConta(Conta _Conta)
        {
            DAO.Models.ContaModel ContaDAO = new DAO.Models.ContaModel();
            ContaDAO.dataReferencia = _Conta.dataReferencia;
            ContaDAO.TarifaID = _Conta.TarifaID;
            ContaDAO.FabricaID = _Conta.FabricaID;
            ContaDAO.DistribuidoraID = _Conta.DistribuidoraID;
            ContaDAO.TipoContratoID = _Conta.TipoContratoID;
            ContaDAO.TipoSubGrupoID = _Conta.TipoSubGrupoID;
            ContaDAO.ConsumoNaPontaTUSD_Registrado = _Conta.ConsumoNaPontaTUSD_Registrado;
            ContaDAO.ConsumoForaPontaTUSD_Registrado = _Conta.ConsumoForaPontaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTE_Registrado = _Conta.ConsumoNaPontaTE_Registrado;
            ContaDAO.ConsumoForaPontaTE_Registrado = _Conta.ConsumoForaPontaTE_Registrado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Registrado = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Registrado = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
            ContaDAO.DemandaTUSD_Registrado = _Conta.DemandaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTUSD_Contratado = _Conta.ConsumoNaPontaTUSD_Contratado;
            ContaDAO.ConsumoForaPontaTUSD_Contratado = _Conta.ConsumoForaPontaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTE_Contratado = _Conta.ConsumoNaPontaTE_Contratado;
            ContaDAO.ConsumoForaPontaTE_Contratado = _Conta.ConsumoForaPontaTE_Contratado;
            ContaDAO.DemandaTUSD_Contratado = _Conta.DemandaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTUSD_Faturado = _Conta.ConsumoNaPontaTUSD_Faturado;
            ContaDAO.ConsumoForaPontaTUSD_Faturado = _Conta.ConsumoForaPontaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTE_Faturado = _Conta.ConsumoNaPontaTE_Faturado;
            ContaDAO.ConsumoForaPontaTE_Faturado = _Conta.ConsumoForaPontaTE_Faturado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Faturado = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Faturado = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
            ContaDAO.DemandaTUSD_Faturado = _Conta.DemandaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTE_TarifaPreco = _Conta.ConsumoNaPontaTE_TarifaPreco;
            ContaDAO.ConsumoForaPontaTE_TarifaPreco = _Conta.ConsumoForaPontaTE_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            ContaDAO.DemandaTUSD_TarifaPreco = _Conta.DemandaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTUSD_Valor = _Conta.ConsumoNaPontaTUSD_Valor;
            ContaDAO.ConsumoForaPontaTUSD_Valor = _Conta.ConsumoForaPontaTUSD_Valor;
            ContaDAO.ConsumoNaPontaTE_Valor = _Conta.ConsumoNaPontaTE_Valor;
            ContaDAO.ConsumoForaPontaTE_Valor = _Conta.ConsumoForaPontaTE_Valor;
            ContaDAO.ConsumoUltrapassagemNaPonta_Valor = _Conta.ConsumoUltrapassagemNaPonta_Valor;
            ContaDAO.ConsumoUltrapassagemForaPonta_Valor = _Conta.ConsumoUltrapassagemForaPonta_Valor;
            ContaDAO.DemandaTUSD_Valor = _Conta.DemandaTUSD_Valor;
            ContaDAO.SubTotal = _Conta.SubTotal;
            ContaDAO.ValorTotal = _Conta.ValorTotal;
            ContaDAO.BandeiraID = _Conta.BandeiraID;

            if (DAO.Conta.CadastrarConta(ContaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Conta DestalhesDaConta(DateTime dataReferencia, int FabricaID)
        {
            DAO.Models.ContaModel _ContaDAO = DAO.Conta.DestalhesDaConta(dataReferencia, FabricaID);
            Conta conta = new Conta();

            conta.dataReferencia = _ContaDAO.dataReferencia;
            conta.TarifaID = _ContaDAO.TarifaID;
            conta.FabricaID = _ContaDAO.FabricaID;
            conta.DistribuidoraID = _ContaDAO.DistribuidoraID;
            conta.TipoContratoID = _ContaDAO.TipoContratoID;
            conta.TipoSubGrupoID = _ContaDAO.TipoSubGrupoID;
            conta.ConsumoNaPontaTUSD_Registrado = _ContaDAO.ConsumoNaPontaTUSD_Registrado;
            conta.ConsumoForaPontaTUSD_Registrado = _ContaDAO.ConsumoForaPontaTUSD_Registrado;
            conta.ConsumoNaPontaTE_Registrado = _ContaDAO.ConsumoNaPontaTE_Registrado;
            conta.ConsumoForaPontaTE_Registrado = _ContaDAO.ConsumoForaPontaTE_Registrado;
            conta.ConsumoUltrapassagemNaPonta_Registrado = _ContaDAO.ConsumoUltrapassagemNaPonta_Registrado;
            conta.ConsumoUltrapassagemForaPonta_Registrado = _ContaDAO.ConsumoUltrapassagemForaPonta_Registrado;
            conta.DemandaTUSD_Registrado = _ContaDAO.DemandaTUSD_Registrado;
            conta.ConsumoNaPontaTUSD_Contratado = _ContaDAO.ConsumoNaPontaTUSD_Contratado;
            conta.ConsumoForaPontaTUSD_Contratado = _ContaDAO.ConsumoForaPontaTUSD_Contratado;
            conta.ConsumoNaPontaTE_Contratado = _ContaDAO.ConsumoNaPontaTE_Contratado;
            conta.ConsumoForaPontaTE_Contratado = _ContaDAO.ConsumoForaPontaTE_Contratado;
            conta.DemandaTUSD_Contratado = _ContaDAO.DemandaTUSD_Contratado;
            conta.ConsumoNaPontaTUSD_Faturado = _ContaDAO.ConsumoNaPontaTUSD_Faturado;
            conta.ConsumoForaPontaTUSD_Faturado = _ContaDAO.ConsumoForaPontaTUSD_Faturado;
            conta.ConsumoNaPontaTE_Faturado = _ContaDAO.ConsumoNaPontaTE_Faturado;
            conta.ConsumoForaPontaTE_Faturado = _ContaDAO.ConsumoForaPontaTE_Faturado;
            conta.ConsumoUltrapassagemNaPonta_Faturado = _ContaDAO.ConsumoUltrapassagemNaPonta_Faturado;
            conta.ConsumoUltrapassagemForaPonta_Faturado = _ContaDAO.ConsumoUltrapassagemForaPonta_Faturado;
            conta.DemandaTUSD_Faturado = _ContaDAO.DemandaTUSD_Faturado;
            conta.ConsumoNaPontaTUSD_TarifaPreco = _ContaDAO.ConsumoNaPontaTUSD_TarifaPreco;
            conta.ConsumoForaPontaTUSD_TarifaPreco = _ContaDAO.ConsumoForaPontaTUSD_TarifaPreco;
            conta.ConsumoNaPontaTE_TarifaPreco = _ContaDAO.ConsumoNaPontaTE_TarifaPreco;
            conta.ConsumoForaPontaTE_TarifaPreco = _ContaDAO.ConsumoForaPontaTE_TarifaPreco;
            conta.ConsumoUltrapassagemNaPonta_TarifaPreco = _ContaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco;
            conta.ConsumoUltrapassagemForaPonta_TarifaPreco = _ContaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco;
            conta.DemandaTUSD_TarifaPreco = _ContaDAO.DemandaTUSD_TarifaPreco;
            conta.ConsumoNaPontaTUSD_Valor = _ContaDAO.ConsumoNaPontaTUSD_Valor;
            conta.ConsumoForaPontaTUSD_Valor = _ContaDAO.ConsumoForaPontaTUSD_Valor;
            conta.ConsumoNaPontaTE_Valor = _ContaDAO.ConsumoNaPontaTE_Valor;
            conta.ConsumoForaPontaTE_Valor = _ContaDAO.ConsumoForaPontaTE_Valor;
            conta.ConsumoUltrapassagemNaPonta_Valor = _ContaDAO.ConsumoUltrapassagemNaPonta_Valor;
            conta.ConsumoUltrapassagemForaPonta_Valor = _ContaDAO.ConsumoUltrapassagemForaPonta_Valor;
            conta.DemandaTUSD_Valor = _ContaDAO.DemandaTUSD_Valor;
            conta.SubTotal = _ContaDAO.SubTotal;
            conta.ValorTotal = _ContaDAO.ValorTotal;
            conta.BandeiraID = _ContaDAO.BandeiraID;

            return conta;
        }

        public List<Conta> TodasContas(int FabricaID)
        {
            List<DAO.Models.ContaModel> ListContaDAO = DAO.Conta.TodasContas(FabricaID);
            List<Conta> listaContas = new List<Conta>();
            foreach (var item in ListContaDAO)
            {
                Conta conta = new Conta();

                conta.dataReferencia = item.dataReferencia;
                conta.TarifaID = item.TarifaID;
                conta.FabricaID = item.FabricaID;
                conta.DistribuidoraID = item.DistribuidoraID;
                conta.TipoContratoID = item.TipoContratoID;
                conta.TipoSubGrupoID = item.TipoSubGrupoID;
                conta.ConsumoNaPontaTUSD_Registrado = item.ConsumoNaPontaTUSD_Registrado;
                conta.ConsumoForaPontaTUSD_Registrado = item.ConsumoForaPontaTUSD_Registrado;
                conta.ConsumoNaPontaTE_Registrado = item.ConsumoNaPontaTE_Registrado;
                conta.ConsumoForaPontaTE_Registrado = item.ConsumoForaPontaTE_Registrado;
                conta.ConsumoUltrapassagemNaPonta_Registrado = item.ConsumoUltrapassagemNaPonta_Registrado;
                conta.ConsumoUltrapassagemForaPonta_Registrado = item.ConsumoUltrapassagemForaPonta_Registrado;
                conta.DemandaTUSD_Registrado = item.DemandaTUSD_Registrado;
                conta.ConsumoNaPontaTUSD_Contratado = item.ConsumoNaPontaTUSD_Contratado;
                conta.ConsumoForaPontaTUSD_Contratado = item.ConsumoForaPontaTUSD_Contratado;
                conta.ConsumoNaPontaTE_Contratado = item.ConsumoNaPontaTE_Contratado;
                conta.ConsumoForaPontaTE_Contratado = item.ConsumoForaPontaTE_Contratado;
                conta.DemandaTUSD_Contratado = item.DemandaTUSD_Contratado;
                conta.ConsumoNaPontaTUSD_Faturado = item.ConsumoNaPontaTUSD_Faturado;
                conta.ConsumoForaPontaTUSD_Faturado = item.ConsumoForaPontaTUSD_Faturado;
                conta.ConsumoNaPontaTE_Faturado = item.ConsumoNaPontaTE_Faturado;
                conta.ConsumoForaPontaTE_Faturado = item.ConsumoForaPontaTE_Faturado;
                conta.ConsumoUltrapassagemNaPonta_Faturado = item.ConsumoUltrapassagemNaPonta_Faturado;
                conta.ConsumoUltrapassagemForaPonta_Faturado = item.ConsumoUltrapassagemForaPonta_Faturado;
                conta.DemandaTUSD_Faturado = item.DemandaTUSD_Faturado;
                conta.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                conta.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                conta.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                conta.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                conta.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                conta.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTUSD_Valor = item.ConsumoNaPontaTUSD_Valor;
                conta.ConsumoForaPontaTUSD_Valor = item.ConsumoForaPontaTUSD_Valor;
                conta.ConsumoNaPontaTE_Valor = item.ConsumoNaPontaTE_Valor;
                conta.ConsumoForaPontaTE_Valor = item.ConsumoForaPontaTE_Valor;
                conta.ConsumoUltrapassagemNaPonta_Valor = item.ConsumoUltrapassagemNaPonta_Valor;
                conta.ConsumoUltrapassagemForaPonta_Valor = item.ConsumoUltrapassagemForaPonta_Valor;
                conta.DemandaTUSD_Valor = item.DemandaTUSD_Valor;
                conta.SubTotal = item.SubTotal;
                conta.ValorTotal = item.ValorTotal;
                conta.BandeiraID = item.BandeiraID;

                listaContas.Add(conta);
            }
            return listaContas;
        }

        public List<Conta> ConsultaEntreDatas(DateTime dataReferencia1, DateTime dataReferencia2, int FabricaID)
        {
            List<DAO.Models.ContaModel> ListContaDAO = DAO.Conta.ConsultaEntreDatas(dataReferencia1, dataReferencia2, FabricaID);
            List<Conta> listaContas = new List<Conta>();
            foreach (var item in ListContaDAO)
            {
                Conta conta = new Conta();

                conta.dataReferencia = item.dataReferencia;
                conta.TarifaID = item.TarifaID;
                conta.FabricaID = item.FabricaID;
                conta.DistribuidoraID = item.DistribuidoraID;
                conta.TipoContratoID = item.TipoContratoID;
                conta.TipoSubGrupoID = item.TipoSubGrupoID;
                conta.ConsumoNaPontaTUSD_Registrado = item.ConsumoNaPontaTUSD_Registrado;
                conta.ConsumoForaPontaTUSD_Registrado = item.ConsumoForaPontaTUSD_Registrado;
                conta.ConsumoNaPontaTE_Registrado = item.ConsumoNaPontaTE_Registrado;
                conta.ConsumoForaPontaTE_Registrado = item.ConsumoForaPontaTE_Registrado;
                conta.ConsumoUltrapassagemNaPonta_Registrado = item.ConsumoUltrapassagemNaPonta_Registrado;
                conta.ConsumoUltrapassagemForaPonta_Registrado = item.ConsumoUltrapassagemForaPonta_Registrado;
                conta.DemandaTUSD_Registrado = item.DemandaTUSD_Registrado;
                conta.ConsumoNaPontaTUSD_Contratado = item.ConsumoNaPontaTUSD_Contratado;
                conta.ConsumoForaPontaTUSD_Contratado = item.ConsumoForaPontaTUSD_Contratado;
                conta.ConsumoNaPontaTE_Contratado = item.ConsumoNaPontaTE_Contratado;
                conta.ConsumoForaPontaTE_Contratado = item.ConsumoForaPontaTE_Contratado;
                conta.DemandaTUSD_Contratado = item.DemandaTUSD_Contratado;
                conta.ConsumoNaPontaTUSD_Faturado = item.ConsumoNaPontaTUSD_Faturado;
                conta.ConsumoForaPontaTUSD_Faturado = item.ConsumoForaPontaTUSD_Faturado;
                conta.ConsumoNaPontaTE_Faturado = item.ConsumoNaPontaTE_Faturado;
                conta.ConsumoForaPontaTE_Faturado = item.ConsumoForaPontaTE_Faturado;
                conta.ConsumoUltrapassagemNaPonta_Faturado = item.ConsumoUltrapassagemNaPonta_Faturado;
                conta.ConsumoUltrapassagemForaPonta_Faturado = item.ConsumoUltrapassagemForaPonta_Faturado;
                conta.DemandaTUSD_Faturado = item.DemandaTUSD_Faturado;
                conta.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                conta.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                conta.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                conta.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                conta.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                conta.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTUSD_Valor = item.ConsumoNaPontaTUSD_Valor;
                conta.ConsumoForaPontaTUSD_Valor = item.ConsumoForaPontaTUSD_Valor;
                conta.ConsumoNaPontaTE_Valor = item.ConsumoNaPontaTE_Valor;
                conta.ConsumoForaPontaTE_Valor = item.ConsumoForaPontaTE_Valor;
                conta.ConsumoUltrapassagemNaPonta_Valor = item.ConsumoUltrapassagemNaPonta_Valor;
                conta.ConsumoUltrapassagemForaPonta_Valor = item.ConsumoUltrapassagemForaPonta_Valor;
                conta.DemandaTUSD_Valor = item.DemandaTUSD_Valor;
                conta.SubTotal = item.SubTotal;
                conta.ValorTotal = item.ValorTotal;
                conta.BandeiraID = item.BandeiraID;

                listaContas.Add(conta);
            }
            return listaContas;
        }

        public bool AtualizarConta(Conta _Conta)
        {
            DAO.Models.ContaModel ContaDAO = new DAO.Models.ContaModel();
            ContaDAO.dataReferencia = _Conta.dataReferencia;
            ContaDAO.TarifaID = _Conta.TarifaID;
            ContaDAO.FabricaID = _Conta.FabricaID;
            ContaDAO.DistribuidoraID = _Conta.DistribuidoraID;
            ContaDAO.TipoContratoID = _Conta.TipoContratoID;
            ContaDAO.TipoSubGrupoID = _Conta.TipoSubGrupoID;
            ContaDAO.ConsumoNaPontaTUSD_Registrado = _Conta.ConsumoNaPontaTUSD_Registrado;
            ContaDAO.ConsumoForaPontaTUSD_Registrado = _Conta.ConsumoForaPontaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTE_Registrado = _Conta.ConsumoNaPontaTE_Registrado;
            ContaDAO.ConsumoForaPontaTE_Registrado = _Conta.ConsumoForaPontaTE_Registrado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Registrado = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Registrado = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
            ContaDAO.DemandaTUSD_Registrado = _Conta.DemandaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTUSD_Contratado = _Conta.ConsumoNaPontaTUSD_Contratado;
            ContaDAO.ConsumoForaPontaTUSD_Contratado = _Conta.ConsumoForaPontaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTE_Contratado = _Conta.ConsumoNaPontaTE_Contratado;
            ContaDAO.ConsumoForaPontaTE_Contratado = _Conta.ConsumoForaPontaTE_Contratado;
            ContaDAO.DemandaTUSD_Contratado = _Conta.DemandaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTUSD_Faturado = _Conta.ConsumoNaPontaTUSD_Faturado;
            ContaDAO.ConsumoForaPontaTUSD_Faturado = _Conta.ConsumoForaPontaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTE_Faturado = _Conta.ConsumoNaPontaTE_Faturado;
            ContaDAO.ConsumoForaPontaTE_Faturado = _Conta.ConsumoForaPontaTE_Faturado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Faturado = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Faturado = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
            ContaDAO.DemandaTUSD_Faturado = _Conta.DemandaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTE_TarifaPreco = _Conta.ConsumoNaPontaTE_TarifaPreco;
            ContaDAO.ConsumoForaPontaTE_TarifaPreco = _Conta.ConsumoForaPontaTE_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            ContaDAO.DemandaTUSD_TarifaPreco = _Conta.DemandaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTUSD_Valor = _Conta.ConsumoNaPontaTUSD_Valor;
            ContaDAO.ConsumoForaPontaTUSD_Valor = _Conta.ConsumoForaPontaTUSD_Valor;
            ContaDAO.ConsumoNaPontaTE_Valor = _Conta.ConsumoNaPontaTE_Valor;
            ContaDAO.ConsumoForaPontaTE_Valor = _Conta.ConsumoForaPontaTE_Valor;
            ContaDAO.ConsumoUltrapassagemNaPonta_Valor = _Conta.ConsumoUltrapassagemNaPonta_Valor;
            ContaDAO.ConsumoUltrapassagemForaPonta_Valor = _Conta.ConsumoUltrapassagemForaPonta_Valor;
            ContaDAO.DemandaTUSD_Valor = _Conta.DemandaTUSD_Valor;
            ContaDAO.SubTotal = _Conta.SubTotal;
            ContaDAO.ValorTotal = _Conta.ValorTotal;
            ContaDAO.BandeiraID = _Conta.BandeiraID;

            if (DAO.Conta.AtualizarConta(ContaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletarConta(Conta _Conta)
        {
            DAO.Models.ContaModel ContaDAO = new DAO.Models.ContaModel();
            ContaDAO.dataReferencia = _Conta.dataReferencia;
            ContaDAO.TarifaID = _Conta.TarifaID;
            ContaDAO.FabricaID = _Conta.FabricaID;
            ContaDAO.DistribuidoraID = _Conta.DistribuidoraID;
            ContaDAO.TipoContratoID = _Conta.TipoContratoID;
            ContaDAO.TipoSubGrupoID = _Conta.TipoSubGrupoID;
            ContaDAO.ConsumoNaPontaTUSD_Registrado = _Conta.ConsumoNaPontaTUSD_Registrado;
            ContaDAO.ConsumoForaPontaTUSD_Registrado = _Conta.ConsumoForaPontaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTE_Registrado = _Conta.ConsumoNaPontaTE_Registrado;
            ContaDAO.ConsumoForaPontaTE_Registrado = _Conta.ConsumoForaPontaTE_Registrado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Registrado = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Registrado = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
            ContaDAO.DemandaTUSD_Registrado = _Conta.DemandaTUSD_Registrado;
            ContaDAO.ConsumoNaPontaTUSD_Contratado = _Conta.ConsumoNaPontaTUSD_Contratado;
            ContaDAO.ConsumoForaPontaTUSD_Contratado = _Conta.ConsumoForaPontaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTE_Contratado = _Conta.ConsumoNaPontaTE_Contratado;
            ContaDAO.ConsumoForaPontaTE_Contratado = _Conta.ConsumoForaPontaTE_Contratado;
            ContaDAO.DemandaTUSD_Contratado = _Conta.DemandaTUSD_Contratado;
            ContaDAO.ConsumoNaPontaTUSD_Faturado = _Conta.ConsumoNaPontaTUSD_Faturado;
            ContaDAO.ConsumoForaPontaTUSD_Faturado = _Conta.ConsumoForaPontaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTE_Faturado = _Conta.ConsumoNaPontaTE_Faturado;
            ContaDAO.ConsumoForaPontaTE_Faturado = _Conta.ConsumoForaPontaTE_Faturado;
            ContaDAO.ConsumoUltrapassagemNaPonta_Faturado = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
            ContaDAO.ConsumoUltrapassagemForaPonta_Faturado = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
            ContaDAO.DemandaTUSD_Faturado = _Conta.DemandaTUSD_Faturado;
            ContaDAO.ConsumoNaPontaTUSD_TarifaPreco = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoForaPontaTUSD_TarifaPreco = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTE_TarifaPreco = _Conta.ConsumoNaPontaTE_TarifaPreco;
            ContaDAO.ConsumoForaPontaTE_TarifaPreco = _Conta.ConsumoForaPontaTE_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemNaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            ContaDAO.ConsumoUltrapassagemForaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            ContaDAO.DemandaTUSD_TarifaPreco = _Conta.DemandaTUSD_TarifaPreco;
            ContaDAO.ConsumoNaPontaTUSD_Valor = _Conta.ConsumoNaPontaTUSD_Valor;
            ContaDAO.ConsumoForaPontaTUSD_Valor = _Conta.ConsumoForaPontaTUSD_Valor;
            ContaDAO.ConsumoNaPontaTE_Valor = _Conta.ConsumoNaPontaTE_Valor;
            ContaDAO.ConsumoForaPontaTE_Valor = _Conta.ConsumoForaPontaTE_Valor;
            ContaDAO.ConsumoUltrapassagemNaPonta_Valor = _Conta.ConsumoUltrapassagemNaPonta_Valor;
            ContaDAO.ConsumoUltrapassagemForaPonta_Valor = _Conta.ConsumoUltrapassagemForaPonta_Valor;
            ContaDAO.DemandaTUSD_Valor = _Conta.DemandaTUSD_Valor;
            ContaDAO.SubTotal = _Conta.SubTotal;
            ContaDAO.ValorTotal = _Conta.ValorTotal;
            ContaDAO.BandeiraID = _Conta.BandeiraID;

            if (DAO.Conta.DeletarConta(ContaDAO))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------Simulacao------------------------------------------------------------

        public bool GerarSimulacao(int fabricaID)
        {
            
            if (DAO.Simulacao.GerarSimulacao(fabricaID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------Grafico--------------------------------------------------------------

        public List<Grafico> DadosParaGrafico(int FabricaID)
        {
            List<DAO.Models.GraficoModel> ListGraficoDAO = DAO.Grafico.DadosParaGrafico(FabricaID);
            List<Grafico> listaGrafico = new List<Grafico>();
            foreach (var item in ListGraficoDAO)
            {
                Grafico grafico = new Grafico();

                grafico.DataDaSimulacao = item.DataDaSimulacao;
                grafico.DataReferencia = item.DataReferencia;
                grafico.TarifaOrigemID = item.TarifaOrigemID;
                grafico.TarifaDestinoID = item.TarifaDestinoID;
                grafico.FabricaID = item.FabricaID;
                grafico.DistribuidoraID = item.DistribuidoraID;
                grafico.TipoContratoID = item.TipoContratoID;
                grafico.TipoSubGrupoID = item.TipoSubGrupoID;
                grafico.BandeiraID = item.BandeiraID;
                grafico.ConsumoNaPontaTUSD_Registrado = item.ConsumoNaPontaTUSD_Registrado;
                grafico.ConsumoForaPontaTUSD_Registrado = item.ConsumoForaPontaTUSD_Registrado;
                grafico.ConsumoNaPontaTE_Registrado = item.ConsumoNaPontaTE_Registrado;
                grafico.ConsumoForaPontaTE_Registrado = item.ConsumoForaPontaTE_Registrado;
                grafico.ConsumoUltrapassagemNaPonta_Registrado = item.ConsumoUltrapassagemNaPonta_Registrado;
                grafico.ConsumoUltrapassagemForaPonta_Registrado = item.ConsumoUltrapassagemForaPonta_Registrado;
                grafico.DemandaTUSD_Registrado = item.DemandaTUSD_Registrado;
                grafico.ConsumoNaPontaTUSD_Contratado = item.ConsumoNaPontaTUSD_Contratado;
                grafico.ConsumoForaPontaTUSD_Contratado = item.ConsumoForaPontaTUSD_Contratado;
                grafico.ConsumoNaPontaTE_Contratado = item.ConsumoNaPontaTE_Contratado;
                grafico.ConsumoForaPontaTE_Contratado = item.ConsumoForaPontaTE_Contratado;
                grafico.DemandaTUSD_Contratado = item.DemandaTUSD_Contratado;
                grafico.ConsumoNaPontaTUSD_Faturado = item.ConsumoNaPontaTUSD_Faturado;
                grafico.ConsumoForaPontaTUSD_Faturado = item.ConsumoForaPontaTUSD_Faturado;
                grafico.ConsumoNaPontaTE_Faturado = item.ConsumoNaPontaTE_Faturado;
                grafico.ConsumoForaPontaTE_Faturado = item.ConsumoForaPontaTE_Faturado;
                grafico.ConsumoUltrapassagemNaPonta_Faturado = item.ConsumoUltrapassagemNaPonta_Faturado;
                grafico.ConsumoUltrapassagemForaPonta_Faturado = item.ConsumoUltrapassagemForaPonta_Faturado;
                grafico.DemandaTUSD_Faturado = item.DemandaTUSD_Faturado;
                grafico.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                grafico.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                grafico.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                grafico.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                grafico.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                grafico.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                grafico.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                grafico.ConsumoNaPontaTUSD_Valor = item.ConsumoNaPontaTUSD_Valor;
                grafico.ConsumoForaPontaTUSD_Valor = item.ConsumoForaPontaTUSD_Valor;
                grafico.ConsumoNaPontaTE_Valor = item.ConsumoNaPontaTE_Valor;
                grafico.ConsumoForaPontaTE_Valor = item.ConsumoForaPontaTE_Valor;
                grafico.ConsumoUltrapassagemNaPonta_Valor = item.ConsumoUltrapassagemNaPonta_Valor;
                grafico.ConsumoUltrapassagemForaPonta_Valor = item.ConsumoUltrapassagemForaPonta_Valor;
                grafico.DemandaTUSD_Valor = item.DemandaTUSD_Valor;
                grafico.SubTotal = item.SubTotal;
                grafico.ValorTotal = item.ValorTotal;
                grafico.TipoContratoDestinoID = item.TipoContratoDestinoID;

                listaGrafico.Add(grafico);
            }
            return listaGrafico;
        }


    }
}
