using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.Bordero;
using System.IO;
using PortalFranquia.dao;

namespace PortalFranquia.modulos.BorderoCheques
{
    public partial class Bordero : System.Web.UI.Page
    {
        dao.Bordero.DaoBordero bdb = new dao.Bordero.DaoBordero();
        int contador = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscaDados();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if ((acessoLogin.dsTipo != "G") && (acessoLogin.dsTipo != "X"))
                {
                    Utils.SemPermissão(Response, Session);
                }

                Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");

            }
        }
        #region Metodos
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private DataTable BuscaDados()
        {
            DataTable dt_carteira = new DataTable();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int id_franquia = acessoLogin.idFranquia;
            dt_carteira = bdb.pro_getCarteiraBordero(id_franquia);
            if (dt_carteira.Rows.Count > 0)
            {
                txtTotalGeral.Text = dt_carteira.Rows.Count.ToString();
                GridBordero.DataSource = dt_carteira;
                GridBordero.DataBind();
                decimal Somatotal = 0;
                txtTotalSelecionada.Text = "0";
                foreach (GridViewRow row in GridBordero.Rows)
                {
                    txtDataBase.Text = row.Cells[10].Text;
                    decimal valor = Convert.ToDecimal(row.Cells[1].Text);
                    Somatotal = Somatotal + valor;
                }
                txtValorGeral.Text = Somatotal.ToString();
            }
            else
            {
                divBotao.Visible = false;
                GridBordero.DataBind();
            }
            return dt_carteira;
        }
        private DataTable BuscaDadosTroca()
        {
            DataTable dt_carteira = new DataTable();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int id_franquia = acessoLogin.idFranquia;
            dt_carteira = bdb.pro_getCarteiraBorderoTroca(id_franquia);
            if (dt_carteira.Rows.Count > 0)
            {
                txtTotalGeral.Text = dt_carteira.Rows.Count.ToString();
                GridBordero.DataSource = dt_carteira;
                GridBordero.DataBind();
                decimal Somatotal = 0;
                txtTotalSelecionada.Text = "0";
                foreach (GridViewRow row in GridBordero.Rows)
                {
                    txtDataBase.Text = row.Cells[10].Text;
                    decimal valor = Convert.ToDecimal(row.Cells[1].Text);
                    Somatotal = Somatotal + valor;
                }
                txtValorGeral.Text = Somatotal.ToString();
            }
            else
            {
                divBotao.Visible = false;
                GridBordero.DataBind();
            }
            return dt_carteira;
        }
        private void CalculaDesconto()
        {
            decimal total = 0;
            decimal Totalbruto = 0;
            foreach (GridViewRow row in GridBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {

                    total = total + (Convert.ToDecimal(row.Cells[12].Text));
                    txtDesconto.Text = total.ToString();
                    Totalbruto = Totalbruto + Convert.ToDecimal(row.Cells[1].Text);
                    txtBruto.Text = Totalbruto.ToString();
                }
            }
        }
        private void GravaBordero()
        {
            if (txtDataBase.Text != "")
            {
                DaoBordero bdb = new DaoBordero();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int tipo = 1;
                int id_franquia = acessoLogin.idFranquia;
                string ds_usuario = acessoLogin.Nome;
                DateTime dt_base = Convert.ToDateTime(txtDataBase.Text);
                int retorno = bdb.pro_setBordero(id_franquia, dt_base, ds_usuario, ds_usuario);
                if (retorno > 0)
                {
                    foreach (GridViewRow row in GridBordero.Rows)
                    {

                        CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                        if (ch.Checked != false && ch != null)
                        {

                            if (chkTroca.Checked == true)
                            {
                                tipo = 2;
                            }

                            int pedido = Convert.ToInt32(row.Cells[0].Text);
                            decimal valor = Convert.ToDecimal(row.Cells[1].Text);
                            DateTime vencimento = Convert.ToDateTime(row.Cells[2].Text);
                            string nr_PEDIDO = row.Cells[3].Text;
                            string titularCheque = row.Cells[4].Text;
                            string nr_documento = row.Cells[5].Text;
                            string nr_banco = row.Cells[6].Text;
                            string nr_conta = row.Cells[7].Text;
                            string nr_agencia = row.Cells[8].Text;
                            string nr_cheque = row.Cells[9].Text;
                            string nr_Cmc7 = Server.HtmlDecode(row.Cells[14].Text);
                            decimal vl_liquido = Convert.ToDecimal(row.Cells[13].Text);
                            bdb.pro_setBorderoItens(tipo,retorno, vencimento, nr_cheque, valor, nr_Cmc7, nr_PEDIDO, vl_liquido, titularCheque, pedido, nr_banco, nr_agencia, nr_conta, nr_documento, ds_usuario);
                        }
                    }
                    divBotao.Visible = false;
                    btnFinalizar.Text = "Bordero Gerado com sucesso: " + retorno.ToString();
                    BuscaDados();
                    Mensagem("Borderô gerado com sucesso: " + retorno.ToString());
                }
            }
        }
        private void flChequeFranquia()
        {
            if (txtDataBase.Text != "")
            {
                DaoBordero bdb = new DaoBordero();
                int retorno = 0;
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                foreach (GridViewRow row in GridBordero.Rows)
                {

                    CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                    if (ch.Checked != false && ch != null)
                    {
                        int pedido = Convert.ToInt32(row.Cells[0].Text);
                        string nr_cheque = row.Cells[9].Text;
                        retorno = bdb.fl_chequesFranquia(pedido, nr_cheque);
                    }
                    divBotao.Visible = false;
                    BuscaDados();
                    Mensagem("Todos os cheques foram processados..");
                }
            }
        }
        #endregion
        protected void chkSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            decimal total = 0;
            txtDesconto.Text = "0";
            txtBruto.Text = "0";
            txtLiquido.Text = "0";
            foreach (GridViewRow row in GridBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {
                    txtTotalSelecionada.Text = (contador = contador + 1).ToString();

                    decimal valor = Convert.ToDecimal(row.Cells[13].Text);
                    total = total + valor;
                    txtLiquido.Text = total.ToString();
                    divBotao.Visible = true;

                    CalculaDesconto();

                    if (ch.Checked == false && txtTotalSelecionada.Text != "0")
                    {
                        contador = Convert.ToInt32(txtTotalSelecionada.Text);
                        txtTotalSelecionada.Text = (contador = contador - 1).ToString();
                        if (contador == 0)
                        {
                            txtTotalSelecionada.Text = "0";
                            txtDesconto.Text = "0";
                            txtBruto.Text = "0";
                            txtLiquido.Text = "0";
                            divBotao.Visible = false;
                        }
                        else
                        {
                            divBotao.Visible = true;
                        }
                    }
                }
                else
                {
                    if (contador == 0)
                    {
                        txtTotalSelecionada.Text = "0";
                        txtLiquido.Text = "";
                        txtDesconto.Text = "";
                        txtBruto.Text = "";

                    }
                    else
                    {

                    }
                }

            }
        }
        protected void chkTodos_CheckedChanged(object sender, EventArgs e)
        {

            Page.MaintainScrollPositionOnPostBack = true;
            decimal Somatotal = 0;

            foreach (GridViewRow row in GridBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch != null)
                {
                    txtTotalSelecionada.Text = (contador = contador + 1).ToString();
                    ch.Checked = (sender as CheckBox).Checked;
                    decimal valor = Convert.ToDecimal(row.Cells[13].Text);
                    Somatotal = Somatotal + valor;
                    txtLiquido.Text = Somatotal.ToString();
                    CalculaDesconto();
                    if (ch.Checked == false && txtTotalSelecionada.Text != "0")
                    {
                        contador = Convert.ToInt32(txtTotalSelecionada.Text);
                        txtTotalSelecionada.Text = (contador = contador - 1).ToString();
                        if (contador == 0)
                        {
                            txtTotalSelecionada.Text = "0";
                            txtDesconto.Text = "0";
                            txtBruto.Text = "0";
                            txtLiquido.Text = "0";
                            divBotao.Visible = false;
                        }
                        else
                        {
                            divBotao.Visible = true;
                        }

                    }
                }
                else
                {
                    if (contador == 0)
                    {
                        txtTotalSelecionada.Text = "0";
                        txtLiquido.Text = "";
                        txtDesconto.Text = "";
                        txtBruto.Text = "";
                        divBotao.Visible = false;
                    }
                    else
                    {
                        divBotao.Visible = false;
                    }
                }

            }
        }

        protected void chkSelecionar_Load(object sender, EventArgs e)
        {

        }
      protected void chkTodos_Load(object sender, EventArgs e)
        {

        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            GravaBordero();
        }
        protected void btnAdmFranquia_Click(object sender, EventArgs e)
        {
            flChequeFranquia();
        }

        protected void chkTroca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTroca.Checked == true)
            {
                BuscaDadosTroca();
            }
            else
            {
                BuscaDados();
            }
        }

    }
}