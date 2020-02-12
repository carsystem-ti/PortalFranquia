using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;

namespace PortalFranquia.componentes.OS
{
    public partial class dadosClienteComplementares : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "script", " $('.somenteNumero').off();$('.somenteNumero').numeric(false, function () { alert('Digite somente números !'); this.value = ''; this.focus(); });", true);
        }

        public void preencheDados(daoOSConsulta DaoOSConsulta)
        {
            txtProduto.Text = DaoOSConsulta.dsTipoProduto +
                                " - Versão " + DaoOSConsulta.nrVersao +
                                (DaoOSConsulta.nrTelefoneRastreador.Length > 0 ? " - " + DaoOSConsulta.nrTelefoneRastreador : "") +
                                (DaoOSConsulta.dsAtivoOperadora.Length > 0 ? " - " + DaoOSConsulta.dsAtivoOperadora : "");

            txtStatus.Text = DaoOSConsulta.dsStatusCliente;

            txtAtendimento.Text = "";

            txtVenda.Text = "";

            txtCPFCNPJ.Text = DaoOSConsulta.nrCPFCNPJ;

            txtRGInsEstadual.Text = DaoOSConsulta.nrRGInsEstadual;

            txtDtNasc.Text = DaoOSConsulta.dtNascimento != null?((DateTime)DaoOSConsulta.dtNascimento).ToString("dd/MM/yyyy"):"";

            txtDtVenda.Text = DaoOSConsulta.dtVenda != null?((DateTime)DaoOSConsulta.dtVenda).ToString("dd/MM/yyyy"):"";

            txtDtConfirmacao.Text = DaoOSConsulta.dtConfirmacao != null?((DateTime)DaoOSConsulta.dtConfirmacao).ToString("dd/MM/yyyy"):"";

            txtVendedor.Text = "";

            txtVeiculo.Text = DaoOSConsulta.dsModelo;

            txtFabricante.Text = DaoOSConsulta.dsFabricanteVeiculo;

            txtCategoria.Text = DaoOSConsulta.dsTipoVeiculo;

            txtAno.Text = DaoOSConsulta.nrAno.ToString();

            txtRenavan.Text = DaoOSConsulta.nrRENAVAN;

            txtChassi.Text = DaoOSConsulta.nrChassi;

            txtCombustivel.Text = DaoOSConsulta.dsCombustivel;

            txtCor.Text = DaoOSConsulta.dsCorVeiculo;

            txtVenda.Text = DaoOSConsulta.dsVendaStatus;

            txtAtendimento.Text = DaoOSConsulta.dsStatusAtendimento;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            pnAtualizaDados.Visible = true;
            txtNovoNome.Focus();
            Utils.HidePesquisaMasterPage(this.Parent.Page.Master);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            daoOSConsulta DaoOSConsulta = (daoOSConsulta)Session["OSAberta"];
            try
            {
                DaoOSConsulta.solicitaAlteracaoSGB(
                    txtNovoNome.Text,
                    txtNovoCPFCNPJ.Text,
                    txtNovoRGInsEstadual.Text,
                    txtNovoDtNascimento.Text,
                    txtNovoVeiculo.Text,
                    txtNovoFabricante.Text,
                    txtNovoCategoria.Text,
                    txtNovoAno.Text,
                    txtNovoRENAVAN.Text,
                    txtNovoCHASSI.Text,
                    txtNovoCombustivel.Text,
                    txtNovoCor.Text,
                    ((dao.AcessoLogin)Session["acessoLogin"]).Nome
                    );
                lbMensErro.Text = "Solicitação feita com sucesso !";
            }
            catch (Exception ex)
            {
                lbMensErro.Text = ex.Message;
            }
            lbMensErro.Visible = true;
        }
    }
}