using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;

namespace PortalFranquia.componentes.OS
{
    public partial class selecionaInstalador : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void carregaInstaladores(daoOSConsulta DaoOSConsulta)
        {
            ddlInstalador.DataSource = DaoOSConsulta.getTecnicos("000906");
            ddlInstalador.DataValueField = "ds_Instalador";
            ddlInstalador.DataTextField = "ds_Instalador";
            ddlInstalador.DataBind();
        }

        public string getInformacoesAdicionais()
        {
            return txtInformacoesAdicionais.Text;
        }

        public string getNomeInstalador()
        {
            return ddlInstalador.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            daoOSConsulta DaoConsulta = (daoOSConsulta)Session["OSAberta"];
            try
            {
                lbMensErro.Text = DaoConsulta.voucher(txtVoucher.Text);
            }
            catch (Exception ex)
            {
                lbMensErro.Text = "Erro: " + ex.Message;
            }
            lbMensErro.Visible = true;
        }
    }
}