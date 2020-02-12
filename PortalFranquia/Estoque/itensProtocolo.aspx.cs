using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.Estoque
{
    public partial class itensProtocolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] == null)
                Response.Redirect("../Login.aspx");
        }
    }
}