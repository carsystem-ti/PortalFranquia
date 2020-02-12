using PortalFranquia.dao.Cadastro;
using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Cliente
{
    public partial class IncluirObservacoesCadastro : System.Web.UI.Page
    {
        string strSessionUser = "";
        string strSessionGrupo = "";
        string strContrato;
        string strNome;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaUsuario();

            if (!IsPostBack)
            {
                strSessionUser = Request.QueryString["txtSessionUser"];
                strSessionGrupo = Request.QueryString["txtGrupo"];
                               
                strSessionUser = (strSessionUser == null) ? "000000" : strSessionUser;
                strSessionGrupo = (strSessionGrupo == null) ? "CETEC" : strSessionGrupo;

                Session.Add("strUser", strSessionUser);
                Session.Add("strGrupo", strSessionGrupo);
            }
            else
            {
                strSessionUser = Session["strUser"].ToString();
                strSessionGrupo = Session["strGrupo"].ToString();
            }

            strNome = Request.QueryString["txtNome"].ToString();
            strContrato = Request.QueryString["txtContrato"];

            lblContrato.Text = strContrato.ToString() + " - " + strNome.ToString();
        }

        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            gravaObs();
        }

        private void gravaObs()
        {
            daoCadastro docto = new daoCadastro();
            docto.pro_setIncluirObs(lblContrato.Text.ToString().Substring(0,6), strSessionUser.ToString(), txtObs.Text.ToString());



        }
    }
}