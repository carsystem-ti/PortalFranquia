using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Vendas
{
    public partial class VendasPagamentos : System.Web.UI.Page
    {
        daoPedidoVendaPagamento bdvp = new daoPedidoVendaPagamento();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session);
            if (!IsPostBack)
            {
                if (Session["pedido"] != null && Session["totalOperacao"] != null)
                {
                    txtpedido.Text = Session["pedido"].ToString();
                    txtTotalOperacao.Text = Session["totalOperacao"].ToString();
                    pro_getPagamentos();
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void getPagamentos()
        {
            bdvp._idPedido = Convert.ToInt32(txtpedido.Text);
            DataTable dt = bdvp.getPagamentos();
            if (dt.Rows.Count > 0)
            {
                gridPagamento.DataSource = dt;
                gridPagamento.DataBind();
            }
            else
            {
                gridPagamento.DataBind();
            }
        }
        public static string MascaraCnpjCpf(string pCnpjCpf)
        {
            string result = "";
            if (pCnpjCpf.Length == 14)
            {
                result = pCnpjCpf.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
            if (pCnpjCpf.Length == 11)
            {
                result = pCnpjCpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
            if ((pCnpjCpf.Length != 11) && (pCnpjCpf.Length != 14))
            {
                result = pCnpjCpf;
            }
            return result;
        }
        private void GravaPagamento(int pedido)
        {
            if (dropForma.SelectedValue != "Selecione" && txtValor.Text != "0,00" && txtValor.Text != "")
            {
                if (Session["tipo"] != null && Session["doc"] != null)
                {
                    int pagamento = Convert.ToInt32(dropForma.SelectedValue);
                    int quantidade = Convert.ToInt32(txtQtdParcela.Text);
                    if (Session["tipo"].ToString() == "0")
                        bdvp._dsDoc = Session["doc"].ToString();
                    else
                        bdvp._dsDoc = Session["doc"].ToString();
                    decimal valorCalculado = Convert.ToDecimal(txtValor.Text) / quantidade;
                    switch (pagamento)
                    {
                        case 1:
                            bdvp._idPedido = pedido;
                            bdvp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdvp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdvp._dataVenc = DateTime.Now.Date;
                            bdvp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            bdvp._dsDoc = Session["doc"].ToString();
                            bdvp._dsTitular = Session["nome"].ToString();
                            bdvp.pro_setPedidoVendaPagamento();
                            getPagamentos();
                            break;
                        case 2:
                            bdvp._idPedido = pedido;
                            bdvp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdvp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdvp._dataVenc = DateTime.Now.Date;
                            bdvp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            if (txtTitular.Text != "")
                                bdvp._dsTitular = txtTitular.Text;
                            else
                                bdvp._dsTitular = Session["nome"].ToString();
                            bdvp.pro_setPedidoVendaPagamento();
                            getPagamentos();
                            break;
                        case 3:
                            if (txtDocumento.Text.Length > 10)
                            {
                                bdvp._idPedido = pedido;
                                bdvp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                                bdvp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                                bdvp._dataVenc = Convert.ToDateTime(txtvencimentoCheque.Text);
                                bdvp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                                if (txtTitular.Text != "")
                                    bdvp._dsTitular = txtTitular.Text;
                                else
                                    bdvp._dsTitular = Session["nome"].ToString();
                                bdvp._nrAgencia = txtAgencia.Text;
                                bdvp._nrConta = txtConta.Text;
                                bdvp._ccm = Server.HtmlDecode(txtLeitura.Text);
                                bdvp._nrBanco = txtBanco.Text;
                                bdvp._nr_cheque = txtNrCheque.Text;
                                bdvp._dsDoc = txtDocumento.Text;
                                bdvp._dsDoc = MascaraCnpjCpf(bdvp._dsDoc);
                                bdvp.pro_setPedidoVendaPagamento();
                                getPagamentos();
                            }
                            break;
                        case 4:
                            bdvp._idPedido = pedido;
                            bdvp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdvp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdvp._dataVenc = DateTime.Now.Date;
                            bdvp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            if (txtTitular.Text != "")
                                bdvp._dsTitular = txtTitular.Text;
                            else
                                bdvp._dsTitular = Session["nome"].ToString();
                            bdvp.pro_setPedidoVendaPagamento();
                            getPagamentos();
                            break;

                        default:
                            break;

                    }
                }
            }
            else
            {
                Mensagem("Selecione todas as informações..");
            }
        }
        protected void imgPagamento_Click(object sender, ImageClickEventArgs e)
        {
            if (dropForma.SelectedValue == "3" && chkLeitora.Checked == true)
            {
                string Ban = txtLeitura.Text.Substring(1, 3);
                txtBanco.Text = Ban;

                string Age = txtLeitura.Text.Substring(4, 4);
                txtAgencia.Text = Age;

                string Com = txtLeitura.Text.Substring(10, 3);

                string Che = txtLeitura.Text.Substring(13, 6);
                txtNrCheque.Text = Che;

                string Con = txtLeitura.Text.Substring(23, 9);
                txtConta.Text = Con;
                GravaPagamento(Convert.ToInt32(txtpedido.Text));
            }
            else
            {
                GravaPagamento(Convert.ToInt32(txtpedido.Text));
                
            }
        }

        protected void chkLeitora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeitora.Checked == true)
            {
                lblLeitura.Visible = true;
                txtLeitura.Visible = true;
                txtCheques.Visible = true;
                txtLeitura.Focus();
                txtLeitura.Text = "";
                lblcheques.Visible = true;
            }
            else
            {
                lblLeitura.Visible = false;
                txtLeitura.Visible = false;
                txtLeitura.Text = "";
                txtCheques.Visible = false;
                lblcheques.Visible = false;
            }
        }
        private void BuscaDados()
        {
           
            if (txtLeitura.Text != "" && txtTitular.Text != "" && txtDocumento.Text != "" && txtQtdParcela.Text != "" && txtvencimentoCheque.Text != "")
            {
                string Ban = txtLeitura.Text.Substring(1, 3);
                txtBanco.Text = Ban;

                string Age = txtLeitura.Text.Substring(4, 4);
                txtAgencia.Text = Age;

                string Com = txtLeitura.Text.Substring(10, 3);

                string Che = txtLeitura.Text.Substring(13, 6);
                txtNrCheque.Text = Che;

                string Con = txtLeitura.Text.Substring(23, 9);
                txtConta.Text = Con;
                GravaPagamento(Convert.ToInt32(txtpedido.Text));
               // GravaPagamento(Convert.ToInt32(txtpedido.Text));
            }
            else
            {
                Mensagem("Favor preencher todos os dados");
            }
        }
        //protected void txtLeitura_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtLeitura.Text != "" && txtTitular.Text != "" && txtDocumento.Text != "" && txtQtdParcela.Text != "" && txtvencimentoCheque.Text != "")
        //    {
        //        string Ban = txtLeitura.Text.Substring(1, 3);
        //        txtBanco.Text = Ban;

        //        string Age = txtLeitura.Text.Substring(4, 4);
        //        txtAgencia.Text = Age;

        //        string Com = txtLeitura.Text.Substring(10, 3);

        //        string Che = txtLeitura.Text.Substring(13, 6);
        //        txtNrCheque.Text = Che;

        //        string Con = txtLeitura.Text.Substring(23, 9);
        //        txtConta.Text = Con;
        //        GravaPagamento(Convert.ToInt32(txtpedido.Text));
        //        txtLeitura.Text = "";
        //        txtLeitura.Focus();
        //    }
        //    else
        //    {
        //        //lblPagamento.Visible = true;
        //        //lblPagamento.Text="FAVOR PREENCHER TODOS OS DADOS..";
        //    }

        //}
        private void pro_getPagamentos()
        {
            DataSet dt_pagamento = new DataSet();
            daoPagamento bdpg = new daoPagamento();
            dt_pagamento = bdpg.getFormasPagamentos();
            if (dt_pagamento.Tables[0].Rows.Count > 0)
            {
                dropForma.DataSource = dt_pagamento;
                dropForma.DataBind();
                dropForma.Items.Insert(0, "Selecione");
                divpagamento.Visible = true;
            }

        }
        private void BloqueiaFormaCheque()
        {
            lblbanco.Visible = false;
            txtBanco.Visible = false;
            txtBanco.Text = "";
            lblconta.Visible = false;
            txtConta.Visible = false;
            txtConta.Text = "";
            txtDocumento.Visible = false;
            txtDocumento.Text = "";
            lbltitular.Visible = false;
            txtTitular.Visible = false;
            txtTitular.Text = "";
            lbldoc.Visible = false;
            lblnrcheque.Visible = false;
            txtNrCheque.Visible = false;
            txtNrCheque.Text = "";
            lblvencimento.Visible = false;
            txtvencimentoCheque.Visible = false;
            txtvencimentoCheque.Text = "";
            lblAgencia.Visible = false;
            txtAgencia.Visible = false;
            txtAgencia.Text = "";
            chkLeitora.Checked = false;
            chkLeitora.Visible = false;

            lblLeitura.Visible = false;
            txtLeitura.Visible = false;
        }
          private void LiberaFormaCheque()
        {
            lblbanco.Visible = true;
            txtBanco.Visible = true;
            lblconta.Visible = true;
            txtConta.Visible = true;
            txtDocumento.Visible = true;
            lbltitular.Visible = true;
            txtTitular.Visible = true;
            lbldoc.Visible = true;
            lblnrcheque.Visible = true;
            txtNrCheque.Visible = true;
            lblvencimento.Visible = true;
            txtvencimentoCheque.Visible = true;
            lblAgencia.Visible = true;
            txtAgencia.Visible = true;
            chkLeitora.Visible = true;
            chkLeitora.Checked = false;
            lblLeitura.Visible = true;
            txtLeitura.Visible = true;
        }
       
        private void RegrasPagamento()
        {
            if (Session["tipo"] != null && Session["doc"] != null)
            {
                if (dropForma.SelectedValue != "" && dropForma.SelectedValue != "Selecione")
                {
                    int tpPagamento = Convert.ToInt32(dropForma.SelectedValue);
                    switch (tpPagamento)
                    {
                        case 1:
                            txtQtdParcela.Text = "1";
                            txtValor.Text = "";
                            txtQtdParcela.Enabled = false;
                            imgPagamento.Enabled = true;
                            txtvencimentoCheque.Visible = false;
                            lblvencimento.Visible = false;
                            BloqueiaFormaCheque();
                            break;

                        case 2:
                            txtQtdParcela.Enabled = true;
                            txtValor.Text = "";
                            txtvencimentoCheque.Visible = false;
                            lblvencimento.Visible = false;
                            imgPagamento.Enabled = true;
                            BloqueiaFormaCheque();
                            break;

                        case 3:
                            txtQtdParcela.Enabled = true;
                            txtvencimentoCheque.Text = DateTime.Now.AddMonths(1).ToString(@"dd/MM/yyyy");
                            txtTitular.Text = Session["nome"].ToString();
                            if (Session["tipo"].ToString() == "0")
                                bdvp._dsDoc = Session["doc"].ToString();
                            else
                                bdvp._dsDoc = Session["doc"].ToString();
                            lblvencimento.Visible = false;
                            imgPagamento.Enabled = true;
                            LiberaFormaCheque();
                            break;

                        case 4:
                            txtQtdParcela.Enabled = true;
                            txtvencimentoCheque.Text = "";
                            txtvencimentoCheque.Visible = true;
                            lblvencimento.Visible = true;
                            imgPagamento.Enabled = true;
                            BloqueiaFormaCheque();
                            break;
                    }
                }
                else
                {
                    imgPagamento.Enabled = false;
                }
            }

        }
        protected void gridPagamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bdvp._id_pagamento= Convert.ToInt32(gridPagamento.Rows[e.RowIndex].Cells[1].Text);
            int retorno = bdvp.pro_setExcluiItensPagamentos();
            if (retorno > 0)
            {
                getPagamentos();
            }
          
        }

        protected void dropForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegrasPagamento();
        }

        protected void gridPagamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gridPagamento.Rows.Count > 0)
            {
                decimal valortotal = 0;
                foreach (GridViewRow grw in gridPagamento.Rows)
                {
                    decimal valorgrid = Convert.ToDecimal(grw.Cells[4].Text);
                    valortotal += valorgrid;
                    decimal valortotalOperacao = Convert.ToDecimal(txtTotalOperacao.Text);
                    if (valortotal >= valortotalOperacao)
                    {
                        btn_avancar.Visible = true;
                    }
                    else
                    {
                        btn_avancar.Visible = false;
                    }
                }
            }
            else
            {
                btn_avancar.Visible = false;
            }
        }

        protected void btn_avancar_Click(object sender, EventArgs e)
        {
            txtpedido.Text=Session["pedido"].ToString();
        }
        
    }
}