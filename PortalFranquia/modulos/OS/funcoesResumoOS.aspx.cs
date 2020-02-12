using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class funcoesResumoOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Form["pFuncao"] == null)
                    return;

                if (Session["acessoLogin"] == null)
                {
                    //Session["acessoLogin"] = new dao.AcessoLogin("supcetec", "geral"); //("000906-PATRICIA", "1803"); // (dao.AcessoLogin)Session["acessoLogin"];
                    Response.Redirect("../../Login.aspx");
                }

                string pFuncao = Request.Form["pFuncao"].ToString();

                switch (pFuncao)
                {
                    case "getResumoOS":
                        getResumoOS();
                        break;
                    case "getDetalhesOS":
                        getDetalhesOS();
                        break;
                    case "getDetalhesOSFiltros":
                        getDetalhesOSFiltros();
                        break;
                    case "getFranquiasRegiao":
                        getFranquiasRegiao();
                        break;
                    case "getFile":
                        getFile();
                        break;
                    case "email":
                        sendEmail();
                        break;
                    default:
                        return;
                }

                //Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }

        }

        //Franquia.pro_getResumoOS ( @dataInicial datetime,  @dataFinal datetime, @codigoCetec char(6) )
        private void getResumoOS()
        {
            try
            {
                DateTime iDataInicial; DateTime iDataFinal; string iCodigoCetec;

                if (Request.Form["start"] != null)
                    iDataInicial = Convert.ToDateTime(Request["start"]);
                else
                {
                    iDataInicial = Convert.ToDateTime("27/10/2013");
                    //Response.Write("Data incial não informada!!");
                    //return;
                }

                if (Request.Form["end"] != null)
                    iDataFinal = Convert.ToDateTime(Request["end"]);
                else
                {
                    iDataFinal = Convert.ToDateTime("7/12/2013");
                    //Response.Write("Data final não informada!!");
                    //return;
                }

                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

                iCodigoCetec = iAcessoLogin.isSupervisor ? Request.Form["pCodigoCetec"].ToString() : iAcessoLogin.cdCetec;

                if (iAcessoLogin.isSupervisor && Request.Form["pCodigoCetec"] != null)
                    iCodigoCetec = Request.Form["pCodigoCetec"];

                dao.resumoOS iFuncoes = new dao.resumoOS();

                System.Collections.ArrayList iListaEventos = new System.Collections.ArrayList();
                List<object> eventList = new List<object>();

                foreach (System.Data.DataRow iLinha in iFuncoes.getResumoOS(iDataInicial, iDataFinal, iCodigoCetec).Rows)
                    iListaEventos.Add(
                                        new
                                        {
                                            title = iLinha["descricaoStatus"].ToString() + ":" + iLinha["quantidade"].ToString(),
                                            start = iLinha["data"].ToString(),
                                            allDay = "true"
                                        }
                                    );

                System.Web.Script.Serialization.JavaScriptSerializer jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = jsonSerialiser.Serialize(iListaEventos);
                Response.Write(json);
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public void getDetalhesOS()
        {
            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                dao.resumoOS iFuncoes = new dao.resumoOS();

                string iCodigoCetec = iAcessoLogin.isSupervisor ? Request.Form["pCodigoCetec"].ToString() : iAcessoLogin.cdCetec;
                object pLocalOS = Request.Form["pLocalOS"];
                object iStatusOS = Request.Form["pStatusOS"];
                DateTime iData = Convert.ToDateTime(Request.Form["pData"]);
                object iServicoOS = Request.Form["pServico"];

                System.Data.DataTable iTabela = iFuncoes.getDetalhesOS(iCodigoCetec, Convert.ToInt32(pLocalOS), iStatusOS, iData, iServicoOS);

                List<object> iLista = new List<object>();

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                    iLista.Add(
                                    new
                                    {
                                        contrato = iLinha["contrato"].ToString(),
                                        nome = iLinha["nome"].ToString(),
                                        telefone = iLinha["telefone"].ToString(),
                                        celular = iLinha["celular"].ToString(),
                                        veiculo = iLinha["veiculo"].ToString(),
                                        servico = iLinha["servico"].ToString(),
                                        status = iLinha["status"].ToString(),
                                        produto = iLinha["produto"].ToString(),
                                        horario = iLinha["horario"].ToString(),
                                        tecnico = iLinha["tecnico"].ToString(),
                                        codigoOS = iLinha["codigoOS"].ToString(),
                                        placa = iLinha["placa"].ToString(),
                                        local = iLinha["local"].ToString()
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

        public void getDetalhesOSFiltros()
        {
            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                dao.resumoOS iFuncoes = new dao.resumoOS();

                string iCodigoCetec = iAcessoLogin.isSupervisor ? Request.Form["pCodigoCetec"].ToString() : iAcessoLogin.cdCetec;
                DateTime iData = Convert.ToDateTime(Request.Form["pData"]);
                int pLocalOS = Convert.ToInt32(Request.Form["pLocalOS"]);

                System.Data.DataTable iTabela = iFuncoes.getDetalhesOSFiltros(iCodigoCetec, iData, pLocalOS);

                List<object> iLista = new List<object>();

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                    iLista.Add(
                                    new
                                    {
                                        servico = iLinha["servico"].ToString(),
                                        quantidade = iLinha["quantidade"].ToString(),
                                        status = iLinha["status"].ToString(),
                                        visita = iLinha["visita"].ToString(),
                                        loja = iLinha["loja"].ToString(),
                                        agenda = iLinha["agendaWeb"].ToString()
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


        public void getFranquiasRegiao()
        {
            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                dao.resumoOS iFuncoes = new dao.resumoOS();

                System.Data.DataTable iTabela = iFuncoes.getFranquiasRegiao();

                List<object> iLista = new List<object>();

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                {
                    if (iAcessoLogin.cdCetec == iLinha["cd_cetec"].ToString() || iAcessoLogin.isSupervisor)
                    {
                        iLista.Add(
                                        new
                                        {
                                            franquia = iLinha["franquia"].ToString(),
                                            regiao = iLinha["regiao"].ToString(),
                                            codigoCetec = iLinha["cd_cetec"].ToString(),
                                            id = iAcessoLogin.isSupervisor ? "franquia-ativa" : (iAcessoLogin.cdCetec == iLinha["cd_cetec"].ToString() ? "franquia-ativa" : "franquia-inativa")
                                        }
                                    );
                    }
                }

                System.Web.Script.Serialization.JavaScriptSerializer jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
                Response.Write(jsonSerialiser.Serialize(iLista));
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }//getFranquiasRegiao

        public void getFile()
        {
            string sFileName = System.IO.Path.GetRandomFileName();
            string sGenName = "agenda.csv";

            Response.AddHeader("Content-disposition", "attachment; filename=" + sGenName);
            Response.ContentType = "application/vnd.ms-excel";

            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                dao.resumoOS iFuncoes = new dao.resumoOS();

                string iCodigoCetec = iAcessoLogin.isSupervisor ? Request.Form["pCodigoCetec"].ToString() : iAcessoLogin.cdCetec;
                object pLocalOS = Request.Form["pLocalOS"];
                object iStatusOS = Request.Form["pStatusOS"];
                DateTime iData = Convert.ToDateTime(Request.Form["pData"]);
                object iServicoOS = Request.Form["pServico"];

                System.Data.DataTable iTabela = iFuncoes.getDetalhesOS(iCodigoCetec, Convert.ToInt32(pLocalOS), iStatusOS, iData, iServicoOS);

                List<object> iLista = new List<object>();

                string iNomeCampos = "";

                foreach (System.Data.DataColumn iColuna in iTabela.Columns)
                    iNomeCampos += iNomeCampos == "" ? iColuna.ColumnName : "," + iColuna.ColumnName;

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                {
                    Response.Write(iLinha["contrato"].ToString() + "," +
                    iLinha["nome"].ToString() + "," +
                    iLinha["telefone"].ToString() + "," +
                    iLinha["celular"].ToString() + "," +
                    iLinha["veiculo"].ToString() + "," +
                    iLinha["servico"].ToString() + "," +
                    iLinha["status"].ToString() + "," +
                    iLinha["produto"].ToString() + "," +
                    iLinha["horario"].ToString() + "," +
                    iLinha["tecnico"].ToString() + "," +
                    iLinha["codigoOS"].ToString() + "," +
                    iLinha["placa"].ToString() + "," +
                    iLinha["local"].ToString() + "\r\n");
                }
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }

            Response.End();
        }
        private void sendEmail()
        {
            try
            {
                if (Request.Form["pCodigoOS"] == null || Request.Form["pEnderecoEmail"] == null)
                {
                    Response.Write("Parametros Invalidos");
                    return;
                }

                Session.Add("pCodigoOS", Request.Form["pCodigoOS"]);

                //string pConteudo = Request.Form["pConteudo"].ToString();// CarSystem.Utilidades.Rede.HTML.getInfoURL("impressaoOS.aspx", "", "", "", 0, "pCodigoOS=" + Request.Form["pCodigoOS"]);
                //string nomeArquivo = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".html");

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                CarSystem.Utilidades.Rede.Email.IsBodyHtml = true;

                Server.Execute("impressaoOS.aspx", htw);

                //nomeArquivo = CarSystem.Utilidades.IO.Arquivo.stringTOtxt(nomeArquivo, pConteudo);

                if (CarSystem.Utilidades.Rede.Email.enviaEmail("naoresponda@carsystem.com", Request.Form["pEnderecoEmail"].ToString(), "OS CarSystem", sw.ToString(),""))
                    Response.Write("Email enviado!");
                else
                    Response.Write("Email NAO enviado!");
            }
            catch (Exception ex)
            {
                Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
    }
}
