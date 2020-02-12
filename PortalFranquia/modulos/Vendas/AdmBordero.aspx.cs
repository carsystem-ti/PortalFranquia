using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.Bordero;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PortalFranquia.dao;
using System.IO;

using System.Text;
namespace PortalFranquia.modulos.BorderoCheques
{
    public partial class AdmBordero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if ((acessoLogin.dsTipo != "G") && (acessoLogin.dsTipo != "X"))
                {
                    Utils.SemPermissão(Response, Session);
                }

                Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
                ValidaAcesso();

            }
        }

        #region Metodos
        private void ValidaAcesso()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idGrupo == 7 || acessoLogin.idGrupo == 12 || acessoLogin.idGrupo == 2 || acessoLogin.idGrupo == 33)
            {
                dropStatus.Visible = true;
                lblstatus.Visible = true;
            }
            else
            {
                dropStatus.Visible = false;
                lblstatus.Visible = false;
            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }

        private void exportarExcelAnalitico()
        {
            DataTable dt_getLeadsAnaliticoPlanilha = new DataTable();
            string caminho = "Relatorio" + txtFranquia.Text + ".XLS".ToString();


            dt_getLeadsAnaliticoPlanilha.Columns.Add("Pedido", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Borderô", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Tipo Evento", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Titular Cheque", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Cpf_Cnpj", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Cliente", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Contrato", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Vencimento", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Dias", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Banco", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Agencia", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Conta", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Cheque", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Cmc7", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Bruto", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Liquido", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("Status", typeof(string));
            dt_getLeadsAnaliticoPlanilha.Columns.Add("ds_franquia", typeof(StringBuilder));

            DataTable dt = (Session["Exportar"] as DataTable);
            //Chamando método static, passando DataTable preenchido e nome do arquivo
            ExportarParaExcelAnalitico(dt, caminho);
        }
        private void ExportarParaExcelAnalitico(DataTable dt_getLeadsAnaliticoPlanilha, string nome)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            foreach (DataColumn column in dt_getLeadsAnaliticoPlanilha.Columns)
            {
                context.Response.Write(column.ColumnName + "\t");
            }
            context.Response.Write(Environment.NewLine);

            foreach (DataRow row in dt_getLeadsAnaliticoPlanilha.Rows)
            {
                for (int i = 0; i < dt_getLeadsAnaliticoPlanilha.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + "\t");
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.ContentType = "application/ms-excel";
            //context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nome + ".xls");
            context.Response.AddHeader("content-disposition", "attachment;filename=RelatorioBorderô.xls");
            context.Response.Charset = "utf-8";
            context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            context.Response.End();
        }
        private void BuscaDados()
        {
            if (txtConsulta.Text != "")
            {

                int selecao = Convert.ToInt32(dropSelecao.SelectedValue);
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int franquia = acessoLogin.idFranquia;
                DaoBordero bdb = new DaoBordero();
                DataTable dt = new DataTable();
                switch (selecao)
                {
                    case 1:
                        //Busca Por Número de Borderô
                        dt = bdb.pro_getDadosBordero(1, Convert.ToInt32(txtConsulta.Text), franquia);
                        break;
                    case 2:
                        dt = bdb.pro_getBorderopedido(1, Convert.ToInt32(txtConsulta.Text.Trim()), franquia);
                        break;
                    case 3:
                        dt = bdb.getBorderoContrato(1, txtConsulta.Text.Trim(), franquia);
                        break;
                    default:
                        Mensagem("Selecione uma fonte de pesquisa...");
                        break;
                }

                if (dt.Rows.Count > 0)
                {
                    GvBordero.DataSource = dt;
                    GvBordero.DataBind();
                    Session.Add("Exportar", dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtFranquia.Text = dr[17].ToString();
                    }
                    decimal Somatotal = 0;
                    decimal SomaLiquido = 0;
                    Txt_nr_quantidade.Text = dt.Rows.Count.ToString();
                    foreach (GridViewRow row in GvBordero.Rows)
                    {
                        decimal valor = Convert.ToDecimal(row.Cells[14].Text);
                        Somatotal = Somatotal + valor;

                        decimal liquido = Convert.ToDecimal(row.Cells[15].Text);
                        SomaLiquido = SomaLiquido + liquido;
                    }
                    Txt_vl_bruto.Text = Somatotal.ToString();
                    Txt_vl_liquido.Text = SomaLiquido.ToString();
                    totalizador.Visible = true;
                }
                else
                {
                    GvBordero.DataBind();
                    pnlDados.Visible = false;
                    Mensagem("Não existe dados para essa fonte de pesquisa");
                    totalizador.Visible = false;
                }
            }
            else
            {
                Mensagem("Favor inserir todos os dados..");
                totalizador.Visible = false;
            }

        }
        private void BuscaDadosAdm()
        {
            int tipo = 0;
            if (txtConsulta.Text != "")
            {
                int nr_status = Convert.ToInt32(dropStatus.SelectedValue);
                switch (nr_status)
                {

                    case 0:
                        tipo = 2;
                        break;
                    case 1:
                        tipo = 3;
                        break;
                    case 2:
                        tipo = 4;
                        break;
                    case 3:
                        tipo = 5;
                        break;
                }
                int selecao = Convert.ToInt32(dropSelecao.SelectedValue);
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                DaoBordero bdb = new DaoBordero();
                DataTable dt = new DataTable();
                switch (selecao)
                {
                    case 1:
                        //Busca Por Número de Borderô
                        dt = bdb.pro_getDadosBordero(tipo, Convert.ToInt32(txtConsulta.Text), 0);
                        break;
                    case 2:
                        dt = bdb.pro_getBorderopedido(tipo, Convert.ToInt32(txtConsulta.Text.Trim()), 0);
                        break;
                    case 3:
                        dt = bdb.getBorderoContrato(tipo, txtConsulta.Text.Trim(), 0);
                        break;
                    default:
                        Mensagem("Selecione uma fonte de pesquisa...");
                        break;
                }

                if (dt.Rows.Count > 0)
                {
                    GvBordero.DataSource = dt;
                    Session.Add("Exportar", dt);
                    GvBordero.DataBind();

                    foreach (DataRow dr in dt.Rows)
                    {
                        txtFranquia.Text = dr[17].ToString();
                    }
                    decimal Somatotal = 0;
                    decimal SomaLiquido = 0;
                    Txt_nr_quantidade.Text = dt.Rows.Count.ToString();
                    foreach (GridViewRow row in GvBordero.Rows)
                    {
                        decimal valor = Convert.ToDecimal(row.Cells[14].Text);
                        Somatotal = Somatotal + valor;

                        decimal liquido = Convert.ToDecimal(row.Cells[15].Text);
                        SomaLiquido = SomaLiquido + liquido;
                    }
                    Txt_vl_bruto.Text = Somatotal.ToString();
                    Txt_vl_liquido.Text = SomaLiquido.ToString();
                    totalizador.Visible = true;

                }
                else
                {
                    GvBordero.DataBind();
                    pnlDados.Visible = false;
                    Mensagem("Não existe dados para essa fonte de pesquisa");
                    totalizador.Visible = false;
                }
            }
            else
            {
                Mensagem("Favor inserir todos os dados..");
                totalizador.Visible = false;
            }

        }
        private void AceiteBordero()
        {
            int total = 0;
            int executado = 0;

            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            foreach (GridViewRow row in GvBordero.Rows)
            {

                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {

                    DaoBordero bdb = new DaoBordero();
                    string contrato = row.Cells[5].Text;
                    string ds_cliente = row.Cells[4].Text;
                    string TitularCheque = row.Cells[2].Text;
                    string nr_Cpf_Cnpj = row.Cells[3].Text;
                    string ds_banco = row.Cells[9].Text;
                    string ds_conta = row.Cells[11].Text;
                    string cheque = row.Cells[12].Text;
                    string ds_agencia = row.Cells[10].Text;
                    DateTime dt_vencimento = Convert.ToDateTime(row.Cells[7].Text);
                    decimal vl_valor = Convert.ToDecimal(row.Cells[14].Text);
                    string usuario = acessoLogin.Nome;
                    executado = bdb.pro_seGeraContasReceber(contrato, ds_cliente, TitularCheque, nr_Cpf_Cnpj, ds_banco, ds_conta, cheque, dt_vencimento, vl_valor, usuario, ds_agencia);
                    if (executado > 0)
                    {
                        total = total + 1;

                    }
                }
            }
            if (total > 0)
            {
                //lblretorno.Text = "Foram aceite: " + total.ToString();
                Mensagem("Quantidade de cheques: " + total.ToString());
                BuscaDados();
            }
        }
        private void BuscaObs(int bordero, string cheque)
        {
            DaoBordero bdb = new DaoBordero();
            DataSet ds = new DataSet();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

            txtUsuario.Text = acessoLogin.Nome;
            txtBordero.Text = bordero.ToString();
            ds = bdb.getObsBordero(bordero, cheque);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTodasMensagem.Text = ds.Tables[0].Rows[0]["ds_Observacao"].ToString();
            }

        }
        private void GravaObs()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            foreach (GridViewRow row in GvBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {
                    int retorno = 0;
                    DaoBordero bdBor = new DaoBordero();
                    int bordero = Convert.ToInt32(row.Cells[1].Text);
                    string cheque = row.Cells[12].Text;
                    string mensagem = txtTodasMensagem.Text;
                    string novamensagem = "Usuario : " + acessoLogin.Nome + " DataLog : " + DateTime.Now + "-" + "Inf: " + txtObs.Text + "\r\n" + mensagem.ToString() + " \r\n ";
                    retorno = bdBor.pro_setObsCheque(bordero, cheque, novamensagem);
                    if (retorno > 0)
                    {
                        Mensagem("Dados atualizado");
                    }
                }
            }
        }
        private void RecusaBordero()
        {
            foreach (GridViewRow row in GvBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {
                    int alterado = 0;
                    DaoBordero bdb = new DaoBordero();
                    int bordero = Convert.ToInt32(row.Cells[1].Text);
                    string cheque = row.Cells[12].Text;
                    alterado = bdb.pro_setRecusaCheque(bordero, cheque);
                    if (alterado > 0)
                    {
                        BuscaDados();
                    }
                    else
                    {
                        Mensagem("Dados não foram atualizados..");
                    }
                }
            }
        }
        #endregion Fim do Metodos
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {

            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idGrupo == 7 || acessoLogin.idGrupo == 12 || acessoLogin.idGrupo == 2 || acessoLogin.idGrupo == 33)
            {
                BuscaDadosAdm();
            }
            else
            {
                BuscaDados();
            }
        }
        protected void dropSelecao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgAceite_Click(object sender, ImageClickEventArgs e)
        {
            AceiteBordero();
        }

        protected void chkSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idGrupo == 2 || acessoLogin.idGrupo == 7)
            {
                int contador = 0;
                foreach (GridViewRow row in GvBordero.Rows)
                {

                    CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");

                    if (ch.Checked != false && ch != null)
                    {

                        contador = contador + 1;
                        if (contador == 1)
                        {
                            string status = row.Cells[16].Text;
                            if (status != "ACEITO")
                            {
                                pnlDados.Visible = true;
                            }
                            else
                            {
                                pnlDados.Visible = false;
                            }
                        }
                        else
                        {
                            pnlDados.Visible = false;
                            ch.Checked = false;
                        }

                    }
                }
                if (contador == 0)
                {
                    pnlDados.Visible = false;
                }
            }
            else
            {
                pnlDados.Visible = false;
            }
        }
        protected void btnLinkView_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GvBordero.Rows)
                {
                    CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                    if (ch.Checked != false && ch != null)
                    {
                        LinkButton btnLinkView = sender as LinkButton;
                        GridViewRow GVEmployeeRow = (GridViewRow)btnLinkView.NamingContainer;
                        BuscaObs(Convert.ToInt32(row.Cells[1].Text), row.Cells[12].Text);
                        PnlEmployee_ModalPopupExtender.Show();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btGravaInf_Click(object sender, EventArgs e)
        {
            GravaObs();
        }

        protected void imgRecusar_Click(object sender, ImageClickEventArgs e)
        {
            RecusaBordero();
        }

        protected void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            int contador = 0;
            foreach (GridViewRow row in GvBordero.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch != null)
                {
                    ch.Checked = (sender as CheckBox).Checked;
                    pnlDados.Visible = true;
                }
            }
            if (contador == 0)
            {
                pnlDados.Visible = false;
            }
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            exportarExcelAnalitico();
        }

    }
}