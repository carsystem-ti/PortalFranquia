//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using PortalFranquia.dao;

//namespace PortalFranquia
//{
//    public partial class WebVendas : System.Web.UI.Page
//    {
//        daoProdutos bdp = new daoProdutos();
//        daoVeiculo bdv = new daoVeiculo();
//        daoRepasse bdr = new daoRepasse();
//        daoPagamento bdpg = new daoPagamento();
//        daoPedidoVendaPagamento bdvp = new daoPedidoVendaPagamento();
//        daoPedido bdpv = new daoPedido();
//        int tipo;
//        private DataTable dtb = null;
//        private DataTable dtp = null;

//        protected void Page_Load(object sender, EventArgs e)
//        {


//            Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
//            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
//            if (!IsPostBack)
//            {
//                //Produtos
//                dtb = new DataTable();
//                dtb = CriarDataTable();
//                Session["vProdutos"] = dtb;
//                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;

//                //Pagamentos
//                dtp = new DataTable();
//                dtp = CriarDataTablePagamento();
//                Session["vPagamentos"] = dtp;
//                this.GridProdutos.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;

//                //BuscaFabricante();
//            }
//        }
//        protected void imgPagamento_Click(object sender, ImageClickEventArgs e)
//        {
//            InseriPagamentos();
//        }
//        private void BuscaProfisao()
//        {
//            daoPedidoVenda vendas = new daoPedidoVenda();
//            DataTable dt = new DataTable();
//            dt = vendas.getProfisao();
//            if (dt.Rows.Count > 0)
//            {
//                dropProfisao.DataSource = dt;
//                dropProfisao.DataBind();
//                dropProfisao.Items.Insert(0, "Selecione");
//            }

//        }
//        private void ExcluirLinhaPagamento(string id)
//        {
//            if (gridPagamento.Rows.Count > 0)
//            {
//                for (int i = 1; i <= 1; i++)
//                {
//                    foreach (DataRow linha in ((DataTable)Session["vPagamentos"]).Rows)
//                    {
//                        if (linha[0].ToString() == id)
//                        {
//                            linha.Delete();
//                            this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                            this.gridPagamento.DataBind();
//                            return;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                //dadosprodutos.Visible = false;
//            }
//        }
//        protected void gridPagamento_RowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            if (gridPagamento.Rows.Count > 0)
//            {
//                finalizar.Visible = true;
//            }
//            //{
//            //    double _valortoal = 0;
//            //    foreach (GridViewRow rw in gridPagamento.Rows)
//            //    {
//            //        if (rw.RowType != DataControlRowType.Header && rw.RowType != DataControlRowType.Footer)
//            //        {
//            //            if (rw.Cells[3].Text != null && rw.Cells[3].Text != string.Empty)
//            //            {
//            //                double valornegociacao = Convert.ToDouble(txtTotalVenda.Text);
//            //                _valortoal += Convert.ToDouble(rw.Cells[3].Text);
//            //                if (_valortoal == valornegociacao)
//            //                {
//            //                    finalizar.Visible = true;
//            //                }
//            //                else
//            //                {
//            //                    finalizar.Visible = false;
//            //                }
//            //            }
//            //        }

//            //    }
//            //}

//        }
//        protected void gridPagamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            string id = gridPagamento.Rows[e.RowIndex].Cells[0].Text;
//            ExcluirLinhaPagamento(id);
//        }
//        public DataTable CriarDataTablePagamento()
//        {
//            DataTable mDataTablePagamento = new DataTable();
//            DataColumn mDataColumnPagamento;

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "Codigo";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "Pagamento";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.Int32");
//            mDataColumnPagamento.ColumnName = "quantidade";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "valor";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "data";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "titular";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "nr_agencia";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "nr_conta";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "nr_documento";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "nr_cheque";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "nr_banco";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

//            mDataColumnPagamento = new DataColumn();
//            mDataColumnPagamento.DataType = Type.GetType("System.String");
//            mDataColumnPagamento.ColumnName = "ccm";
//            mDataTablePagamento.Columns.Add(mDataColumnPagamento);



//            return mDataTablePagamento;

//        }
//        public DataTable CriarDataTable()
//        {
//            DataTable mDataTable = new DataTable();
//            DataColumn mDataColumn;

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "Codigo";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "Produto";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "placa";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "modelo";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "cor";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "chassi";
//            mDataTable.Columns.Add(mDataColumn);


//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "renavan";
//            mDataTable.Columns.Add(mDataColumn);


//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "valor";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "id_modelo";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "tipo";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "ano";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "comb";
//            mDataTable.Columns.Add(mDataColumn);

//            mDataColumn = new DataColumn();
//            mDataColumn.DataType = Type.GetType("System.String");
//            mDataColumn.ColumnName = "tipoProduto";
//            mDataTable.Columns.Add(mDataColumn);


//            return mDataTable;

//        }
//        protected void Wizard1_PreRender(object sender, EventArgs e)
//        {
//            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
//            SideBarList.DataSource = Wizard1.WizardSteps;
//            SideBarList.DataBind();

//        }

//        protected string GetClassForWizardStep(object wizardStep)
//        {
//            WizardStep step = wizardStep as WizardStep;

//            if (step == null)
//            {
//                return "";
//            }
//            int stepIndex = Wizard1.WizardSteps.IndexOf(step);

//            if (stepIndex < Wizard1.ActiveStepIndex)
//            {
//                return "prevStep";
//            }
//            else if (stepIndex > Wizard1.ActiveStepIndex)
//            {
//                return "nextStep";
//            }
//            else
//            {
//                return "currentStep";
//            }
//        }



//        protected void btnPesquisar_Click(object sender, EventArgs e)
//        {
//            if (txtCpf.Text != "")
//            {
//                bool Valida = false;
//                Valida = ValidaCpf(txtCpf.Text);
//                switch (Valida)
//                {
//                    case true:
//                        DataSet dsValida = new DataSet();
//                        daoPedido bdv = new daoPedido();
//                        bdv._nrDocumento = txtCpf.Text;
//                        dsValida = bdv.ValidaGeracaoPedidos();
//                        if (dsValida.Tables[0].Rows.Count > 0)
//                        {
//                            lblmensagem.Visible = true;
//                            lblmensagem.Text = ("Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString());
//                        }
//                        else
//                        {
//                            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "").ToString();
//                            Consulta(cpf);
//                        }
//                        break;
//                    default:
//                        lblmensagem.Visible = true;
//                        lblmensagem.Text = "CPF INVÁLIDO";
//                        filtroAprovacao.Visible = false;
//                        break;
//                }
//            }
//            else
//            {
//                lblmensagem.Visible = true;
//                lblmensagem.Text = "Selecione todas as informações";
//            }
//        }
//        private void Consulta(string nr_documento)
//        {
//            double valor = Convert.ToDouble("50.00");
//            string retorno;
//            CarSystem.Banco.BoaVista.BoaVista boa = new CarSystem.Banco.BoaVista.BoaVista("usr_web", "premium", "principal", CarSystem.Tipos.Servidores.Fury);

//            boa.isProducao = false;

//            CarSystem.Banco.BoaVista.BoaVista.Consulta iConsulta = boa.efetuaConsulta(nr_documento, valor);

//            lblmensagem.Text = (iConsulta.codigoConsulta.ToString());
//            lblmensagem.Text = (iConsulta.dataConsulta.ToString());

//            if (nr_documento.Length == 14)
//                retorno = (CarSystem.Utilidades.Formatar.formataCNPJ(iConsulta.documento.ToString()));
//            else
//                retorno = (CarSystem.Utilidades.Formatar.formataCPF(iConsulta.documento.ToString()));

