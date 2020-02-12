using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using PortalFranquia.dao;
using Dados = CarSystem.BancoDados.Dados;

namespace PortalFranquia.modulos.OS
{
    public partial class OrdemServico : Page
    {
        private const string NomeBanco = "Principal";
        //private Dados _bancoDados;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string RetornaOs(OrdemS ordem)
        {
            var retorno = "";
            string myJsonString;
            List<Cliente> listaClientes = new List<Cliente>();
            if (ordem.Contrato == "" && ordem.Placa == null && ordem.Documento == "")
            {

                retorno = "Preencha os valores corretamente.";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                OrdemServico ordemS = new OrdemServico();
                DataTable tabela = ordemS.RetornaCliente(ordem.Contrato, ordem.Placa, ordem.Documento);
                Cliente cliente;
                foreach (DataRow linha in tabela.Rows)
                {
                    cliente = new Cliente();
                    cliente.Equipamento = linha["Equipamento"].ToString();
                    cliente.Versao = linha["Versão NS"].ToString();
                    cliente.Ano = linha["Ano"].ToString();
                    cliente.AtivadoEm = linha["Ativado em"].ToString();
                    cliente.AtivadoAs = linha["Ativado as"].ToString();
                    cliente.AtivadoPor = linha["Ativado por"].ToString();
                    cliente.Chassi = linha["Chassi do veiculo"].ToString();
                    cliente.ClienteNome = linha["Nome"].ToString();
                    cliente.Combustivel = linha["Combustivel"].ToString();
                    cliente.ConfirmadaEm = linha["Confirmação da venda"].ToString();
                    cliente.Contrato = linha["Contrato"].ToString();
                    cliente.Cor = linha["Cor"].ToString();
                    cliente.DataInstalacao = linha["Data da instalaçao"].ToString();
                    cliente.DataNascimento = linha["Data Nascimento"].ToString();
                    cliente.DataVenda = linha["Data da venda"].ToString();
                    if (linha["Cnpj"].ToString() == "")
                    {
                        cliente.Documento = linha["Cpf"].ToString();
                    }
                    else if (linha["Cpf"].ToString() == "")
                    {
                        cliente.Documento = linha["Cnpj"].ToString();
                    }
                    cliente.Fabricante = linha["Fabricante"].ToString();
                    cliente.Instalador = linha["Instalador"].ToString();
                    cliente.Instaladora = linha["Instaladora"].ToString();
                    cliente.Modelo = linha["Modelo"].ToString();
                    cliente.Placa = linha["Placa"].ToString();
                    cliente.Renavam = linha["Renavan do veiculo"].ToString();
                    cliente.Rg = linha["Rg"].ToString();
                    cliente.StatusOs = linha["OS Status"].ToString();
                    cliente.StatusAtendimento = DefineStatusAtendimento(linha["Status de atendimento"].ToString());
                    cliente.StatusEquipamento = linha["Status Equipamento"].ToString();
                    cliente.StatusVenda = DefineStatusVenda(linha["Status Venda"].ToString());
                    cliente.TipoVeiculo = linha["Tipo de Veiculo"].ToString();
                    cliente.Vendedor = linha["Vendedor"].ToString();
                    cliente.ProximaRenovacao = linha["Prox. renovação"].ToString();
                    cliente.Produto = linha["Equipamento"].ToString();
                    if (cliente.Produto == "Plus")
                    {
                        cliente.Vigencia = ordemS.RetornaVigencia(cliente.Contrato);
                    }
                    try
                    {
                        cliente.AtivadoEm = cliente.AtivadoEm.Substring(0, 10) + " - " + cliente.AtivadoAs.Substring(11, 5);
                    }
                    catch (Exception)
                    {

                        cliente.AtivadoEm = "Sem data definida";
                    }
                    listaClientes.Add(cliente);
                }

                myJsonString = (new JavaScriptSerializer()).Serialize(listaClientes);
            }

            return myJsonString;
        }

        private static string DefineStatusAtendimento(string status)
        {
            string statusAtendimento;
            switch (status)
            {
                case "0":
                    statusAtendimento = "Normal";
                    break;
                case "1":
                    statusAtendimento = "Inadimplente";
                    break;
                case "2":
                    statusAtendimento = "Inativo";
                    break;
                default:
                    statusAtendimento = "";
                    break;
            }
            return statusAtendimento;
        }

