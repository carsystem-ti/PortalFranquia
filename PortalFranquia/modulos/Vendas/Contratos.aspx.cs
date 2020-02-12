using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Vendas
{
    public partial class Contratos : System.Web.UI.Page
    {
          
        daoPedido bdpv = new daoPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session);
            if (!IsPostBack)
            {
                txtpedido.Text = Session["pedido"].ToString();
                BuscaDadosPedidosAbertos(Convert.ToInt32(txtpedido.Text));
            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["cnxFranquia"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }

                    }

                }

            }

        }
        protected void GridContrato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string customerId = GridContrato.DataKeys[e.Row.RowIndex].Value.ToString();

                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;

                gvOrders.DataSource = GetData(string.Format("SELECT distinct p.id_pedido,ve.id_item,pv.ds_placa,pv.nr_contrato FROM Franquia.tbl_PedidoVenda p inner join [Franquia].[tbl_PedidoVendaItens] ve on p.id_pedido=ve.id_pedido inner join  Franquia.tbl_PedidoVendaVeiculo pv on pv.id_item=ve.id_item inner join Modelos m on pv.id_modelo=m.id_modelo inner join Franquia.tbl_ProdutoVenda prod on  prod.id_produto=ve.id_produto where prod.tp_produto='P' and p.id_pedido='{0}'", customerId));

                gvOrders.DataBind();

            }
        }

        protected void GridContrato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                daoContrato bdc = new daoContrato();
                DataSet dsPedido = new DataSet();
                string nr_contrato = null;
                string aux = null;
                string habilita = "N".ToString();
                bdc._idPedido = Convert.ToInt32(GridContrato.Rows[e.RowIndex].Cells[1].Text);
                dsPedido = bdc.getPedido();
                if (dsPedido.Tables[0].Rows.Count > 0)
                {
                    DataSet dsValida = new DataSet();
                    daoPedido bdv = new daoPedido();
                    bdv._nrDocumento = dsPedido.Tables[0].Rows[0]["ds_documento"].ToString();
                    dsValida = bdv.ValidaGeracaoPedidos();
                    if (dsValida.Tables[0].Rows.Count > 0)
                    {
                        //lblmensagem.Visible = true;
                       Mensagem("Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString());

                    }
                    else
                    {
                        for (int i = 0; i < dsPedido.Tables[0].Rows.Count; i++)
                        {

                            bdc._dsNome = dsPedido.Tables[0].Rows[i]["ds_cliente"].ToString();
                            bdc._tpPessoa = Convert.ToInt32(dsPedido.Tables[0].Rows[0]["tp_cliente"].ToString());

                            if (bdc._tpPessoa == 0)
                                bdc._dsCpf = dsPedido.Tables[0].Rows[i]["ds_documento"].ToString();
                            else
                                bdc._dsCnpj = dsPedido.Tables[0].Rows[i]["ds_documento"].ToString();

                            bdc._dsRg = dsPedido.Tables[0].Rows[i]["nr_rg"].ToString();
                            bdc._dtNascimento = Convert.ToDateTime(dsPedido.Tables[0].Rows[i]["dt_nascimento"].ToString());
                            bdc._dsEndereco = dsPedido.Tables[0].Rows[i]["ds_endereco"].ToString();
                            bdc._nrResidencia = dsPedido.Tables[0].Rows[i]["nr_endereco"].ToString();
                            bdc._dsComplemento = dsPedido.Tables[0].Rows[i]["ds_complemento"].ToString();
                            bdc._dsCep = dsPedido.Tables[0].Rows[i]["nr_cep"].ToString();
                            bdc._dsBairro = dsPedido.Tables[0].Rows[i]["ds_bairro"].ToString();
                            bdc._dsCidade = dsPedido.Tables[0].Rows[i]["ds_cidade"].ToString();
                            bdc._dsUF = dsPedido.Tables[0].Rows[i]["ds_uf"].ToString();
                            bdc._nrTelResidencial = dsPedido.Tables[0].Rows[i]["Telefone"].ToString();
                            bdc._nrTelCelular = dsPedido.Tables[0].Rows[i]["Celular"].ToString();
                            bdc._ds_pontoReferencia = dsPedido.Tables[0].Rows[i]["ds_complemento"].ToString();
                            bdc._dsEmail = dsPedido.Tables[0].Rows[i]["ds_email"].ToString();
                            bdc._tpVeiculo = dsPedido.Tables[0].Rows[i]["ds_categoria"].ToString();
                            bdc._ds_fabricante = dsPedido.Tables[0].Rows[i]["ds_Fabricante"].ToString();
                            bdc._ds_modelo = dsPedido.Tables[0].Rows[i]["modelo"].ToString();
                            bdc._ds_placa = dsPedido.Tables[0].Rows[i]["ds_placa"].ToString();
                            DataSet dsValidaHabit = new DataSet();
                            dsValidaHabit = bdc.ValidaHabilitacao();
                            if (dsValidaHabit.Tables[0].Rows.Count > 0)
                                bdc._dt_Renova = DateTime.Now.AddMonths(12);
                            else
                                bdc._dt_Renova = DateTime.Now;
                            bdc._ds_anoVeiculo = dsPedido.Tables[0].Rows[i]["ds_ano"].ToString();
                            bdc._ds_cor = dsPedido.Tables[0].Rows[i]["ds_cor"].ToString();
                            bdc._ds_combustivel = dsPedido.Tables[0].Rows[i]["ds_combustivel"].ToString();
                            bdc._ds_Renavam = dsPedido.Tables[0].Rows[i]["ds_renavan"].ToString();
                            bdc._ds_Chassi = dsPedido.Tables[0].Rows[i]["ds_chassi"].ToString();
                            bdc._ds_Produto = dsPedido.Tables[0].Rows[i]["ds_produto"].ToString();
                            bdc._ds_vendedor = dsPedido.Tables[0].Rows[i]["cd_vendedor"].ToString();
                            bdc._ds_sexo = dsPedido.Tables[0].Rows[i]["tp_Sexo"].ToString();
                            bdc._ds_Profissao = dsPedido.Tables[0].Rows[i]["cd_profisao"].ToString();
                            bdc._idmidia = dsPedido.Tables[0].Rows[i]["id_midia"].ToString();
                            bdc._id_produto = dsPedido.Tables[0].Rows[i]["id_produto"].ToString();
                            nr_contrato = bdc.pro_setGeraContrato();
                            if (nr_contrato != null)
                            {
                                bdc._nrcontrato = nr_contrato;
                                int alter = bdc.pro_setVinculaPedidoContrato();
                                if (bdc._id_produto == "000424" || bdc._id_produto == "000425" || bdc._id_produto == "000426" || bdc._id_produto == "000426" || bdc._id_produto == "000427" || bdc._id_produto == "000436" || bdc._id_produto == "000437" || bdc._id_produto == "000438" || bdc._id_produto == "000439")
                                {
                                    int gravar = bdc.pro_seQbe();
                                }
                                if (alter > 0)
                                {
                                    aux = aux + ", " + nr_contrato;
                                    lblmensagem.Visible = true;
                                    lblmensagem.Text = "Contrato: " + aux + " gerado com sucesso...";
                                    Mensagem("Contrato: " + aux + " gerado com sucesso...");
                                    BuscaDadosPedidosAbertos(bdc._idPedido);
                                }

                            }
                        }
                       
                        
                    }
                }
            }
            catch (Exception ex)
            {
                erro.Visible = true;
                lblerro.Text=ex.ToString();
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
        private void BuscaDadosPedidosAbertos(int pedido)
        {
            DataTable dt_ped = new DataTable();
            dt_ped = bdpv.PedidosContrato(pedido);
            if (dt_ped.Rows.Count > 0)
            {
                GridContrato.DataSource = dt_ped;
                GridContrato.DataBind();
            }
        }
        protected void GridContrato_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(GridContrato);
        }
    }
}