//            retorno = (iConsulta.statusConsulta.ToString());



//            switch (retorno)
//            {
//                case "Aprovado":
//                    filtroAprovacao.Visible = true;
//                    rdbAprovado.Visible = true;
//                    rdbReprovado.Visible = false;
//                    rdbanalise.Visible = false;
//                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
//                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
//                    txtResultado.Text = iConsulta.statusConsulta.ToString();
//                    break;
//                case "Reprovado":
//                    filtroAprovacao.Visible = true;
//                    rdbReprovado.Visible = true;
//                    rdbAprovado.Visible = false;
//                    rdbanalise.Visible = false;
//                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
//                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
//                    txtResultado.Text = iConsulta.statusConsulta.ToString();
//                    break;
//                default:
//                    filtroAprovacao.Visible = false;
//                    break;
//            }

//        }
//        public bool ValidaCpf(string cpf)
//        {
//            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
//            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
//            string tempCpf;
//            string digito;
//            int soma;
//            int resto;

//            cpf = cpf.Trim();
//            cpf = cpf.Replace(".", "").Replace("-", "");

//            if (cpf.Length != 11)
//                return false;

//            tempCpf = cpf.Substring(0, 9);
//            soma = 0;
//            for (int i = 0; i < 9; i++)
//                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

//            resto = soma % 11;
//            if (resto < 2)
//                resto = 0;
//            else
//                resto = 11 - resto;

//            digito = resto.ToString();

//            tempCpf = tempCpf + digito;

//            soma = 0;
//            for (int i = 0; i < 10; i++)
//                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

//            resto = soma % 11;
//            if (resto < 2)
//                resto = 0;
//            else
//                resto = 11 - resto;

//            digito = digito + resto.ToString();

//            return cpf.EndsWith(digito);

//        }

//        protected void btnCnpj_Click(object sender, EventArgs e)
//        {
//            bool Cnpj = false;
//            Cnpj = ValidaCnpj(txtCnpj.Text.Replace(",", "."));
//            switch (Cnpj)
//            {
//                case true:
//                    DataSet dsValida = new DataSet();
//                    daoPedido bdv = new daoPedido();
//                    bdv._nrDocumento = txtCnpj.Text;
//                    dsValida = bdv.ValidaGeracaoPedidos();
//                    if (dsValida.Tables[0].Rows.Count > 0)
//                    {
//                        lblmensagem.Visible = true;
//                        lblmensagem.Text = ("Existe um contrato vinculado ao CPF: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString());
//                    }
//                    else
//                    {
//                        Consulta(txtCnpj.Text.Replace(".", "").Replace("-", "").ToString().Replace("/", "").Replace(",", ""));
//                    }
//                    break;
//                default:
//                    lblmensagem.Visible = true;
//                    lblmensagem.Text = "CNPJ INVÁLIDO";
//                    filtroAprovacao.Visible = false;
//                    break;
//            }
//        }
//        public bool ValidaCnpj(string cnpj)
//        {
//            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
//            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
//            int soma;
//            int resto;
//            string digito;
//            string tempCnpj;

//            cnpj = cnpj.Trim();
//            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

//            if (cnpj.Length != 14)
//                return false;

//            tempCnpj = cnpj.Substring(0, 12);

//            soma = 0;
//            for (int i = 0; i < 12; i++)
//                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

//            resto = (soma % 11);
//            if (resto < 2)
//                resto = 0;
//            else
//                resto = 11 - resto;

//            digito = resto.ToString();

//            tempCnpj = tempCnpj + digito;
//            soma = 0;
//            for (int i = 0; i < 13; i++)
//                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

//            resto = (soma % 11);
//            if (resto < 2)
//                resto = 0;
//            else
//                resto = 11 - resto;

//            digito = digito + resto.ToString();

//            return cnpj.EndsWith(digito);
//        }
//        protected void rdbTpPessoa_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
//            switch (tipo)
//            {
//                case 0:
//                    ConsultaCpf.Visible = true;
//                    ConsultaCnpj.Visible = false;
//                    txtCnpj.Text = "";
//                    LimpaCampos();
//                    break;
//                case 1:
//                    ConsultaCnpj.Visible = true;
//                    ConsultaCpf.Visible = false;
//                    txtCpf.Text = "";
//                    LimpaCampos();
//                    break;
//            }
//        }
//        private void LimpaCampos()
//        {
//            txtResultado.Text = "";
//            txtCodigoConsulta.Text = "";
//            txtData.Text = "";
//            filtroAprovacao.Visible = false;
//            dadoscliente.Visible = false;
//            dadosclienteComplementares.Visible = false;
//            //dadosprodutos.Visible = false;
//            // dadosresidencial.Visible = false;
//            //dadosVeiculo.Visible = false;
//            rdbAprovado.Checked = false;
//            rdbReprovado.Checked = false;
//            rdbanalise.Checked = false;
//        }
//        private void BloqueiaCampos()
//        {
//            rdbTpPessoa.Enabled = false;
//            txtCnpj.Enabled = false;
//            txtCpf.Enabled = false;

//        }
//        protected void rdbAprovado_CheckedChanged(object sender, EventArgs e)
//        {
//            dadoscliente.Visible = true;
//            dadosclienteComplementares.Visible = true;
//            BloqueiaCampos();
//            BuscaProfisao();
//            BuscaMidias();
//        }
//        private void BuscaMidias()
//        {
//            DataSet dsMIDIAS = new DataSet();
//            daoPedidoVenda bdm = new daoPedidoVenda();
//            dsMIDIAS = bdm.Midias();
//            dropMidia.DataSource = dsMIDIAS;
//            dropMidia.DataBind();
//            dropMidia.Items.Insert(0, "Selecione");
//        }
//        private void BloqueiaDadosCliente()
//        {
//            txtNome.Enabled = false;
//            TxtResidencial.Enabled = false;
//            txtCelular.Enabled = false;
//            txtComercial.Enabled = false;
//            txtEmail.Enabled = false;
//            imgAvancarCliente.Visible = false;
//            imgEditCliente.Visible = true;
//        }
//        protected void imgAvancarCliente_Click(object sender, ImageClickEventArgs e)
//        {
//            if (txtComercial.Text.Length >= 10 && TxtResidencial.Text.Length >= 10 && txtCelular.Text.Length >= 11 && txtCodigoConsulta.Text != "" && txtData.Text != "" && txtNome.Text != "" && TxtResidencial.Text != "" && txtCelular.Text != "" && txtEmail.Text != "" && dropMidia.SelectedValue != "Selecione")
//            {
//                dadosresidencial.Visible = true;
//                BloqueiaDadosCliente();
//            }
//            else
//            {
//                lblmensagem.Visible = true;
//                lblmensagem.Text = "FAVOR PREENCHER TODOS OS CAMPOS..";
//            }
//        }
//        private void LiberaDadosCliente()
//        {

