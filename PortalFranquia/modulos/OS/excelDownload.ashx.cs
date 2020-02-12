using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalFranquia.modulos.OS
{
    /// <summary>
    /// Summary description for excelDownload
    /// </summary>
    public class excelDownload : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            getFile(context);
        }

        public void getFile(HttpContext context)
        {
            try
            {
                dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)context.Session["acessoLogin"];

                string iCodigoCetec = iAcessoLogin.isSupervisor ? context.Request["pCodigoCetec"].ToString() : iAcessoLogin.cdCetec;
                object pLocalOS = context.Request["pLocalOS"];
                object iStatusOS = context.Request["pStatusOS"];
                DateTime iData = Convert.ToDateTime(context.Request["pData"]);
                object iServicoOS = context.Request["pServico"];

                dao.resumoOS iFuncoes = new dao.resumoOS();
                System.Data.DataTable iTabela = iFuncoes.getDetalhesOS(iCodigoCetec, Convert.ToInt32(pLocalOS), iStatusOS, iData, iServicoOS);

                context.Response.ContentType = "application/vnd.ms-excel";
                context.Response.AddHeader("Content-disposition", "attachment; filename=agenda.csv");

                string iLinhasArquivo = "";

                foreach (System.Data.DataColumn iColuna in iTabela.Columns)
                    iLinhasArquivo += iLinhasArquivo == "" ? iColuna.ColumnName : ";" + iColuna.ColumnName;

                context.Response.Write(iLinhasArquivo += "\r\n");

                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                {
                    context.Response.Write(iLinha["contrato"].ToString() 
                                            + ";" + iLinha["nome"].ToString() 
                                            + ";" + iLinha["telefone"].ToString() 
                                            + ";" + iLinha["celular"].ToString() 
                                            + ";" + iLinha["veiculo"].ToString() 
                                            + ";" + iLinha["servico"].ToString() 
                                            + ";" + iLinha["status"].ToString()
                                            + ";" + iLinha["codigoOS"].ToString()                                             
                                            + ";" + iLinha["horario"].ToString()                                            
                                            + ";" + iLinha["produto"].ToString()
                                            + ";" + iLinha["tecnico"].ToString()
                                            + ";" + iLinha["placa"].ToString() 
                                            + ";" + iLinha["local"].ToString() + "\r\n");
                }
            }
            catch (Exception ex)
            {
                int linhaErro = (new System.Diagnostics.StackTrace(ex, true)).GetFrame(0).GetFileLineNumber();
                context.Response.Write("ERRO##class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message + "\r\nLinha:" + linhaErro.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}