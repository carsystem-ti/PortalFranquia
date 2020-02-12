using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;


namespace PortalFranquia
{
    public partial class principal : System.Web.UI.MasterPage
    {
        public delegate void EventoAfterVoltar(Object urlVoltar, Object urlVoltarInvisiveis);

        public event EventoAfterVoltar AfterVoltar;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), "MaskedEditFix"))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "MaskedEditFix", String.Format("<script type='text/javascript' src='{0}'></script>", Page.ResolveUrl("~/./js/MaskedEditFix.js")));
            //}

            if (Session["acessoLogin"] == null)
                Response.Redirect("~/Login.aspx");
            else
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                lbFranquia.Text = "Franquia: " + acessoLogin.Franquia;
                lbNome.Text = "Nome: " + acessoLogin.Nome;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void lkbtVoltar_Click(object sender, EventArgs e)
        {
            object urlVoltar = Session["urlVoltar"];
            if (Session["urlVoltar"] is Array)
            {
                ShowPaineis((string[])Session["urlVoltarInvisiveis"], false);
                ShowPaineis((string[])Session["urlVoltar"], true);
                Session["urlVoltar"] = Session["urlVoltarPageDefault"];
            }
            else
            {
                Response.Redirect((String)Session["urlVoltar"]);
                lkbtVoltar.Visible = false;
                Session["urlVoltar"] = null;
            }

            if (AfterVoltar != null)
                AfterVoltar(urlVoltar, Session["urlVoltarInvisiveis"]);
        }

        private void ShowPaineis(string[] paineis, bool visivel)
        {
            foreach (string nome in paineis)
            {
                Control painel;
                if (nome.IndexOf("MASTER->") > -1)
                    painel = FindControl(nome.Substring(8));
                else
                    painel = ContentPlaceHolder1.FindControl(nome);
                painel.Visible = visivel;
            }
        }
    }    
}