//            txtNome.Enabled = false;
//            TxtResidencial.Enabled = false;
//            txtCelular.Enabled = false;
//            txtComercial.Enabled = false;
//            txtEmail.Enabled = false;
//            imgAvancarCliente.Visible = true;
//            imgEditCliente.Visible = false;
//        }
//        protected void imgEditCliente_Click(object sender, ImageClickEventArgs e)
//        {
//            LiberaDadosCliente();
//        }
//        //private void Mensagem(string message)
//        //{
//        //    //string message = "Número do Pedido gerador com sucesso";
//        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
//        //}
//        private void BuscaCep()
//        {
//            if (txtCep.Text != "")
//            {
//                DataSet ds_cep = new DataSet();
//                string nr_cep = txtCep.Text;
//                ds_cep = bdp.pro_getCep(nr_cep);
//                if (ds_cep.Tables[0].Rows.Count > 0)
//                {
//                    txtEndereco.Text = ds_cep.Tables[0].Rows[0]["Rua"].ToString();
//                    txtBairro.Text = ds_cep.Tables[0].Rows[0]["Bairro"].ToString();
//                    txtCidade.Text = ds_cep.Tables[0].Rows[0]["Cidade"].ToString();
//                    txtUf.Text = ds_cep.Tables[0].Rows[0]["Estado"].ToString();
//                    txtnr.Text = "";
//                    txtComplemento.Text = "";
//                    imgEndereco.Visible = true;
//                    DataSet dsCep = new DataSet();
//                    ds_cep = bdr.ValidaTecnologia(nr_cep, "NS");
//                    if (ds_cep.Tables[0].Rows.Count > 0)
//                    {
//                        string ds_tecnologia = ds_cep.Tables[0].Rows[0]["Tec"].ToString();
//                        if (ds_tecnologia == "nOK")
//                        {
//                            imgEndereco.Visible = false;
//                            Session["ns"] = "0";
//                        }
//                        else
//                        {
//                            imgEndereco.Visible = true;
//                            Session["ns"] = "1";
//                        }
//                    }
//                    ds_cep = bdr.ValidaTecnologia(nr_cep, "GSM");
//                    {
//                        string ds_tecnologia = ds_cep.Tables[0].Rows[0]["Tec"].ToString();
//                        if (ds_tecnologia == "nOK")
//                        {
//                            imgEndereco.Visible = false;
//                            Session["gsm"] = "0";
//                        }
//                        else
//                        {
//                            imgEndereco.Visible = true;
//                            Session["gsm"] = "1";
//                        }
//                    }

//                }
//                else
//                {
//                    lblmensagem.Visible = true;
//                    lblmensagem.Text = "CEP NÃO ENCONTRADO";
//                    txtEndereco.Text = "";
//                    txtBairro.Text = "";
//                    txtCidade.Text = "";
//                    txtUf.Text = "";
//                    txtnr.Text = "";
//                    imgEndereco.Visible = false;
//                }
//            }
//        }
//        protected void imgCep_Click(object sender, ImageClickEventArgs e)
//        {
//            BuscaCep();
//        }
//        protected void dropProdutos_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (dropProdutos.SelectedValue != "Selecione")
//            {
//                if (dropProdutos.SelectedValue == "22")
//                {
//                    if (GridProdutos.Rows.Count > 0)
//                    {
//                        foreach (GridViewRow grw in GridProdutos.Rows)
//                        {
//                            string placa = grw.Cells[1].Text.ToUpper();
//                            string tipo = grw.Cells[12].Text;
//                            if (placa == txtPlaca.Text.ToUpper() && tipo == "P")
//                            {
//                                DataSet dsvlMonitoramento = new DataSet();
//                                daoPedidoVenda bdv = new daoPedidoVenda();
//                                //bdv._id_Produto = Convert.ToInt32(grw.Cells[0].Text);
//                                string produto = grw.Cells[0].Text;
//                                dsvlMonitoramento = bdv.ValorHabilitacaoMonitoramento(produto);
//                                decimal VlMonitoramento = Convert.ToDecimal(dsvlMonitoramento.Tables[0].Rows[0]["VlMonitoramento"].ToString());
//                                txtValorTabela.Text = VlMonitoramento.ToString();
//                            }
//                        }
//                    }
//                }
//                else
//                {


//                    DataSet vlProduto = new DataSet();
//                    daoProdutos bdp = new daoProdutos();
//                    int id_produto = Convert.ToInt32(dropProdutos.SelectedValue);
//                    vlProduto = bdp.pro_getValorProdutoVenda(id_produto);
//                    if (vlProduto.Tables[0].Rows.Count > 0)
//                    {
//                        decimal valor = Convert.ToDecimal(vlProduto.Tables[0].Rows[0]["vl_venda"].ToString());
//                        txtValorTabela.Text = valor.ToString();
//                        //string.Format("{0:0.00}", valor);
//                        //valor.ToString("N2").Replace(".", "");
//                    }
//                }
//            }
//            else
//            {
//                txtValorTabela.Text = "";
//                txtValorProduto.Text = "";
//            }
//        }

//        private void BloqueiaDadosResidencias()
//        {
//            txtEndereco.Enabled = false;
//            txtComplemento.Enabled = false;
//            txtnr.Enabled = false;
//            txtCep.Enabled = false;
//            txtBairro.Enabled = false;
//            txtCidade.Enabled = false;
//            txtUf.Enabled = false;
//            imgEndereco.Visible = false;
//            imgEditEndereco.Visible = true;
//        }
//        private void getProdutoVendas(int modelo, string tipoveiculo)
//        {
//            int verifica = 0;

//            DataTable dt = new DataTable();
//            dt = bdp.ValidaModeloProdutos(modelo);
//            if (dt.Rows.Count > 0)
//            {
//                verifica = 1;
//            }
//            if (Session["ns"].ToString() == "0" && txtResultado.Text == "Reprovado" && verifica == 1)
//            {
//                tipo = 1;
//            }
//            else if (Session["ns"].ToString() == "1" && txtResultado.Text == "Reprovado" && verifica == 1)
//            {
//                tipo = 2;
//            }
//            else if (Session["ns"].ToString() == "0" && txtResultado.Text == "Aprovado" && verifica == 1)
//            {
//                tipo = 3;
//            }
//            else if (Session["ns"].ToString() == "1" && txtResultado.Text == "Aprovado" && verifica == 1)
//            {
//                tipo = 4;
//            }

//            if (Session["ns"].ToString() == "0" && txtResultado.Text == "Reprovado" && verifica == 0)
//            {
//                tipo = 5;
//            }
//            else if (Session["ns"].ToString() == "1" && txtResultado.Text == "Reprovado" && verifica == 0)
//            {
//                tipo = 6;
//            }
//            else if (Session["ns"].ToString() == "0" && txtResultado.Text == "Aprovado" && verifica == 0)
//            {
//                tipo = 7;
//            }
//            else if (Session["ns"].ToString() == "1" && txtResultado.Text == "Aprovado" && verifica == 0)
//            {
//                tipo = 8;
//            }

