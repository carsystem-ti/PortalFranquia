using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Agenda
{
    public partial class Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ( Request.Form["pFuncao"] == null )
            //    return;

            string pFuncao = "getResumoOS"; // Request.Form["pFuncao"];

            switch (pFuncao)
            {
                case "getResumoOS":
                    getResumoOS();
                    break;
                default:
                    return;
            }

            Response.End();
        }

        //Franquia.pro_getResumoOS ( @dataInicial datetime,  @dataFinal datetime, @codigoCetec char(6) )
        private void getResumoOS()
        {
            DateTime iDataInicial; DateTime iDataFinal; string iCodigoCetec;

            dao.AcessoLogin iAcessoLogin = new dao.AcessoLogin("000906-PATRICIA", "1803"); // (dao.AcessoLogin)Session["acessoLogin"];

            if (Request["start"] != null)
                iDataInicial = Convert.ToDateTime(Request["start"]);
            else
            {
                iDataInicial = Convert.ToDateTime("27/10/2013");
                //Response.Write("Data incial não informada!!");
                //return;
            }

            if (Request["end"] != null)
                iDataFinal = Convert.ToDateTime(Request["end"]);
            else
            {
                iDataFinal = Convert.ToDateTime("7/12/2013");
                //Response.Write("Data final não informada!!");
                //return;
            }

            iCodigoCetec = iAcessoLogin.cdCetec;

            if (iAcessoLogin.isSupervisor && Request.Form["pCodigoCetec"] != null)
                iCodigoCetec = Request.Form["pCodigoCetec"];

            funcoesAgenda iFuncoes = new funcoesAgenda();

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

    }
}