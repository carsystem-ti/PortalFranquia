using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class EnderecoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCep.Text = Request.QueryString["txtCep"].ToString();
            lblEndereco.Text = Request.QueryString["txtEndereco"].ToString();
            lblNumero.Text = Request.QueryString["txtNumero"].ToString();

            lblComplemento.Text = Request.QueryString["txtComplemento"].ToString();
            lblBairro.Text = Request.QueryString["txtBairro"].ToString();
            lblCidade.Text = Request.QueryString["txtCidade"].ToString();
            lblUf.Text = Request.QueryString["txtUf"].ToString();

            lblReferencia.Text = Request.QueryString["txtReferencia"].ToString();
            lblRegiao.Text = Request.QueryString["txtRegiao"].ToString();
        }
    }
}