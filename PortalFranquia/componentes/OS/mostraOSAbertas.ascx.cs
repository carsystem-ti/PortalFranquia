using PortalFranquia.modulos.OS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.componentes.OS
{
    public partial class mostraOSAbertas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void ConfiguraGrid(string nome, DataTable dados)
        {
            grid.DataSource = dados;
            grid.DataBind();
            lbTitulo.Text = "Serviço: " + nome.ToUpper();
        }

       
    }

}