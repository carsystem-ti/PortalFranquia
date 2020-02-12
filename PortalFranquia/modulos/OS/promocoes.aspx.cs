using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;

namespace PortalFranquia.modulos.OS
{
    public partial class promocoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtContrato.Focus();
            Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dao.OS.Promocoes daoPromocoes = new dao.OS.Promocoes();
            try
            {
                lbMensagem.Text = daoPromocoes.verificaVoucher(txtContrato.Text, txtVoucher.Text, ((AcessoLogin)Session["acessoLogin"]).Nome);
                if (lbMensagem.Text.ToString().Contains("sucesso"))
                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                else
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                txtContrato.Focus();
            }
            catch (Exception ex)
            {
                lbMensagem.Text = ex.Message;
            }
            lbMensagem.Visible = true;
        }
    }
}