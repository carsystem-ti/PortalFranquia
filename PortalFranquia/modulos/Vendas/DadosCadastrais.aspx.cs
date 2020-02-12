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
    public partial class DadosCadastrais : System.Web.UI.Page
    {
        
        daoProdutos bdp = new daoProdutos();
        daoRepasse bdr = new daoRepasse();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setVoltarUrl(Page, Session);
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        protected void rdbTpPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
            switch (tipo)
            {
                case 0:
                    ConsultaCpf.Visible = true;
                    ConsultaCnpj.Visible = false;
                    txtCnpj.Text = "";
                    //LimpaCampos();
                    break;
                case 1:
                    ConsultaCnpj.Visible = true;
                    ConsultaCpf.Visible = false;
                    txtCpf.Text = "";
                    //LimpaCampos();
                    break;
            }
        }
        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }
        private void ValidaNome()
        {
            if (txtNome.Text.ToUpper() == "NE")
            {
                txtNome.Enabled = true;
            }
            else
            {
                txtNome.Enabled = false;
            }
        }
        private void Consulta(string nr_documento)
        {
            double valor = Convert.ToDouble("1000,00");
            string retorno;


            CarSystem.Banco.BoaVista.BoaVista bv = new CarSystem.Banco.BoaVista.BoaVista("userFranquia", "2FACA908-D931-4DA8-BC99-497C7B515021", "principal", CarSystem.Tipos.Servidores.Fury);





            CarSystem.Banco.BoaVista.BoaVista boa = new CarSystem.Banco.BoaVista.BoaVista("usr_web", "premium", "principal", CarSystem.Tipos.Servidores.Fury);

            boa.isProducao = true;

            CarSystem.Banco.BoaVista.BoaVista.Consulta iConsulta = boa.efetuaConsulta(nr_documento, valor);

           // CarSystem.Banco.BoaVista.BoaVista.Consulta c = bv.efetuaConsultaWS(nr_documento, false);


            lblmensagem.Text = (iConsulta.codigoConsulta.ToString());
            lblmensagem.Text = (iConsulta.dataConsulta.ToShortDateString());

            if (nr_documento.Length == 14)
                retorno = (CarSystem.Utilidades.Formatar.formataCNPJ(iConsulta.documento.ToString()));
            else
                retorno = (CarSystem.Utilidades.Formatar.formataCPF(iConsulta.documento.ToString()));

            retorno = (iConsulta.statusConsulta.ToString().ToUpper());
            string ds_nome = iConsulta.nome.ToString();
            switch (retorno)
            {
                case "APROVADO":
                    filtroAprovacao.Visible = true;
                    rdbAprovado.Visible = true;
                    rdbReprovado.Visible = false;
                    rdbanalise.Visible = false;
                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
                    txtResultado.Text = iConsulta.statusConsulta.ToString();
                    Session["boavista"] = retorno;
                    txtNome.Text = ds_nome;
                    ValidaNome();
                    Mensagem(iConsulta.erro);
                    break;
                case "REPROVADO":
                    filtroAprovacao.Visible = true;
                    rdbReprovado.Visible = true;
                    rdbAprovado.Visible = false;
                    rdbanalise.Visible = false;
                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
                    txtResultado.Text = iConsulta.statusConsulta.ToString();
                    txtNome.Text = ds_nome;
                    Session["boavista"] = retorno;
                    ValidaNome();
                    Mensagem(iConsulta.erro);
                    break;
                default:
                    filtroAprovacao.Visible = false;
                    break;
            }

        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text != "")
            {
                bool Valida = false;
                Valida = ValidaCpf(txtCpf.Text);
                switch (Valida)
                {
                    case true:
                        DataSet dsValida = new DataSet();
                        daoPedido bdv = new daoPedido();
                        bdv._nrDocumento = txtCpf.Text;
                        dsValida = bdv.ValidaGeracaoPedidos();
                        if (dsValida.Tables[0].Rows.Count > 0)
                        {
                            //lblmensagem.Visible = true;
                            //lblmensagem.Text = 
                              Mensagem("Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString());
                        }
                        else
                        {
                            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "").ToString();
                            Consulta(cpf);
                        }
                        break;
                    default:
                       // lblmensagem.Visible = true;
                       // lblmensagem.Text = "CPF INVÁLIDO";
                        Mensagem("CPF INVÁLIDO");
                        filtroAprovacao.Visible = false;
                        break;
                }
            }
            else
            {
                //lblmensagem.Visible = true;
                //lblmensagem.Text = "Selecione todas as informações";
                Mensagem("Selecione todas as informações");
            }
        }
        public bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
        protected void btnCnpj_Click(object sender, EventArgs e)
        {
            bool Cnpj = false;
            Cnpj = ValidaCnpj(txtCnpj.Text.Replace(".","").Replace("/","").Replace("-",""));
            switch (Cnpj)
            {
                case true:
                    DataSet dsValida = new DataSet();
                    daoPedido bdv = new daoPedido();
                    bdv._nrDocumento = txtCnpj.Text;
                    dsValida = bdv.ValidaGeracaoPedidos();
                    if (dsValida.Tables[0].Rows.Count > 0)
                    {
                        //lblmensagem.Visible = true;
                        //lblmensagem.Text = ("Existe um contrato vinculado ao CPF: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString());
                        Mensagem("Existe um contrato vinculado ao CPF: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString());
                    }
                    else
                    {
                        Consulta(txtCnpj.Text.Replace(".", "").Replace("-", "").ToString().Replace("/", "").Replace(",", ""));
                    }
                    break;
                default:
                   // lblmensagem.Visible = true;
                    //lblmensagem.Text = "CNPJ INVÁLIDO";
                    Mensagem("CNPJ INVÁLIDO");
                    filtroAprovacao.Visible = false;
                    break;
            }
        }
        private void BuscaProfisao()
        {
            daoPedidoVenda vendas = new daoPedidoVenda();
            DataTable dt = new DataTable();
            dt = vendas.getProfisao();
            if (dt.Rows.Count > 0)
            {
                dropProfisao.DataSource = dt;
                dropProfisao.DataBind();
                dropProfisao.Items.Insert(0, "Selecione");
            }

        }
        private void BuscaMidias()
        {
            DataSet dsMIDIAS = new DataSet();
            daoPedidoVenda bdm = new daoPedidoVenda();
            dsMIDIAS = bdm.Midias();
            dropMidia.DataSource = dsMIDIAS;
            dropMidia.DataBind();
            dropMidia.Items.Insert(0, "Selecione");
        }
        private void BloqueiaDadosCliente()
        {
            txtNome.Enabled = false;
            TxtResidencial.Enabled = false;
            txtCelular.Enabled = false;
            txtComercial.Enabled = false;
            txtEmail.Enabled = false;
            imgAvancarCliente.Visible = false;
            imgEditCliente.Visible = true;
        }
        private void BloqueiaCampos()
        {
            rdbTpPessoa.Enabled = false;
            txtCnpj.Enabled = false;
            txtCpf.Enabled = false;

        }
        protected void rdbAprovado_CheckedChanged(object sender, EventArgs e)
        {
            dadoscliente.Visible = true;
            dadosclienteComplementares.Visible = true;
            BloqueiaCampos();
            BuscaProfisao();
            BuscaMidias();
            int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
            if (tipo == 0)
            {
                Session["tipo"] = rdbTpPessoa.SelectedValue;
                Session["doc"] = txtCpf.Text;
                Session["nome"] = txtNome.Text;
            }
            else
            {
                Session["tipo"] = rdbTpPessoa.SelectedValue;
                Session["doc"] = txtCnpj.Text;
                Session["nome"] = txtNome.Text;
            }
        }
        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void imgAvancarCliente_Click(object sender, ImageClickEventArgs e)
        {
            bool retorno = false;
            if (txtComercial.Text.Length >= 10 && TxtResidencial.Text.Length >= 10 && txtCelular.Text.Length >= 11 && txtCodigoConsulta.Text != "" && txtData.Text != "" && txtNome.Text != "" && TxtResidencial.Text != "" && txtCelular.Text != "" && txtEmail.Text != "" && dropMidia.SelectedValue != "Selecione" && dropProfisao.SelectedValue != "Selecione")
            {
                retorno=ValidarEmail(txtEmail.Text);
                if (retorno == true)
                {
                    dadosresidencial.Visible = true;
                    BloqueiaDadosCliente();
                }
                else
                {
                    Mensagem("Email Inválido");
                }
            }
            else
            {
                //lblmensagem.Visible = true;
                Mensagem("FAVOR PREENCHER TODOS OS CAMPOS..");
                //lblmensagem.Text = "FAVOR PREENCHER TODOS OS CAMPOS..";
            }
        }
        private void LiberaDadosCliente()
        {

          
            TxtResidencial.Enabled = false;
            txtCelular.Enabled = false;
            txtComercial.Enabled = false;
            txtEmail.Enabled = false;
            imgAvancarCliente.Visible = true;
            imgEditCliente.Visible = false;
        }
        protected void imgEditCliente_Click(object sender, ImageClickEventArgs e)
        {
            LiberaDadosCliente();
        }
        private void BuscaCep()
        {

            if (txtCep.Text != "")
            {
                DataSet ds_cep = new DataSet();
                string nr_cep = txtCep.Text;
                ds_cep = bdp.pro_getCep(nr_cep);
                if (ds_cep.Tables[0].Rows.Count > 0)
                {
                    txtEndereco.Text = ds_cep.Tables[0].Rows[0]["Rua"].ToString();
                    if (txtEndereco.Text == "")
                    {
                        txtEndereco.ReadOnly = false;
                    }
                    txtBairro.Text = ds_cep.Tables[0].Rows[0]["Bairro"].ToString();
                    txtCidade.Text = ds_cep.Tables[0].Rows[0]["Cidade"].ToString();
                    txtUf.Text = ds_cep.Tables[0].Rows[0]["Estado"].ToString();
                    txtnr.Text = "";
                    txtComplemento.Text = "";
                    imgEndereco.Visible = true;
                    DataSet dsCep = new DataSet();
                    ds_cep = bdr.ValidaTecnologia(nr_cep, "NS");
                    if (ds_cep.Tables[0].Rows.Count > 0)
                    {
                        string ds_tecnologia = ds_cep.Tables[0].Rows[0]["Tec"].ToString();
                        if (ds_tecnologia == "nOK")
                        {
                            imgEndereco.Visible = true;
                            Session["ns"] = "0";
                        }
                        else
                        {
                            imgEndereco.Visible = true;
                            Session["ns"] = "1";
                        }
                    }
                    else
                    {
                        Session["gsm"] = "1";
                        imgEndereco.Visible = true;
                        
                    }
                }
                else
                {
                    ///lblmensagem.Visible = true;
                  Mensagem("CEP NÃO ENCONTRADO,OU FORA DA FAIXA DE COBERTURA");
                    txtEndereco.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtUf.Text = "";
                    txtnr.Text = "";
                    imgEndereco.Visible = false;
                }
            }
        }
        protected void imgCep_Click(object sender, ImageClickEventArgs e)
        {
            BuscaCep();
        }

        protected void imgEndereco_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCep.Text != "" && txtEndereco.Text != "" && txtnr.Text != "" && txtComplemento.Text != "" && txtBairro.Text != "" && txtCidade.Text != "" && txtUf.Text != "")
            {
                habilitarProximo.Visible = true;
                //dadosVeiculo.Visible = true;
                //BloqueiaDadosResidencias();
                // dadosVeiculo.Visible = true;
                //getProdutoVendas();
                ///BuscaFabricante();
            }
            else
            {
                //lblmensagem.Visible = true;
                //lblmensagem.Text = ("FAVOR PREENCHER TODOS OS DADOS..");
                Mensagem("FAVOR PREENCHER TODOS OS DADOS..");
            }
        }
        private void liberaDadosResidencias()
        {
            txtEndereco.Enabled = true;
            txtComplemento.Enabled = true;
            txtnr.Enabled = true;
            txtCep.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            imgEndereco.Visible = true;
            imgEditEndereco.Visible = false;
        }
        protected void imgEditEndereco_Click(object sender, ImageClickEventArgs e)
        {
            liberaDadosResidencias();
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            if (txtComercial.Text.Length >= 10 && TxtResidencial.Text.Length >= 10 && txtCelular.Text.Length >= 11 && txtCodigoConsulta.Text != "" && txtData.Text != "" && txtNome.Text != "" && TxtResidencial.Text != "" && txtCelular.Text != "" && txtEmail.Text != "" && dropMidia.SelectedValue != "Selecione")
            {
                try
                {
                    Session["cep"] = txtCep.Text;
                    daoPedidoVenda bdpv = new daoPedidoVenda();
                    
                    int nr_Pedidovenda = 0;
                    string tipo = null;
                    string ds_doc = null;
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    int id_franquia = acessoLogin.idFranquia;
                    int id_vendedor = acessoLogin.cdVendedorInterno;
                    int id_consulta = Convert.ToInt32(txtCodigoConsulta.Text);
                    string ds_nome = txtNome.Text;
                    string cep = txtCep.Text;
                    string endereco = txtEndereco.Text;
                    string nr_endereco = txtnr.Text;
                    string ds_complemento = txtComplemento.Text;
                    string ds_bairro = txtBairro.Text;
                    string ds_cidade = txtCidade.Text;
                    string ds_uf = txtUf.Text;
                    string ds_rg = txtRG.Text;
                    string sexo = dropSexo.SelectedValue;
                    if (rdbTpPessoa.SelectedValue == "0")
                    {
                        ds_doc = txtCpf.Text;
                        tipo = rdbTpPessoa.SelectedValue;
                    }
                    else
                    {
                        ds_doc = txtCnpj.Text;
                        tipo = rdbTpPessoa.SelectedValue;
                    }
                    string ddtel = TxtResidencial.Text.Substring(0, 2).ToString();
                    string nrTelResidencia = TxtResidencial.Text;
                    string dddCel = txtCelular.Text.Substring(0, 2).ToString();
                    string nrCel = txtCelular.Text;
                    string dddComer = txtComercial.Text.Substring(0, 2).ToString();
                    string nrTelCom = txtComercial.Text;
                    int id_consultaCredito = Convert.ToInt32(txtCodigoConsulta.Text);
                    DateTime dt_consulta = Convert.ToDateTime(txtData.Text);
                    string ds_consultaCredito = txtResultado.Text; ;
                    DateTime dt = DateTime.ParseExact(txtdtNascimento.Text, "dd/MM/yyyy", null);
                    string ds_email = txtEmail.Text;
                    int id_profisao = Convert.ToInt32(dropProfisao.SelectedValue);
                    string id_midia = dropMidia.SelectedValue;
                    nr_Pedidovenda = bdpv.pro_setPedidoVenda(id_franquia, id_vendedor, ds_nome, tipo, cep, endereco, nr_endereco, ds_complemento, ds_bairro, ds_cidade, ds_uf, ds_doc, dddCel, nrTelResidencia, dddCel, nrCel, dddComer, nrTelCom, id_consulta, dt_consulta, ds_consultaCredito, ds_rg, sexo, dt, ds_email, id_profisao, id_midia);
                    if (nr_Pedidovenda > 0)
                    {
                        txtpedido.Text = nr_Pedidovenda.ToString();
                        btn_confirmar.Enabled = false;
                        btn_avancar.Enabled = true;
                        Session["pedido"] = txtpedido.Text;
                        Mensagem("PEDIDO: " +  txtpedido.Text +  " CONFIRMADO,FAVOR SEGUIR PREENCHENDO AS INFORMAÇÕES");
                    }

                }
                catch (Exception ex)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = ex.ToString();
                }
            }
            else
            {
                //lblmensagem.Visible = true;
                Mensagem("Favor preencher todos os dados corretamente");
            }
        }

        protected void rdbReprovado_CheckedChanged(object sender, EventArgs e)
        {
            dadoscliente.Visible = true;
            dadosclienteComplementares.Visible = true;
            BloqueiaCampos();
            BuscaProfisao();
            BuscaMidias();
            int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
            if (tipo == 0)
            {
                Session["tipo"] = rdbTpPessoa.SelectedValue;
                Session["doc"] = txtCpf.Text;
                Session["nome"] = txtNome.Text;
            }
            else
            {
                Session["tipo"] = rdbTpPessoa.SelectedValue;
                Session["doc"] = txtCnpj.Text;
                Session["nome"] = txtNome.Text;
            }
        }

        
    }
}