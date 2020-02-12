using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia
{
    public partial class homeEstoque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setNomeModulo(Page, "Estoque");
            Utils.setVoltarUrl(Page, Session, "Home.aspx");            
        }
    }
}