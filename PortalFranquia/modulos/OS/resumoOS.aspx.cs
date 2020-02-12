using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class resumoOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session, "../../Home.aspx");
        }
    }
}