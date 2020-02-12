using PortalFranquia.dao;
using PortalFranquia.dao.relatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.relatorios
{
    public partial class RelVendasFranquia : System.Web.UI.Page
    {

        DataTable dtrelexport = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.dsTipo != "G")
            {
                Utils.SemPermissão(Response, Session);
            }
            Utils.setVoltarUrl(Page, Session, "Relatorio.aspx");

            if (!IsPostBack)
            {

                ddlMes.SelectedIndex = DateTime.Now.Month -1;
                txtAno.Text = DateTime.Now.Year.ToString();
            }
        }

        //Calcular o Subtotal
        protected void GridRelVnd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridRelVnd.Rows.Count > 0)
            {
                decimal SomaGeral = 0;

                foreach (GridViewRow row in GridRelVnd.Rows)
                {
                    if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                    {
                        decimal valor = Convert.ToDecimal(row.Cells[4].Text.Replace("R$", ""));
                        SomaGeral += valor;
                        if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[3].Text = "SubTotal";
                            e.Row.Cells[4].Text = string.Format("{0:c}", valor);
                            e.Row.Cells[4].Text = string.Format("{0:c}", SomaGeral);
                            
                        }
                    }
                }
            }
        }

        private void BuscaDados()
        {
            if (txtAno.Text != "")
            {
                daoRelVendas bdv = new daoRelVendas();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int franquia = acessoLogin.idFranquia;
                DataTable dt = bdv.franquiarelatoriovendas(Convert.ToInt32(txtAno.Text), Convert.ToInt32(ddlMes.SelectedValue),franquia);
                Session.Add("Contatos2Excel", dt);
                if (dt.Rows.Count > 0)
                {
                    GridRelVnd.DataSource = dt;
                    GridRelVnd.DataBind();
                    lbTitulovnd.Text = "Período de Apuração "  + bdv.periodo;
                    lbTitulovnd.Visible = true;
                    pnTituloRelvnd.Visible = true;
                    lbexportar.Visible = true;
                    imgExport.Visible = true;
                    
                    
                }
                else
                {
                    GridRelVnd.DataBind();
                    pnTituloRelvnd.Visible = false;
                    lbexportar.Visible = false;
                    imgExport.Visible = true;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscaDados();
            //Agrupamento do GridView
            GridViewHelper helper = new GridViewHelper(this.GridRelVnd);
            helper.RegisterGroup("ds_vendedor", true, true);
            helper.RegisterSummary("vl_unitario", SummaryOperation.Sum, "ds_vendedor");
            helper.ApplyGroupSort();

        }

        protected void GridRelVnd_Sorting(object sender, GridViewSortEventArgs e)
        {
            BuscaDados();
        }

        //Exportando os dados do relatorio de vendas para o MS Excel
        private void exportarExcelAnalitico()
        {
            //BuscaDados();
            string relvendas = "Relatorio_Analitico_Vendas";
            dtrelexport.Columns.Add("Data", typeof(string));
            dtrelexport.Columns.Add("ds_vendedor", typeof(string));
            dtrelexport.Columns.Add("nr_contrato", typeof(string));
            dtrelexport.Columns.Add("ds_produto", typeof(string));
            dtrelexport.Columns.Add("vl_unitario", typeof(string));
            DataTable dt = (Session["Contatos2Excel"] as DataTable);
            dt.Columns.Remove("id_franquia");
            dt.Columns.Remove("ds_franquia");
            dt.Columns.Remove("ds_cliente");
            dt.Columns.Remove("id_pedido");
            dt.Columns.Remove("id_item");
            dt.Columns["dt_confirmacao"].ColumnName = "Data";
            dt.Columns["ds_vendedor"].ColumnName = "Vendedor";
            dt.Columns["nr_contrato"].ColumnName = "Contrato";
            dt.Columns["ds_produto"].ColumnName = "Produto";
            dt.Columns["vl_unitario"].ColumnName = "Valor";

          //Chamando método static, passando DataTable preenchido e nome do arquivo
            ExportarParaExcelAnalitico(dt, relvendas);
        }
        //Exportando dados da proc para o Ms Excel
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
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nome + ".xls");
            context.Response.End();
        }

        protected void imgExport_Click(object sender, ImageClickEventArgs e)
        {
            exportarExcelAnalitico();
        }

    }
}

