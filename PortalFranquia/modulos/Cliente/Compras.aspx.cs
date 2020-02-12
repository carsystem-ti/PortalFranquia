using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Cliente
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSessionUser = "";
            string strSessionGrupo = "";

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

            string strContrato;

            strContrato = Request.QueryString["txtContrato"];
            buscarCompras(strContrato.ToString());
            
        }

        private void buscarCompras(string strContrato)
        {
            DataTable dtCompras = new DataTable();
            daoCompras compras = new daoCompras();

            dtCompras = compras.pro_getCompras(strContrato.ToString());

            gdCompras.DataSource = dtCompras;
            gdCompras.DataBind();
        }

        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }
    }
}