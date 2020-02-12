using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.componentes;

namespace PortalFranquia
{
    public partial class Home : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (((string) Session["mensErroHome"]) != null)
            {
                lbMensErro.Text = Session["mensErroHome"].ToString();
                lbMensErro.Visible = true;
                Session["mensErroHome"] = null;
            }

            Utils.HideControlsMasterPage(Master);
            
        }
    }
}