//            DataTable dtProdutos = new DataTable();
//            dtProdutos = bdp.pro_getProdutosVendas(tipo, modelo, tipoveiculo);
//            if (dtProdutos.Rows.Count > 0)
//            {
//                dropProdutos.DataSource = dtProdutos;
//                dropProdutos.DataBind();
//                dropProdutos.Items.Insert(0, "Selecione");
//                dadosVeiculo.Visible = true;
//            }
//            else
//            {
//                //dadosVeiculo.Visible = false;
//            }
//        }
//        protected void imgEndereco_Click(object sender, ImageClickEventArgs e)
//        {
//            if (txtCep.Text != "" && txtEndereco.Text != "" && txtnr.Text != "" && txtComplemento.Text != "" && txtBairro.Text != "" && txtCidade.Text != "" && txtUf.Text != "")
//            {
//                dadosVeiculo.Visible = true;
//                BloqueiaDadosResidencias();
//                dadosVeiculo.Visible = true;
//                //getProdutoVendas();
//                BuscaFabricante();
//            }
//            else
//            {
//                lblmensagem.Visible = true;
//                lblmensagem.Text = ("FAVOR PREENCHER TODOS OS DADOS..");
//            }
//        }
//        private void BuscaFabricante()
//        {
//            DataTable fabricante = new DataTable();
//            fabricante = bdv.BuscaFabricante();
//            dropFabricante.DataSource = fabricante;
//            dropFabricante.DataBind();
//            dropFabricante.Items.Insert(0, "Selecione");
//            BuscaCoresAutomotivas();
//        }
//        private void BuscaCoresAutomotivas()
//        {
//            DataTable cores = new DataTable();
//            cores = bdv.Cores();
//            dropCores.DataSource = cores;
//            dropCores.DataBind();
//            dropCores.Items.Insert(0, "Selecione");
//        }
//        private void liberaDadosResidencias()
//        {
//            txtEndereco.Enabled = true;
//            txtComplemento.Enabled = true;
//            txtnr.Enabled = true;
//            txtCep.Enabled = true;
//            txtBairro.Enabled = true;
//            txtCidade.Enabled = true;
//            txtUf.Enabled = true;
//            imgEndereco.Visible = true;
//            imgEditEndereco.Visible = false;
//        }
//        protected void imgEditEndereco_Click(object sender, ImageClickEventArgs e)
//        {
//            liberaDadosResidencias();
//        }
//        protected void imgAddprodutos_Click(object sender, ImageClickEventArgs e)
//        {
//            //CalculaPorcetagem();
//            ValidaPlaca();
//        }
//        private void InseriTaxaPlus()
//        {
//            if (dropProdutos.SelectedValue == "3" || dropProdutos.SelectedValue == "4" || dropProdutos.SelectedValue == "5" || dropProdutos.SelectedValue == "7" || dropProdutos.SelectedValue == "8" || dropProdutos.SelectedValue == "9" || dropProdutos.SelectedValue == "12" || dropProdutos.SelectedValue == "13" || dropProdutos.SelectedValue == "14" || dropProdutos.SelectedValue == "16" || dropProdutos.SelectedValue == "18")
//            {

//                DataSet ds_VlRepasse = new DataSet();

//                daoPedidoVenda bdv = new daoPedidoVenda();
//                bdv._id_Produto = Convert.ToInt32(dropProdutos.SelectedValue);
//                ds_VlRepasse = bdv.ValorRepasse();
//                decimal VlAdesao = Convert.ToDecimal(ds_VlRepasse.Tables[0].Rows[0]["vl_repasse"].ToString());
//                incluirNoDataTable("25", "ADESÃO PLUS", txtPlaca.Text, dropmodelo.SelectedValue + '-' + dropmodelo.SelectedItem.Text, dropCores.SelectedValue.ToUpper(), txtChassi.Text, txtRenavam.Text, VlAdesao.ToString("N2"), dropmodelo.SelectedValue, txtTipoVeiculo.Text, txtAno.Text, dropComb.SelectedValue, "S", (DataTable)Session["vProdutos"]);
//                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
//                this.GridProdutos.DataBind();
//            }
//        }
//        private void InseriProdutos()
//        {
//            string tipo = "0".ToString();
//            try
//            {
//                if (dropProdutos.SelectedValue == "20" || dropProdutos.SelectedValue == "21" || dropProdutos.SelectedValue == "22" || dropProdutos.SelectedValue == "23" || dropProdutos.SelectedValue == "25")
//                {

//                    tipo = "S";
//                }
//                else
//                {
//                    tipo = "P";
//                }
//                incluirNoDataTable(dropProdutos.SelectedValue, dropProdutos.SelectedItem.Text, txtPlaca.Text.ToString().ToUpper(), dropmodelo.SelectedItem.Text, dropCores.SelectedValue.ToUpper(), txtChassi.Text, txtRenavam.Text, txtValorProduto.Text, dropmodelo.SelectedValue, txtTipoVeiculo.Text.ToString().ToUpper(), txtAno.Text, dropComb.SelectedValue.ToString().ToUpper(), tipo, (DataTable)Session["vProdutos"]);
//                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
//                this.GridProdutos.DataBind();
//                //lblmensagem.Visible = true;
//                InseriTaxaPlus();

//            }
//            catch (Exception e)
//            {
//                e.Message.ToString();
//            }

//        }
//        private void ValidaPlaca()
//        {
//            DataSet ds = new DataSet();

//            if (txtPlaca.Text != "" && dropFabricante.SelectedValue != "Selecione" && dropCores.SelectedValue != "Selecione" && dropmodelo.SelectedValue != "Selecione" && txtValorTabela.Text != "" && txtValorProduto.Text != "0,00" && dropProdutos.SelectedValue != "Selecione")
//            {
//                try
//                {
//                    string ds_placa = txtPlaca.Text.Replace("-", "").ToString();
//                    ds = bdv.ValidaPlacaVeiculo(ds_placa.ToString());
//                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["ds_Placa"].ToString()) == 1)
//                    {
//                        lblmensagem.Visible = true;
//                        lblmensagem.Text = "Placa de veículo já consta em nossa base.";
//                        return;
//                    }
//                    else
//                    {

//                        InseriProdutos();
//                    }
//                }
//                catch (Exception e)
//                {
//                    e.Message.ToString();
//                }
//            }
//            else
//            {
//                lblmensagem.Visible = true;
//                lblmensagem.Text = "Favor preencher todos os dados";
//            }
//        }
//        protected void imgEditVeiculo_Click(object sender, ImageClickEventArgs e)
//        {
//            liberaDadosResidencias();
//        }
//        private void BuscaModelo()
//        {
//            if (dropFabricante.SelectedValue != "Selecione")
//            {
//                int id_fabricante = Convert.ToInt32(dropFabricante.SelectedValue);
//                DataTable modelo = bdv.BuscaModelo(id_fabricante);
//                dropmodelo.DataSource = modelo;
//                dropmodelo.DataBind();
//                dropmodelo.Items.Insert(0, "Selecione");
//            }
//        }
//        protected void dropFabricante_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            BuscaModelo();
//        }

//        protected void dropmodelo_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (dropmodelo.SelectedValue != "Selecione")
//            {
//                DataSet dtCategoria = bdv.BuscaTipoVeiculo(Convert.ToInt32(dropmodelo.SelectedValue));
//                if (dtCategoria.Tables[0].Rows.Count > 0)
//                {
//                    txtTipoVeiculo.Text = dtCategoria.Tables[0].Rows[0]["ds_categoria"].ToString();
//                    int modelo = Convert.ToInt32(dropmodelo.SelectedValue);
//                    string tipoveiculo = txtTipoVeiculo.Text;
//                    getProdutoVendas(modelo, tipoveiculo);
//                }
//                else
//                {
//                    txtTipoVeiculo.Text = "";
//                }


//            }
//        }
//        protected void imgVeiculo_Click(object sender, ImageClickEventArgs e)
//        {
//            imgEditVeiculo.Visible = true;
//            imgVeiculo.Visible = false;
//            pro_getPagamentos();
//        }

//        private void incluirNoDataTable(string incremento, string produto, string placa, string modelo, string cor, string chassi, string renavan, string valor, string id_modelo, string tipo, string ano, string comb, string tipoProduto, DataTable mTable)
//        {
//            try
//            {
//                DataRow linha;
//                linha = mTable.NewRow();

