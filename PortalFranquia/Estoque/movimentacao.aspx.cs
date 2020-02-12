using PortalFranquia.dao;
using PortalFranquia.dao.Estoque;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.Estoque
{
    public partial class movimentacao : System.Web.UI.Page
    {
        private DaoMovimentacao daoMovimentacao = new DaoMovimentacao();

        protected void Page_Load(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = null;

            if (Session.Count > 0)
            {
                daoMovimentacao.Usuario = Session[0] != null ? ((AcessoLogin)Session[0]).Nome : null;
                acessoLogin = (AcessoLogin)Session["acessoLogin"];
            }

            Utils.setNomeModulo(Page, "Estoque - Movimentação");
            Utils.setVoltarUrl(Page, Session, "~/homeEstoque.aspx");
            TimerTabela_Tick(null, null);
            txtID.Focus();

            if (acessoLogin.idGrupo != 7 && acessoLogin.idGrupo != 21 && acessoLogin.idGrupo != 46 && acessoLogin.idGrupo != 47)
                Utils.SemPermissão(Response, Session);

            if (!Page.IsPostBack)
            {
                if (Session["acessoLogin"] != null)
                {
                    switch (acessoLogin.idGrupo)
                    {
                        case 46: // Contabilidade
                            Session["listaEquipamento"] = 3;
                            onAtualizaGrid(null, null);
                            panNumeroNota.Visible = true;
                            panTipoLocalizacao.Visible = false;
                            break;

                        default: // Estoque, CQP e Cadastro 
                            ddlListaLocalizacao.DataSource = daoMovimentacao.getListaLocalizacaoEquipamento(acessoLogin.idGrupo);
                            ddlListaLocalizacao.DataTextField = "ds_Localizacao";
                            ddlListaLocalizacao.DataValueField = "id_StatusLocalizacao";
                            ddlListaLocalizacao.DataBind();
                            panNumeroNota.Visible = false;
                            panTipoLocalizacao.Visible = true;
                            break;
                    }
                }
            }
        }

        private void AdicionaCelula(TableRow linha, string texto, HorizontalAlign alinhamento, string idLinha)
        {
            TableCell cel = new TableCell();
            LinkButton lkBtn = new LinkButton();
            lkBtn.ID = idLinha;
            lkBtn.Text = texto;
            lkBtn.Command += new CommandEventHandler(onAtualizaGrid);
            lkBtn.ClientIDMode = ClientIDMode.Static;
            cel.Controls.Add(lkBtn);
            cel.HorizontalAlign = alinhamento;
            cel.Font.Bold = true;
            linha.Cells.Add(cel);
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = lkBtn.UniqueID;
            trigger.EventName = "Click";
            updPanError.Triggers.Add(trigger);
            updPanGrid.Triggers.Add(trigger);
        }

        private TableRow AdicionaLinha(out byte countLinha, Table tabela)
        {
            TableRow linha = new TableRow();
            tabela.Rows.Add(linha);
            countLinha = 0;
            return linha;
        }

        private void criaTabelas(DataTable dtPosicao, Table tabela, string preFix1, string preFix2)
        {
            while (tabela.Rows.Count != 1)
                tabela.Rows.RemoveAt(1);

            byte countLinha;
            TableRow linha = AdicionaLinha(out countLinha, tabela);

            foreach (DataRow dr in dtPosicao.Rows)
            {
                if (countLinha++ == 0)
                    linha = AdicionaLinha(out countLinha, tabela);

                AdicionaCelula(linha, dr["ds_nome"].ToString(), HorizontalAlign.Left, preFix1 + dr["id_statusLocalizacao"].ToString());
                AdicionaCelula(linha, dr["nr_Total"].ToString(), HorizontalAlign.Right, preFix2 + dr["id_statusLocalizacao"].ToString());
            }
        }

        protected void TimerLimpaMens_Tick(object sender, EventArgs e)
        {
            TimerLimpaMens.Enabled = false;
            lbError.Text = "";
        }

        private void showMensError(string mensagem)
        {
            TimerLimpaMens.Enabled = true;
            lbError.Text = mensagem;
        }

        protected void TimerTabela_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPosicao;
                switch (((AcessoLogin)Session["acessoLogin"]).idGrupo)
                {
                    case 46: // Contabilidade
                        dtPosicao = daoMovimentacao.getPosicoesContabilidade();
                        break;

                    case 47: // CQP
                        dtPosicao = daoMovimentacao.getPosicoesCQP();
                        break;

                    case 7: // Administrativo Cadastro
                    case 48: // Cadastro
                        dtPosicao = daoMovimentacao.getPosicoesCadastro();
                        break;

                    default: // Estoque
                        criaTabelas(daoMovimentacao.getAlertasEstoque(), tblAlertas, "alr", "ali");
                        dtPosicao = daoMovimentacao.getPosicoes();
                        break;
                }

                criaTabelas(dtPosicao, tblPosicao, "bds", "bqt");
                onAtualizaGrid(null, null);
            }
            catch (Exception ex)
            {
                showMensError(ex.Message);
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AtualizaGrid", "configuraClickGrid();", true);
        }

        private void onAtualizaGrid(object sender, CommandEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    LinkButton link = sender as LinkButton;
                    if (link.ID.Contains("alr") || link.ID.Contains("ali"))
                        Session["listaEquipamento"] = 99999;
                    else
                        Session["listaEquipamento"] = link.ID.Substring(3);
                }

                if (Session["listaEquipamento"] != null)
                {
                    string nome;
                    grdListaEquipamentos.DataSource = daoMovimentacao.getListaEquipamentosByLocalizacao(Convert.ToInt32(Session["listaEquipamento"]), out nome);
                    grdListaEquipamentos.DataBind();
                    lblTitLista.Text = "Lista de Equipamentos (" + nome + ")";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AtualizaGrid", "configuraClickGrid();", true);
                }
            }
            catch (Exception ex)
            {
                showMensError(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length < 5)
            {
                showMensError("Informe o número correto do equipamento !");
                txtID.Focus();
            }
            else
            if (((AcessoLogin)Session[0]).idGrupo == 46 && txtNotaFiscal.Text == "")
            {
                showMensError("Informe o número da nota !");
                txtNotaFiscal.Focus();
            }
            else
            {
                try
                {
                    daoMovimentacao.setStatusLocalizacao(
                        txtID.Text,
                        ((AcessoLogin)Session[0]).idGrupo == 46 ? 4 : Convert.ToInt32(ddlListaLocalizacao.SelectedValue),
                        ((AcessoLogin)Session[0]).idGrupo == 46 ? Convert.ToInt32(txtNotaFiscal.Text) : (int?)null
                    );
                    showMensError("Alteração efetuada com sucesso !");
                    TimerTabela_Tick(null, null);
                    if (Session["listaEquipamento"] != null)
                        onAtualizaGrid(null, null);
                    txtID.Text = "";
                    txtNotaFiscal.Text = "";
                }
                catch (Exception ex)
                {
                    showMensError(ex.Message);
                }
                txtID.Focus();
            }
        }
    }
}