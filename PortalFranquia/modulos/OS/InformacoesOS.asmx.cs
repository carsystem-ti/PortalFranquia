using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using PortalFranquia.dao.OS;


namespace PortalFranquia.modulos.OS
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://carsystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]       
        public RetornoSelect[] getMotivosTroca()
        {
            daoOSConsulta DaoOSConsulta = new daoOSConsulta();
            DataTable dt = DaoOSConsulta.getMotivosTroca();

            if (dt.Rows.Count > 0)
            {
                RetornoSelect[] retorno = new RetornoSelect[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RetornoSelect ret = new RetornoSelect();
                    ret.texto = dt.Rows[i].Field<string>("str_Item");
                    ret.value = dt.Rows[i].Field<string>("str_Item");
                    retorno[i] = ret;
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                return retorno;
            }
            else
                return null;
        }
    }
    
    public class RetornoSelect
    {
        public string texto { get; set; }
        public string value { get; set; }
    }
}
