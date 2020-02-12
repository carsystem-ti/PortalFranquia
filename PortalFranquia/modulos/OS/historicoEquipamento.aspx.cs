using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;

namespace PortalFranquia.modulos.OS
{
    
    public partial class historicoEquipamento : System.Web.UI.Page
    {
       
        


        const string nomeBanco = "Principal";
        CarSystem.BancoDados.Dados _bancoDados;

        public CarSystem.BancoDados.Dados bancoDados
        {
            get
            {
                if (_bancoDados == null)
                    _bancoDados = new CarSystem.BancoDados.Dados(nomeBanco, CarSystem.Tipos.Servidores.Fury
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["usuarioBanco"]
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["senhaBanco"]);

                return _bancoDados;
            }
            set { _bancoDados = value; }
        }
        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
            
            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaUsuario();
            if (Request.Form["pFuncao"] != null && Request.Form["pFuncao"].ToString() == "getHistorico")
            {
                getHistorico();
                Response.End();
            }

            Utils.setNomeModulo(this, "Consulta Historico");
            Utils.setVoltarUrl(Page, Session, "OS.aspx");            
        }
        [WebMethod(EnableSession = true)]
        public static string GetData(Vinculo Vinculo)
        {
            string retorno = "";
            
            
            
                if (Vinculo.pFranquia == "" || Vinculo.pCodigoEquipamento == "" || Vinculo.pVinculo == "" || Vinculo.pFranquia.Length < 6 || Vinculo.pCodigoEquipamento.Length < 5)
                {
                    retorno = "Preencha todos os valores corretamente.";
                }
                else
                {
                    historicoEquipamento hist = new historicoEquipamento();
                    retorno = hist.SetVinculo(Vinculo.pCodigoEquipamento, Vinculo.pFranquia, Convert.ToInt32(Vinculo.pVinculo));
                }
            
            string myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
            return myJsonString;
        }
        private string SetVinculo(string equipamento,string franquia,int tipoEstoque){
            try
            {
                //dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = "bdPrincipal.Estoque.pro_setGerencia";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                bancoDados.Comandos.adicionaParametro("@codigoEquipamento", System.Data.SqlDbType.VarChar, 6, equipamento);
                bancoDados.Comandos.adicionaParametro("@tipoEstoque", System.Data.SqlDbType.Int, 6, tipoEstoque);
                bancoDados.Comandos.adicionaParametro("@codigoLocalizacao", System.Data.SqlDbType.Char, 6, franquia);
                bancoDados.Comandos.adicionaParametro("@usuario", System.Data.SqlDbType.VarChar, 50, "supcetec");

                bancoDados.retornaDados = true;
                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                foreach (System.Data.DataRow iLinha in iTabelaRetorno.Rows)
                {
                    var retorno = Convert.ToInt32(iLinha["isErro"]);
                    if (retorno == 1)
                    {
                        return "Operação não realizada.";
                    }
                }
                
                bancoDados.Conexoes.close();
                
                return "Processo concluído.";
   
            }
            catch (Exception ex)
            {

                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public void getHistorico() {

            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                System.Data.DataTable iTabela = getHistorico(Request.Form["pCriterio"].ToString(), Convert.ToInt32(Request.Form["pTipoBusca"]));

                Session.Add("dt_Relatorio_Peca", iTabela);

                List<object> iLista = new List<object>();

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                    iLista.Add(
                                    new
                                    {
                                        prestadora = iLinha["OS Empresa"].ToString(),
                                        servico = iLinha["Servico Executado"].ToString(),
                                        isFranquia = iLinha["Venda Franquia"].ToString(),
                                        novoID = iLinha["Novo ID"].ToString(),
                                        velhoID = iLinha["Velho ID"].ToString(),
                                        contrato = iLinha["Contrato"].ToString(),
                                        emEstoque = iLinha["Em estoque"].ToString(),
                                        troca = iLinha["Troca"].ToString(),
                                        semEquipamento = iLinha["SemEquipamento"].ToString(),
                                        mensagem = iLinha["Mensagem"].ToString(),
                                        data = iLinha["Data"].ToString(),
                                        hora = iLinha["Hora"].ToString(),
                                        usuario = iLinha["Usuario"].ToString(),
                                        efetuado = iLinha["Efetuado"].ToString()
                                    }
                                );

                System.Web.Script.Serialization.JavaScriptSerializer jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
                Response.Write(jsonSerialiser.Serialize(iLista));
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public System.Data.DataTable getHistorico(string pCriterio, int pTipoBusca)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getLogEquipamentos";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@criterio", System.Data.SqlDbType.VarChar, 10, pCriterio);
                bancoDados.Comandos.adicionaParametro("@tipoBusca", System.Data.SqlDbType.TinyInt, 2, pTipoBusca);                
                bancoDados.retornaDados = true;

                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataTable dt = (Session["dt_Relatorio_Peca"] as DataTable);
            ExportarParaExcelSintetico(dt, "Relatorio_Peca");
        }

        public void ExportarParaExcelSintetico(DataTable dt_peça, string RelatorioPeca)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            foreach (DataColumn column in dt_peça.Columns)
            {
                context.Response.Write(column.ColumnName + "\t");
            }
            context.Response.Write(Environment.NewLine);

            foreach (DataRow row in dt_peça.Rows)
            {
                for (int i = 0; i < dt_peça.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + "\t");
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.ContentType = "application/ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + RelatorioPeca + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            context.Response.End();

        }
    }




    public class Vinculo
    {
        public string pFuncao { get; set; }  
        public string pCodigoEquipamento{ get; set; }  
        public string pFranquia{ get; set; }  
        public string pVinculo{ get; set; }  
    }
}