//                linha["Codigo"] = incremento;
//                linha["Produto"] = produto;
//                linha["placa"] = placa;
//                linha["modelo"] = modelo;
//                linha["cor"] = cor;
//                linha["chassi"] = chassi;
//                linha["renavan"] = renavan;
//                linha["valor"] = valor;
//                linha["id_modelo"] = id_modelo;
//                linha["tipo"] = tipo;
//                linha["ano"] = ano;
//                linha["comb"] = comb;
//                linha["tipoProduto"] = tipoProduto;
//                mTable.Rows.Add(linha);
//            }
//            catch (Exception e)
//            {
//                e.Message.ToString();
//            }
//        }
//        private void FinalizaPedido()
//        {
//            if (gridPagamento.Rows.Count > 0 && GridProdutos.Rows.Count > 0)
//            {
//                finalizar.Visible = true;
//            }
//            else
//            {
//                finalizar.Visible = false;
//            }
//        }

//        protected void GridProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            if (GridProdutos.Rows.Count > 0)
//            {
//                imgVeiculo.Visible = true;
//                divpagamento.Visible = true;
//                pagamento.Visible = true;
//            }
//            else
//            {
//                imgVeiculo.Visible = false;
//            }
//            if (GridProdutos.Rows.Count > 0)
//            {
//                decimal SomaUnitario = 0;
//                decimal SomaGeral = 0;

//                foreach (GridViewRow row in GridProdutos.Rows)
//                {
//                    if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
//                    {
//                        decimal valorrecebido = Convert.ToDecimal(txtValorTabela.Text);
//                        decimal valorgeral = Convert.ToDecimal(row.Cells[8].Text);

//                        if (row.Cells[8].Text != "")
//                        {
//                            SomaUnitario += valorrecebido;
//                            SomaGeral += valorgeral;

//                            if (e.Row.RowType == DataControlRowType.Footer)
//                            {


//                                e.Row.Cells[5].Text = "Quantidade";
//                                e.Row.Cells[6].Text = GridProdutos.Rows.Count.ToString();
//                                e.Row.Cells[7].Text = "Total";
//                                txtTotalVenda.Text = SomaGeral.ToString();
//                                //SomaGeral.ToString("N2");
//                                e.Row.Cells[8].Text = SomaGeral.ToString();
//                                ///SomaGeral.ToString("N2").Replace(".", "");

//                            }
//                        }
//                    }
//                }

//            }
//        }
//        private void CalculaPorcetagem()
//        {
//            // % de desconto
//            decimal porcentagem = Convert.ToDecimal(ConfigurationManager.AppSettings[("porcentagem")].ToString());

//            //Valor original
//            decimal valor = Convert.ToDecimal(txtValorTabela.Text);
//            //Convert.ToDouble(Session["valor"].ToString().Replace(".",",")); // valor original

//            //Percentual atual
//            decimal percentual = porcentagem / Convert.ToInt32("100"); // 2%

//            //Valor calculado
//            decimal valor_final = valor + (percentual * valor);

//            //Valor desejado pelo consultor
//            decimal valorDesejado = Math.Round(Convert.ToDecimal(txtValorProduto.Text));

//            if (valorDesejado <= valor_final)
//            {
//                ValidaPlaca();
//            }
//            else
//            {
//                lblmensagem.Visible = true;
//                lblmensagem.Text = "Valor ultrapassa 5% valor máximo é:" + valor_final.ToString();
//            }

//        }
//        private void BloqueiaFormaCheque()
//        {
//            lblbanco.Visible = false;
//            txtBanco.Visible = false;
//            txtBanco.Text = "";
//            lblconta.Visible = false;
//            txtConta.Visible = false;
//            txtConta.Text = "";
//            lbldocumento.Visible = false;
//            txtDocumento.Visible = false;
//            txtDocumento.Text = "";
//            lbltitular.Visible = false;
//            txtTitular.Visible = false;
//            txtTitular.Text = "";
//            lbldoc.Visible = false;
//            lblnrcheque.Visible = false;
//            txtNrCheque.Visible = false;
//            txtNrCheque.Text = "";
//            lblvencimento.Visible = false;
//            txtvencimentoCheque.Visible = false;
//            txtvencimentoCheque.Text = "";
//            lblAgencia.Visible = false;
//            txtAgencia.Visible = false;
//            txtAgencia.Text = "";
//            chkLeitora.Checked = false;
//            chkLeitora.Visible = false;

//            lblLeitura.Visible = false;
//            txtLeitura.Visible = false;
//        }
//        private void incluirNoDataTablePagamento(string incremento, string pagamento, string valor,
//                                              string data, string quantidade, string titular, string nr_agencia, string nr_conta, string nr_documento, string nr_cheque, string nr_banco, string ccm, DataTable mDataTablePagamento)
//        {
//            try
//            {
//                DataRow linha;
//                linha = mDataTablePagamento.NewRow();

//                linha["Codigo"] = incremento;
//                linha["Pagamento"] = pagamento;
//                linha["quantidade"] = quantidade;
//                linha["valor"] = valor;
//                linha["data"] = data;
//                linha["titular"] = titular;
//                linha["nr_agencia"] = nr_agencia;
//                linha["nr_conta"] = nr_conta;
//                linha["nr_documento"] = nr_documento;
//                linha["nr_cheque"] = nr_cheque;
//                linha["nr_banco"] = nr_banco;
//                linha["ccm"] = ccm;

//                mDataTablePagamento.Rows.Add(linha);
//            }
//            catch (Exception e)
//            {
//                e.Message.ToString();
//            }
//        }
//        private void InseriPagamentos()
//        {
//            try
//            {
//                int tipo = Convert.ToInt32(dropForma.SelectedValue);
//                switch (tipo)
//                {
//                    case 1:
//                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtNome.Text, "", "", txtDocumento.Text, "", "", "", (DataTable)Session["vPagamentos"]);
//                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                        this.gridPagamento.DataBind();
//                        break;
//                    case 2:
//                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.Date.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtNome.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
//                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                        this.gridPagamento.DataBind();
//                        break;
//                    case 3:
//                        int quantidade = Convert.ToInt32(txtQtdParcela.Text);
//                        for (int i = 0; i < quantidade; i++)
//                        {
//                            if (chkLeitora.Checked == false)
//                            {
//                                string Ban = txtLeitura.Text.Substring(1, 3);
//                                txtBanco.Text = Ban;

//                                string Age = txtLeitura.Text.Substring(4, 4);
//                                txtAgencia.Text = Age;

//                                string Com = txtLeitura.Text.Substring(10, 3);

//                                string Che = txtLeitura.Text.Substring(13, 6);
//                                txtNrCheque.Text = Che;

//                                string Con = txtLeitura.Text.Substring(23, 9);
//                                txtConta.Text = Con;
//                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text, txtNome.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
//                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                                this.gridPagamento.DataBind();
//                                txtLeitura.Text = "";
//                                txtLeitura.Focus();
//                            }
//                            else
//                            {
//                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
//                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                                this.gridPagamento.DataBind();
//                                txtLeitura.Text = "";
//                                txtLeitura.Focus();
//                            }

//                        }
//                        break;

//                    case 4:
//                        incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, DateTime.Now.Date.ToString(@"dd/MM/yyyy"), txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
//                        this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
//                        this.gridPagamento.DataBind();
//                        break;
//                    default:

//                        lblPagamento.Visible = true;
//                        lblPagamento.Text = "Selecione uma Forma de Pagamento";
//                        break;
//                }



//            }
//            catch (Exception e)
//            {
//                e.Message.ToString();
//            }
//        }
//        protected void btnCancelar_Click(object sender, EventArgs e)
//        {

