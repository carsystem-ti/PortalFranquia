using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia;
using PortalFranquia.dao;
using System.IO;



namespace DPromocional
{
    public partial class Relatorio : System.Web.UI.Page
    {
        DataTable dtrelexport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

            if (acessoLogin.dsTipo != "G")
            {
                Utils.SemPermissão(Response, Session);
            }

            if (!IsPostBack)
            {
                Utils.setVoltarUrl(Page, Session, "Relatorio.aspx");
                Utils.setNomeModulo(Page, "Relatórios - Pagamentos Serviços");

                ddlMes.SelectedIndex = DateTime.Now.Month - 1;
                txtAno.Text = DateTime.Now.Year.ToString();

                if (acessoLogin.cdCetec == "")
                {
                    ddlFranquia.Visible = true;
                    daoRelatorioPagamento DaoRelatorio = new daoRelatorioPagamento();
                    ddlFranquia.DataSource = DaoRelatorio.getFranquias(14);
                    ddlFranquia.DataValueField = "id_franquia";
                    ddlFranquia.DataTextField = "ds_franquia";
                    ddlFranquia.DataBind();

                    lbFranquia.Visible = true;
                }
            }
            lbMensErro.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            daoRelatorioPagamento DaoRelatorio = new daoRelatorioPagamento();
            try
            {
                AcessoLogin acessoLogin = ((AcessoLogin)Session["acessoLogin"]);

                if (acessoLogin.idFranquia == 0)
                    Session["FranquiaRel"] = ddlFranquia.SelectedValue;
                else
                    Session["FranquiaRel"] = acessoLogin.idFranquia;


                Object dAjusteCredito;
                Object dDescontosDiversos;
                Object dDebitosGerais;
                Object dCreditosGerais;

                gridSintetico.DataSource = DaoRelatorio.getSintetico(Convert.ToInt32(Session["FranquiaRel"]), ddlMes.SelectedIndex + 1, Convert.ToInt32(txtAno.Text), out dAjusteCredito, out dDescontosDiversos, out dDebitosGerais, out dCreditosGerais);
                gridSintetico.DataBind();

                gridSinteticoAjusteCre.DataSource = dAjusteCredito;
                gridSinteticoAjusteCre.DataBind();

                gridSinteticoAjusteDeb.DataSource = dDescontosDiversos;
                gridSinteticoAjusteDeb.DataBind();

                gridSinteticoDebitos.DataSource = dDebitosGerais;
                gridSinteticoDebitos.DataBind();

                gridSinteticoCreditos.DataSource = dCreditosGerais;
                gridSinteticoCreditos.DataBind();

                lbTotAjusteCredito.Text = DaoRelatorio.totAjusteCredito;
                lbTotAjusteDebito.Text = DaoRelatorio.totAjusteDebito;

                lbComissoes.Text = DaoRelatorio.totComissoes;
                lbCredito.Text = DaoRelatorio.totCredito;

                lbTitulo.Text = "RELATÓRIO DE PAGAMENTOS  -  Franquia  - " + DaoRelatorio.nomeFranquia;
                lbPeriodo.Text = "Período de apuração " + DaoRelatorio.periodo;

                lbSaldo.Text = DaoRelatorio.totGeral;

                pnAnalitico.Visible = false;
                pnAnaliticoAjusteCredito.Visible = false;
                pnAnaliticoServico.Visible = false;
                pnDescontosDiversos.Visible = false;
                pnSintetico.Visible = true;
                pnTitulo.Visible = true;

                lbexportar.Visible = true;
                lbexportservexterno.Visible = true;
                lbexportserveinterno.Visible = true;
                lbexportarajustcredito.Visible = true;
                lbexportaforavendapolitica.Visible = true;
                lbexportvendapolitica.Visible = true;
                lbexportarajustcredito.Visible = true;

                imggridVendaPolitica.Visible = true;
                imggridForaVendaPolitica.Visible = true;
                imggridDescontosDiversos.Visible = true;
                imggridservicoexterno.Visible = true;
                imggridServicoInterno.Visible = true;
                imggridanaliticoajustcredito.Visible = true;
                

            }
            catch (Exception ex)
            {
                ShowMensagem(ex.Message);
            }

        }

