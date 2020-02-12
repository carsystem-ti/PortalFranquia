using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;
using PortalFranquia.dao.Vourcher;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Configuration;

    
namespace PortalFranquia.modulos.Vendas
{
    public partial class VendaVourcher : System.Web.UI.Page
    {
        
        
        public static string usuario;
        daoVourcher bdv = new daoVourcher();
        DataTable iTable = new DataTable();

        VoucherPordutos vp = new VoucherPordutos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    Utils.setVoltarUrl(Page, Session);
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string ds_tipo = acessoLogin.dsTipo;
                    if (ds_tipo != "G" && ds_tipo != "A" && ds_tipo != "C" && ds_tipo != "W")
                    {
                        Utils.SemPermissão(Response, Session);    
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public class VourcherDetalhada
        {
           
            public string id_pedido { get; set; }
            public string id_veiculo { get; set; }
            public string dt_pedido { get; set; }
            public string st_pedido { get; set; }
            public string ds_cliente { get; set; }
            public string nr_cpfCnpj { get; set; }
            public string ds_nome { get; set; }
            public string Tipo { get; set; }
            public string ds_produto { get; set; }
            public string Modelo { get; set; }
            public string ds_endereco { get; set; }
            public string nr_endereco { get; set; }
            public string ds_complemento { get; set; }
            public string ds_bairro { get; set; }
            public string ds_cidade { get; set; }
            public string ds_uf { get; set; }
            public string nr_cep { get; set; }
            public string ds_email { get; set; }
            public string nr_celular { get; set; }
            public string nr_telefone { get; set; }
            public string ds_vendedor { get; set; }
            public string nr_rg { get; set; }
            public string ds_usuPedido { get; set; }
            public string cd_supervisor { get; set; }
            public string ds_fabricante { get; set; }
            public string ds_tipoVeiculo { get; set; }
            public string ds_renavan { get; set; }
            public string ds_chassi { get; set; }
            public string ds_anoVeiculo { get; set; }
            public string ds_cores { get; set; }
            public string cd_midia { get; set; }
            public string ds_status { get; set; }
            public string  nr_contrato { get; set; }
            public string ds_placa { get; set; }
            public string tp_venda { get; set; }      
        }

        public class VoucherPordutos
        {
            public string ds_produto { get; set; }
            public string id_veiculo { get; set; }
        }
        public void BuscaDados()
        {
            if (dropFiltro.SelectedValue != "SELECIONE" && (txtBuscaDados.Text != "" || txtConsultaCpfCnpj.Text != ""))
            {
                DataSet dt = new DataSet();
                string fl_retirado = "N";
                string fl_recebimento = "2";
                string nr_os=null;
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                daoVourcher bv = new daoVourcher();
                VendaVourcher venda = new VendaVourcher();
                bv._tipo = Convert.ToInt32(dropFiltro.SelectedValue);
                if (bv._tipo == 1)
                {
                    bv._idPedido = Convert.ToInt32(txtBuscaDados.Text);
                }
                else
                {

                    bv._dsFiltro = txtConsultaCpfCnpj.Text;
                }
                dt = bv.get_Vourcher();
                if (dt.Tables[0].Rows.Count > 0)
                {
                    txtDataPedido.Text = dt.Tables[0].Rows[0]["dt_pedido"].ToString();
                    txtNumeroPedido.Text = dt.Tables[0].Rows[0]["id_pedido"].ToString();
                    txtStatusPedido.Text = dt.Tables[0].Rows[0]["st_pedido"].ToString();
                    txtCpfCnpj.Text = dt.Tables[0].Rows[0]["nr_cpfCnpj"].ToString();
                    txtRg.Text = dt.Tables[0].Rows[0]["nr_rg"].ToString();
                    txtNome.Text = dt.Tables[0].Rows[0]["ds_cliente"].ToString();
                    txtCep.Text = dt.Tables[0].Rows[0]["nr_cep"].ToString();
                    txtNumero.Text = dt.Tables[0].Rows[0]["nr_endereco"].ToString();
                    txtComplemento.Text = dt.Tables[0].Rows[0]["ds_complemento"].ToString();
                    txtBairro.Text = dt.Tables[0].Rows[0]["ds_bairro"].ToString();
                    txtCidade.Text = dt.Tables[0].Rows[0]["ds_cidade"].ToString();
                    txtUF.Text = dt.Tables[0].Rows[0]["ds_uf"].ToString();
                    txtTelefone.Text = dt.Tables[0].Rows[0]["nr_telefone"].ToString();
                    txtCelular.Text = dt.Tables[0].Rows[0]["nr_celular"].ToString();
                    txtEmail.Text = dt.Tables[0].Rows[0]["ds_email"].ToString();
                    txtEndereco.Text = dt.Tables[0].Rows[0]["ds_endereco"].ToString();
                    txtMidia.Text = dt.Tables[0].Rows[0]["cd_midia"].ToString();
                    txtVendedor.Text = dt.Tables[0].Rows[0]["ds_vendedor"].ToString();
                    fl_retirado = dt.Tables[0].Rows[0]["fl_retirado"].ToString();
                    fl_recebimento = dt.Tables[0].Rows[0]["id_tipoRecebimento"].ToString();
                    BuscaVeiculos(Convert.ToInt32(txtNumeroPedido.Text));
                    BuscaPagamentos(Convert.ToInt32(txtNumeroPedido.Text));
                    BuscaCoresAutomotivas();
                    BuscaDadosProdutos();
                    DataSet  ds_os = bv.getValidaStatusOS(Convert.ToInt32(txtNumeroPedido.Text));
                    if (ds_os.Tables[0].Rows.Count > 0)
                    {
                        nr_os = ds_os.Tables[0].Rows[0]["nr_os"].ToString();
                    }
                    if (txtStatusPedido.Text == "CONFIRMADO") 
                    {
                        lblmensagem.Text = "";
                        btnValidaPlaca.Visible = true;
                       
                    }
                    else if (txtStatusPedido.Text == "PENDENTE")
                    {
                        if (fl_retirado == "S" || fl_recebimento == "1" || acessoLogin.Nome == ConfigurationManager.AppSettings[("liberado1")].ToString() || acessoLogin.Nome == ConfigurationManager.AppSettings[("liberado2")].ToString() || nr_os != null)
                        {
                            lblmensagem.Text = "";
                            btnValidaPlaca.Visible = true;

                        }
                        else
                        {
                            lblmensagem.Text = "PEDIDO COM STATUS: " + txtStatusPedido.Text + "  NÃO FOI DISTRIBUIDO OS MOTOBOY não foi passado para distribuição Motoboy, ou  usuário não tem permissão. Vendedor :  " + txtVendedor.Text;
                            lblmensagem.Visible = true;
                            gridItens.DataBind();
                            gridPagamentos.DataBind();
                            LimpaCampos();
                            btnValidaPlaca.Visible = false;
                        }

                            
                    }
                    else
                    {


                        lblmensagem.Visible = true;
                        lblmensagem.Text = "PEDIDO COM STATUS: " + txtStatusPedido.Text + " NÃO PODE SER GERADO CONTRATO,NECESSARIO CONCLUIR PEDIDO, VENDEDOR " + txtVendedor.Text;
                        btnValidaPlaca.Visible = false;

                    }
                }
                else
                {
                    gridItens.DataBind();
                    gridPagamentos.DataBind();
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "NÃO ENCONTRAMOS ESSE PEDIDO/VOURCHER";
                    LimpaCampos();
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "FAVOR PREENCHER TODOS OS DADOS";
            }
        }
        public void BuscaVeiculos(int pedido)
        {
            daoVourcher bv = new daoVourcher();
            DataTable dtProdutos = new DataTable();
            bv._idPedido = pedido;
            dtProdutos=bv.getVeiculos();
            slcprodutos.DataSource = dtProdutos;
            slcprodutos.DataBind();
            slcprodutos.Items.Insert(0, "SELECIONE");
     
        }
        [WebMethod]
        public static string Veiculos(int id_pedido)
        {
            //string retorno = "";
            string myJsonString;
            DataTable dt = new DataTable();
            daoVourcher bv = new daoVourcher();
            VendaVourcher venda = new VendaVourcher();
            bv._idPedido = id_pedido;
            var ret = venda.RetornaProdutos(bv.getVeiculos());
            myJsonString = (new JavaScriptSerializer()).Serialize(ret);

            return myJsonString;
        }
        public void BuscaCoresAutomotivas() 
        {
            DataTable dtCores = new DataTable();
            daoVourcher bv = new daoVourcher();
            dtCores = bv.getCoresAutomotivas();
            slcCores.DataSource = dtCores;
            slcCores.DataBind();
            slcCores.Items.Insert(0, "SELECIONE");
        }
        private void BuscaDadosProdutos()
        {
            if (txtNumeroPedido.Text != "")
            {
                string contrato = null;
                DataSet ds_itens = new DataSet();
                daoVourcher bdv = new daoVourcher();
                VendaVourcher venda = new VendaVourcher();
                bdv._tipo = 3;
                bdv._id_veiculo = 0;
                bdv._idPedido = Convert.ToInt32(txtNumeroPedido.Text);
                ds_itens = bdv.getVourcherPedidos();
                if (ds_itens.Tables[0].Rows.Count > 0)
                {
                    gridItens.DataSource = ds_itens;
                    gridItens.DataBind();
                    contrato = ds_itens.Tables[0].Rows[0]["nr_contrato"].ToString();
                    if (contrato != "" && Session["fl_boleto"].ToString() == "1")
                    {
                        btnIMprimir.Visible = true;
                        btnGeraContrato.Visible = false;
                    }
                    else
                    {
                        btnGeraContrato.Visible = false;
                        btnIMprimir.Visible = false;
                    }
                }
                else
                {
                    gridItens.DataBind();
                }
            }
        }
        private void BuscaItens()
        {


            if (slcprodutos.SelectedValue != "SELECIONE" && txtNumeroPedido.Text != "")
            {
                string contrato=null;
                DataSet ds_itens = new DataSet();
                daoVourcher bdv = new daoVourcher();
                VendaVourcher venda = new VendaVourcher();
                bdv._tipo = 1;
                bdv._id_veiculo = Convert.ToInt32(slcprodutos.SelectedValue);
                bdv._idPedido = Convert.ToInt32(txtNumeroPedido.Text);
                ds_itens=bdv.getItensVeiculo();
                gridItens.DataSource = ds_itens;
                gridItens.DataBind();
                
                txtFabricante.Text = ds_itens.Tables[0].Rows[0]["ds_fabricante"].ToString();
                txtModelo.Text = ds_itens.Tables[0].Rows[0]["Modelo"].ToString();
                txtTipoVeiculo.Text = ds_itens.Tables[0].Rows[0]["ds_categoria"].ToString();
                txtAno.Text = ds_itens.Tables[0].Rows[0]["ds_ano"].ToString();
                contrato=ds_itens.Tables[0].Rows[0]["nr_contrato"].ToString();
                //if(contrato != null)
                //contrato = Convert.ToInt32(ds_itens.Tables[0].Rows[0]["nr_contrato"].ToString());
                if (contrato != "")
                {
                    btnIMprimir.Visible = true;
                    btnGeraContrato.Visible = false;
                }
                else
                {
                    btnGeraContrato.Visible = true;
                    btnIMprimir.Visible = false;
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "FAVOR PREENCHER TODOS OS DADOS";
            }
            
        }

        private void getVeiculoSelecionado()
        {


            if (slcprodutos.SelectedValue != "SELECIONE" && txtNumeroPedido.Text != "")
            {
                
                DataSet ds_itens = new DataSet();
                daoVourcher bdv = new daoVourcher();
                VendaVourcher venda = new VendaVourcher();
               

                
                bdv._tipo = 1;
                bdv._id_veiculo = Convert.ToInt32(slcprodutos.SelectedValue);
                bdv._idPedido = Convert.ToInt32(txtNumeroPedido.Text);

                ds_itens = bdv.getItensVeiculo();
                gridItens.DataSource = ds_itens;
                gridItens.DataBind();
                if (ds_itens.Tables[0].Rows[0]["ds_placa"].ToString() != "")
                {
                    txtPlaca.Text = ds_itens.Tables[0].Rows[0]["ds_placa"].ToString().Replace("-","");
                    txtPlaca.Enabled = false;
                }
                else
                {

                    txtPlaca.Text = "";
                    txtPlaca.Enabled = true;
                }
                txtFabricante.Text = ds_itens.Tables[0].Rows[0]["ds_fabricante"].ToString();
                txtModelo.Text = ds_itens.Tables[0].Rows[0]["Modelo"].ToString();
                txtTipoVeiculo.Text = ds_itens.Tables[0].Rows[0]["ds_categoria"].ToString();
                txtAno.Text = ds_itens.Tables[0].Rows[0]["ds_ano"].ToString();
                btnGeraContrato.Visible = false;
                btnIMprimir.Visible = false;
                
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "FAVOR PREENCHER TODOS OS DADOS";
            }

        }
        private List<VourcherDetalhada> getValidaContrato(DataTable IValida)
        {
            List<VourcherDetalhada> listaContrato = new List<VourcherDetalhada>();
            foreach (DataRow linha in IValida.Rows)
            {
                VourcherDetalhada vs = new VourcherDetalhada();
                vs.nr_contrato = linha["Pedido"].ToString();
                vs.ds_status = linha["Status"].ToString();
                listaContrato.Add(vs);
            }
            return listaContrato;
        }
        private void LimpaMensagem()
        {
            lblmensagem.Visible = false;
        }
        private List<VourcherDetalhada> RetornaProdutos(DataTable tabela)
        {
            List<VourcherDetalhada> listaVeiculos = new List<VourcherDetalhada>();
            foreach (DataRow linha in tabela.Rows)
            {
                VourcherDetalhada vs = new VourcherDetalhada();
                vs.ds_produto = linha["ds_produto"].ToString();
                vs.id_veiculo = linha["id_veiculo"].ToString();
                listaVeiculos.Add(vs);
            }
            return listaVeiculos;
        }
        private List<VourcherDetalhada> tpVenda(DataTable tabela)
        {
            List<VourcherDetalhada> tpvenda = new List<VourcherDetalhada>();
            VourcherDetalhada vs= new VourcherDetalhada();
            foreach (DataRow tp in tabela.Rows)
            {
                vs.tp_venda = tp["tpVenda"].ToString();
                tpvenda.Add(vs);
            }

            return tpvenda;
        }
        private List<VourcherDetalhada> RetornaItensProdutos(DataTable tabela)
        {
            List<VourcherDetalhada> listaItensVeiculos = new List<VourcherDetalhada>();
            foreach (DataRow linha in tabela.Rows)
            {
                VourcherDetalhada vs = new VourcherDetalhada();
                vs.ds_produto = linha["ds_produto"].ToString();
                vs.id_veiculo = linha["id_veiculo"].ToString();
                vs.ds_vendedor = linha["ds_vendedor"].ToString();
                vs.id_pedido = linha["id_pedido"].ToString();
                vs.Modelo = linha["Modelo"].ToString();
                vs.Tipo = linha["Tipo"].ToString();
                vs.ds_tipoVeiculo = linha["ds_categoria"].ToString();
                vs.ds_fabricante = linha["ds_fabricante"].ToString();
                vs.ds_anoVeiculo = linha["ds_ano"].ToString();
                vs.nr_contrato =linha["nr_contrato"].ToString();
                vs.ds_placa = linha["ds_placa"].ToString();

                listaItensVeiculos.Add(vs);
            }
            return listaItensVeiculos;
        }
         [System.Web.Services.WebMethod]
        public static string setContrato(int id_veiculo, int nr_pedido, string ds_produto, string ds_nome, string nr_CpfCnpj, 
                                        string nr_RG, string nr_Cep, string ds_endereco, string nr_residencial, 
                                        string ds_complemento, string ds_bairro, string ds_cidade, string ds_uf, 
                                        string ds_telefone, string ds_celular, string ds_sexo, string ds_placa, 
                                        string dt_nascimento, string ds_email,string ds_fabricante,
                                        string tp_Veiculo, string ds_modelo, string ds_AnoVeiculo, string ds_cores, string ds_combustivel,
                                        string ds_renavan, string ds_chassi, string ds_vendedor, string ds_midia)
        {
            string retorno = "";
            string myJsonString;
            int ret = 0;
            try
            {

                VendaVourcher venda = new VendaVourcher();
                daoVourcher bdc = new daoVourcher();
                DataSet dsPedido = new DataSet();
                string nr_contrato = null;
                string habilita = "N".ToString();
                DataSet dsValida = new DataSet();
                daoPedido bdv = new daoPedido();
                var tipovenda = venda.tpVenda(bdc.getTpVenda(nr_pedido));
                nr_CpfCnpj = nr_CpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "").ToString();
                bdv._nrDocumento = nr_CpfCnpj;
                dsValida = bdc.ValidaGeracaoPedidos(nr_CpfCnpj, ds_placa);
                if (dsValida.Tables[0].Rows.Count > 0)
                {
                    retorno = "Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString();
                    myJsonString = (new JavaScriptSerializer()).Serialize(retorno);
                }
                else
                {

                    bdc._dsNome = ds_nome;
                    if (nr_CpfCnpj.Length > 11)
                        bdc._tpPessoa = 1;
                    else
                        bdc._tpPessoa = 0;
                    if (bdc._tpPessoa == 0)
                        bdc._dsCpf = nr_CpfCnpj;
                    else
                        bdc._dsCnpj = nr_CpfCnpj;

                    bdc._dsRg = nr_RG;
                    bdc._dtNascimento = Convert.ToDateTime(dt_nascimento);
                    bdc._dsEndereco = ds_endereco;
                    bdc._nrResidencia = nr_residencial;
                    bdc._dsComplemento = ds_complemento;
                    bdc._dsCep = nr_Cep;
                    bdc._dsBairro = ds_bairro;
                    bdc._dsCidade = ds_cidade;
                    bdc._dsUF = ds_uf;
                    bdc._nrTelResidencial = ds_telefone;
                    bdc._nrTelCelular = ds_celular;
                    bdc._ds_pontoReferencia = ds_complemento;
                    bdc._dsEmail = ds_email;
                    bdc._tpVeiculo = tp_Veiculo;
                    bdc._ds_fabricante = ds_fabricante;
                    bdc._ds_modelo = ds_modelo;
                    bdc._ds_placa = ds_placa;
                    bdc._id_veiculo = id_veiculo;
                    DataSet dsValidaHabit = new DataSet();
                    dsValidaHabit = bdc.ValidaHabilitacao();
                    if (dsValidaHabit.Tables[0].Rows.Count > 0)
                        bdc._dt_Renova = DateTime.Now.AddMonths(12);
                    else
                        bdc._dt_Renova = DateTime.Now;
                    bdc._ds_anoVeiculo = ds_AnoVeiculo;
                    bdc._ds_cor = ds_cores;
                    bdc._ds_combustivel = ds_combustivel;
                    bdc._ds_Renavam = ds_renavan;
                    bdc._ds_Chassi = ds_chassi;
                    bdc._ds_Produto = ds_produto;

                    bdc._ds_vendedor = ds_vendedor;
                    bdc._ds_sexo = ds_sexo;
                    bdc._ds_Profissao = "1";
                    bdc._idmidia = ds_midia;
                    nr_contrato = bdc.pro_setGeraContrato();
                    if (nr_contrato != null)
                    {
                        bdc._nrcontrato = nr_contrato;
                        ret = bdc.pro_setVinculaContrato(nr_contrato);
                        return "Contrato gerado com sucesso : " + nr_contrato;
              
                    }
                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return "";
        }
         private void LimpaCampos()
         {
             txtNumeroPedido.Text = "";
             txtDataPedido.Text = "";
             txtCpfCnpj.Text = "";
             txtRg.Text = "";
             txtPlaca.Text = "";
             txtRenavan.Text = "";
             txtStatusPedido.Text="";
             txtTelefone.Text = "";
             txtCelular.Text = "";
             txtAno.Text = "";
             txtBairro.Text = "";
             txtCidade.Text = "";
             txtUF.Text = "";
             txtCep.Text = "";
             txtComplemento.Text = "";
             txtEndereco.Text = "";
             txtNumero.Text = "";
             txtNome.Text = "";
             txtModelo.Text = "";
             txtFabricante.Text = "";
             txtEmail.Text = "";
             txtTipoVeiculo.Text = "";
             txtMidia.Text = "";
             txtVendedor.Text = "";
             
         }
         public void  setContrato()
         {
             if (txtNumeroPedido.Text != "" && txtCpfCnpj.Text != "" && txtRg.Text != "" && txtPlaca.Text != "" && txtVendedor.Text != "" && txtMidia.Text != "" && txtCep.Text != "" && txtChassi.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtUF.Text != "" && txtFabricante.Text != "" && txtModelo.Text != "" && dropsexo.SelectedValue != "SELECIONE" && slcCombustivel.SelectedValue != "SELECIONE" && slcprodutos.SelectedValue != "SELECIONE" && slcCores.SelectedValue != "SELECIONE" && txtAno.Text != "" && txtTipoVeiculo.Text != "" && txtDataNascimento.Text != "" && txtBairro.Text != "" && txtCidade.Text != "" && txtNumero.Text != "")
             {
                 int ret = 0;
                 try
                 {
                     AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                     lblmensagem.Text = "";
                     VendaVourcher venda = new VendaVourcher();
                     daoVourcher bdc = new daoVourcher();
                     DataSet dsPedido = new DataSet();
                     string nr_contrato = null;
                     string habilita = "N".ToString();
                     DataSet dsValida = new DataSet();
                     daoPedido bdv = new daoPedido();
                     var tipovenda = venda.tpVenda(bdc.getTpVenda(Convert.ToInt32(txtNumeroPedido.Text)));
                     string nr_CpfCnpj = txtCpfCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "").ToString();
                     string ds_placa = txtPlaca.Text;
                     bdv._nrDocumento = nr_CpfCnpj;
                     dsValida = bdc.ValidaGeracaoPedidos(nr_CpfCnpj, ds_placa);
                     if (dsValida.Tables[0].Rows.Count > 0)
                     {
                         lblmensagem.Visible = true;
                         lblmensagem.Text = "Cpf vinculado ao contrato: " + dsValida.Tables[0].Rows[0]["Pedido"].ToString() + " com status: " + dsValida.Tables[0].Rows[0]["status"].ToString();

                     }
                     else
                     {

                         bdc._dsNome = txtNome.Text;
                         if (nr_CpfCnpj.Length > 11)
                             bdc._tpPessoa = 1;
                         else
                             bdc._tpPessoa = 0;
                         if (bdc._tpPessoa == 0)
                             bdc._dsCpf = nr_CpfCnpj;
                         else
                             bdc._dsCnpj = nr_CpfCnpj;

                         bdc._dsRg = txtRg.Text;
                         bdc._dtNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                         bdc._dsEndereco = txtEndereco.Text;
                         bdc._nrResidencia = txtNumero.Text;
                         bdc._dsComplemento = txtComplemento.Text;
                         bdc._dsCep = txtCep.Text;
                         bdc._dsBairro = txtBairro.Text;
                         bdc._dsCidade = txtCidade.Text;
                         bdc._dsUF = txtUF.Text;
                         bdc._nrTelResidencial = txtTelefone.Text;
                         bdc._nrTelCelular = txtCelular.Text;
                         bdc._ds_pontoReferencia = txtComplemento.Text;
                         bdc._dsEmail = txtEmail.Text;
                         bdc._tpVeiculo = txtTipoVeiculo.Text;
                         bdc._ds_fabricante = txtFabricante.Text;
                         bdc._ds_modelo = txtModelo.Text;
                         bdc._ds_placa = ds_placa;
                         bdc._id_veiculo = Convert.ToInt32(slcprodutos.SelectedValue);
                         DataSet dsValidaHabit = new DataSet();
                         dsValidaHabit = bdc.ValidaHabilitacao();
                         if (dsValidaHabit.Tables[0].Rows.Count > 0)
                             bdc._dt_Renova = DateTime.Now.AddMonths(12);
                         else
                             bdc._dt_Renova = DateTime.Now;
                         bdc._ds_anoVeiculo = txtAno.Text;
                         bdc._ds_cor = slcCores.SelectedValue;
                         bdc._ds_combustivel = slcCombustivel.SelectedValue;
                         bdc._ds_Renavam = txtRenavan.Text;
                         bdc._ds_Chassi = txtChassi.Text;
                         bdc._ds_Produto = slcprodutos.SelectedItem.Text;
                         bdc._id_produto = slcprodutos.SelectedValue;
                         bdc._ds_vendedor = txtVendedor.Text.Substring(0,6);
                         bdc._ds_sexo = dropsexo.SelectedValue;
                         bdc._ds_Profissao = "1";
                         bdc._idmidia = txtMidia.Text;
                         bdc._nrPedido = Convert.ToInt32(txtNumeroPedido.Text);
                         bdc._ds_usuario = acessoLogin.Nome;
                         nr_contrato = bdc.pro_setGeraContrato();
                         if (nr_contrato != null)
                         {
                             bdc._nrcontrato = nr_contrato;
                             ret = bdc.pro_setVinculaContrato(nr_contrato);
                             //if (bdc._id_produto == "000424" || bdc._id_produto == "000425" || bdc._id_produto == "000426" || bdc._id_produto == "000420" || bdc._id_produto == "000427" || bdc._id_produto == "000436" || bdc._id_produto == "000437" || bdc._id_produto == "000438" || bdc._id_produto == "000439")
                             //{
                             //    int gravar = bdc.pro_seQbe();
                             //}
                             lblmensagem.Visible = true;
                             lblmensagem.Text = "Contrato gerado com sucesso : " + nr_contrato;
                             if (Session["fl_boleto"].ToString() == "1")
                             {
                                 btnIMprimir.Visible = true;

                             }
                             else
                             {
                                 btnIMprimir.Visible = true;
                             }


                         }
                     }
                 }
                 catch (Exception ex)
                 {

                     lblmensagem.Visible=true;
                    lblmensagem.Text= ex.ToString();
                 }
             }
             else
             {
                 lblmensagem.Visible = true;
                 lblmensagem.Text = "FAVOR PREENCHER TODOS OS DADOS";
             }
         }
 private List<VourcherDetalhada> RetornaColunasDetalhada(DataTable tabela)
        {
            List<VourcherDetalhada> listaDetalhada = new List<VourcherDetalhada>();
            foreach (DataRow linha in tabela.Rows)
            {
                VourcherDetalhada vs = new VourcherDetalhada();
                vs.id_pedido = linha["id_pedido"].ToString();
                vs.id_veiculo = linha["id_Veiculo"].ToString();
                vs.dt_pedido = linha["dt_pedido"].ToString();
                vs.st_pedido = linha["st_pedido"].ToString();
                vs.ds_cliente = linha["ds_cliente"].ToString();
                vs.nr_cpfCnpj = linha["nr_cpfCnpj"].ToString();
                vs.Modelo = linha["Modelo"].ToString();
                vs.ds_endereco = linha["ds_endereco"].ToString();
                vs.ds_bairro = linha["ds_bairro"].ToString();
                vs.ds_cidade = linha["ds_cidade"].ToString();
                vs.ds_complemento = linha["ds_complemento"].ToString();
                vs.nr_endereco = linha["nr_endereco"].ToString();
                vs.ds_usuPedido = linha["ds_usuPedido"].ToString();
                vs.ds_uf = linha["ds_uf"].ToString();
                vs.cd_supervisor = linha["cd_supervisor"].ToString();
                vs.nr_cep = linha["nr_cep"].ToString();
                vs.ds_email = linha["ds_email"].ToString();
                vs.nr_celular = linha["nr_celular"].ToString();
                vs.nr_telefone = linha["nr_telefone"].ToString();
                vs.nr_rg = linha["nr_rg"].ToString();
                vs.ds_vendedor = linha["ds_vendedor"].ToString();
                vs.Tipo = linha["Tipo"].ToString();
                vs.ds_produto = linha["ds_produto"].ToString();
                vs.ds_produto = linha["ds_produto"].ToString();
                vs.cd_midia = linha["cd_midia"].ToString();
                listaDetalhada.Add(vs);
            }
            return listaDetalhada;
        }

        [WebMethod]
        public static string ImprimiBoleto(int id_pedido)
        {
            daoVourcher bdp = new daoVourcher();
            //System.Web.UI.HtmlControls.HtmlGenericControl divBoleto = new System.Web.UI.HtmlControls.HtmlGenericControl();
            //divBoleto.InnerHtml = "";

            string t = "";
            if (id_pedido > 0)

                switch ("boleto")
                {
                    case "boleto":
                     t = bdp.getExecuteBoleto(Convert.ToInt32(id_pedido));
                        break;
                    //case "taxa":
                    //   // divBoleto.InnerHtml = bdp.executaBoleto(Convert.ToInt32(id_pedido), true);
                    //    break;
                    //case "aceite":
                    //    //GridPedidosAbertos_SelectedIndexChanged(sender, null);
                    //    break;
                }
            return t;
             
             
             //"<table> " +
             //"<tr>" + 
             //"<td>" + "teste" +  "<td>" +
             //"</tr>" +
             //"</table>";
        }
        public void Limpadados()
        {
            lblmensagem.Visible = false;
            lblmensagem.Text = "";
        }
        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Limpadados();
            BuscaDados();
        }

        protected void btnValidaPlaca_Click(object sender, EventArgs e)
        {
            Limpadados();
            if (txtPlaca.Text != "" && txtDataNascimento.Text != "" && txtRenavan.Text != "" && txtChassi.Text != "" &&  slcCores.SelectedValue != "SELECIONE" && slcCombustivel.SelectedValue != "SELECIONE" && dropsexo.SelectedValue != "SELECIONE")
            {
                daoVourcher bdv = new daoVourcher();
                VendaVourcher venda = new VendaVourcher();
                VourcherDetalhada vs = new VourcherDetalhada();
                DataSet iTable = new DataSet();
                iTable = bdv.ValidaPlaca(txtPlaca.Text.Trim());
                int _countPlaca = Convert.ToInt32(iTable.Tables[0].Rows[0]["ds_Placa"].ToString());
                if (_countPlaca > 0)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "PLACA JA CONSTA NA BASE DE DADOS";
                }
                else
                {
                    BuscaItens();
                }

                
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "FAVOR PREENCHER TODOS OS DADOS";
            }
            
        }
        private void BuscaPagamentos(int pedido)
        {
            Session["fl_boleto"] = "0";
            daoVourcher bdv = new daoVourcher();
            VendaVourcher venda = new VendaVourcher();
            VourcherDetalhada vs = new VourcherDetalhada();
            DataTable iTpagamentos = new DataTable();
            iTpagamentos = bdv.getPagamentos(pedido);
            if(iTpagamentos.Rows.Count > 0)
            {
                 gridPagamentos.DataSource = iTpagamentos;
                 gridPagamentos.DataBind();

                 foreach (DataRow dw in iTpagamentos.Rows)
                 {
                     int boleto = Convert.ToInt32(dw[9].ToString());
                     if (boleto == 1)
                     {
                         Session["fl_boleto"] = 1;
                     }
                     
                 }
            }
       
        }
        protected void btnGeraContrato_Click(object sender, EventArgs e)
        {
            Limpadados();
            setContrato();
        }

        protected void btnIMprimir_Click(object sender, EventArgs e)
        {
            divBoleto.InnerHtml = "";

            daoVourcher bdp = new daoVourcher();
            divBoleto.InnerHtml = "";
            int pedido = Convert.ToInt32(txtNumeroPedido.Text);
            if (pedido > 0)
                Session["id_pedido"] = pedido.ToString();
                //divBoleto.InnerHtml = bdp.getBoletos(pedido);
            Response.Redirect("Boleto.aspx");
        }

        protected void dropFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dropFiltro_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (dropFiltro.SelectedValue == "1")
            {
             
                txtBuscaDados.Visible = true;
                txtConsultaCpfCnpj.Visible = false;
                txtConsultaCpfCnpj.Text = "";
            }
            else
            {

                txtBuscaDados.Visible = false;
                txtConsultaCpfCnpj.Visible = true;
                txtBuscaDados.Text = "";
              
            }
        }

        protected void chkAlterar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlterar.Checked == true)
            {
                
                txtAno.Enabled = true;

            }
            else
            {
                
                txtAno.Enabled = false;
            }
        }

        protected void slcprodutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            getVeiculoSelecionado();
            
            
        }
     }
}