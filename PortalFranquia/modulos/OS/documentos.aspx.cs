using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia;
using System.Data;

namespace PortalFranquia.modulos.OS
{
    public partial class documentos : System.Web.UI.Page
    {
        const string nomeBanco = "Principal";
        CarSystem.BancoDados.Dados _bancoDados;

        public CarSystem.BancoDados.Dados bancoDados
        {
            get
            {
                if (_bancoDados == null)
                    _bancoDados = new CarSystem.BancoDados.Dados(nomeBanco, CarSystem.Tipos.Servidores.Fury
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["usuarioBanco"]
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["senhaBanco"]);

                return _bancoDados;
            }
            set { _bancoDados = value; }
        }
        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSessionUser = "";
            string strSessionGrupo = "";

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

            Utils.setNomeModulo(Page, "Documentos");
            Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");

            
        }

        protected void btnCertificado_Click(object sender, EventArgs e)
        {
            string strSessionUser = "";
            string strSessionGrupo = "";
            string url;

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

            url = "Certificado.aspx?txtContrato=" + txtContrato.Text.ToString() + "&User=" + strSessionUser.ToString();
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=800,WIDTH=1100,top=250,left=150,toolbar=no,scrollbars=no,resizable=yes');</script>");
            //Response.Redirect(url);
        }

        protected void btnCarne_Click(object sender, EventArgs e)
        {
            string url;
            string strOptions;

            if (txtContrato.Text.ToString() != "")
            {
                lblMensagem.Text = "";

                url = "https://portal.carsystem.com/webBoleto/listaDebitos.aspx?txtContrato=" + txtContrato.Text.ToString() + "&codEmpresa=1";
                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=500,WIDTH=900,top=150,left=150,toolbar=no,scrollbars=no,resizable=yes');</script>");

            }
            else
            {
                lblMensagem.Text = "Favor preencher o número do contrato";
            }
        }

        protected void btnCheckList_Click(object sender, EventArgs e)
        {
            string url;

            if (txtContrato.Text.ToString() != "")
            {
                lblMensagem.Text = "";

                url = "https://portal.carsystem.com/Carsystemweb/checkList/CheckListCarro.aspx?txtContrato=" + txtContrato.Text.ToString();
                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=800,WIDTH=1100,top=250,left=150,toolbar=no,scrollbars=no,resizable=yes');</script>");
            }
            else
            {
                lblMensagem.Text = "Favor preencher o número do contrato";
            }
        }

        protected void btnAutorizacao_Click(object sender, EventArgs e)
        {
            string url;

            if (txtContrato.Text.ToString() != "")
            {
                lblMensagem.Text = "";

                url = "https://portal.carsystem.com/carsystemweb/Caixa%20Cetec/CAC/CartaTransferencia.aspx?txtContrato=" + txtContrato.Text.ToString();
                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=800,WIDTH=800,top=250,left=150,toolbar=no,scrollbars=no,resizable=yes');</script>");
            }
            else
            {
                lblMensagem.Text = "Favor preencher o número do contrato";
            }
        }

        protected void btnReciboEntrega_Click(object sender, EventArgs e)
        {
            string url;

            if (txtContrato.Text.ToString() != "")
            {
                lblMensagem.Text = "";

                url = "ReciboEntrega.aspx?txtContrato=" + txtContrato.Text.ToString();
                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=800,WIDTH=1100,top=250,left=150,toolbar=no,scrollbars=no,resizable=yes');</script>");
            }
            else
            {
                lblMensagem.Text = "Favor preencher o número do contrato";
            }
        }
    }
}