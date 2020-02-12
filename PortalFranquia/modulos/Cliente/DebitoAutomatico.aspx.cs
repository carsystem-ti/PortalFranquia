using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using PortalFranquia.modulos.OS;

namespace PortalFranquia.modulos.Cliente
{
    public partial class DebitoAutomatico : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setNomeModulo(Page, "Cliente - Débito Automático");
            Utils.setVoltarUrl(Page, Session, "~/modulos/Cliente/Cliente.aspx");
        }

        [WebMethod]
        public static string RetornaDadosCliente(string contrato)
        {
            string retorno = "";
            string myJsonString;
            if (contrato == null)
            {
                retorno = "Contrato não preenchido";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                DebitoAutomatico debitoAutomatico = new DebitoAutomatico();
                myJsonString = debitoAutomatico.ClienteInformacao(contrato);
            }
            return myJsonString;
        }

        private string ClienteInformacao(string contrato)
        {
            try
            {
                DadosCliente cliente = new DadosCliente();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = "sgb.Debito.pro_getDadosAutomatico";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroContrato", SqlDbType.VarChar, 10, contrato);
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    cliente.Documento = linha["documentoCliente"].ToString();
                    cliente.Nome = linha["nomeCliente"].ToString();
                    cliente.Placa = linha["placaVeiculo"].ToString();
                }
                var myJsonString = (new JavaScriptSerializer()).Serialize(cliente);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetirarDebitoAutomatico(string contrato)
        {
            string retorno = "";
            string myJsonString;
            if (contrato == null)
            {
                retorno = "Contrato não preenchido";
                myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            }
            else
            {
                DebitoAutomatico debitoAutomatico = new DebitoAutomatico();
                myJsonString = debitoAutomatico.RetirarContrato(contrato);
            }
            return myJsonString;
        }

        private string RetirarContrato(string contrato)
        {
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = "sgb.Debito.pro_setRetiraDebito";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroContrato", SqlDbType.VarChar, 10, contrato);
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                return "O contrato: " + contrato + " foi retirado do débito automático.";
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }

        }

        [WebMethod]
        public static string AdicionarDebitoAutomatico(AdicionarDebito adicionar)
        {
           // string retorno = null;
            string myJsonString;

            DebitoAutomatico debitoAutomatico = new DebitoAutomatico();
            myJsonString = debitoAutomatico.AdicionarDebito(adicionar);

            return myJsonString;
        }

        private string AdicionarDebito(AdicionarDebito adicionar)
        {
            try
            {
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = "sgb.Debito.pro_setDadosAutomatico";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.Comandos.adicionaParametro("@nomeBanco", SqlDbType.VarChar, 20, adicionar.NomeBanco);
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroAgencia", SqlDbType.VarChar, 15, adicionar.NumeroAgencia);
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroConta", SqlDbType.VarChar, 15, adicionar.NumeroConta);
                utilitario.BancoDados.Comandos.adicionaParametro("@digitoAgencia", SqlDbType.TinyInt, 15, adicionar.DigitoAgencia);
                utilitario.BancoDados.Comandos.adicionaParametro("@digitoConta", SqlDbType.TinyInt, 15, adicionar.DigitoConta);
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroDocumento", SqlDbType.VarChar, 19, adicionar.NumeroDocumento);
                utilitario.BancoDados.Comandos.adicionaParametro("@titular", SqlDbType.VarChar, 103, adicionar.Titular);
                utilitario.BancoDados.Comandos.adicionaParametro("@cartaoCredito", SqlDbType.VarChar, 16, adicionar.CartaoCredito);
                utilitario.BancoDados.Comandos.adicionaParametro("@dataValidade", SqlDbType.Char, 4, adicionar.DataValidade);
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroSeguranca", SqlDbType.VarChar, 5, adicionar.NumeroSeguranca);
                utilitario.BancoDados.Comandos.adicionaParametro("@tipoDebito", SqlDbType.TinyInt, 5, adicionar.TipoDebito);
                utilitario.BancoDados.Comandos.adicionaParametro("@numeroContrato", SqlDbType.VarChar, 10, adicionar.NumeroContrato);
                utilitario.BancoDados.execute();
                utilitario.BancoDados.Conexoes.close();
                return "O contrato: " + adicionar.NumeroContrato + " foi adicionado ao débito automático.";
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        [WebMethod]
        public static string RetornaBancos()
        {
            DebitoAutomatico debitoAutomatico = new DebitoAutomatico();
            return debitoAutomatico.Bancos();
        }

        private string Bancos()
        {
            var myJsonString = "";
            try
            {
                List<string> listaBanco = new List<string>();
                Utilitario utilitario = new Utilitario();
                utilitario.BancoDados.Comandos.limpaParametros();
                utilitario.BancoDados.Comandos.textoComando = "sgb.Debito.pro_getBancos";
                utilitario.BancoDados.Comandos.tipoComando = CommandType.StoredProcedure;
                utilitario.BancoDados.retornaDados = true;
                DataTable iTabelaRetorno = utilitario.BancoDados.execute().Tables[0];
                utilitario.BancoDados.Conexoes.close();

                foreach (DataRow linha in iTabelaRetorno.Rows)
                {
                    listaBanco.Add(linha["Banco"].ToString());
                }
                myJsonString = (new JavaScriptSerializer()).Serialize(listaBanco);
                return myJsonString;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }

        }
    }

    public class DadosCliente
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Placa { get; set; }
    }

    public class AdicionarDebito
    {
        public string NomeBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public string DigitoAgencia { get; set; }
        public string DigitoConta { get; set; }
        public string NumeroDocumento { get; set; }
        public string Titular { get; set; }
        public string CartaoCredito { get; set; }
        public string DataValidade { get; set; }
        public string NumeroSeguranca { get; set; }
        public string TipoDebito { get; set; }
        public string NumeroContrato { get; set; }
    }
}