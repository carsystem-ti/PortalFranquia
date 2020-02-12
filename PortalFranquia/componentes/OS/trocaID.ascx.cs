using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;

namespace PortalFranquia.componentes.OS
{
    public partial class trocaID : System.Web.UI.UserControl
    {
        public string nrIDAtual
        {
            get
            {
                return txtIDAtual.Text;
            }
            set
            {
                txtIDAtual.Text = value;
            }
        }

        public void IDsLiberados(DataTable listaID)
        {
            ddlIDs.DataSource = listaID;
            ddlIDs.DataTextField = "id_item";
            ddlIDs.DataValueField = "id_item";
            ddlIDs.DataBind();
        }

        public void MotivosTroca(DataTable motivosTroca)        
        {
            ddlMotivoTroca.DataSource = motivosTroca;
            ddlMotivoTroca.DataTextField = "str_Item";
            ddlMotivoTroca.DataValueField = "str_Item";
            ddlMotivoTroca.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTroca_Click(object sender, EventArgs e)
        {
            daoOSConsulta DaoOSConsulta = (daoOSConsulta)Session["OSAberta"];

            try            
            {
                lbMens.Text = DaoOSConsulta.trocaPeca(ddlIDs.SelectedValue,  ((dao.AcessoLogin)Session["acessoLogin"]).Nome, ddlMotivoTroca.SelectedValue);
            }
            catch (Exception error)
            {
                lbMens.Text = " Erro: "  + error.Message;
            }

            
            lbMens.Visible = true;
            Utils.HidePesquisaMasterPage(this.Parent.Page.Master);            
        }
    }
}