using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace PortalFranquia.modulos.Chamados
{
    public partial class Chamados : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                Utils.setVoltarUrl(Page, Session);
                ValidaUsuario();
                VerificaAcesso();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void VerificaAcesso()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idFranquia == 0)
            {
                ChamadoMethod bdf = new ChamadoMethod();
                DataSet ds = bdf.DadosSolicitados(acessoLogin.Nome);
                Session["id_departamento"] = ds.Tables[0].Rows[0]["id_departamento"].ToString();
                Session["ds_email"] = ds.Tables[0].Rows[0]["ds_email"].ToString();
                Session["ds_Departamento"] = ds.Tables[0].Rows[0]["ds_Departamento"].ToString();
                Session["id_grupo"] = ds.Tables[0].Rows[0]["id_grupo"].ToString();
                    
            }
        }
        private void ValidaUsuario()
        {
            Session["fl_abertura"] = "0";
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string ds_tipo = acessoLogin.dsTipo;
                    switch (ds_tipo)
                    {
                        case "G":
                            break;
                        case "A":
                            break;
                        case "W":
                              imgAbrir.Visible = true;
                              lblAbrir.Visible = true;
                              Session["fl_abertura"] = "1";
                            break;
                        case "C":
                            imgAbrir.Visible = true;
                            lblAbrir.Visible = true;
                            Session["fl_abertura"] = "1";
                            break;
                        default:
                            Utils.SemPermissão(Response, Session);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void imgAbrir_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 1;
            ind.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            canceladas.Visible = false;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        private static void atualiza()
        {

        }
        private  void UltimoClick(string tipo)
        {

            switch (tipo)
            {

                case "1":
                    ind.Visible = true;
                    reabertos.Visible = false;
                    ChamadosAbertos.Visible = false;
                    atendimento.Visible = false;
                    encerradas.Visible = false;
                    canceladas.Visible = false;
                    MeusChamados.Visible = false;
                    break;

                case "2":
                    ChamadosAbertos.Visible = true;
                    reabertos.Visible = false;
                    ind.Visible = false;
                    atendimento.Visible = false;
                    encerradas.Visible = false;
                    canceladas.Visible = false;
                    MeusChamados.Visible = false;
                    break;

                case "3":
                    atendimento.Visible = true;
                    reabertos.Visible = false;
                    ChamadosAbertos.Visible = false;
                    ind.Visible = false;
                    canceladas.Visible = false;
                    encerradas.Visible = false;
                    MeusChamados.Visible = false;
                    break;


                case "4":
                    encerradas.Visible = true;
                    reabertos.Visible = false;
                    ChamadosAbertos.Visible = false;
                    ind.Visible = false;
                    atendimento.Visible = false;
                    canceladas.Visible = false;
                    MeusChamados.Visible = false;
                    break;

                case "5":
                    canceladas.Visible = true;
                    reabertos.Visible = false;
                    ChamadosAbertos.Visible = false;
                    ind.Visible = false;
                    atendimento.Visible = false;
                    encerradas.Visible = false;
                    MeusChamados.Visible = false;
                    break;


                case "6":
                    reabertos.Visible = true;
                    canceladas.Visible = false;
                    ChamadosAbertos.Visible = false;
                    ind.Visible = false;
                    atendimento.Visible = false;
                    encerradas.Visible = false;
                    MeusChamados.Visible = false;
                    break;

                case "7":
                    MeusChamados.Visible = true;
                    reabertos.Visible = false;
                    canceladas.Visible = false;
                    ChamadosAbertos.Visible = false;
                    ind.Visible = false;
                    atendimento.Visible = false;
                    encerradas.Visible = false;
                    break;

            }

        }
        protected void lblAbrir_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 1;
            ind.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            canceladas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void lblAbertas_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 2;
            ChamadosAbertos.Visible = true;
            reabertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            canceladas.Visible = false;
            MeusChamados.Visible = false;
        }
        protected void imgAbertas_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 2;
            ChamadosAbertos.Visible = true;
            reabertos.Visible = false;
            ind.Visible = false; 
            atendimento.Visible = false;
            canceladas.Visible = false;
            encerradas.Visible = false;
            canceladas.Visible = false;
            MeusChamados.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Imprimir()", true);
            
        }
        protected void lblEmatendimento_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 3;
            atendimento.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            canceladas.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;

        }

        protected void imgEmAtendimento_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 3;
            reabertos.Visible = false;
            atendimento.Visible = true;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            canceladas.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void lblEncerradas_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 4;
            encerradas.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible =false;
            ind.Visible = false;
            atendimento.Visible = false;
            MeusChamados.Visible = false;
            canceladas.Visible = false;
        }
         protected void lblEncerradas_Click1(object sender, EventArgs e)
        {
            Session["Menu"] = 4;
            encerradas.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            canceladas.Visible = false;
            MeusChamados.Visible = false;
        }
        protected void lblCanceladas_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 5;
            canceladas.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;
            
        }
        
        protected void imgCanceladas_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 5;
            canceladas.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void imgEncerradas_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 4;
            encerradas.Visible = true;
            reabertos.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            canceladas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void lblReabertos_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 6;
            reabertos.Visible = true;
            canceladas.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void imgReabertos_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 6;
            reabertos.Visible = true;
            canceladas.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            MeusChamados.Visible = false;
        }

        protected void lblMeuchamados_Click(object sender, EventArgs e)
        {
            Session["Menu"] = 7;
            MeusChamados.Visible = true;
            reabertos.Visible = false;
            canceladas.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
            
        }

        protected void imgMeusChamados_Click(object sender, ImageClickEventArgs e)
        {
            Session["Menu"] = 7;
            MeusChamados.Visible = true;
            reabertos.Visible = false;
            canceladas.Visible = false;
            ChamadosAbertos.Visible = false;
            ind.Visible = false;
            atendimento.Visible = false;
            encerradas.Visible = false;
        }

      

    }
}