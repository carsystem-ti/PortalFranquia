using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.componentes;
using PortalFranquia.interfaces;

namespace PortalFranquia
{
    public static class Utils
    {
        public static void setNomeModulo(Page page, string nome)
        {
            Label lbModulo = (Label)page.Master.FindControl("lbModulo");
            lbModulo.Text = "Módulo: " + nome;
            lbModulo.Visible = true;
        }

        #region Botão Voltar

        public static void setVoltarUrl(Page page, HttpSessionState Session)
        {
            setVoltarUrl(page, Session, "~/Home.aspx");
        }

        public static void setVoltarUrl(Page page, HttpSessionState Session, string url)
        {
            Session["urlVoltar"] = url;
            ExibirVoltar(page);
        }

        public static void setVoltarUrl(Page page, HttpSessionState Session, string[] paineisVisiveis, string[] paineisInvisiveis, string urlDefault)
        {
            Session["urlVoltarPageDefault"] = urlDefault;
            Session["urlVoltar"] = paineisVisiveis;
            Session["urlVoltarInvisiveis"] = paineisInvisiveis;
            ExibirVoltar(page);
        }

        public static void setEventoAfterVoltar(MasterPage master, principal.EventoAfterVoltar eventoAfterVoltar)
        {
            ((principal)master).AfterVoltar += eventoAfterVoltar;
        }

        private static void ExibirVoltar(Page page)
        {
            LinkButton lkbtVoltar = (LinkButton)page.Master.FindControl("lkbtVoltar");
            lkbtVoltar.Visible = true;
        }


        #endregion

        public static void SemPermissão(HttpResponse resp, HttpSessionState Session)
        {
            Session["mensErroHome"] = "Você não tem permissão para utilizar este módulo";
            resp.Redirect("~/Home.aspx");
        }


        #region Componente de Pesquisa
        public static void ConfiguraPesquisaMasterPage(MasterPage master, Dictionary<string, string> campos, string parametroTipoPesquisa, string parametroValorPesquisa,
                                                        string conexao, string procedure, BuscaCliente.EventoPesquisa eventoPesquisa,
                                                        BuscaCliente.EventoErroPesquisa eventoErroPesquisa)
        {
            BuscaCliente buscaCliente = (BuscaCliente)master.FindControl("buscaCliente");
            buscaCliente.ConfiguraBusca(campos, parametroTipoPesquisa, parametroValorPesquisa, conexao, procedure);
            buscaCliente.RetornoPesquisa += eventoPesquisa;
            buscaCliente.ErroRetorno += eventoErroPesquisa;
        }

        public static void ConfiguraPesquisaMasterPage(MasterPage master, Dictionary<string, string> campos, Busca busca, BuscaCliente.EventoPesquisaObject eventoPesquisaObject,
                                                        BuscaCliente.EventoErroPesquisa eventoErroPesquisa)
        {
            BuscaCliente buscaCliente = (BuscaCliente)master.FindControl("buscaCliente");
            buscaCliente.ConfiguraBusca(campos, busca);
            buscaCliente.RetornoPesquisaObject += eventoPesquisaObject;
            buscaCliente.ErroRetorno += eventoErroPesquisa;
        }

        public static void HidePesquisaMasterPage(MasterPage master)
        {
            ((BuscaCliente)master.FindControl("buscaCliente")).Visible = false;
        }

        public static void HideControlsMasterPage(MasterPage master)
        {
            Panel pnCabec = (Panel)master.FindControl("pnInfAuxCabec");

            foreach (Control control in pnCabec.Controls)
                control.Visible = false;
        }

        public static void HideShowControlMasterPage(MasterPage master, string controlName, bool visible)
        {
            Panel pnCabec = (Panel)master.FindControl("pnInfAuxCabec");

            ((Control)pnCabec.FindControl(controlName)).Visible = visible;
        }

        public static void HideControlsShowControlMasterPage(MasterPage master, string controlName)
        {
            HideControlsMasterPage(master);
            HideShowControlMasterPage(master, controlName, true);
        }

        public static Object GetControlMasterPager(MasterPage master, string controlName)
        {
            return master.FindControl(controlName);
        }

        public static bool VisibleControlMasterPage(MasterPage master, string controlName)
        {
            return master.FindControl(controlName).Visible;
        }

        public static void FocusValorPesquisaMastePage(MasterPage master)
        {
            ((BuscaCliente)master.FindControl("buscaCliente")).setValorFocus();
        }

        public static void LimpaValorPesquisaMastePage(MasterPage master)
        {
            ((BuscaCliente)master.FindControl("buscaCliente")).setLimpaValor();
        }

        #endregion
    }
}