using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia
{
    public partial class HomeVendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session);
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.dsTipo != "G")
            {
                Utils.SemPermissão(Response, Session);
            }

            
        }
    }
}