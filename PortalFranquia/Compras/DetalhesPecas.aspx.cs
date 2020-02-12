using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PortalFranquia.dao;
namespace PortalFranquia.Compras
{
    public partial class DetalhesPecas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pedido = Convert.ToInt32(Session["id_pedido"]);
            DetalhesID(pedido);
        }
        private void DetalhesID(int pedido)
        {
            daoPedidoItens BDi=new daoPedidoItens();
            DataTable dt = new DataTable();
            
            dt = BDi.pro_getDetalhesPecas(pedido);
            if (dt.Rows.Count > 0)
            {
                GridDetalhes.DataSource = dt;
                GridDetalhes.DataBind();
                pnTitulo.Visible = true;
                lbTitulo.Text += " Franquia " + Session["ds_franquia"].ToString();
            }
            else
            {
                GridDetalhes.DataBind();
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
        protected void GridDetalhes_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(GridDetalhes);
        }
    }
}