        protected void gridSintetico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "analitico")
            {
                try
                {
                    daoRelatorioPagamento DaoRelatorio = new daoRelatorioPagamento();
                    GridViewRow row = gridSintetico.Rows[Convert.ToInt32(e.CommandArgument)];

                    HiddenField idAgenda = (HiddenField)gridSintetico.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");

                    if (row.Cells[0].Text.ToString().Contains("VENDAS"))
                    {
                        decimal totVlUnitario = 0;
                        decimal totVlDesconto = 0;
                        decimal totVlBaseCom = 0;
                        decimal totVlComissao = 0;

                        DataTable dtPoliticaVenda = DaoRelatorio.getAnaliticoPoliticaVenda(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                        gridVendaPolitica.DataSource = dtPoliticaVenda;
                        gridVendaPolitica.DataBind();

                        calcSubTotal(gridVendaPolitica.FooterRow, dtPoliticaVenda, ref totVlUnitario, ref totVlDesconto, ref totVlBaseCom, ref totVlComissao);

                        dtPoliticaVenda = DaoRelatorio.getAnaliticoForaPoliticaVenda(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                        gridForaVendaPolitica.DataSource = dtPoliticaVenda;
                        gridForaVendaPolitica.DataBind();

                        if (gridForaVendaPolitica.Rows.Count > 0)
                        {
                            calcSubTotal(gridForaVendaPolitica.FooterRow, dtPoliticaVenda, ref totVlUnitario, ref totVlDesconto, ref totVlBaseCom, ref totVlComissao);

                            lbTotValor.Text = totVlUnitario.ToString("###,###,##0.00");
                            lbTotDesconto.Text = totVlDesconto.ToString("###,###,##0.00");
                            lbTotPerDesc.Text = ((totVlDesconto * 100) / totVlUnitario).ToString("###,###,##0.00") + '%';
                            lbTotVlCobrado.Text = totVlBaseCom.ToString("###,###,##0.00");
                            lbTotComissao.Text = totVlComissao.ToString("###,###,##0.00");
                        }

                        pnAnalitico.Visible = true;
                        pnSintetico.Visible = false;
                        pnAnaliticoAjusteCredito.Visible = false;
                        pnAnaliticoServico.Visible = false;
                        //
                        lbexportar.Visible = true;
                        lbexportservexterno.Visible = true;
                        lbexportserveinterno.Visible = true;
                        lbexportarajustcredito.Visible = true;
                        lbexportaforavendapolitica.Visible = true;
                        lbexportvendapolitica.Visible = true;
                        lbexportarajustcredito.Visible = true;

                        imggridVendaPolitica.Visible = true;
                        imggridForaVendaPolitica.Visible = true;
                        imggridDescontosDiversos.Visible = true;
                        imggridservicoexterno.Visible = true;
                        imggridServicoInterno.Visible = true;
                        imggridanaliticoajustcredito.Visible = true;
                       

                        lbPeriodoVendaNaoPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Vendas fora da Política de Vendas";
                        lbPeriodoVendaPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Vendas de acordo com a Política de Vendas";

                        Utils.setVoltarUrl(Page, Session, new string[] { "pnSintetico" }, new string[] { "pnAnalitico" }, "Relatorio.aspx");
                    }
                    else
                    {
                        DataTable dtServico = DaoRelatorio.getAnaliticoServicoInterno(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                        decimal tot = dtServico.AsEnumerable().Sum(x => x.Field<decimal>("vl_servico"));
                        gridServicoInterno.DataSource = dtServico;
                        gridServicoInterno.DataBind();


                        if (dtServico.Rows.Count > 0)
                            gridServicoInterno.FooterRow.Cells[7].Text = tot.ToString("###,###,##0.00");

                        dtServico = DaoRelatorio.getAnaliticoServicoExterno(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                        decimal tot2 = dtServico.AsEnumerable().Sum(x => x.Field<decimal>("vl_servico"));
                        tot = tot + tot2;
                        gridServicoExterno.DataSource = dtServico;
                        gridServicoExterno.DataBind();
                        if (dtServico.Rows.Count > 0)
                            gridServicoExterno.FooterRow.Cells[7].Text = tot2.ToString("###,###,##0.00");

                        pnAnalitico.Visible = false;
                        pnSintetico.Visible = false;
                        pnAnaliticoAjusteCredito.Visible = false;
                        pnAnaliticoServico.Visible = true;

                        lbPeriodoServicoInterno.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Serviços Pagos INTERNOS";
                        lbPeriodoServicoExterno.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Serviços Pagos EXTERNOS";
                        lbTotValorServico.Text = tot.ToString("###,###,##0.00");

                        Utils.setVoltarUrl(Page, Session, new string[] { "pnSintetico" }, new string[] { "pnAnaliticoServico" }, "Relatorio.aspx");
                    }

                }
                catch (Exception ex)
                {
                    ShowMensagem(ex.Message);
                }

            }
        }
        protected void gridVendaPolitica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 5;
                e.Row.Cells[0].Text = "SubTotal";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Font.Bold = true;

            }
            else
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToDouble(e.Row.Cells[5].Text) < 0)
                        e.Row.CssClass = "Negativo";
                }
        }
        private void calcSubTotal(GridViewRow linha, DataTable dt, ref decimal totVlUnitario, ref decimal totVlDesconto, ref decimal totVlBaseCom, ref decimal totVlComissao)
        {
            if (dt.Rows.Count > 0)
            {
                decimal auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_unitario"));
                totVlUnitario += auxCalc;
                linha.Cells[5].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                decimal totDesconto = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_desconto"));
                totVlDesconto += totDesconto;
                linha.Cells[6].Text = totDesconto.ToString("###,###,##0.00");
                linha.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                linha.Cells[7].Text = ((totDesconto * 100) / auxCalc).ToString("###,###,##0.00") + '%';
                linha.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_basecom"));
                totVlBaseCom += auxCalc;
                linha.Cells[8].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_comissao"));
                totVlComissao += auxCalc;
                linha.Cells[10].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            }
        }
        private void ShowMensagem(string mens)
        {
            lbMensErro.Text = "Erro: " + mens;
            lbMensErro.Visible = true;
            pnSintetico.Visible = false;
            pnAnalitico.Visible = false;
            
        }
        protected void gridSinteticoAjusteCre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "analitico")
            {
                try
                {
                    daoRelatorioPagamento DaoRelatorio = new daoRelatorioPagamento();
                    GridViewRow row;
                    HiddenField idAgenda;
                    HiddenField idLancamento;
                    HiddenField tp;
                    if (e.CommandSource == gridSinteticoAjusteCre)
                    {
                        row = gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)];
                        idAgenda = (HiddenField)gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                        idLancamento = (HiddenField)gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idLancamento");
                        tp = (HiddenField)gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("tp");
                    }
                    else
                        if (e.CommandSource == gridSinteticoAjusteDeb)
                        {
                            row = gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)];
                            idAgenda = (HiddenField)gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                            idLancamento = (HiddenField)gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idLancamento");
                            tp = (HiddenField)gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("tp");
                        }
                        else
                        {
                            row = gridSinteticoDebitos.Rows[Convert.ToInt32(e.CommandArgument)];
                            idAgenda = (HiddenField)gridSinteticoDebitos.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                            idLancamento = (HiddenField)gridSinteticoDebitos.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idLancamento");
                            tp = (HiddenField)gridSinteticoDebitos.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("tp");
                        }

                    DataTable dtAjusteCre = DaoRelatorio.getAnaliticoAjusteCredito(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value), Convert.ToInt32(idLancamento.Value), Convert.ToInt32(tp.Value));

                    if (e.CommandSource == gridSinteticoAjusteDeb || e.CommandSource == gridSinteticoAjusteCre)
                    {
                        gridAnaliticoAjusteCredito.DataSource = dtAjusteCre;
                        gridAnaliticoAjusteCredito.DataBind();

                        decimal auxCalc = dtAjusteCre.AsEnumerable().Sum(x => x.Field<decimal>("valor"));
                        gridAnaliticoAjusteCredito.FooterRow.Cells[0].Text = auxCalc.ToString("###,###,##0.00");
                        gridAnaliticoAjusteCredito.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;


                        pnAnaliticoAjusteCredito.Visible = true;
                        Utils.setVoltarUrl(Page, Session, new string[] { "pnSintetico" }, new string[] { "pnAnaliticoAjusteCredito" }, "Relatorio.aspx");
                    }
                    else
                    {
                        gridDescontosDiversos.DataSource = dtAjusteCre;
                        gridDescontosDiversos.DataBind();

                        decimal auxCalc = dtAjusteCre.AsEnumerable().Sum(x => x.Field<decimal>("vl_notaFiscalCS"));
                        gridDescontosDiversos.FooterRow.Cells[7].Text = auxCalc.ToString("###,###,##0.00");
                        gridDescontosDiversos.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                        gridDescontosDiversos.FooterRow.Cells[6].Text = "Total:";
                        gridDescontosDiversos.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                        pnDescontosDiversos.Visible = true;
                        Utils.setVoltarUrl(Page, Session, new string[] { "pnSintetico" }, new string[] { "pnDescontosDiversos" }, "Relatorio.aspx");
                    }

                    pnAnalitico.Visible = false;
                    pnSintetico.Visible = false;
                    //
                    lbexportar.Visible = true;
                    lbexportservexterno.Visible = true;
                    lbexportserveinterno.Visible = true;
                    lbexportarajustcredito.Visible = true;
                    lbexportaforavendapolitica.Visible = true;
                    lbexportvendapolitica.Visible = true;
                    lbexportarajustcredito.Visible = true;
                    imggridVendaPolitica.Visible = true;
                    imggridForaVendaPolitica.Visible = true;
                    imggridDescontosDiversos.Visible = true;
                    imggridservicoexterno.Visible = true;
                    imggridServicoInterno.Visible = true;
                    imggridanaliticoajustcredito.Visible = true;
                    imggridDescontosDiversos.Visible = true;
                    imggridservicoexterno.Visible = true;
                    imggridServicoInterno.Visible = true;
                }

                catch (Exception ex)
                {
                    ShowMensagem(ex.Message);
                }

            }
        }
        protected void gridServicoInterno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 7;
                e.Row.Cells[0].Text = "SubTotal";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

            }
            else
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToDouble(e.Row.Cells[7].Text) <= 0)
                        e.Row.CssClass = "Negativo";
                }
        }
        protected void gridSinteticoDebitos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COMPRA DE PRODUTOS")
                    e.Row.Cells[2].Controls[0].Visible = false;
            }
        }
        //Botões para exportar os dados da grid para o excel
        protected void imggridDescontosDiversos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Serviços_Externos.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_Serviços_Externos.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridDescontosDiversos.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        protected void imggridservicoexterno_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Serviços_Externo.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_Serviços_Externo.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridServicoExterno.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        protected void imggridServicoInterno_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Serviços_Internos.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_Serviços_Internos.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridServicoInterno.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        protected void imggridanaliticoajustcredito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Ajuste_Credito.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_Ajuste_Credito.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridAnaliticoAjusteCredito.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        protected void imggridForaVendaPolitica_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Vendas_Fora_da_Politica.xls");
            Response.Charset = "";
            Response.ContentType = "application/Vendas_Fora_da_Politica.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridForaVendaPolitica.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        protected void imggridVendaPolitica_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_Vendas__da_Politica.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_Vendas__da_Politica.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridVendaPolitica.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
       
    }
}



       
        
  
