using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class OS : System.Web.UI.Page
    {
       // dao.AcessoLogin acessoLogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setNomeModulo(Page, "O.S.");
            Utils.setVoltarUrl(Page, Session);            

        }
    }
}