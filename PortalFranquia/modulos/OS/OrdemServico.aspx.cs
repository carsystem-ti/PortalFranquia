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
        ///private Dados _bancoDados;
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
                utilitario.BancoDados.Comandos.textoComando = "CepBR.[dbo].[Proc_REP_CT_GetCEP]";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@strCEP", SqlDbType.VarChar, 9, cep);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    endereco.Bairro = linha["Bairro"].ToString();
                    endereco.Cidade = linha["Cidade"].ToString();
                    endereco.Rua = linha["Rua"].ToString();
                    endereco.Uf = linha["Estado"].ToString();
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
            public string Rua { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
        }

        public class Km
        {
            public string CodigoCidade { get; set; }
            public string DescricaoCidade { get; set; }
        }
    }
}