//        }
//        private void GravaPagamento(int pedido)
//        {

//            foreach (GridViewRow grwp in gridPagamento.Rows)
//            {
//                int pagamento = Convert.ToInt32(dropForma.SelectedValue);
//                int quantidade = Convert.ToInt32(txtQtdParcela.Text);
//                if (rdbTpPessoa.SelectedValue == "0")
//                    bdvp._dsDoc = txtCpf.Text;
//                else
//                    bdvp._dsDoc = txtCnpj.Text;
//                decimal valorCalculado = Convert.ToDecimal(txtValor.Text) / quantidade;
//                switch (pagamento)
//                {
//                    case 1:
//                        bdvp._idPedido = pedido;
//                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
//                        bdvp._vlPagamento = Convert.ToDecimal(grwp.Cells[3].Text);
//                        bdvp._dataVenc = DateTime.Now.Date;
//                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
//                        bdvp._dsDoc = txtCpf.Text;
//                        bdvp._dsTitular = txtNome.Text;
//                        bdvp.pro_setPedidoVendaPagamento();
//                        break;
//                    case 2:
//                        bdvp._idPedido = pedido;
//                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
//                        bdvp._vlPagamento = Convert.ToDecimal(grwp.Cells[3].Text);
//                        bdvp._dataVenc = DateTime.Now.Date;
//                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
//                        if (grwp.Cells[5].Text != "&nbsp;" || grwp.Cells[5].Text != "")
//                            bdvp._dsTitular = grwp.Cells[5].Text;
//                        else
//                            bdvp._dsTitular = txtNome.Text;
//                        bdvp.pro_setPedidoVendaPagamento();
//                        break;
//                    case 3:
//                        bdvp._idPedido = pedido;
//                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
//                        bdvp._vlPagamento = Convert.ToDecimal(grwp.Cells[3].Text);
//                        bdvp._dataVenc = Convert.ToDateTime(grwp.Cells[4].Text);
//                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
//                        bdvp._dsTitular = grwp.Cells[5].Text;
//                        bdvp._nrAgencia = grwp.Cells[6].Text;
//                        bdvp._nrConta = grwp.Cells[7].Text;
//                        bdvp._ccm = Server.HtmlDecode(grwp.Cells[11].Text);
//                        bdvp._nrBanco = grwp.Cells[10].Text;
//                        bdvp._nr_cheque = grwp.Cells[9].Text;
//                        bdvp.pro_setPedidoVendaPagamento();
//                        break;
//                    case 4:
//                        bdvp._idPedido = pedido;
//                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
//                        bdvp._vlPagamento = Convert.ToDecimal(grwp.Cells[3].Text);
//                        bdvp._dataVenc = DateTime.Now.Date;
//                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
//                        bdvp._dsTitular = grwp.Cells[5].Text;
//                        if (grwp.Cells[5].Text != "&nbsp;" || grwp.Cells[5].Text != "")
//                            bdvp._dsTitular = grwp.Cells[5].Text;
//                        else
//                            bdvp._dsTitular = txtNome.Text;
//                        bdvp.pro_setPedidoVendaPagamento();
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//        private void GravaItens(int nr_venda)
//        {
//            if (GridProdutos.Rows.Count > 0)
//            {
//                foreach (GridViewRow grw in GridProdutos.Rows)
//                {
//                    int nr_itens = 0;
//                    int id_veiculo = 0;
//                    daoPedidoVendaItens bdvi = new daoPedidoVendaItens();
//                    daoPedidoVendaVeiculo bdvv = new daoPedidoVendaVeiculo();
//                    daoPedidoVendaPagamento bdp = new daoPedidoVendaPagamento();
//                    bdvi._idPedido = nr_venda;
//                    bdvi._idproduto = grw.Cells[0].Text;
//                    bdvi._valorProduto = Convert.ToDecimal(grw.Cells[8].Text);
//                    bdvi._vlDesconto = Convert.ToDecimal(grw.Cells[8].Text);
//                    nr_itens = bdvi.pro_setPedidoVendaItens();
//                    bdvv._idItem = nr_itens;
//                    bdvv._idmodelo = Convert.ToInt32(grw.Cells[2].Text);
//                    bdvv._idPedido = nr_venda;
//                    bdvv._dsplaca = grw.Cells[1].Text.ToString().Replace("-", "");
//                    bdvv._dsCor = grw.Cells[4].Text;
//                    bdvv._dsCombustivel = grw.Cells[11].Text;
//                    bdvv._dsAno = grw.Cells[10].Text;
//                    bdvv._dsRenavan = grw.Cells[6].Text;
//                    bdvv._dsChassi = grw.Cells[5].Text;

//                    id_veiculo = bdvv.pro_setPedidoVendaVeiculo();


//                }
//                GravaPagamento(nr_venda);
//            }
//        }
//        private void GravaPedido()
//        {
//            try
//            {

//                daoPedidoVenda bdpv = new daoPedidoVenda();
//                int nr_Pedidovenda = 0;
//                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
//                bdpv._id_franquia = acessoLogin.idFranquia;
//                bdpv._id_vendedor = acessoLogin.cdVendedorInterno;
//                bdpv.id_consulta = Convert.ToInt32(txtCodigoConsulta.Text);
//                bdpv._ds_nome = txtNome.Text;
//                bdpv._nrCep = txtCep.Text;
//                bdpv._endereco = txtEndereco.Text;
//                bdpv._nrEndereco = txtnr.Text;
//                bdpv._dsComplemento = txtComplemento.Text;
//                bdpv._dsBairro = txtBairro.Text;
//                bdpv._dsCidade = txtCidade.Text;
//                bdpv._dsUf = txtUf.Text;
//                bdpv._dsRG = txtRG.Text;
//                bdpv._tpSexo = dropSexo.SelectedValue;
//                if (rdbTpPessoa.SelectedValue == "0")
//                {
//                    bdpv._dsDocumento = txtCpf.Text;
//                    bdpv._tpCliente = rdbTpPessoa.SelectedValue;
//                }
//                else
//                {
//                    bdpv._dsDocumento = txtCnpj.Text;
//                    bdpv._tpCliente = rdbTpPessoa.SelectedValue;
//                }
//                bdpv._ddTel = TxtResidencial.Text.Substring(0, 2).ToString();
//                bdpv._nrTel = TxtResidencial.Text.Substring(2, 8);
//                bdpv._ddcel = txtCelular.Text.Substring(0, 2).ToString();
//                bdpv._nrCel = txtCelular.Text.Substring(2, 9);
//                bdpv._ddCom = txtComercial.Text.Substring(0, 2).ToString();
//                bdpv._nrCom = txtComercial.Text.Substring(2, 8);
//                bdpv._id_consultaCredito = Convert.ToInt32(txtCodigoConsulta.Text);
//                bdpv._dtConsultaCredito = Convert.ToDateTime(txtData.Text);
//                bdpv._dsConsultaCredito = txtResultado.Text;
//                bdpv._dtNascimento = Convert.ToDateTime(txtdtNascimento.Text);
//                bdpv._ds_email = txtEmail.Text;
//                bdpv._cd_profissao = Convert.ToInt32(dropProfisao.SelectedValue);
//                bdpv._idmidia = dropMidia.SelectedValue;
//                nr_Pedidovenda = bdpv.pro_setPedidoVenda();
//                if (nr_Pedidovenda > 0)
//                {
//                    GravaItens(nr_Pedidovenda);
//                    BuscaDadosPedidosAbertos(nr_Pedidovenda);
//                    //btnFinalizar.Text="Pedido gerado N: " + nr_Pedidovenda + " finalizado com sucesso:";
//                    btnCancelar.Visible = false;
//                    btnFinalizar.Text = "Número do Pedido: " + nr_Pedidovenda;
//                    btnFinalizar.Enabled = false;
//                }

