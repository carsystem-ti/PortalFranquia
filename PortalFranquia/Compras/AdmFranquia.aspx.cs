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
    public partial class AdmFranquia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] != null)
            {
                Utils.setVoltarUrl(Page, Session, "HomeCompras.aspx");
                if (!IsPostBack)
                {
                    ValidaAcesso();
                }
            }
            else
            {
                Response.Redirect("../../Login.aspx");
            }
        }
        private void ValidaAcesso()
        {
            if (Session["acessoLogin"] != null)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int grupo = acessoLogin.idGrupo;
                switch (grupo)
                {
                    case 33 :
                        dropfranquias.Visible = true;
                        lblFranquia.Visible = true;
                        getFranquiasCetecs();
                        break;
                    default:
                        dropfranquias.Visible = false;
                        lblFranquia.Visible = false;
                        break;
                    
                }

            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        private void BuscaDadosPedidosAbertos()
        {
            if (txtInicial.Text != "" && TxtFinal.Text != "" && dropfranquias.SelectedValue != "Selecione")
            {
                int id_franquia= 0;
                daoPedidoVenda bdpv = new daoPedidoVenda();
                DataTable dt_ped = new DataTable();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if (acessoLogin.idGrupo == 33)
                {
                     id_franquia = Convert.ToInt32(dropfranquias.SelectedValue);
                }
                else
                {
                    id_franquia = acessoLogin.idFranquia;
                }
                int tipo = 1;
                DateTime dataInicial = Convert.ToDateTime(txtInicial.Text + " 00:00:00");
                DateTime dataFinal = Convert.ToDateTime(TxtFinal.Text + " 23:59:59");
                dt_ped = bdpv.getMeusPedidosCompras(tipo, dataInicial, dataFinal, id_franquia);
                if (dt_ped.Rows.Count > 0)
                {
                    gridContrato.DataSource = dt_ped;
                    gridContrato.DataBind();
                }
                else
                {
                    gridContrato.DataBind();
                    Mensagem("Não existe Dados..");
                }
            }
            else
            {
                Mensagem("Favor preencher todos os dados..");
            }
        }
        private void getFranquiasCetecs()
        {
            daoPedidoVenda bdpv = new daoPedidoVenda();
            DataTable dtFranquias = new DataTable();
            dtFranquias = bdpv.getFranquiaCetecs();
            if (dtFranquias.Rows.Count > 0)
            {
                dropfranquias.DataSource = dtFranquias;
                dropfranquias.DataBind();
                dropfranquias.Items.Insert(0, "Selecione");

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
        public class GridDecoratorDetalhes
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

            Session["id_pedido"] = Convert.ToInt32(gridContrato.SelectedRow.Cells[0].Text);
            Session["ds_franquia"] = gridContrato.SelectedRow.Cells[1].Text;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "abrir-1", "window.open('DetalhesPecas.aspx')", true);
        }
        private void DetalhesID(int pedido)
        {
            daoPedidoItens BDi = new daoPedidoItens();
            DataTable dt = new DataTable();

            dt = BDi.pro_getDetalhesPecas(pedido);
            if (dt.Rows.Count > 0)
            {
                GridDetalhes.DataSource = dt;
                GridDetalhes.DataBind();
                lblmensagem.Visible = true;
                lblmensagem.Text = "TOTAL DE PEÇAS DO PEDIDO : " + dt.Rows.Count;
            }
            else
            {
                GridDetalhes.DataBind();
                lblmensagem.Visible = true;
                lblmensagem.Text = "DETALHAMENTO DO ID´S...";
            }
        }
        protected void GridDetalhes_PreRender(object sender, EventArgs e)
        {
            GridDecoratorDetalhes.MergeRows(GridDetalhes);
        }

        protected void btnLinkView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnLinkView = sender as LinkButton;
                GridViewRow GVEmployeeRow = (GridViewRow)btnLinkView.NamingContainer;
                DetalhesID(Convert.ToInt32(GVEmployeeRow.Cells[0].Text));
                PnlEmployee_ModalPopupExtender.Show();
            }
            catch (Exception)
            { 
            }
        }
    }
}