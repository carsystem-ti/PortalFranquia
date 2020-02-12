using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia
{
    public partial class HomeVendas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if ((acessoLogin.dsTipo != "G") && (acessoLogin.dsTipo != "V") && (acessoLogin.dsTipo != "X") && (acessoLogin.dsTipo != "A"))
            {
                Utils.SemPermissão(Response, Session);
            }
            
            Utils.setVoltarUrl(Page,Session);
        }
    }
}