using PortalFranquia.dao;
using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Cliente
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        DataTable dsCadastro = new DataTable();
        daoDocumentos docto = new daoDocumentos();

        protected void Page_Load(object sender, EventArgs e)
        {
            string strSessionUser = "";
            string strSessionGrupo = "";
            string url;

            ValidaUsuario();

            if (!IsPostBack)
            {
                strSessionUser = Request.QueryString["txtSessionUser"];
                strSessionGrupo = Request.QueryString["txtGrupo"];

                strSessionUser = (strSessionUser == null) ? "000000" : strSessionUser;
                strSessionGrupo = (strSessionGrupo == null) ? "CETEC" : strSessionGrupo;

                Session.Add("strUser", strSessionUser);
                Session.Add("strGrupo", strSessionGrupo);
            }
            else
            {
                strSessionUser = Session["strUser"].ToString();
                strSessionGrupo = Session["strGrupo"].ToString();
            }
        }

        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            VerificaContrato();
        }

        private void VerificaContrato()
        {
            string strErro;
            


            if (txtContrato.Text.ToString() == "" && txtPlaca.Text.ToString() == "" && txtCpfCnpj.Text.ToString() == "")
            {
                strErro = "1";

                mensagemErro();
                pnlCadastro.Visible = false;

            }
            else
            {
                getDadosCadastroCliente();
            }
        }

        private void mensagemErro()
        {
            string url;
            string strMensagem;

            strMensagem = "Favor digitar o numero do CONTRATO, PLACA ou CPF/CNPJ !!!";
            url = "Erro.aspx?strMensagem=" + strMensagem.ToString();

            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=100,WIDTH=600,top=300,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");

        }

        private void getDadosCadastroCliente()
        {
            string contrato = "";
            string placa = "";
            string CPFCNPJ = "";

            string ds_atendimento;

            //DataTable dsCadastro = new DataTable();

            contrato = txtContrato.Text.ToString();
            placa = txtPlaca.Text.ToString();
            CPFCNPJ = txtCpfCnpj.Text.ToString();

            DataTable dsUltimaOS = new DataTable();
            daoVeiculo ultimaOS = new daoVeiculo();

            // Verifica ultima OS se é de RETIRADA para TDV
            dsUltimaOS = ultimaOS.getUltimaOS(txtContrato.Text.ToString());

            if (dsUltimaOS.Rows[0]["ds_chamado"].ToString() != "Retirada")
            {
                // btnVeiculo.Enabled = false;
                btnVeiculo.ToolTip = "Ultima OS não é de RETIRADA";
            }

            dsCadastro = docto.getDadosCadastro(contrato.ToString(), placa.ToString(), CPFCNPJ.ToString());

            if (dsCadastro.Rows.Count != 0)
            {
                pnlCadastro.Visible = true;

                lblContrato.Text = dsCadastro.Rows[0]["Contrato"].ToString();

                if (dsCadastro.Rows[0]["status de atendimento"].ToString() == "2")
                {
                    btnIncObs.Enabled = false;
                }

                //Status Equipamento
                lblStatusEquipamento.Text = dsCadastro.Rows[0]["Status Equipamento"].ToString();

                //Status de Atendimento
                switch (dsCadastro.Rows[0]["status de atendimento"].ToString())
                {
                    case "0":
                        ds_atendimento = "Normal";
                        lblAtendimento.Text = ds_atendimento.ToString();
                        break;
                    case "1":
                        ds_atendimento = "Inadimplente";
                        lblAtendimento.Text = ds_atendimento.ToString();
                        break;
                    case "2":
                        ds_atendimento = "Inativo";
                        lblAtendimento.Text = ds_atendimento.ToString();
                        break;
                }

                //Status Venda
                switch (dsCadastro.Rows[0]["Status Venda"].ToString())
                {
                    case "0":
                        ds_atendimento = "Confirmado";
                        lblStatusVenda.Text = ds_atendimento.ToString();
                        break;
                    case "1":
                        ds_atendimento = "Pendente";
                        lblStatusVenda.Text = ds_atendimento.ToString();
                        break;
                    case "2":
                        ds_atendimento = "Em Cancelado";
                        lblStatusVenda.Text = ds_atendimento.ToString();
                        break;
                    case "3":
                        ds_atendimento = "Em Cancelamento";
                        lblStatusVenda.Text = ds_atendimento.ToString();
                        break;
                }
            }
            else
            {
                string url;
                string strMensagem;

                strMensagem = "Favor digitar o numero do CONTRATO, PLACA ou CPF/CNPJ, novamente, pois o mesmo não foi encontrado !!!";
                url = "Erro.aspx?strMensagem=" + strMensagem.ToString();

                Response.Write("<script> window.open( '" + url + "','_blank', 'fullscreen=No', 'width=300', 'height=300', 'top=100', 'left=100', 'resizable=No', 'status=No', 'scrollbars=No', 'location=No'); </script>");
            }

            lblCliente.Text = dsCadastro.Rows[0]["Nome"].ToString();

            if (dsCadastro.Rows[0]["Cpf"].ToString() != "")
            {
                lblCpfCnpj.Text = dsCadastro.Rows[0]["Cpf"].ToString();
            }
            else
            {
                lblCpfCnpj.Text = dsCadastro.Rows[0]["Cnpj"].ToString();
            }

            lblRgIe.Text = dsCadastro.Rows[0]["Rg"].ToString();

            DateTime DataNascimento = Convert.ToDateTime(dsCadastro.Rows[0]["Data Nascimento"].ToString());
            lblDtNascimento.Text = DataNascimento.Day + "/" + DataNascimento.Month + "/" + DataNascimento.Year;

            lblTpVeiculo.Text = dsCadastro.Rows[0]["Tipo de Veiculo"].ToString();
            lblFabricante.Text = dsCadastro.Rows[0]["Fabricante"].ToString();
            lblModelo.Text = dsCadastro.Rows[0]["Modelo"].ToString();
            lblPlaca.Text = dsCadastro.Rows[0]["Placa"].ToString();
            lblAno.Text = dsCadastro.Rows[0]["Ano"].ToString();
            lblRenavan.Text = dsCadastro.Rows[0]["Renavan do veiculo"].ToString();
            lblChassi.Text = dsCadastro.Rows[0]["Chassi do Veiculo"].ToString();
            lblCombustivel.Text = dsCadastro.Rows[0]["Combustivel"].ToString();
            lblCor.Text = dsCadastro.Rows[0]["Cor"].ToString();

            lblTelResidencial.Text = dsCadastro.Rows[0]["Telefone"].ToString();
            lblTelCelular.Text = dsCadastro.Rows[0]["Celular"].ToString();
            lblTelComercial.Text = dsCadastro.Rows[0]["Tel. Comercial"].ToString();

            txtObs.Text = dsCadastro.Rows[0]["Observação"].ToString();

            DateTime Instalacao = Convert.ToDateTime(dsCadastro.Rows[0]["Data da instalaçao"].ToString());
            lblInstalacao.Text = Instalacao.Day + "/" + Instalacao.Month + "/" + Instalacao.Year;

            lblAtivadoPor.Text = dsCadastro.Rows[0]["Ativado por"].ToString();

            DateTime ativadoEm = Convert.ToDateTime(dsCadastro.Rows[0]["Ativado em"].ToString());
            DateTime ativadoAs = Convert.ToDateTime(dsCadastro.Rows[0]["Ativado as"].ToString());

            lblAtivadoEm.Text = ativadoEm.Day + "/" + ativadoEm.Month + "/" + ativadoEm.Year + " - " + ativadoAs.Hour + ":" + ativadoAs.Minute;

            lblInstaladora.Text = dsCadastro.Rows[0]["Instaladora"].ToString();
            lblInstalador.Text = dsCadastro.Rows[0]["Instalador"].ToString();

            DateTime DataVenda = Convert.ToDateTime(dsCadastro.Rows[0]["Data da venda"].ToString());
            lblDataVenda.Text = DataVenda.Day + "/" + DataVenda.Month + "/" + DataVenda.Year;

            DateTime ConfirmadaEm = Convert.ToDateTime(dsCadastro.Rows[0]["Confirmação da venda"].ToString());
            lblConfirmadaEm.Text = ConfirmadaEm.Day + "/" + ConfirmadaEm.Month + "/" + ConfirmadaEm.Year;

            lblVendedor.Text = dsCadastro.Rows[0]["Vendedor"].ToString();

            DateTime RenovacaoAte = Convert.ToDateTime(dsCadastro.Rows[0]["Prox. renovação"].ToString());
            lblRenovacaoAte.Text = RenovacaoAte.Day + "/" + RenovacaoAte.Month + "/" + RenovacaoAte.Year;

            
        }

        protected void btnEndereco_Click(object sender, EventArgs e)
        {
            carregaEndereco();
        }

        private void carregaEndereco()
        {
            string url;

            string strCep;
            string strEndereco;
            string strNumero;
            string strComplemento;
            string strBairro;
            string strCidade;
            string strUf;

            string strReferencia;
            string strRegiao;

            dsCadastro = docto.getDadosCadastro(txtContrato.Text.ToString(), txtPlaca.Text.ToString(), txtCpfCnpj.Text.ToString());

            strCep = dsCadastro.Rows[0]["Cep"].ToString();
            strEndereco = dsCadastro.Rows[0]["endereco"].ToString();
            strNumero = dsCadastro.Rows[0]["Numero Residencial"].ToString();
            strComplemento = dsCadastro.Rows[0]["Complemento"].ToString();
            strBairro = dsCadastro.Rows[0]["Bairro"].ToString();
            strCidade = dsCadastro.Rows[0]["Cidade"].ToString();
            strUf = dsCadastro.Rows[0]["Uf"].ToString();

            strReferencia = dsCadastro.Rows[0]["Ponto de referencia"].ToString();
            strRegiao = dsCadastro.Rows[0]["Região"].ToString();

            if (txtContrato.Text.ToString() != "")
            {
                url = "EnderecoCliente.aspx?txtCep=" + strCep.ToString() + "&txtEndereco=" + strEndereco.ToString() + "&txtNumero=" + strNumero.ToString() + "&txtComplemento=" + strComplemento.ToString() + "&txtBairro=" + strBairro.ToString() + "&txtCidade=" + strCidade.ToString() + "&txtUf=" + strUf.ToString() + "&txtReferencia=" + strReferencia.ToString() + "&txtRegiao=" + strRegiao.ToString();

                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=200,WIDTH=900,top=400,left=50,toolbar=no,scrollbars=no,resizable=yes');</script>");

            }
        }

        protected void btnIncObs_Click(object sender, EventArgs e)
        {
            IncluirObs();
        }

        private void IncluirObs()
        {
            string url;

            url = "IncluirObservacoesCadastro.aspx?txtContrato=" + txtContrato.Text.ToString() + "&txtNome=" + lblCliente.Text.ToString();
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=250,WIDTH=555,top=250,left=670,toolbar=no,scrollbars=no,resizable=yes');</script>");

        }
        protected void btnAlterarCadastro_Click(object sender, EventArgs e)
        {
            AlterarDadosCadastro();
        }

        private void AlterarDadosCadastro()
        {
            throw new NotImplementedException();
        }

        protected void btnVeiculo_Click(object sender, EventArgs e)
        {
            AlterarDadosVeiculo();
        }

        private void AlterarDadosVeiculo()
        {
            string strContrato;
            string url;

            if (txtContrato.Text.ToString() != "")
            {
                strContrato = txtContrato.Text.ToString();

                url = "Veiculo.aspx?txtContrato=" + strContrato.ToString();
                Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=250,WIDTH=1200,top=450,left=50,toolbar=no,scrollbars=no,resizable=yes');</script>");

            }
        }

        protected void btnProprietario_Click(object sender, EventArgs e)
        {
            AlteraDadosProprietário();
        }

        private void AlteraDadosProprietário()
        {
            throw new NotImplementedException();
        }

        protected void btnCompras_Click(object sender, EventArgs e)
        {
            buscaCompras();
        }

        private void buscaCompras()
        {
            string url;

            url = "Compras.aspx?txtContrato=" + txtContrato.Text.ToString();
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=500,WIDTH=1400,top=100,left=50,toolbar=no,scrollbars=no,resizable=yes');</script>");
        }
    }
}