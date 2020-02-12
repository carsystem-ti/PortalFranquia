using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PortalFranquia.dao.daoTroca;
using PortalFranquia.dao;
using PortalFranquia.dao.trocas;
using PortalFranquia.componentes;
namespace PortalFranquia.modulos.Troca
{
    public partial class Troca : System.Web.UI.Page
    {
        private DataTable dtp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
            if (!IsPostBack)
            {
              
                getPagamento();
                dtp = new DataTable();
                dtp = CriarDataTablePagamento();
                Session["vPagamentos"] = dtp;
                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;                                
                
            }
            //Utils.ConfiguraPesquisaMasterPage(Master, new Dictionary<string, string>() { { "contrato", "1" }, { "placa", "2" } }, "@tp", "@doc", "cnxFranquia",
            //                        "[Franquia].[pro_getDadosTrocas]", new BuscaCliente.EventoPesquisa(retornoPesquisa), new BuscaCliente.EventoErroPesquisa(retornoErro));
        }
        private void retornoErro(Exception e)
        {
            Mensagem(e.Message);
        }
        public void retornoPesquisa(DataTable dt)
        {

            if (dt.Rows.Count > 0)
            {
                txtNome.Text = dt.Rows[0].Field<string>("ds_nome");
                txtId.Text = dt.Rows[0].Field<string>("idpeca");
                txtContrato.Text = dt.Rows[0].Field<string>("Pedido");
                txtPlaca.Text = dt.Rows[0].Field<string>("ds_placa");
                txtProduto.Text = dt.Rows[0].Field<string>("ds_produto");
                txtStatusContrato.Text = dt.Rows[0].Field<string>("ds_statusCliente");
                txtStatusAtendimento.Text = dt.Rows[0].Field<string>("ds_statusAtendimento");
                txtstatusVenda.Text = dt.Rows[0].Field<string>("ds_statusVenda");
                txtCpf_Cnpj.Text = dt.Rows[0].Field<string>("ds_Cpf_Cnpj");
                txtDocumento.Text = dt.Rows[0].Field<string>("ds_documento");
                txtDataNascimento.Text = dt.Rows[0].Field<string>("dt_nascimento");
                txtDataVenda.Text = dt.Rows[0].Field<string>("dt_venda");
                txtDtConfirmacao.Text = dt.Rows[0].Field<string>("dt_confirmacao");
                txtVendedor.Text = dt.Rows[0].Field<string>("ds_vendedor");
                txtVeiculo.Text = dt.Rows[0].Field<string>("ds_modelo");
                txtFabricante.Text = dt.Rows[0].Field<string>("ds_fabricante");
                txtCategoria.Text = dt.Rows[0].Field<string>("ds_categoria");
                txtAno.Text = dt.Rows[0].Field<string>("ds_ano");
                txtRenavan.Text = dt.Rows[0].Field<string>("ds_renavan");
                txtChassi.Text = dt.Rows[0].Field<string>("ds_chassi");
                txtCombustivel.Text = dt.Rows[0].Field<string>("ds_combustivel");
                txtCor.Text = dt.Rows[0].Field<string>("cor");
                divProduto.Visible = true;
                int id_produto = dt.Rows[0].Field<Int32>("id_produto");
                txtCodigo.Text = id_produto.ToString();
                getProdutos(id_produto);
            }
            else
            {
                Mensagem("Contrato não atende os requisitos..");
                LimpaCampos();
            }
            
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        public DataTable CriarDataTablePagamento()
        {
            DataTable mDataTablePagamento = new DataTable();
            DataColumn mDataColumnPagamento;

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "Codigo";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "Pagamento";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.Int32");
            mDataColumnPagamento.ColumnName = "quantidade";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "valor";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "data";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "titular";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_agencia";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_conta";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_documento";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_cheque";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_banco";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "ccm";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);



            return mDataTablePagamento;

        }
        private void incluirNoDataTablePagamento(string incremento, string pagamento, string valor, string data, string quantidade, string titular, string nr_agencia, string nr_conta, string nr_documento, string nr_cheque, string nr_banco, string ccm, DataTable mDataTablePagamento)
        {
            DataRow linha;
            linha = mDataTablePagamento.NewRow();
            linha["Codigo"] = incremento;
            linha["Pagamento"] = pagamento;
            linha["quantidade"] = quantidade;
            linha["valor"] = valor;
            linha["data"] = data;
            linha["titular"] = titular;
            linha["nr_agencia"] = nr_agencia;
            linha["nr_conta"] = nr_conta;
            linha["nr_documento"] = nr_documento;
            linha["nr_cheque"] = nr_cheque;
            linha["nr_banco"] = nr_banco;
            linha["ccm"] = ccm;

            mDataTablePagamento.Rows.Add(linha);


        }
        private void ExcluirLinhaPagamento(string id)
        {
            if (gridPagamento.Rows.Count > 0)
            {
                for (int i = 1; i <= 1; i++)
                {
                    foreach (DataRow linha in ((DataTable)Session["vPagamentos"]).Rows)
                    {
                        if (linha[0].ToString() == id)
                        {
                            linha.Delete();
                            this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                            this.gridPagamento.DataBind();
                            return;
                        }
                    }
                }
            }
            else
            {
                //dadosprodutos.Visible = false;
            }
        }
        private void InseriPagamentos()
        {
            int tipo = Convert.ToInt32(dropForma.SelectedValue);
                switch (tipo)
                {
                    case 1:
                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtTitular.Text, "", "", txtDocumento.Text, "", "", "", (DataTable)Session["vPagamentos"]);
                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView; 
                        this.gridPagamento.DataBind();
                        break;
                    case 2:
                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.Date.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                        this.gridPagamento.DataBind();
                        break;
                    case 3:
                        int quantidade = Convert.ToInt32(txtQtdParcela.Text);
                        for (int i = 0; i < quantidade; i++)
                        {
                            if (chkLeitora.Checked == false)
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
                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text,txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                                this.gridPagamento.DataBind();
                                txtLeitura.Text = "";
                                txtLeitura.Focus();
                            }
                            else
                            {
                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                                this.gridPagamento.DataBind();
                                txtLeitura.Text = "";
                                txtLeitura.Focus();
                            }

                        }
                        break;

                    case 4:
                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.Date.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                        this.gridPagamento.DataBind();
                        break;
                    default:

                        //lblPagamento.Visible = true;
                        //lblPagamento.Text = "Selecione uma Forma de Pagamento";
                        break;
                }



        }
      
        private void getPagamento()
        {
            daoPagamento bdp = new daoPagamento();
            DataSet dsPag = bdp.getFormasPagamentos();
            dropForma.DataSource = dsPag;
            dropForma.DataBind();
            dropForma.Items.Insert(0, "Selecione");
        }
        private void getProdutos(int produto)
        {
            daoProdutoTroca bdt = new daoProdutoTroca();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

            DataTable dsPag = bdt.pro_getProdutosTrocas(produto,acessoLogin.Codigo);
            if (dsPag.Rows.Count > 0)
            {
                dropProdutosTrocas.DataSource = dsPag;
                dropProdutosTrocas.DataBind();
                dropProdutosTrocas.Items.Insert(0, "Selecione");
                divProduto.Visible = true;
            }
            else
            {
                BloqueiaDados();
                divProduto.Visible = false;
                Mensagem("Não há peças disponível no momento...");
                LimpaCampos();
            }


        }
        private void BuscaDados()
        {
            DataSet ds = new DataSet();
            daoTrocas bdt = new daoTrocas();
            if (dropSelecao.SelectedValue != "Selecione")
            {
                int tipo =Convert.ToInt32(dropSelecao.SelectedValue);

                switch (tipo)
                {
                    case 1:
                        ds = bdt.pro_getDados(1, txtContratoPlaca.Text);
                        break;
                    case 2:
                        ds = bdt.pro_getDados(2, txtContratoPlaca.Text);
                        break;
                }
            }
            else
            {
                
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtNome.Text = ds.Tables[0].Rows[0]["ds_nome"].ToString();
                txtId.Text = ds.Tables[0].Rows[0]["idpeca"].ToString();
                txtContrato.Text = ds.Tables[0].Rows[0]["Pedido"].ToString();
                txtPlaca.Text = ds.Tables[0].Rows[0]["ds_placa"].ToString();
                txtProduto.Text = ds.Tables[0].Rows[0]["ds_produto"].ToString();
                txtStatusContrato.Text = ds.Tables[0].Rows[0]["ds_statusCliente"].ToString();
                txtStatusAtendimento.Text = ds.Tables[0].Rows[0]["ds_statusAtendimento"].ToString();
                txtstatusVenda.Text = ds.Tables[0].Rows[0]["ds_statusVenda"].ToString();
                txtCpf_Cnpj.Text = ds.Tables[0].Rows[0]["ds_Cpf_Cnpj"].ToString();
                txtDocumento.Text = ds.Tables[0].Rows[0]["ds_documento"].ToString();
                txtDataNascimento.Text = ds.Tables[0].Rows[0]["dt_nascimento"].ToString();
                txtDataVenda.Text = ds.Tables[0].Rows[0]["dt_venda"].ToString();
                txtDtConfirmacao.Text = ds.Tables[0].Rows[0]["dt_confirmacao"].ToString();
                txtVendedor.Text = ds.Tables[0].Rows[0]["ds_vendedor"].ToString();
                txtVeiculo.Text = ds.Tables[0].Rows[0]["ds_modelo"].ToString();
                txtFabricante.Text = ds.Tables[0].Rows[0]["ds_fabricante"].ToString();
                txtCategoria.Text = ds.Tables[0].Rows[0]["ds_categoria"].ToString();
                txtAno.Text = ds.Tables[0].Rows[0]["ds_ano"].ToString();
                txtRenavan.Text = ds.Tables[0].Rows[0]["ds_renavan"].ToString();
                txtChassi.Text = ds.Tables[0].Rows[0]["ds_chassi"].ToString();
                txtCombustivel.Text = ds.Tables[0].Rows[0]["ds_combustivel"].ToString();
                txtCor.Text = ds.Tables[0].Rows[0]["Cor"].ToString();
                divProduto.Visible = true;
                txtCodigo.Text = ds.Tables[0].Rows[0]["id_produto"].ToString();
                int _produto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_produto"].ToString());
                getProdutos(_produto);
            }
            else
            {
                Mensagem("Contrato não atende os requisitos..");
                LimpaCampos();
            }

        }
        private void BloqueiaDados()
        {
            dropProdutosTrocas.Enabled = false;
            txtValorCobrado.Enabled = false;
            imgEditCliente.Visible = true;
            imgAvancarCliente.Visible = false;
            
        }
        private void LiberaDados()
        {
            dropProdutosTrocas.Enabled = true;
            txtValorCobrado.Enabled = true;
            dropProdutosTrocas.Enabled = false;
            imgEditCliente.Visible = false;
            imgAvancarCliente.Visible = true;

        }
        protected void imgAvancarCliente_Click(object sender, ImageClickEventArgs e)
        {
            divpagamento.Visible = true;
            txtValorTotalOperacao.Text = txtValorTroca.Text;
            BloqueiaDados();
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
            lblnrcheque.Visible = false;
            txtNrCheque.Visible = false;
            txtNrCheque.Text = "";
            lblvencimento.Visible = false;
            txtvencimentoCheque.Visible = false;
            txtvencimentoCheque.Text = "";
            lblAgencia.Visible = false;
            txtAgencia.Visible = false;
            txtAgencia.Text = "";
            lblcheques.Visible = false;
            txtCheques.Visible = false;
        }
        private void LiberaFormaCheque()
        {
            lblbanco.Visible = true;
            txtBanco.Visible = true;
            lblconta.Visible = true;
            txtConta.Visible = true;
            txtDocumento.Visible = true;
            lblnrcheque.Visible = true;
            txtNrCheque.Visible = true;
            lblvencimento.Visible = true;
            txtvencimentoCheque.Visible = true;
            lblAgencia.Visible = true;
            txtAgencia.Visible = true;
            txtTitular.Visible = true;
            lbltitular.Visible = true;
            lbldoc.Visible = true;
            txtDocumento.Visible = true;
            txtLeitura.Visible = true;
            lblLeitura.Visible = true;
            txtCpfCnpjCheque.Visible = true;
            lblcheques.Visible = true;
            txtCheques.Visible = true;
            chkLeitora.Visible = true;

        }
        private void RegrasPagamento()
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
                        txtTitular.Text = "Teste";
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
                // txtValor.Text = "";
                // txtQtdParcela.Text = "";

            }

        }
        protected void imgAddprodutos_Click(object sender, ImageClickEventArgs e)
        {

        }
        private void BuscaProdutoTroca()
        {
            if (dropProdutosTrocas.SelectedValue != "Selecione")
            {
                daoProdutoTroca bdt = new daoProdutoTroca();
                DataSet ds_valor = new DataSet();
                int _idProdutoTroca = Convert.ToInt32(dropProdutosTrocas.SelectedValue);
                int id_produto = Convert.ToInt32(txtCodigo.Text);
                ds_valor = bdt.pro_getValorTroca(_idProdutoTroca, id_produto);
                if (ds_valor.Tables[0].Rows.Count > 0)
                {
                    decimal vl_valor = Convert.ToDecimal(ds_valor.Tables[0].Rows[0]["vl_valor"].ToString());
                    txtValorTroca.Text = Decimal.Round(Convert.ToDecimal(vl_valor), 2).ToString();

                }
            }
        }
        protected void dropProdutosTrocas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaProdutoTroca();
        }

        protected void dropForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegrasPagamento();
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

        protected void imgPagamento_Click(object sender, ImageClickEventArgs e)
        {
            InseriPagamentos();
        }

        protected void txtLeitura_TextChanged(object sender, EventArgs e)
        {
            if (txtLeitura.Text != "" && txtTitular.Text != "" && txtCpfCnpjCheque.Text != "" && txtQtdParcela.Text != "" && txtvencimentoCheque.Text != "")
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
                ///GravaPagamento(Convert.ToInt32(txtpedido.Text));
                txtLeitura.Focus();
            }
            else
            {
                //lblPagamento.Visible = true;
                //lblPagamento.Text="FAVOR PREENCHER TODOS OS DADOS..";
            }
        }

        protected void gridPagamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gridPagamento.Rows.Count > 0)
            {
                decimal valortotal = 0;
                foreach (GridViewRow grw in gridPagamento.Rows)
                {
                    decimal valorgrid = Convert.ToDecimal(grw.Cells[3].Text);
                    valortotal += valorgrid;
                    decimal valortotalOperacao = Convert.ToDecimal(txtValorTotalOperacao.Text);
                    if (valortotal >= valortotalOperacao)
                    {
                        finalizar.Visible = true;
                    }
                    else
                    {
                        finalizar.Visible = false;
                    }
                }
            }
            else
            {
                finalizar.Visible = false;
            }
        }
        private int GravaPagamento(int troca)
        {
            int nr_pagamento = 0;
            if (dropForma.SelectedValue != "Selecione" && txtValor.Text != "0,00" && txtValor.Text != "" && gridPagamento.Rows.Count > 0)
            {
                foreach (GridViewRow gwp in gridPagamento.Rows)
                {
                    daoTrocas bdtp = new daoTrocas();
                    int pagamento = Convert.ToInt32(dropForma.SelectedValue);
                    int quantidade = Convert.ToInt32(txtQtdParcela.Text);
                    bdtp._dsDoc = txtCpf_Cnpj.Text;
                    decimal valorCalculado = Convert.ToDecimal(txtValor.Text) / quantidade;
                    switch (pagamento)
                    {
                        case 1:
                            bdtp._idtroca = troca;
                            bdtp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdtp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdtp._dataVenc = DateTime.Now.Date;
                            bdtp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            bdtp._dsDoc = txtCpf_Cnpj.Text;
                            bdtp._dsTitular = txtNome.Text;
                            nr_pagamento=bdtp.pro_setTrocaPagamento();

                            break;
                        case 2:
                            bdtp._idtroca = troca;
                            bdtp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdtp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdtp._dataVenc = DateTime.Now.Date;
                            bdtp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            if (txtTitular.Text != "")
                                bdtp._dsTitular = txtTitular.Text;
                            else
                                bdtp._dsTitular = txtNome.Text;
                            nr_pagamento = bdtp.pro_setTrocaPagamento();

                            break;
                        case 3:
                            bdtp._idtroca = troca;
                            bdtp._idTipo = Convert.ToInt32(gwp.Cells[0].Text);
                            bdtp._vlPagamento = Convert.ToDecimal(gwp.Cells[3].Text);
                            bdtp._dataVenc = Convert.ToDateTime(gwp.Cells[4].Text);
                            bdtp._pcParcela = Convert.ToInt32(gwp.Cells[2].Text);
                            bdtp._dsDoc = txtCpf_Cnpj.Text;
                            if (txtTitular.Text != "")
                                bdtp._dsTitular = gwp.Cells[5].Text;
                            else
                                bdtp._dsTitular = gwp.Cells[5].Text;
                            bdtp._nrAgencia = gwp.Cells[6].Text;
                            bdtp._nrConta = gwp.Cells[7].Text;
                            bdtp._ccm = Server.HtmlDecode(gwp.Cells[11].Text);
                            bdtp._nrBanco = gwp.Cells[10].Text;
                            bdtp._nr_cheque =gwp.Cells[9].Text;
                            nr_pagamento = bdtp.pro_setTrocaPagamento();
                            break;
                        case 4:
                            bdtp._idtroca = troca;
                            bdtp._idTipo = Convert.ToInt32(dropForma.SelectedValue);
                            bdtp._vlPagamento = Convert.ToDecimal(txtValor.Text);
                            bdtp._dataVenc = DateTime.Now.Date;
                            bdtp._pcParcela = Convert.ToInt32(txtQtdParcela.Text);
                            if (txtTitular.Text != "")
                                bdtp._dsTitular = txtTitular.Text;
                            else
                                bdtp._dsTitular = txtNome.Text;
                            nr_pagamento = bdtp.pro_setTrocaPagamento();
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
            return nr_pagamento;
        }
        private void LimpaCampos()
        {
        txtNome.Text = "";
        txtContrato.Text = "";
        txtPlaca.Text = "";
        txtId.Text = "";
        txtContrato.Text = "";
        txtProduto.Text = "";
        txtStatusContrato.Text="";
        txtStatusAtendimento.Text="";
        txtstatusVenda.Text="";
        txtCpf_Cnpj.Text="";
        txtDocumento.Text="";
        txtDataNascimento.Text="";
        txtDataVenda.Text="";
        txtDtConfirmacao.Text="";
        txtVendedor.Text="";
        txtVeiculo.Text="";
        txtFabricante.Text="";
        txtCategoria.Text="";
        txtAno.Text="";
        txtRenavan.Text="";
        txtChassi.Text="";
        txtCombustivel.Text="";
        txtCor.Text = "";
        divProduto.Visible = false;
        divpagamento.Visible = false;
        finalizar.Visible = false;
   }
        private void GravaTroca()
        {
            if (txtContrato.Text != "" && txtProduto.Text != "" && txtValorTroca.Text != "0,00")
            {
                
                int nr_troca = 0;
                daoTrocas bdt = new daoTrocas();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                string contrato = txtContrato.Text;
                int id_franquia = acessoLogin.idFranquia;
                string ds_produtoAnterior = txtProduto.Text.Substring(0, 6);
                string vendedor = acessoLogin.Nome;
                nr_troca = bdt.pro_setTroca(contrato, id_franquia, ds_produtoAnterior, vendedor);
                if (nr_troca > 0)
                {
                    int nr_itens = 0;
                    int id_novoProduto = Convert.ToInt32(dropProdutosTrocas.SelectedValue);
                    decimal vl_troca = Convert.ToDecimal(txtValorTroca.Text);
                    decimal vl_cobrado = Convert.ToDecimal(txtValorCobrado.Text);
                    nr_itens = bdt.pro_setTrocaItens(nr_troca, id_novoProduto, vl_troca, vl_cobrado);
                    if (nr_itens > 0)
                    {
                        int nr_pagamento = GravaPagamento(nr_troca);
                        if (nr_pagamento > 0)
                        {
                            string produto = dropProdutosTrocas.SelectedItem.Text;
                            string ds_Usuario = acessoLogin.Nome;
                            int alterado = bdt.pro_setAtualizaClientes(contrato, produto, ds_Usuario);
                            if (alterado > 0)
                            {
                                Mensagem("Troca gerada com sucesso: " + nr_troca.ToString());
                                btnFinalizar.Text = "Pedido gerado N.: " + nr_troca.ToString();
                                btnFinalizar.Enabled = false;
                                btnCancelar.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                Mensagem("Favor preencher todos os dados");
            }
        }
        protected void gridPagamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridPagamento.Rows[e.RowIndex].Cells[0].Text;
            ExcluirLinhaPagamento(id);
        }

        protected void imgEditCliente_Click(object sender, ImageClickEventArgs e)
        {
            LiberaDados();
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            GravaTroca();
        }

        protected void imgBusca_Click(object sender, ImageClickEventArgs e)
        {
            BuscaDados();
        }
    }
}