//            }
//            catch (Exception ex)
//            {
//                ex.Message.ToString();
//            }
//        }
//        protected void btnFinalizar_Click(object sender, EventArgs e)
//        {
//            GravaPedido();
//        }

//        protected void txtLeitura_TextChanged(object sender, EventArgs e)
//        {
//            if (txtLeitura.Text != "" && txtTitular.Text != "" && txtDocumento.Text != "" && txtQtdParcela.Text != "" && txtvencimentoCheque.Text != "")
//            {
//                string Ban = txtLeitura.Text.Substring(1, 3);
//                txtBanco.Text = Ban;

//                string Age = txtLeitura.Text.Substring(4, 4);
//                txtAgencia.Text = Age;

//                string Com = txtLeitura.Text.Substring(10, 3);

//                string Che = txtLeitura.Text.Substring(13, 6);
//                txtNrCheque.Text = Che;

//                string Con = txtLeitura.Text.Substring(23, 9);
//                txtConta.Text = Con;
//                InseriPagamentos();
//                txtLeitura.Text = "";
//                txtLeitura.Focus();
//            }
//            else
//            {
//                lblPagamento.Visible = true;
//                lblPagamento.Text = "FAVOR PREENCHER TODOS OS DADOS..";
//            }

//        }
//        protected void chkLeitora_CheckedChanged(object sender, EventArgs e)
//        {
//            if (chkLeitora.Checked == true)
//            {
//                lblLeitura.Visible = true;
//                txtLeitura.Visible = true;
//                txtCheques.Visible = true;
//                txtLeitura.Focus();
//                txtLeitura.Text = "";
//                lblcheques.Visible = true;
//            }
//            else
//            {
//                lblLeitura.Visible = false;
//                txtLeitura.Visible = false;
//                txtLeitura.Text = "";
//                txtCheques.Visible = false;
//                lblcheques.Visible = false;
//            }
//        }
//        private void LiberaFormaCheque()
//        {
//            lblbanco.Visible = true;
//            txtBanco.Visible = true;
//            lblconta.Visible = true;
//            txtConta.Visible = true;
//            lbldocumento.Visible = true;
//            txtDocumento.Visible = true;
//            lbltitular.Visible = true;
//            txtTitular.Visible = true;
//            lbldoc.Visible = true;
//            lblnrcheque.Visible = true;
//            txtNrCheque.Visible = true;
//            lblvencimento.Visible = true;
//            txtvencimentoCheque.Visible = true;
//            lblAgencia.Visible = true;
//            txtAgencia.Visible = true;
//            chkLeitora.Visible = true;
//            chkLeitora.Checked = false;
//            lblLeitura.Visible = true;
//            txtLeitura.Visible = true;
//        }
//        private void RegrasPagamento()
//        {
//            if (dropForma.SelectedValue != "" && dropForma.SelectedValue != "Selecione")
//            {
//                int tpPagamento = Convert.ToInt32(dropForma.SelectedValue);
//                switch (tpPagamento)
//                {
//                    case 1:
//                        txtQtdParcela.Text = "1";
//                        txtValor.Text = "";
//                        txtQtdParcela.Enabled = false;
//                        imgPagamento.Enabled = true;
//                        txtvencimentoCheque.Visible = false;
//                        lblvencimento.Visible = false;
//                        BloqueiaFormaCheque();
//                        break;

//                    case 2:
//                        txtQtdParcela.Enabled = true;
//                        txtValor.Text = "";
//                        txtvencimentoCheque.Visible = false;
//                        lblvencimento.Visible = false;
//                        imgPagamento.Enabled = true;
//                        BloqueiaFormaCheque();
//                        break;

//                    case 3:
//                        txtQtdParcela.Enabled = true;
//                        txtvencimentoCheque.Text = DateTime.Now.AddMonths(1).ToString(@"dd/MM/yyyy");
//                        txtTitular.Text = txtNome.Text;
//                        int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
//                        switch (tipo)
//                        {
//                            case 0:
//                                txtDocumento.Text = txtCpf.Text;
//                                break;

//                            case 1:
//                                txtDocumento.Text = txtCnpj.Text;
//                                break;
//                        }

//                        lblvencimento.Visible = false;
//                        imgPagamento.Enabled = true;
//                        LiberaFormaCheque();
//                        break;

//                    case 4:
//                        txtQtdParcela.Enabled = true;
//                        txtvencimentoCheque.Text = "";
//                        txtvencimentoCheque.Visible = true;
//                        lblvencimento.Visible = true;
//                        imgPagamento.Enabled = true;
//                        BloqueiaFormaCheque();
//                        break;
//                }
//            }
//            else
//            {
//                imgPagamento.Enabled = false;
//                // txtValor.Text = "";
//                // txtQtdParcela.Text = "";

//            }

//        }
//        private void BuscaDadosPedidosAbertos(int pedido)
//        {
//            DataTable dt_ped = new DataTable();
//            dt_ped = bdpv.PedidosContrato(pedido);
//            if (dt_ped.Rows.Count > 0)
//            {
//                GridContrato.DataSource = dt_ped;
//                GridContrato.DataBind();
//            }
//        }
//        private void pro_getPagamentos()
//        {
//            daoPagamento bdpg = new daoPagamento();
//            DataSet dt_pagamento = new DataSet();
//            dt_pagamento = bdpg.getFormasPagamentos();
//            if (dt_pagamento.Tables[0].Rows.Count > 0)
//            {
//                dropForma.DataSource = dt_pagamento;
//                dropForma.DataBind();
//                dropForma.Items.Insert(0, "Selecione");
//            }

//        }
//        protected void dropForma_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            RegrasPagamento();
//        }

//        private void ExcluirLinha(string id)
//        {
//            if (GridProdutos.Rows.Count > 0)
//            {
//                for (int i = 1; i <= 1; i++)
//                {
//                    foreach (DataRow linha in ((DataTable)Session["vProdutos"]).Rows)
//                    {
//                        if (linha[0].ToString() == id)
//                        {
//                            linha.Delete();
//                            this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
//                            this.GridProdutos.DataBind();
//                            return;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                // dadosprodutos.Visible = false;
//            }
//        }

//        protected void GridProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            string id = GridProdutos.Rows[e.RowIndex].Cells[0].Text;
//            ExcluirLinha(id);

//        }
//        protected void GridContrato_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            daoContrato bdc = new daoContrato();
//            DataSet dsPedido = new DataSet();
//            string nr_contrato = null;
//            string aux = null;
//            string habilita = "N".ToString();
//            bdc._idPedido = Convert.ToInt32(GridContrato.Rows[e.RowIndex].Cells[1].Text);
//            dsPedido = bdc.getPedido();
//            if (dsPedido.Tables[0].Rows.Count > 0)
//            {
//                DataSet dsValida = new DataSet();
//                daoPedido bdv = new daoPedido();
//                bdv._nrDocumento = dsPedido.Tables[0].Rows[0]["ds_documento"].ToString();
//                dsValida = bdv.ValidaGeracaoPedidos();
//                if (dsValida.Tables[0].Rows.Count > 0)
//                {
//                    lblmensagem.Visible = true;
//                    lblmensagem.Text = ("Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString());
//                }
//                else
//                {
//                    for (int i = 0; i < dsPedido.Tables[0].Rows.Count; i++)
//                    {