        private static string DefineStatusVenda(string status)
        {
            string retorno;
            switch (status)
            {
                case "0":
                    retorno = "Confirmado";
                    break;
                case "1":
                    retorno = "Pendente";
                    break;
                case "2":
                    retorno = "Cancelado";
                    break;
                case "3":
                    retorno = "Em Cancelamento";
                    break;
                default:
                    retorno = status;
                    break;
            }
            return retorno;
        }

        private string RetornaVigencia(string contrato)
        {
            string dataVigencia = "";
            try
            {
                Utilitario uti = new Utilitario();
                uti.BancoDados.Comandos.limpaParametros();
                uti.BancoDados.Comandos.textoComando = NomeBanco + "dbo.pro_VIS_getDtVigenciaVistoria";
                uti.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;

                uti.BancoDados.Comandos.adicionaParametro("@nr_contrato", SqlDbType.VarChar, 10, contrato);
                uti.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = uti.BancoDados.execute().Tables[0];
                uti.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    dataVigencia = linha["dt_vigencia"].ToString();
                }

                return dataVigencia;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        private DataTable RetornaCliente(string contrato, string placa, string documento)
        {
            try
            {
                if (placa == null)
                {
                    placa = "";
                }
                Utilitario uti = new Utilitario();
                uti.BancoDados.Comandos.limpaParametros();
                uti.BancoDados.Comandos.textoComando = "dbo.pro_getClientes";
                uti.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                uti.BancoDados.Comandos.adicionaParametro("@strContrato", SqlDbType.VarChar, 10, contrato);
                uti.BancoDados.Comandos.adicionaParametro("@strPlaca", SqlDbType.VarChar, 8, placa);
                uti.BancoDados.Comandos.adicionaParametro("@strDocumento", SqlDbType.VarChar, 20, documento);
                uti.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = uti.BancoDados.execute().Tables[0];
                uti.BancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {

                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }


        [WebMethod]
        public static string RetornaOrdemServico(string contrato)
        {
            string retorno = "";
            string myJsonString;
            if (contrato == null)
            {
                retorno = "Contrato não preenchido!";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                OrdemServico ordemS = new OrdemServico();
                var os = ordemS.RetornaColunasOsDetalhada(ordemS.RetornaOsDetalhada(contrato));
                myJsonString = (new JavaScriptSerializer()).Serialize(os);
            }

            return myJsonString;
        }

        private static string DefineStatusOs(string status)
        {
            string retorno;
            switch (status)
            {
                case "0":
                    retorno = "Aberta";
                    break;
                case "1":
                    retorno = "Encerrada";
                    break;
                case "2":
                    retorno = "Cancelada";
                    break;
                case "3":
                    retorno = "Não Atendida";
                    break;
                case "4":
                    retorno = "Em Atendimento";
                    break;
                case "5":
                    retorno = "Concluído";
                    break;
                default:
                    retorno = "Não definido";
                    break;
            }
            return retorno;
        }

        private DataTable RetornaOsDetalhada(string contrato)
        {
            try
            {
                Utilitario uti = new Utilitario();
                uti.BancoDados.Comandos.limpaParametros();
                uti.BancoDados.Comandos.textoComando = NomeBanco + ".dbo.Proc_CAC_GetOsDetalhada";
                uti.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;

                uti.BancoDados.Comandos.adicionaParametro("@nr_contrato", SqlDbType.VarChar, 10, contrato);
                uti.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = uti.BancoDados.execute().Tables[0];
                uti.BancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {

                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        private string RetornaJumper(string contrato, string intLan)
        {
            string retorno = "";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".dbo.pro_buscaJumper";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;

                utilitario.BancoDados.Comandos.adicionaParametro("@nr_Contrato", SqlDbType.VarChar, 10, contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@nr_IntLan", SqlDbType.VarChar, 10, intLan);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    retorno = linha["fl_jumper"].ToString();
                }
                return retorno;
            }
            catch (Exception ex)
            {

                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        private List<OsDetalhada> RetornaColunasOsDetalhada(DataTable tabela)
        {
            List<OsDetalhada> listaOsDetalhada = new List<OsDetalhada>();
            foreach (DataRow linha in tabela.Rows)
            {
                OsDetalhada os = new OsDetalhada();
                os.AbertaAs = linha["AbertaAs"].ToString();
                os.AbertaEm = linha["AbertaEm"].ToString();
                os.AbertaPor = linha["AbertaPor"].ToString();
                os.AlteradoAs = linha["AlteradoAs"].ToString();
                os.AlteradoEm = linha["AlteradoEm"].ToString();
                os.AlteradoPor = linha["AlteradoPor"].ToString();
                os.Bairro = linha["Bairro"].ToString();
                os.Cidade = linha["Cidade"].ToString();
                os.DataVisita = linha["DataVisita"].ToString();
                os.EncerradaPor = linha["EncerradaPor"].ToString();
                os.EncerradaAs = linha["EncerradaAs"].ToString();
                os.EncerradaEm = linha["EncerradaEm"].ToString();
                os.Endereco = linha["Endereco"].ToString();
                os.HoraVisita = linha["HoraVisita"].ToString();
                os.InformacaoRegiao = linha["InformacaoRegiao"].ToString();
                os.InformacoesChamado = linha["InformacoesChamado"].ToString();
                os.Instalador = linha["Instalador"].ToString();
                os.IntLan = linha["IntLan"].ToString();
                os.MedidaAdotada = linha["MedidaAdotada"].ToString();
                os.Numero = linha["Numero"].ToString();
                os.NumeroEncerramento = linha["NumeroEncerramento"].ToString();
                os.StatusOs = DefineStatusOs(linha["StatusOs"].ToString());
                os.TipoChamado = linha["TipoChamado"].ToString();
                os.Uf = linha["Uf"].ToString();
                os.Jumper = RetornaJumper(os.Numero, os.IntLan);
                listaOsDetalhada.Add(os);
            }
            return listaOsDetalhada;
        }

        [WebMethod]
        public static string Informacao(string pedido, string numeroEncerramento, string campo, string observacao)
        {
            string retorno;
            string myJsonString;
            if (pedido == null || campo == null || observacao == null)
            {
                retorno = "Valores não preenchidos!";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                OrdemServico ordemS = new OrdemServico();
                string usuario = ordemS.RetornaUsuario();
                retorno = ordemS.IncluirInformacao(pedido, numeroEncerramento, campo, usuario, observacao);
                //var os = ordemS.RetornaColunasOsDetalhada(ordemS.RetornaOsDetalhada(pedido));
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            return myJsonString;
        }

        private string IncluirInformacao(string pedido, string numeroEncerramento, string campo, string usuario, string observacao)
        {
            const string retorno = "Cadastrado!";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".dbo.pro_OS_infChamado";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;

                utilitario.BancoDados.Comandos.adicionaParametro("@nr_pedido", SqlDbType.VarChar, 10, pedido);
                utilitario.BancoDados.Comandos.adicionaParametro("@nr_encerramento", SqlDbType.VarChar, 15, numeroEncerramento);
                utilitario.BancoDados.Comandos.adicionaParametro("@ds_campo", SqlDbType.VarChar, 3, campo);
                utilitario.BancoDados.Comandos.adicionaParametro("@ds_user", SqlDbType.VarChar, 50, usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@ds_obs", SqlDbType.VarChar, 8000, observacao);
                // utilitario.BancoDados.retornaDados = true;
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();

                //foreach (DataRow linha in iTabelaRetorno.Rows)
                //{
                //    retorno = linha["fl_jumper"].ToString();
                //}
                return retorno;
            }
            catch (Exception ex)
            {

                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        private string RetornaUsuario()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            return acessoLogin.Nome;
        }

        [WebMethod]
        public static string RetornaEndereco(string cep)
        {
            string retorno;
            string myJsonString;
            if (cep == null)
            {
                retorno = "Cep não preenchido!";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                OrdemServico ordemS = new OrdemServico();
                retorno = ordemS.EnderecoInformacao(cep);
                myJsonString = retorno;
            }
            return myJsonString;
        }

        private string EnderecoInformacao(string cep)
        {
            try
            {
                Endereco endereco = new Endereco();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = ".[dbo].[pro_getEnderecoCetecCep]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@cd_cetecCep", SqlDbType.VarChar, 9, cep);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    endereco.Estado = linha["Estado"].ToString();
                    endereco.Rua = linha["Rua"].ToString();
                    endereco.Bairro = linha["Bairro"].ToString();
                    endereco.Cidade = linha["Cidade"].ToString();
                    endereco.Numero = linha["Numero"].ToString();
                    endereco.Telefone = linha["Telefone"].ToString();

                }
                var myJsonString = (new JavaScriptSerializer()).Serialize(endereco);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaTipoChamadoOs(string statusCliente)
        {
            string retorno;
            string myJsonString;
            if (statusCliente == null)
            {
                retorno = "Favor recarregar a página!";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                OrdemServico ordemS = new OrdemServico();
                retorno = ordemS.TipoChamadoOs(statusCliente);
                myJsonString = retorno;
            }
            return myJsonString;
        }

        private string TipoChamadoOs(string statusCliente)
        {
            try
            {
                List<string> listaTipoChamado = new List<string>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_CADOS_getTipoChamadoOS]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@statusCliente", SqlDbType.VarChar, 50, statusCliente);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    listaTipoChamado.Add(linha["ds_os_tipo"].ToString());
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(listaTipoChamado);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaDistanciaKm()
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.DistanciaKm();
            var myJsonString = retorno;
            return myJsonString;
        }

        private string DistanciaKm()
        {
            try
            {
                List<Km> listaKm = new List<Km>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[Franquia].[pro_getKm]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    Km km = new Km
                    {
                        CodigoCidade = linha["strCodCid"].ToString(),
                        DescricaoCidade = linha["strDesc"].ToString()
                    };
                    listaKm.Add(km);
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(listaKm);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaAvisos()
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.AvisosOs();
            var myJsonString = retorno;
            return myJsonString;
        }

        private string AvisosOs()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            try
            {
                List<Avisos> listaAvisos = new List<Avisos>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_VIS_getOSVisita]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@empresaLoja", SqlDbType.VarChar, 10, acessoLogin.cdCetec);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    Avisos aviso = new Avisos()
                    {
                        NumeroOs = linha["IntLan"].ToString(),
                        Contrato = linha["Os pedido"].ToString(),
                        Chamado = linha["Chamado"].ToString(),
                        Aberto = linha["Aberta Em"].ToString(),
                        Empresa = linha["ds_empresa"].ToString()
                    };
                    listaAvisos.Add(aviso);
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(listaAvisos);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaRelatorioCetec(string numeroOs)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.RelatorioCetec(numeroOs);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string RelatorioCetec(string numeroOs)
        {
            try
            {
                Relatorio relatorio = new Relatorio();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[Proc_Web_RelatorioOS_Cetec]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@intLan", SqlDbType.Int, 10, numeroOs);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    relatorio.ControleOs = linha["Controle de os"].ToString();
                    relatorio.Id = linha["Id"].ToString();
                    relatorio.Pedido = linha["Pedido"].ToString();
                    relatorio.Nome = linha["Nome"].ToString();
                    relatorio.EnderecoCliente = linha["Endereço"].ToString();
                    relatorio.Numero = linha["Cl nmero residencia"].ToString();
                    relatorio.Cep = linha["Cep"].ToString();
                    relatorio.Complemento = linha["Complemento"].ToString();
                    relatorio.Bairro = linha["Bairro"].ToString();
                    relatorio.Cidade = linha["Cidade"].ToString();
                    relatorio.Uf = linha["Uf"].ToString();
                    relatorio.Telefone = linha["Tel"].ToString();
                    relatorio.Celular = linha["Celular"].ToString();
                    relatorio.PontoReferencia = linha["Ponto de referencia"].ToString();
                    relatorio.EnderecoChamado = linha["End do chamado"].ToString();
                    relatorio.NumeroChamado = linha["N do chamado"].ToString();
                    relatorio.Regiao = linha["N do chamado"].ToString();
                    relatorio.BairroChamado = linha["Bairr do chamado"].ToString();
                    relatorio.CidadeChamado = linha["Cid do chamado"].ToString();
                    relatorio.EstadoChamado = linha["Est do chamado"].ToString();
                    relatorio.FoneChamado = linha["F para contato no chamado"].ToString();
                    relatorio.ReferenciaChamado = linha["Ref para o chamado"].ToString();
                    relatorio.TipoVeiculo = linha["Tipo veiculo"].ToString();
                    relatorio.NumeroSerie = linha["N de serie"].ToString();
                    relatorio.Modelo = linha["Modelo do veiculo"].ToString();
                    relatorio.Placa = linha["Placa do veiculo"].ToString();
                    relatorio.Cor = linha["Cor"].ToString();
                    relatorio.Ano = linha["Ano"].ToString();
                    relatorio.Combustivel = linha["Comb do veiculo"].ToString();
                    relatorio.Renavam = linha["Renavan do veiculo"].ToString();
                    relatorio.Chassi = linha["Chassi do veiculo"].ToString();
                    relatorio.Produto = linha["P proudto"].ToString();
                    relatorio.AbertaEm = linha["Aberta em"].ToString();
                    relatorio.AbertaAs = linha["Aberta as"].ToString();
                    relatorio.HoraMarcada = linha["Hora marcada ou prometida"].ToString();
                    relatorio.VisitaMarcada = linha["Visita marcada para"].ToString();
                    relatorio.ChamadoDe = linha["Chamado de"].ToString();
                    relatorio.InformacoesChamado = linha["Informações chamado"].ToString();
                    relatorio.Peca = linha["Peca"].ToString();
                    relatorio.Versao = linha["Versao"].ToString();
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(relatorio);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name +
                                    "\r\n" + ex.Message);
            }
        }

       
        private string VisitaOs(string numeroOs)
        {
            try
            {
                Relatorio relatorio = new Relatorio();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_VIS_getOSVisita]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@empresaLoja", SqlDbType.VarChar, 10, numeroOs);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    relatorio.Versao = linha["Versao"].ToString();
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(relatorio);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name +
                                    "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaEmpresa()
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.EmpresaOs();
            var myJsonString = retorno;
            return myJsonString;
        }

        private string EmpresaOs()
        {
            string empresa = RetornaUsuario();
            empresa = empresa.Substring(0, 6);
            try
            {
                List<Empresa> listaEmpresas = new List<Empresa>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[Franquia].[pro_getEmpresas]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@codigoEmpresa", SqlDbType.VarChar, 6, empresa);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    Empresa empresas = new Empresa()
                    {
                        CodigoEmpresa = linha["codigoEmpresa"].ToString(),
                        NomeEmpresa = linha["nomeEmpresa"].ToString()
                    };
                    listaEmpresas.Add(empresas);
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(listaEmpresas);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaInstaladores(string codigoEmpresa)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.Instaladores(codigoEmpresa);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string Instaladores(string codigoEmpresa)
        {
            codigoEmpresa = codigoEmpresa.PadLeft(6, '0');
            try
            {
                List<string> listaInstaladores = new List<string>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[Franquia].[pro_getInstaladores]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@codigoEmpresa", SqlDbType.VarChar, 6, codigoEmpresa);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {

                    listaInstaladores.Add(linha["instalador"].ToString());

                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(listaInstaladores);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaUsuarioValidado()
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.UsuarioValidadoOs();
            var myJsonString = retorno;
            return myJsonString;
        }

        private string UsuarioValidadoOs()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            try
            {
                UsuarioValidado usuarioValidado = new UsuarioValidado();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[Franquia].[pro_getValidaUsuario]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@pUsuario", SqlDbType.VarChar, 25, acessoLogin.Nome);
                utilitario.BancoDados.Comandos.adicionaParametro("@pIdUsuario", SqlDbType.Int, 6, Convert.ToInt32(acessoLogin.idUsuario));
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    usuarioValidado.Altera = linha["fl_altera"].ToString();
                    usuarioValidado.Cadastro = linha["fl_cadastro"].ToString();
                    usuarioValidado.CepPrestadora = linha["Cep_Prestadora"].ToString();
                    usuarioValidado.CodigoRevenda = linha["id_revenda"].ToString();
                    usuarioValidado.Consulta = linha["fl_consulta"].ToString();
                    usuarioValidado.Grupo = linha["cd_grupo"].ToString();
                    usuarioValidado.Nome = linha["ds_nome"].ToString();
                    usuarioValidado.NomeRevenda = linha["ds_revenda"].ToString();
                    usuarioValidado.Uf = linha["UF"].ToString();
                }

                var myJsonString = (new JavaScriptSerializer()).Serialize(usuarioValidado);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }


        [WebMethod]
        public static void FlagVendaPendente(string contrato, string intLan)
        {
            OrdemServico ordemS = new OrdemServico();
            ordemS.VendaPendente(contrato, intLan);
            //var myJsonString = retorno;
            //return myJsonString;    
        }

        private void VendaPendente(string contrato, string intLan)
        {
            //const string retorno = "Cadastrado!";    
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_updt_FlagVendaPendente]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@strContrato", SqlDbType.VarChar, 10, contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@strLancamento", SqlDbType.VarChar, 10, intLan);
                //utilitario.BancoDados.retornaDados = true;
                //DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                //  var myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                //return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        #region Grava
        [WebMethod]
        public static string GravaOsAberta(Os ordemServico)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.OsAberta(ordemServico);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string OsAberta(Os ordemServico)
        {
            const string retorno = "Cadastrado!";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_setGravaOSAberta]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@strStatus", SqlDbType.Char, 1, ordemServico.Status);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_pedido", SqlDbType.VarChar, 10, ordemServico.Contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@Chamado_de", SqlDbType.VarChar, 20, ordemServico.TipoChamado);
                utilitario.BancoDados.Comandos.adicionaParametro("@Informações_chamado", SqlDbType.VarChar, -1, ordemServico.Informacao);
                utilitario.BancoDados.Comandos.adicionaParametro("@Usuario_Logado", SqlDbType.VarChar, 20, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Emp_instala", SqlDbType.VarChar, 6, ordemServico.Instaladora);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_instalador", SqlDbType.VarChar, 40, ordemServico.Instalador);
                utilitario.BancoDados.Comandos.adicionaParametro("@Visita_marcada_para", SqlDbType.VarChar, 10, ordemServico.DataMarcada);
                utilitario.BancoDados.Comandos.adicionaParametro("@Hora_marcada_ou_prometida", SqlDbType.DateTime, 10, ordemServico.HoraMarcada);
                utilitario.BancoDados.Comandos.adicionaParametro("@Hora_maxima_atender", SqlDbType.DateTime, 10, ordemServico.HoraMarcada);
                utilitario.BancoDados.Comandos.adicionaParametro("@End_do_chamado", SqlDbType.VarChar, 60, ordemServico.Endereco);
                utilitario.BancoDados.Comandos.adicionaParametro("@Bairro_do_chamado", SqlDbType.VarChar, 30, ordemServico.Bairro);
                utilitario.BancoDados.Comandos.adicionaParametro("@Cid_do_chamado", SqlDbType.VarChar, 25, ordemServico.Cidade);
                utilitario.BancoDados.Comandos.adicionaParametro("@Est_do_chamado", SqlDbType.VarChar, 3, ordemServico.Estado);
                utilitario.BancoDados.Comandos.adicionaParametro("@F_para_contato_no_chamado", SqlDbType.VarChar, 15, ordemServico.FoneContato);
                utilitario.BancoDados.Comandos.adicionaParametro("@Ref_para_o_chamado", SqlDbType.VarChar, 200, ordemServico.PontoReferencia);
                utilitario.BancoDados.Comandos.adicionaParametro("@Inf_regiao", SqlDbType.VarChar, 20, ordemServico.Informacao);
                utilitario.BancoDados.Comandos.adicionaParametro("@N_do_chamado", SqlDbType.VarChar, 6, ordemServico.Numero);
                utilitario.BancoDados.Comandos.adicionaParametro("@Saida_destino", SqlDbType.VarChar, 60, ordemServico.SaidaDestino);
                utilitario.BancoDados.Comandos.adicionaParametro("@Cod_cidades", SqlDbType.VarChar, 6, ordemServico.CodigoCidade);
                utilitario.BancoDados.Comandos.adicionaParametro("@IDOS", SqlDbType.VarChar, 10, ordemServico.Id);
                utilitario.BancoDados.Comandos.adicionaParametro("@Motivo_Cancelamento", SqlDbType.Char, 1, ordemServico.MotivoCancelamento);
                utilitario.BancoDados.Comandos.adicionaParametro("@Resolvido", SqlDbType.VarChar, 6, ordemServico.Resolvido);

                //utilitario.BancoDados.retornaDados = true;
                //DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                var myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string GravaOsEncerrada(Os ordemServico)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.OsEncerrada(ordemServico);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string OsEncerrada(Os ordemServico)
        {
            const string retorno = "Cadastrado!";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_setGravaOSEncerrada]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@strStatus", SqlDbType.Char, 1, ordemServico.Status);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_pedido", SqlDbType.VarChar, 10, ordemServico.Contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@Chamado_de", SqlDbType.VarChar, 20, ordemServico.TipoChamado);
                utilitario.BancoDados.Comandos.adicionaParametro("@IDOS", SqlDbType.VarChar, 10, ordemServico.Id);
                utilitario.BancoDados.Comandos.adicionaParametro("@Usuario_Logado", SqlDbType.VarChar, 20, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Vl_a_pagar", SqlDbType.Decimal, 10, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@serv_executado", SqlDbType.VarChar, 15, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@desc_serviço", SqlDbType.VarChar, 40, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Problema_foi_resolvido", SqlDbType.VarChar, 2, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Medida_adotada", SqlDbType.VarChar, -1, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Acao_do_serviço", SqlDbType.VarChar, 30, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Houvi_troca_equip", SqlDbType.Char, 1, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Ouvi_troca_de_gps", SqlDbType.Char, 1, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@O_novo_equipamento", SqlDbType.VarChar, 60, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Resolvido_por", SqlDbType.VarChar, 8, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@vlrPago", SqlDbType.Decimal, 10, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Emp_instala", SqlDbType.VarChar, 6, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_instalador", SqlDbType.VarChar, 40, ordemServico.Usuario);
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                var myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string GravaOsCancelada(Os ordemServico)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.OsCancelada(ordemServico);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string OsCancelada(Os ordemServico)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

            const string retorno = "Cadastrado!";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_setGravaOSCancelada]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_pedido", SqlDbType.VarChar, 10, ordemServico.Contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@IDOS", SqlDbType.VarChar, 10, ordemServico.Id);
                utilitario.BancoDados.Comandos.adicionaParametro("@Emp_instala", SqlDbType.VarChar, 6, acessoLogin.cdCetec);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_instalador", SqlDbType.VarChar, 40, ordemServico.Instalador);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_status", SqlDbType.Char, 1, ordemServico.Status);
                utilitario.BancoDados.Comandos.adicionaParametro("@Usuario_Logado", SqlDbType.VarChar, 20, acessoLogin.Nome);
                utilitario.BancoDados.Comandos.adicionaParametro("@Motivo_Cancelamento", SqlDbType.Char, 1, ordemServico.TipoChamado);
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                var myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string GravaOsAtendimento(Os ordemServico)
        {
            OrdemServico ordemS = new OrdemServico();
            var retorno = ordemS.OsAtendimento(ordemServico);
            var myJsonString = retorno;
            return myJsonString;
        }

        private string OsAtendimento(Os ordemServico)
        {
            const string retorno = "Cadastrado!";
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = NomeBanco + ".[dbo].[pro_setGravaOSEmAtendimento]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_pedido", SqlDbType.VarChar, 10, ordemServico.Contrato);
                utilitario.BancoDados.Comandos.adicionaParametro("@IDOS", SqlDbType.VarChar, 10, ordemServico.Id);
                utilitario.BancoDados.Comandos.adicionaParametro("@Emp_instala", SqlDbType.VarChar, 6, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_instalador", SqlDbType.VarChar, 40, ordemServico.Usuario);
                utilitario.BancoDados.Comandos.adicionaParametro("@Os_status", SqlDbType.Char, 1, ordemServico.Status);
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                var myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        #endregion


        public class OrdemS
        {
            public string Contrato { get; set; }
            public string Placa { get; set; }
            public string Documento { get; set; }
        }

        public class Cliente
        {
            public string Equipamento { get; set; }
            public string Versao { get; set; }

            public string Contrato { get; set; }
            public string StatusOs { get; set; }
            public string StatusEquipamento { get; set; }
            public string StatusAtendimento { get; set; }
            public string StatusVenda { get; set; }
            public string DataInstalacao { get; set; }
            public string AtivadoPor { get; set; }
            public string AtivadoEm { get; set; }
            public string AtivadoAs { get; set; }
            public string Instalador { get; set; }
            public string Instaladora { get; set; }

            public string ClienteNome { get; set; }
            public string Documento { get; set; }
            public string Rg { get; set; }
            public string DataNascimento { get; set; }
            public string DataVenda { get; set; }
            public string ConfirmadaEm { get; set; }
            public string Vendedor { get; set; }
            public string ProximaRenovacao { get; set; }
            public string Vigencia { get; set; }

            public string Fabricante { get; set; }
            public string Modelo { get; set; }
            public string Placa { get; set; }
            public string Ano { get; set; }
            public string TipoVeiculo { get; set; }
            public string Renavam { get; set; }
            public string Chassi { get; set; }
            public string Combustivel { get; set; }
            public string Cor { get; set; }
            public string Produto { get; set; }
        }

        public class OsDetalhada
        {
            public string NumeroEncerramento { get; set; }
            public string StatusOs { get; set; }
            public string IntLan { get; set; }
            public string TipoChamado { get; set; }
            public string DataVisita { get; set; }
            public string HoraVisita { get; set; }
            public string Instalador { get; set; }
            public string Endereco { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string InformacaoRegiao { get; set; }
            public string InformacoesChamado { get; set; }
            public string MedidaAdotada { get; set; }
            public string AbertaPor { get; set; }
            public string AbertaEm { get; set; }
            public string AbertaAs { get; set; }
            public string AlteradoPor { get; set; }
            public string AlteradoEm { get; set; }
            public string AlteradoAs { get; set; }
            public string EncerradaPor { get; set; }
            public string EncerradaEm { get; set; }
            public string EncerradaAs { get; set; }
            public string Jumper { get; set; }
        }

        public class Endereco
        {
            public string Estado { get; set; }
            public string Rua { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Numero { get; set; }
            public string Telefone { get; set; }
        }

        public class Km
        {
            public string CodigoCidade { get; set; }
            public string DescricaoCidade { get; set; }
        }

        public class Avisos
        {
            public string NumeroOs { get; set; }
            public string Contrato { get; set; }
            public string Chamado { get; set; }
            public string Aberto { get; set; }
            public string Empresa { get; set; }
        }

        public class Empresa
        {
            public string CodigoEmpresa { get; set; }
            public string NomeEmpresa { get; set; }
        }

        public class UsuarioValidado
        {
            public string CodigoRevenda { get; set; }
            public string Nome { get; set; }
            public string Grupo { get; set; }
            public string NomeRevenda { get; set; }
            public string Cadastro { get; set; }
            public string Consulta { get; set; }
            public string Altera { get; set; }
            public string Uf { get; set; }
            public string CepPrestadora { get; set; }
        }

        public class Os
        {
            public string Status { get; set; }
            public string Contrato { get; set; }
            public string TipoChamado { get; set; }
            public string Informacao { get; set; }
            public string Usuario { get; set; }
            public string Instaladora { get; set; }
            public string Instalador { get; set; }
            public string DataMarcada { get; set; }
            public string HoraMarcada { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string FoneContato { get; set; }
            public string PontoReferencia { get; set; }
            public string Regiao { get; set; }
            public string Numero { get; set; }
            public string SaidaDestino { get; set; }
            public string CodigoCidade { get; set; }
            public string Id { get; set; }
            public string MotivoCancelamento { get; set; }
            public string Resolvido { get; set; }

        }

        public class Relatorio
        {
            public string ControleOs { get; set; }
            public string Id { get; set; }
            public string Pedido { get; set; }
            public string Nome { get; set; }
            public string EnderecoCliente { get; set; }
            public string Numero { get; set; }
            public string Cep { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string Telefone { get; set; }
            public string Celular { get; set; }
            public string PontoReferencia { get; set; }
            public string EnderecoChamado { get; set; }
            public string NumeroChamado { get; set; }
            public string Regiao { get; set; }
            public string BairroChamado { get; set; }
            public string CidadeChamado { get; set; }
            public string EstadoChamado { get; set; }
            public string FoneChamado { get; set; }
            public string ReferenciaChamado { get; set; }
            public string TipoVeiculo { get; set; }
            public string NumeroSerie { get; set; }
            public string Modelo { get; set; }
            public string Placa { get; set; }
            public string Cor { get; set; }
            public string Ano { get; set; }
            public string Combustivel { get; set; }
            public string Renavam { get; set; }
            public string Chassi { get; set; }
            public string Produto { get; set; }
            public string AbertaEm { get; set; }
            public string AbertaAs { get; set; }
            public string HoraMarcada { get; set; }
            public string VisitaMarcada { get; set; }
            public string ChamadoDe { get; set; }
            public string InformacoesChamado { get; set; }
            public string Peca { get; set; }
            public string Versao { get; set; }
        }
    }
}
