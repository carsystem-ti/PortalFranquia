using PortalFranquia.dao;
using PortalFranquia.dao.daoTroca;
using PortalFranquia.dao.trocas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Vendas
{
    public partial class MeusPedidosTroca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscaDadosPedidosAbertos();
               
        }
      
        private void BuscaDadosPedidosAbertos()
        {
            if (txtInicial.Text != "" && TxtFinal.Text != "")
            {
                try
                {
                    
                    daoProdutoTroca bdt=new daoProdutoTroca();
                    DataTable dt_ped = new DataTable();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    int id_franquia = acessoLogin.idFranquia;
                    int tipo = 1;
                    DateTime dt_inicial = DateTime.ParseExact(txtInicial.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
                    DateTime dt_final = DateTime.ParseExact(TxtFinal.Text + " 23:59:59", "dd/MM/yyyy HH:mm:ss", null);
                    dt_ped =bdt.getMeusPedidosTroca(tipo, dt_inicial, dt_final, id_franquia);
                    if (dt_ped.Rows.Count > 0)
                    {
                        gridContrato.DataSource = dt_ped;
                        gridContrato.DataBind();

                    }
                    else
                    {
                        Mensagem("Não existe dados para essa fonte de busca..");
                        gridContrato.DataBind();
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            else
            {
                Mensagem("Favor preencher todos os dados..");
                gridContrato.DataBind();

            }
        }
        public class GridDecorator
        {
            public static void MergeRows(GridView gridView)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
                    int i = 0;

                    if (row.Cells[i].Text.TrimEnd().TrimStart() == previousRow.Cells[i].Text.TrimEnd().TrimStart())
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                    else
                    {
                        i = 1;
                    }

                }
            }

        }
        protected void gridContrato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridContrato.PageIndex = e.NewPageIndex;
            BuscaDadosPedidosAbertos();
        }

        protected void gridContrato_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(gridContrato);
        }

        protected void gridContrato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gridContrato, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gridContrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}