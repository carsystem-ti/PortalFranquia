using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Cliente
{
    public partial class Erro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErroMensagem.Text = Request.QueryString["strMensagem"].ToString();
        }
    }
}