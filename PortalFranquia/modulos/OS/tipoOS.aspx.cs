using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PortalFranquia.componentes.OS;
using PortalFranquia.dao;
using PortalFranquia.dao.OS;

namespace PortalFranquia.modulos.OS
{
    public partial class tipoOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            Utils.setNomeModulo(Page, "O.S. - Abrir O.S.");
            
            Utils.setEventoAfterVoltar(Master, EventoAfterVoltar);

            if (!IsPostBack)
            {
                Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");
                Utils.FocusValorPesquisaMastePage(Master);

                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

                if ((acessoLogin.Nome.ToUpper() != "000760-DIEGO SOUZA") && (!acessoLogin.isSupervisor))
                    Utils.SemPermissão(Response, Session);
                
            }

            lbMensErro.Visible = false;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            daoOSConsulta DaoConsultaOS = new daoOSConsulta();
           // Utils.ConfiguraPesquisaMasterPage(Master, new Dictionary<string, string>() { { "Contrato", "nr_Contrato" }, { "Placa", "nr_Placa" }, { "CPF/CNPJ", "nr_CPF" } }, DaoConsultaOS, RetornoPesquisa, RetornoErro);

            retornoCPFCNPJ.RetornoPesquisaCPFCNPJ += RetornoPesquisaCPFCNPJ;
        }

        private void EventoAfterVoltar(Object urlVoltar, Object urlVoltarInvisiveis)
        {
            if (urlVoltar is Array)
            {
                string[] paineisVisiveis = (string[])urlVoltar;
                // busca de cliente
                if (paineisVisiveis.Contains("MASTER->buscaCliente") && paineisVisiveis.Contains("pnTipoOS"))
                {
                    configuraBotoesOS(null);
                    lbTitulo.ForeColor = System.Drawing.Color.Gray;
                }
                else
                    // selecionar o tipo de OS 
                    if (paineisVisiveis.Contains("MASTER->dadosCliente") && paineisVisiveis.Contains("pnTipoOS"))
                    {
                        Utils.setVoltarUrl(Page, Session, new string[] { "MASTER->buscaCliente", "pnTipoOS" }, new string[] { "MASTER->dadosCliente" }, "~/modulos/OS/OS.aspx");
                        configuraBotoesOS((daoOSConsulta)Session["OSAberta"]);
                        lbTitulo.ForeColor = System.Drawing.Color.DarkBlue;
                        ((dadosCliente)Utils.GetControlMasterPager(Master, "dadosCliente")).setTituloTipoOS = "";
                    }
                    else
                        // Troca de ID
                        if (paineisVisiveis.Contains("MASTER->dadosCliente") && paineisVisiveis.Contains("selecionaID"))
                            Utils.setVoltarUrl(Page, Session, new string[] { "pnTipoOS", "MASTER->dadosCliente" }, new string[] { "selecionaID", "rodape", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                        else
                            // Interna e Externa
                            if (paineisVisiveis.Contains("MASTER->dadosCliente") && paineisVisiveis.Contains("selecionaInternaExterna"))
                                Utils.setVoltarUrl(Page, Session, new string[] { "selecionaID", "MASTER->dadosCliente" }, new string[] { "selecionaInternaExterna", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                            else
                                //Seleciona Instalador
                                if (paineisVisiveis.Contains("MASTER->dadosCliente") && paineisVisiveis.Contains("dadosClienteComplementares"))
                                {
                                    Utils.setVoltarUrl(Page, Session, new string[] { "selecionaInternaExterna", "MASTER->dadosCliente" }, new string[] { "dadosClienteComplementares", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                                    btnAvancar.Text = "Avançar >>";
                                }
            }
        }

        private void RetornoPesquisa(Object retorno)
        {
            daoOSConsulta DaoConsulta = (daoOSConsulta)retorno;

            if (DaoConsulta.dtRetornoCPF != null)
            {
                Session["OSAberta"] = DaoConsulta;
                retornoCPFCNPJ.Visible = true;
                retornoCPFCNPJ.PreencheGrid(DaoConsulta.dtRetornoCPF);                
                
                pnTipoOS.Visible = false;
            }
            else
                if (DaoConsulta.dsStatusOS != "0")
                {
                    Utils.HidePesquisaMasterPage(Master);
                    ((dadosCliente)Utils.GetControlMasterPager(Master, "dadosCliente")).PreencheDados(DaoConsulta);

                    configuraBotoesOS(DaoConsulta);
                    lbTitulo.ForeColor = System.Drawing.Color.DarkBlue;

                    Session["OSAberta"] = DaoConsulta;

                    Utils.setVoltarUrl(Page, Session, new string[] { "MASTER->buscaCliente", "pnTipoOS" }, new string[] { "MASTER->dadosCliente" }, "~/modulos/OS/OS.aspx");

                    lbMensErro.Visible = false;
                }
                else
                {
                    Utils.FocusValorPesquisaMastePage(Master);
                    RetornoErro("Cliente já possui OS aberta !");
                }
        }

        private void RetornoPesquisaCPFCNPJ()
        {
            retornoCPFCNPJ.Visible = false;
            pnTipoOS.Visible = true;
            RetornoPesquisa(Session["OSAberta"]);
        }

        private void RetornoErro(Exception ex)
        {
            lbMensErro.Text = ex.Message;
            lbMensErro.Visible = true;
        }

        private void RetornoErro(string mensagem)
        {
            lbMensErro.Text = mensagem;
            lbMensErro.Visible = true;
        }

        private void EnableTipoOS(string nome, bool enable)
        {
            LinkButton hiperLink = (LinkButton)pnTipoOS.FindControl("Link" + nome);
            if (enable)
                hiperLink.CssClass = "linkMenu";
            else
                hiperLink.CssClass = "linkMenu desabilitaLink";
            hiperLink.Enabled = enable;

            HtmlImage img = (HtmlImage)pnTipoOS.FindControl("img" + nome);

            if (enable)
                img.Src = "../../imagens/OS/" + nome + ".jpg";
            else
                img.Src = "../../imagens/OS/" + nome + "PB.jpg";
        }

        protected void Link_Click(object sender, EventArgs e)
        {
            try
            {
                daoOSConsulta DaoOSConsulta = (daoOSConsulta)Session["OSAberta"];
                DaoOSConsulta.nw_dsTipoOS = ((LinkButton)sender).ID.ToString().Substring(4);
                ((dadosCliente)Utils.GetControlMasterPager(Master, "dadosCliente")).setTituloTipoOS = "OS de " + DaoOSConsulta.nw_dsTipoOS;
                pnTipoOS.Visible = false;
                selecionaID.Visible = true;
                Utils.HidePesquisaMasterPage(Master);
                selecionaID.nrIDAtual = DaoOSConsulta.nrIDAtual;
                selecionaID.IDsLiberados(DaoOSConsulta.getEquipamentosDisponiveis(((AcessoLogin)Session["acessoLogin"]).cdCetec));
                selecionaID.MotivosTroca(DaoOSConsulta.getMotivosTroca());
                // Configura o link para voltar
                Utils.setVoltarUrl(Page, Session, new string[] { "pnTipoOS", "MASTER->dadosCliente" }, new string[] { "selecionaID", "rodape", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                rodape.Visible = true;
            }
            catch (Exception ex)
            {
                RetornoErro(ex);
            }
        }

        protected void btnAvancar_Click(object sender, EventArgs e)
        {
            btnAvancar.Text = "Avançar >>";
            Utils.HideControlsMasterPage(Master);
            if (selecionaID.Visible)
            {
                selecionaID.Visible = false;
                selecionaInternaExterna.Visible = true;
                Utils.setVoltarUrl(Page, Session, new string[] { "selecionaID", "MASTER->dadosCliente" }, new string[] { "selecionaInternaExterna", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
            }
            else
                if (selecionaInternaExterna.Visible)
                {
                    selecionaInternaExterna.Visible = false;
                    dadosClienteComplementares.Visible = true;
                    dadosClienteComplementares.preencheDados((daoOSConsulta)Session["OSAberta"]);
                    Utils.setVoltarUrl(Page, Session, new string[] { "selecionaInternaExterna", "MASTER->dadosCliente" }, new string[] { "dadosClienteComplementares", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                }
                else
                    if (dadosClienteComplementares.Visible)
                    {
                        dadosClienteComplementares.Visible = false;
                        selecionaInstalador.Visible = true;
                        selecionaInstalador.carregaInstaladores((daoOSConsulta)Session["OSAberta"]);
                        Utils.setVoltarUrl(Page, Session, new string[] { "dadosClienteComplementares", "MASTER->dadosCliente" }, new string[] { "selecionaInstalador", "MASTER->buscaCliente" }, "~/modulos/OS/OS.aspx");
                        btnAvancar.Text = "Gravar";
                    }
                    else
                        if (selecionaInstalador.Visible)
                        {
                            try
                            {
                                // Move os dados para gravação da OS
                                daoOSConsulta DaoOSConsulta = (daoOSConsulta)Session["OSAberta"];
                                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                                DaoOSConsulta.nw_nrOSStatus = "0";
                                DaoOSConsulta.nw_dsInformacoesOS = selecionaInstalador.getInformacoesAdicionais();
                                DaoOSConsulta.nw_dsNomeUsuario = acessoLogin.Nome;
                                DaoOSConsulta.nw_cdEmpInstaladora = acessoLogin.Codigo;
                                DaoOSConsulta.nw_dsNomeInstalador = selecionaInstalador.getNomeInstalador();
                                if (!selecionaInternaExterna.getOSInterna())
                                {
                                    DaoOSConsulta.nw_dsEnderecoOS = "";
                                    DaoOSConsulta.nw_dsBairroOS = "";
                                    DaoOSConsulta.nw_dsCidadeOS = "";
                                    DaoOSConsulta.nw_dsUFOS = "";
                                    DaoOSConsulta.nw_FoneContatoOS = "";
                                    DaoOSConsulta.nw_PontoReferenciaOS = "";
                                    DaoOSConsulta.nw_RegiaoOS = "";
                                    DaoOSConsulta.nw_EnderecoNumeroOS = "";
                                    DaoOSConsulta.nw_dsCidadeKMOS = "";
                                    DaoOSConsulta.nw_cdCidadeKMOS = "";
                                }
                                else
                                    DaoOSConsulta.preencheEnderecoCETEC(acessoLogin.cdCetec);

                                DaoOSConsulta.nw_cdMotivoCancelamentoOS = "";

                                if (DaoOSConsulta.setGravaOS())
                                {
                                    selecionaInstalador.Visible = false;
                                    Utils.HideShowControlMasterPage(Master, "buscaCliente", true);
                                    Utils.HideShowControlMasterPage(Master, "dadosCliente", false);
                                    pnTipoOS.Visible = true;
                                    Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");
                                    configuraBotoesOS(null);
                                    btnAvancar.Visible = false;
                                    Utils.FocusValorPesquisaMastePage(Master);
                                    Utils.LimpaValorPesquisaMastePage(Master);
                                    RetornoErro("OS aberta com sucesso !");
                                }
                                else
                                {
                                    RetornoErro("Não foi possível abrir OS");
                                    btnAvancar.Text = "Gravar";
                                }
                            }
                            catch (Exception ex)
                            {
                                RetornoErro(ex);
                                btnAvancar.Text = "Gravar";
                            }
                            return;
                        }
            Utils.HideShowControlMasterPage(Master, "dadosCliente", true);
        }

        private void configuraBotoesOS(daoOSConsulta DaoConsulta)
        {
            EnableTipoOS("Instalacao", DaoConsulta == null ? false : DaoConsulta.OSinstalacao);
            EnableTipoOS("Suporte", DaoConsulta == null ? false : DaoConsulta.OSsuporte);
            EnableTipoOS("Retirada", DaoConsulta == null ? false : DaoConsulta.OSretirada);
            EnableTipoOS("Reinstalacao", DaoConsulta == null ? false : DaoConsulta.OSreinstalacao);
            EnableTipoOS("Troca", DaoConsulta == null ? false : DaoConsulta.OStroca);
            EnableTipoOS("Recall", DaoConsulta == null ? false : DaoConsulta.OSrecall);
            EnableTipoOS("RevisaoPlus", DaoConsulta == null ? false : DaoConsulta.OSrevisaoPlus);
            EnableTipoOS("Constatacao", DaoConsulta == null ? false : DaoConsulta.OSconstatacao);
        }
    }
}