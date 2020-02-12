using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia;


namespace PortalFranquia
{
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setNomeModulo(Page, "Relatórios");
            Utils.setVoltarUrl(Page, Session);
        }
    }
}