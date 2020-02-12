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
    public partial class MeusPedidosVendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] == null)
            {
   
                Response.Redirect("../../Login.aspx");
            }
            Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
            if (!IsPostBack)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if (acessoLogin.idGrupo == 33)
                    getFranquiasCetecs();
                    //    Response.Redirect("~/Vendas/AdmFranquia.aspx");
            }
        }
        private void getFranquiasCetecs()
        {
            daoPedidoVenda bdpv = new daoPedidoVenda();
            DataTable dtFranquias = new DataTable();
            dropfranquias.Visible = true;
            dtFranquias = bdpv.getFranquiaCetecs();
            if (dtFranquias.Rows.Count > 0)
            {
                dropfranquias.DataSource = dtFranquias;
                dropfranquias.DataBind();
                dropfranquias.Items.Insert(0, "Selecione");


            }

        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void BuscaDadosPedidosAbertos()
        {
            if (Session["acessoLogin"] != null)
            {

                if (txtInicial.Text != "" && TxtFinal.Text != "")
                {
                    try
                    {
                        daoPedidoVenda bdpv = new daoPedidoVenda();
                        DataTable dt_ped = new DataTable();
                        AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                        int id_franquia = acessoLogin.idFranquia;
                        if (acessoLogin.idFranquia == 0 && dropfranquias.SelectedValue != "Selecione")
                            id_franquia = Convert.ToInt32(dropfranquias.SelectedValue);
                        int tipo = 1;
                        DateTime dt_inicial = Convert.ToDateTime(txtInicial.Text + " 00:00:00");
                        DateTime dt_final = Convert.ToDateTime(TxtFinal.Text + " 23:59:59");
                        dt_ped = bdpv.getMeusPedidos(tipo, dt_inicial, dt_final, id_franquia);
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
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscaDadosPedidosAbertos();
        }

        protected void gridContrato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridContrato.PageIndex = e.NewPageIndex;
            BuscaDadosPedidosAbertos();
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
        protected void gridContrato_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(gridContrato);

        }

        protected void gridContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["pedido"] = gridContrato.SelectedDataKey[0].ToString();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "abrir-1", "window.open(http://localhost:15301/Recibo.aspx')", true);
            //string _open = "window.open('Recibo.aspx');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),"Imprimir()", true);
        }
    }
}