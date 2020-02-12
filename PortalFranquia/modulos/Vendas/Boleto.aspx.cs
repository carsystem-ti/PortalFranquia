using PortalFranquia.dao.Vourcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Vendas
{
    public partial class Bleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_pedido"] != null)
            {
                Boleto(Convert.ToInt32(Session["id_pedido"].ToString()));
            }
        }
        private void Boleto(int id_pedido)
        {
            divBoleto.InnerHtml = "";
            daoVourcher bdp = new daoVourcher();
            divBoleto.InnerHtml = bdp.getExecuteBoleto(id_pedido);
        }
    }
}