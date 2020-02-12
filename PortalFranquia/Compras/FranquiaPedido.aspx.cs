using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;

namespace PortalFranquia
{
    public partial class FranquiaPedido : System.Web.UI.Page
    {
        daoPedido bdp = new daoPedido();
        daoPedidoItens bdi = new daoPedidoItens();
        //int tipo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session, "HomeCompras.aspx");
            if (!IsPostBack)
            {
                rdbFiltro.SelectedValue = "1";
                FiltroPedidos();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if (acessoLogin.idGrupo == 7 || acessoLogin.idGrupo == 33)
                {
                    Response.Redirect("AdmFranquia.aspx");
                }

            }

        }
        private void BuscaMensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        private void DesabilitaFuncoes()
        {
            enviarCadastro.Visible = false;
            cancelarPedido.Visible = false;
        }
        private void FiltroPedidos()
        {
            int filtro = Convert.ToInt32(rdbFiltro.SelectedValue);
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int franquia = acessoLogin.idFranquia;
            DataTable dt = bdp.pro_getFiltroPedidos(filtro, franquia);
            if (dt.Rows.Count > 0)
            {
                GridPedidosAbertos.DataSource = dt;
                GridPedidosAbertos.DataBind();
                grid.Visible = true;
                DesabilitaFuncoes();
            }
            else
            {
                GridPedidosAbertos.DataBind();
                GridItem.DataBind();
                cancelarPedido.Visible = false;
                divItem.Visible = false;
                grid.Visible = false;
                BuscaMensagem("Não existe dados para essa fonte de busca");
            }
        }
        protected void GridPedidosAbertos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton iBotaoBoleto = (ImageButton)e.Row.FindControl("imgBoleto");
                ImageButton iBotaoTaxa = (ImageButton)e.Row.FindControl("imgTaxa");

                if (bdp.getCodigoBoleto(Convert.ToInt32(e.Row.Cells[0].Text), false) == 0)
                    iBotaoBoleto.Visible = false;
                else
                {
                    iBotaoBoleto.CommandArgument = "boleto;" + e.Row.Cells[0].Text;
                    iBotaoBoleto.AlternateText = "Imprimir Boleto Pedido";
                    iBotaoBoleto.ToolTip = "Imprimir Boleto Pedido";
                }

                if (bdp.getCodigoBoleto(Convert.ToInt32(e.Row.Cells[0].Text), true) == 0)
                    iBotaoTaxa.Visible = false;
                else
                {
                    iBotaoTaxa.CommandArgument = "taxa;" + e.Row.Cells[0].Text;
                    iBotaoTaxa.AlternateText = "Imprimir Boleto Taxa";
                    iBotaoTaxa.ToolTip = "Imprimir Boleto Taxa";
                }

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                foreach (TableCell iCelula in e.Row.Cells)
                {
                    if (iCelula.HasControls())
                        continue;

                    iCelula.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridPedidosAbertos, "Select$" + e.Row.RowIndex);
                }

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridPedidosAbertos, "Select$" + e.Row.RowIndex);
            }
        }
        private void BuscaItens()
        {
            int item = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[1].Text);
            int pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
            DataTable dt_itens = bdi.pro_getFiltroPedidosItens(item,pedido);
            if (dt_itens.Rows.Count > 0)
            {
                GridItem.DataSource = dt_itens;
                GridItem.DataBind();
                divItem.Visible = true;
                cancelarPedido.Visible = false;
            }
            else
            {
                cancelarPedido.Visible = false;
                divItem.Visible = false;
                FiltroPedidos();
            }

        }
        protected void GridPedidosAbertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = GridPedidosAbertos.SelectedRow.Cells[6].Text;
            int item = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[1].Text);
            int pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
            int filtro = Convert.ToInt32(rdbFiltro.SelectedValue);
            switch (filtro)
            {
                case 1:
                    enviarCadastro.Visible = true;
                    cancelarPedido.Visible = true;
                    divItem.Visible = false;
                    break;
                case 6:
                    enviarCadastro.Visible = false;
                    cancelarPedido.Visible = false;
                    DataTable dt_itens = bdi.pro_getFiltroPedidosItens(item,pedido);
                    if (dt_itens.Rows.Count > 0)
                    {
                        GridItem.DataSource = dt_itens;
                        GridItem.DataBind();
                        divItem.Visible = true;
                        cancelarPedido.Visible = false;
                    }
                    else
                    {
                        cancelarPedido.Visible = false;
                        divItem.Visible = false;
                    }
                    break;
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
        protected void GridPedidosAbertos_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(GridPedidosAbertos);

        }

        protected void rdbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltroPedidos();
        }

        protected void GridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridItem, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridItem.SelectedRow.Cells[1].Text != "")
                {
                    int retorno = 0;
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string id_peca = GridItem.SelectedRow.Cells[1].Text;
                    string ds_usuario = acessoLogin.Nome;
                    int pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
                    string cd_cetec = acessoLogin.cdCetec;
                    retorno = bdi.pro_setAceite(id_peca, ds_usuario, pedido,cd_cetec);
                    if (retorno > 0)
                    {
                        BuscaMensagem("Aceite Realizado com sucesso");

                    }
                }
                BuscaItens();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void CancelaPedido()
        {
            try
            {
                int retorno = 0;
                int id_pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
                bdp.pro_setAlteraStatus(id_pedido, 8);
                if (retorno > 0)
                {
                    BuscaMensagem("Pedido: " + id_pedido + " Cancelado com sucesso");
                }
                else
                {
                    BuscaMensagem("Não foi possível cancelar esse pedido");
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
        private void EnviaCadastro()
        {
            try
            {
                int retorno = 0;
                int id_pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
                bdp.pro_setAlteraStatus(id_pedido, 2);
                if (retorno > 0)
                {
                    BuscaMensagem("Pedido: " + id_pedido + " enviado com sucesso");
                }
                else
                {
                    BuscaMensagem("Não foi possível cancelar esse pedido");
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelaPedido();
            FiltroPedidos();
        }

        protected void btnEnviarCadastro_Click(object sender, EventArgs e)
        {
            EnviaCadastro();
            FiltroPedidos();
        }
        protected void imgLog_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (GridPedidosAbertos.SelectedRow.Cells[0].Text != null)
                {
                    Session["pedido"] = GridPedidosAbertos.SelectedRow.Cells[0].Text;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "abrir-1", "window.open('LogPedidoCompra.aspx')", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Imprimir()", true);
                }
            }
            catch (Exception ex)
            {
                BuscaMensagem(ex.Message.ToString());
            }
        }

        protected void GridPedidosAbertos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPedidosAbertos.PageIndex = e.NewPageIndex;
            FiltroPedidos();
        }

        protected void GridPedidosAbertos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            divBoleto.InnerHtml = "";

            if (e.CommandArgument == null ) 
                return;

            string[] iArgumento = e.CommandArgument.ToString().Split(';');

            switch ( iArgumento[0] )
            {
                case "boleto":
                    divBoleto.InnerHtml = bdp.executaBoleto(Convert.ToInt32(iArgumento[1]), false);
                    break;
                case "taxa":
                    divBoleto.InnerHtml = bdp.executaBoleto(Convert.ToInt32(iArgumento[1]), true);
                    break;
                case "aceite":
                    GridPedidosAbertos_SelectedIndexChanged(sender, null);
                    break;
            }            
        }
    }
}