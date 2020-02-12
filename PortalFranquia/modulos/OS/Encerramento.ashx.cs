using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace PortalFranquia.modulos.OS
{
    /// <summary>
    /// Descrição resumida de Encerramento
    /// </summary>
    public class Encerramento : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "texto/simples";
            context.Response.Write("Olá, Mundo");
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static void atende(int numeroDetalhes)
        {

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