//                        bdc._dsNome = dsPedido.Tables[0].Rows[i]["ds_cliente"].ToString();
//                        bdc._tpPessoa = Convert.ToInt32(dsPedido.Tables[0].Rows[0]["tp_cliente"].ToString());

//                        if (bdc._tpPessoa == 0)
//                            bdc._dsCpf = dsPedido.Tables[0].Rows[i]["ds_documento"].ToString();
//                        else
//                            bdc._dsCnpj = dsPedido.Tables[0].Rows[i]["ds_documento"].ToString();

//                        bdc._dsRg = dsPedido.Tables[0].Rows[i]["nr_rg"].ToString();
//                        bdc._dtNascimento = Convert.ToDateTime(dsPedido.Tables[0].Rows[i]["dt_nascimento"].ToString());
//                        bdc._dsEndereco = dsPedido.Tables[0].Rows[i]["ds_endereco"].ToString();
//                        bdc._nrResidencia = dsPedido.Tables[0].Rows[i]["nr_endereco"].ToString();
//                        bdc._dsComplemento = dsPedido.Tables[0].Rows[i]["ds_complemento"].ToString();
//                        bdc._dsCep = dsPedido.Tables[0].Rows[i]["nr_cep"].ToString();
//                        bdc._dsBairro = dsPedido.Tables[0].Rows[i]["ds_bairro"].ToString();
//                        bdc._dsCidade = dsPedido.Tables[0].Rows[i]["ds_cidade"].ToString();
//                        bdc._dsUF = dsPedido.Tables[0].Rows[i]["ds_uf"].ToString();
//                        bdc._nrTelResidencial = dsPedido.Tables[0].Rows[i]["Telefone"].ToString();
//                        bdc._nrTelCelular = dsPedido.Tables[0].Rows[i]["Celular"].ToString();
//                        bdc._ds_pontoReferencia = dsPedido.Tables[0].Rows[i]["ds_complemento"].ToString();
//                        bdc._dsEmail = dsPedido.Tables[0].Rows[i]["ds_email"].ToString();
//                        bdc._tpVeiculo = dsPedido.Tables[0].Rows[i]["ds_categoria"].ToString();
//                        bdc._ds_fabricante = dsPedido.Tables[0].Rows[i]["ds_Fabricante"].ToString();
//                        bdc._ds_modelo = dsPedido.Tables[0].Rows[i]["modelo"].ToString();
//                        bdc._ds_placa = dsPedido.Tables[0].Rows[i]["ds_placa"].ToString();
//                        DataSet dsValidaHabit = new DataSet();
//                        dsValidaHabit = bdc.ValidaHabilitacao();
//                        if (dsValidaHabit.Tables[0].Rows.Count > 0)
//                            bdc._dt_Renova = DateTime.Now.AddMonths(12);
//                        else
//                            bdc._dt_Renova = DateTime.Now;
//                        bdc._ds_anoVeiculo = dsPedido.Tables[0].Rows[i]["ds_ano"].ToString();
//                        bdc._ds_cor = dsPedido.Tables[0].Rows[i]["ds_cor"].ToString();
//                        bdc._ds_combustivel = dsPedido.Tables[0].Rows[i]["ds_combustivel"].ToString();
//                        bdc._ds_Renavam = dsPedido.Tables[0].Rows[i]["ds_renavan"].ToString();
//                        bdc._ds_Chassi = dsPedido.Tables[0].Rows[i]["ds_chassi"].ToString();
//                        bdc._ds_Produto = dsPedido.Tables[0].Rows[i]["ds_produto"].ToString();
//                        bdc._ds_vendedor = dsPedido.Tables[0].Rows[i]["cd_vendedor"].ToString();
//                        bdc._ds_sexo = dsPedido.Tables[0].Rows[i]["tp_Sexo"].ToString();
//                        bdc._ds_Profissao = dsPedido.Tables[0].Rows[i]["cd_profisao"].ToString();
//                        bdc._idmidia = dsPedido.Tables[0].Rows[i]["id_midia"].ToString();
//                        nr_contrato = bdc.pro_setGeraContrato();
//                        if (nr_contrato != null)
//                        {
//                            bdc._nrcontrato = nr_contrato;
//                            int alter = bdc.pro_setVinculaPedidoContrato();
//                            if (alter > 0)
//                            {
//                                aux = aux + ", " + nr_contrato;
//                            }

//                        }
//                    }
//                    lblmensagem.Visible = true;
//                    lblmensagem.Text = "Contrato: " + aux + " gerado com sucesso...";

//                    BuscaDadosPedidosAbertos(bdc._idPedido);
//                }
//            }
//        }
//        public class GridDecorator
//        {
//            public static void MergeRows(GridView gridView)
//            {
//                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
//                {
//                    GridViewRow row = gridView.Rows[rowIndex];
//                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
//                    int i = 0;

//                    if (row.Cells[i].Text.TrimEnd().TrimStart() == previousRow.Cells[i].Text.TrimEnd().TrimStart())
//                    {
//                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
//                                               previousRow.Cells[i].RowSpan + 1;
//                        previousRow.Cells[i].Visible = false;
//                    }
//                    else
//                    {
//                        i = 1;
//                    }

//                }
//            }

//        }
//        protected void GridContrato_PreRender(object sender, EventArgs e)
//        {
//            GridDecorator.MergeRows(GridContrato);

//        }
//        private static DataTable GetData(string query)
//        {
//            string strConnString = ConfigurationManager.ConnectionStrings["cnxFranquia"].ConnectionString;
//            using (SqlConnection con = new SqlConnection(strConnString))
//            {
//                using (SqlCommand cmd = new SqlCommand())
//                {
//                    cmd.CommandText = query;
//                    using (SqlDataAdapter sda = new SqlDataAdapter())
//                    {
//                        cmd.Connection = con;
//                        sda.SelectCommand = cmd;
//                        using (DataSet ds = new DataSet())
//                        {
//                            DataTable dt = new DataTable();
//                            sda.Fill(dt);
//                            return dt;
//                        }

//                    }

//                }

//            }

//        }
//        protected void GridContrato_RowDataBound(object sender, GridViewRowEventArgs e)
//        {

//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {

//                string customerId = GridContrato.DataKeys[e.Row.RowIndex].Value.ToString();

//                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;

//                gvOrders.DataSource = GetData(string.Format("SELECT distinct p.id_pedido,ve.id_item,pv.ds_placa,pv.nr_contrato FROM Franquia.tbl_PedidoVenda p inner join [Franquia].[tbl_PedidoVendaItens] ve on p.id_pedido=ve.id_pedido inner join  Franquia.tbl_PedidoVendaVeiculo pv on pv.id_item=ve.id_item inner join Modelos m on pv.id_modelo=m.id_modelo inner join Franquia.tbl_ProdutoVenda prod on  prod.id_produto=ve.id_produto where prod.tp_produto='P' and p.id_pedido='{0}'", customerId));

//                gvOrders.DataBind();

//            }
//        }

//        protected void rdbReprovado_CheckedChanged(object sender, EventArgs e)
//        {
//            dadoscliente.Visible = true;
//            dadosclienteComplementares.Visible = true;
//            BloqueiaCampos();
//            BuscaProfisao();
//            BuscaMidias();
//        }

//        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
//        {
//            Response.Redirect("MeusPedidosVendas.aspx");
//        }
//    }
//}