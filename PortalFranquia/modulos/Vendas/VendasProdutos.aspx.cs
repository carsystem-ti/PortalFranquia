using PortalFranquia.dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Vendas
{
    public partial class Produtos : System.Web.UI.Page
    {
        daoVeiculo bdv = new daoVeiculo();
        daoProdutos bdp = new daoProdutos();
        daoPedidoVendaItens bdi = new daoPedidoVendaItens();
        //int tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["pedido"] != null)
                    {
                        BuscaCoresAutomotivas();
                        BuscaFabricante();
                        //BuscaItens();
                        txtpedido.Text = Session["pedido"].ToString();
                        //BuscaItens();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void BuscaCoresAutomotivas()
        {
            DataTable cores = new DataTable();
            cores = bdv.Cores();
            dropCores.DataSource = cores;
            dropCores.DataBind();
            dropCores.Items.Insert(0, "Selecione");
        }
        private void BuscaFabricante()
        {
            DataTable fabricante = new DataTable();
            fabricante = bdv.BuscaFabricante();
            dropFabricante.DataSource = fabricante;
            dropFabricante.DataBind();
            dropFabricante.Items.Insert(0, "Selecione");

        }
        private void InseriTaxaPlus()
        {
            if (dropProdutos.SelectedValue == "3" || dropProdutos.SelectedValue == "4" || dropProdutos.SelectedValue == "5" || dropProdutos.SelectedValue == "7" || dropProdutos.SelectedValue == "8" || dropProdutos.SelectedValue == "9" || dropProdutos.SelectedValue == "12" || dropProdutos.SelectedValue == "13" || dropProdutos.SelectedValue == "14" || dropProdutos.SelectedValue == "16" || dropProdutos.SelectedValue == "18" ||dropProdutos.SelectedValue == "26")
            {
                DataSet ds_VlRepasse = new DataSet();
                daoPedidoVendaItens bdvi = new daoPedidoVendaItens();
                daoPedidoVenda bdv = new daoPedidoVenda();
                daoPedidoVendaVeiculo bdvv = new daoPedidoVendaVeiculo();
                int produto = Convert.ToInt32(dropProdutos.SelectedValue);
                ds_VlRepasse = bdv.ValorRepasse(produto);
                decimal VlAdesao = Convert.ToDecimal(ds_VlRepasse.Tables[0].Rows[0]["vl_repasse"].ToString());
                decimal valorProduto = VlAdesao;
                int pedido = Convert.ToInt32(txtpedido.Text);
                decimal vlDesconto = VlAdesao;
                int id_produto = Convert.ToInt32("25".ToString());
                int item = bdvi.pro_setPedidoVendaItens(pedido, id_produto, valorProduto, vlDesconto);
                int modelo = Convert.ToInt32(dropmodelo.SelectedValue);
                int id_pedido = Convert.ToInt32(txtpedido.Text); ;
                string placa = txtPlaca.Text.ToString().Replace("-", "");
                string cor = dropCores.SelectedItem.Text; ;
                string dsCombustivel = dropComb.SelectedItem.Text;
                string ano = txtAno.Text;
                string renavan = txtRenavam.Text; ;
                string chassi = txtChassi.Text;
                int id_veiculo = bdvv.pro_setPedidoVendaVeiculo(pedido, item, modelo, placa, cor, dsCombustivel, ano, renavan, chassi);
            }
        }
        private void BuscaItens()
        {
            int ped = Convert.ToInt32(txtpedido.Text);
            DataSet dtItens = new DataSet();
            dtItens = bdi.getVendasItens(ped);
            if (dtItens.Tables[0].Rows.Count > 0)
            {
                GridProdutos.DataSource = dtItens;
                GridProdutos.DataBind();
            }
            else
            {
                GridProdutos.DataBind();
            }
        }
        private void GravaItens()
        {
            if (dropFabricante.SelectedValue != "Selecione" && dropmodelo.SelectedValue != "Selecione" && dropCores.SelectedValue != "Selecione" && txtAno.Text != ""
                && txtValorProduto.Text != "" && txtValorTabela.Text != "" && txtValorProduto.Text != "0,00" && txtValorTabela.Text != "0,00")
            {
                int produto = Convert.ToInt32(dropProdutos.SelectedValue);
                
                int nr_itens = 0;
                int id_veiculo = 0;
                daoPedidoVendaItens bdvi = new daoPedidoVendaItens();
                daoPedidoVendaVeiculo bdvv = new daoPedidoVendaVeiculo();
                daoPedidoVendaPagamento bdp = new daoPedidoVendaPagamento();
                daoPedidoVenda bdv = new daoPedidoVenda();
                int pedido = Convert.ToInt32(txtpedido.Text);
                decimal vl_Vendido = Convert.ToDecimal(txtValorProduto.Text);
                decimal vldesconto = Convert.ToDecimal(txtValorTabela.Text);
                DataSet ds_VlRepasse = new DataSet();
                ds_VlRepasse = bdv.ValorRepasse(produto);
                decimal VlAdesao = Convert.ToDecimal(ds_VlRepasse.Tables[0].Rows[0]["vl_repasse"].ToString());
                decimal valorProduto = vl_Vendido - VlAdesao;
                nr_itens = bdvi.pro_setPedidoVendaItens(pedido, produto, valorProduto, vldesconto);
                int item = nr_itens;
                int modelo = Convert.ToInt32(dropmodelo.SelectedValue);
                int id_pedido = Convert.ToInt32(txtpedido.Text);
                string placa = txtPlaca.Text.ToString().Replace("-", "");
                string cor = dropCores.SelectedItem.Text;
                string combustivel = dropComb.SelectedItem.Text;
                string ano = txtAno.Text;
                string renavan = txtRenavam.Text;
                string chassi = txtChassi.Text; ;
                id_veiculo = bdvv.pro_setPedidoVendaVeiculo(id_pedido, item, modelo, placa, cor, combustivel, ano, renavan, chassi);
                if (id_veiculo > 0)
                {
                    //lblmensagem.Visible = true;
                    //lblmensagem.Text = "Dados gravados";
                    Mensagem("Dados gravados,Favor prosseguir");
                    DataSet dtItens = new DataSet();
                    int nr_pedido = Convert.ToInt32(txtpedido.Text);
                    InseriTaxaPlus();
                    dtItens = bdi.getVendasItens(nr_pedido);
                    GridProdutos.DataSource = dtItens;
                    GridProdutos.DataBind();
                }
            }
            else
            {

            }

        }
        private void ValidaPlaca()
        {
            DataSet ds = new DataSet();

            if (txtPlaca.Text != "" && dropFabricante.SelectedValue != "Selecione" && dropCores.SelectedValue != "Selecione" && dropmodelo.SelectedValue != "Selecione" && txtValorTabela.Text != "" && txtValorProduto.Text != "0,00" && dropProdutos.SelectedValue != "Selecione")
            {
                try
                {
                    string ds_placa = txtPlaca.Text.Replace("-", "").ToString();
                    ds = bdv.ValidaPlacaVeiculo(ds_placa.ToString());
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["ds_Placa"].ToString()) == 1)
                    {
                        //lblmensagem.Visible = true;
                        //lblmensagem.Text = "Placa de veículo já consta em nossa base.";
                        Mensagem("Placa de veículo já consta em nossa base.");
                        return;
                    }
                    else
                    {

                        GravaItens();
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
            else
            {
                //lblmensagem.Visible = true;
                //lblmensagem.Text = "Favor preencher todos os dados";
                Mensagem("Favor preencher todos os dados");
            }
        }
        private void CalculaPorcetagem()
        {
            // % de desconto
            decimal porcentagem = Convert.ToDecimal(ConfigurationManager.AppSettings[("porcentagem")].ToString());

            //Valor original
            decimal valor = Convert.ToDecimal(txtValorTabela.Text);
            //Convert.ToDouble(Session["valor"].ToString().Replace(".",",")); // valor original

            //Percentual atual
            decimal percentual = porcentagem / Convert.ToInt32("100"); // 2%

            //Valor calculado
            decimal valor_final = valor + (percentual * valor);

            decimal valor_finalMenor = valor - (percentual * valor);
            //Valor desejado pelo consultor
            decimal valorDesejado = Math.Round(Convert.ToDecimal(txtValorProduto.Text));

            if ((valorDesejado <= valor_final) && (valorDesejado >= valor_finalMenor))
            {
                ValidaPlaca();
            }
            else
            {
                //lblmensagem.Visible = true;
                //lblmensagem.Text = "Valor ultrapassa 5% valor máximo é:" + valor_final.ToString();
                Mensagem("Porcentagem: " + porcentagem + "%" + " valor máximo é: " + Decimal.Round(Convert.ToDecimal(valor_final), 2).ToString() + " valor mínimo: " + Decimal.Round(Convert.ToDecimal(valor_finalMenor), 2).ToString());
            }

        }
        private void VerificaGuincho()
        {
            int produto = Convert.ToInt32(dropProdutos.SelectedValue);
            decimal valor = Convert.ToDecimal(txtValorProduto.Text);
            decimal vl_GuinchoPopular = Convert.ToDecimal(ConfigurationManager.AppSettings[("vlGuinchoCarro")].ToString());
            decimal Vl_GuinchoUtilitario = Convert.ToDecimal(ConfigurationManager.AppSettings[("vlGuinchoUtilitario")].ToString());
            decimal Vl_GuinchoPromocao = Convert.ToDecimal("1,00");
            if ((dropProdutos.SelectedValue == "21" && valor == vl_GuinchoPopular || valor == Vl_GuinchoPromocao) || (dropProdutos.SelectedValue == "23" && valor == Vl_GuinchoUtilitario || valor == Vl_GuinchoPromocao))
            {
                CalculaPorcetagem();
            }
            else
            {
                Mensagem("Valores divergentes, favor corrigi-los.");
            }
        }
        protected void imgAddprodutos_Click(object sender, ImageClickEventArgs e)
        {
           // GravaItens();
            if (dropProdutos.SelectedValue == "21" || dropProdutos.SelectedValue == "23")
            {
                VerificaGuincho();
            }
            else
            {
                CalculaPorcetagem();
            }
        }

        protected void GridProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                btn_avancar.Enabled = true;
                decimal valortotal = 0;
                foreach (GridViewRow grw in GridProdutos.Rows)
                {
                    decimal valorgrid = Convert.ToDecimal(grw.Cells[9].Text);
                    valortotal += valorgrid;
                }
                Session["totalOperacao"] = Decimal.Round(Convert.ToDecimal(valortotal), 2).ToString();
            }
            else
            {
                btn_avancar.Enabled = false;
            }
           
        }

        protected void GridProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            daoPedidoVendaItens bdi = new daoPedidoVendaItens();
            bdi._item = Convert.ToInt32(GridProdutos.Rows[e.RowIndex].Cells[1].Text);
            bdi._item = bdi.pro_setExcluiItens();
            BuscaItens();
        }
        private void BuscaModelo()
        {
            if (dropFabricante.SelectedValue != "Selecione")
            {

                int id_fabricante = Convert.ToInt32(dropFabricante.SelectedValue);
                DataTable modelo = bdv.BuscaModelo(id_fabricante);
                dropmodelo.DataSource = modelo;
                dropmodelo.DataBind();
                dropmodelo.Items.Insert(0, "Selecione");
            }
        }
        protected void dropFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaModelo();
        }
        //private void getProdutoVendas(int _isAprovado,string _nrcep,string _cdCetec,int ano,int modelo)
        //{
        //    int verifica = 0;

        //    DataTable dt = new DataTable();
        //    dt = bdp.ValidaModeloProdutos(modelo);
        //    if (dt.Rows.Count > 0)
        //    {
        //        verifica = 1;
        //    }
        //    if (Session["ns"].ToString() == "0" && Session["boavista"].ToString() == "Reprovado" && verifica == 1)
        //    {
        //        tipo = 1;
        //    }
        //    else if (Session["ns"].ToString() == "1" && Session["boavista"].ToString() == "Reprovado" && verifica == 1)
        //    {
        //        tipo = 2;
        //    }
        //    else if (Session["ns"].ToString() == "0" && Session["boavista"].ToString() == "Aprovado" && verifica == 1)
        //    {
        //        tipo = 3;
        //    }
        //    else if (Session["ns"].ToString() == "1" && Session["boavista"].ToString() == "Aprovado" && verifica == 1)
        //    {
        //        tipo = 4;
        //    }

        //    if (Session["ns"].ToString() == "0" && Session["boavista"].ToString() == "Reprovado" && verifica == 0)
        //    {
        //        tipo = 5;
        //    }
        //    else if (Session["ns"].ToString() == "1" && Session["boavista"].ToString() == "Reprovado" && verifica == 0)
        //    {
        //        tipo = 6;
        //    }
        //    else if (Session["ns"].ToString() == "0" && Session["boavista"].ToString() == "Aprovado" && verifica == 0)
        //    {
        //        tipo = 7;
        //    }
        //    else if (Session["ns"].ToString() == "1" && Session["boavista"].ToString() == "Aprovado" && verifica == 0)
        //    {
        //        tipo = 8;
        //    }

        //    DataTable dtProdutos = new DataTable();
        //    dtProdutos = bdp.pro_getProdutosVendas(tipo, modelo, tipoveiculo);
        //    if (dtProdutos.Rows.Count > 0)
        //    {
        //        dropProdutos.DataSource = dtProdutos;
        //        dropProdutos.DataBind();
        //        dropProdutos.Items.Insert(0, "Selecione");
        //        dadosVeiculo.Visible = true;
        //    }
        //    else
        //    {
        //        //dadosVeiculo.Visible = false;
        //    }
        //}
        protected void dropmodelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropmodelo.SelectedValue != "Selecione" && txtAno.Text != "" && txtAno.Text.Length >= 4)
            {
                DataSet dtCategoria = bdv.BuscaTipoVeiculo(Convert.ToInt32(dropmodelo.SelectedValue));
                if (dtCategoria.Tables[0].Rows.Count > 0)
                {
                    DataTable dtProdutos = new DataTable();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    int isAprovado = Session["boavista"].ToString() == "Aprovado" ? 1 : 0;
                    txtTipoVeiculo.Text = dtCategoria.Tables[0].Rows[0]["ds_categoria"].ToString();
                    int modelo = Convert.ToInt32(dropmodelo.SelectedValue);
                    string tipoveiculo = txtTipoVeiculo.Text;
                    int ano = Convert.ToInt32(txtAno.Text);
                    string cd_cetec = acessoLogin.cdCetec;
                    string nr_cep = Session["cep"].ToString();
                    //getProdutoVendas(isAprovado, nr_cep, cd_cetec, ano, modelo);
                    dtProdutos = bdp.pro_getProdutosVendas(isAprovado, nr_cep, cd_cetec, ano, modelo);
                    if (dtProdutos.Rows.Count > 0)
                    {
                        dropProdutos.DataSource = dtProdutos;
                        dropProdutos.DataBind();
                        dropProdutos.Items.Insert(0, "Selecione");
                        dadosVeiculo.Visible = true;
                    }
                    else
                    {
                        //dadosVeiculo.Visible = false;
                    }    
                    
                    
                    //modelo, tipoveiculo, ano,isAprovado,cd_cetec);
                }
                else
                {
                    txtTipoVeiculo.Text = "";
                }


            }
            else 
            {
                Mensagem("Favor preencher corretamente os dados...");
            }
        }

        protected void dropProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropProdutos.SelectedValue != "Selecione")
            {
                if (dropProdutos.SelectedValue == "22")
                {
                    if (GridProdutos.Rows.Count > 0)
                    {
                        foreach (GridViewRow grw in GridProdutos.Rows)
                        {
                            string placa = grw.Cells[2].Text.ToUpper();
                            string tipo = grw.Cells[10].Text;
                            if (placa == txtPlaca.Text.ToUpper() && tipo == "P")
                            {
                                DataSet dsvlMonitoramento = new DataSet();
                                daoPedidoVenda bdv = new daoPedidoVenda();
                                ///bdv._dsproduto= grw.Cells[3].Text;
                                string ds_produto = grw.Cells[3].Text;
                                dsvlMonitoramento = bdv.ValorHabilitacaoMonitoramento(ds_produto);
                                decimal VlMonitoramento = Convert.ToDecimal(dsvlMonitoramento.Tables[0].Rows[0]["VlMonitoramento"].ToString());
                                txtValorTabela.Text = Decimal.Round(Convert.ToDecimal(VlMonitoramento), 2).ToString();
                            }
                        }
                    }
                }
                else
                {
                    DataSet vlProduto = new DataSet();
                    daoProdutos bdp = new daoProdutos();
                    int id_produto = Convert.ToInt32(dropProdutos.SelectedValue);
                    vlProduto = bdp.pro_getValorProdutoVenda(id_produto);
                    if (vlProduto.Tables[0].Rows.Count > 0)
                    {
                        decimal valor = Convert.ToDecimal(vlProduto.Tables[0].Rows[0]["vl_venda"].ToString());
                        txtValorTabela.Text = Decimal.Round(Convert.ToDecimal(valor), 2).ToString();
                    }
                }
            }
            else
            {
                txtValorTabela.Text = "";
                txtValorProduto.Text = "";
            }
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {

        }
    }
}