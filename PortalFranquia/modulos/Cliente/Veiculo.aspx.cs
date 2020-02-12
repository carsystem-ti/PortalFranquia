using PortalFranquia.dao;
using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Cliente
{
    public partial class Veiculo : System.Web.UI.Page
    {
        string strSessionUser = "";
        string strSessionGrupo = "";
        string strContrato = "";

        protected void Page_Load(object sender, EventArgs e)
        {

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

            strContrato = Request.QueryString["txtContrato"];

            //VerificaUltimaOS(strContrato.ToString());

            CarregaVeiculoAtual(strContrato.ToString());

        }

        //private void VerificaUltimaOS(string strContrato)
        //{
        //    DataTable dsUltimaOS = new DataTable();
        //    daoVeiculo ultimaOS = new daoVeiculo();

        //    dsUltimaOS = ultimaOS.getUltimaOS(strContrato.ToString());

        //    if (dsUltimaOS.Rows[0]["ds_chamado"].ToString() != "Retirada")
        //    {
        //        string strMensagemErro;
        //        strMensagemErro = "Ultima OS não de Retirada.";

        //        mensagemErro(strMensagemErro);
        //        btnTrocaVeiculo.Enabled = true;

        //    } else
        //    {
        //        CarregaVeiculoAtual(strContrato.ToString());
        //    }
        //}

        //private void mensagemErro(string strMens)
        //{
        //    string url;

        //    url = "Erro.aspx?strMensagem=" + strMens.ToString();
        //    Response.Write("<script language='javascript'> window.open('" + url + "', 'window','_blank','HEIGHT=100,WIDTH=600,top=300,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");
        //}

        private void CarregaVeiculoAtual(string strContrato)
        {

            DataTable dsVeiculo = new DataTable();
            daoVeiculo veiculoAtual = new daoVeiculo();

            dsVeiculo = veiculoAtual.getDadosVeiculo(strContrato.ToString());

            lblPlaca.Text = dsVeiculo.Rows[0]["Placa"].ToString();
            lblTipo.Text = dsVeiculo.Rows[0]["Tipo de Veiculo"].ToString();
            lblModelo.Text = dsVeiculo.Rows[0]["Modelo"].ToString();
            lblFabricante.Text = dsVeiculo.Rows[0]["Fabricante"].ToString();
            lblCor.Text = dsVeiculo.Rows[0]["Cor"].ToString();
            lblComb.Text = dsVeiculo.Rows[0]["Combustivel"].ToString();
            lblChassi.Text = dsVeiculo.Rows[0]["Chassi do veiculo"].ToString();
            lblRenavan.Text = dsVeiculo.Rows[0]["Renavan do veiculo"].ToString();
            lblAno.Text = dsVeiculo.Rows[0]["Ano"].ToString();
        }

        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }

        protected void btnTrocaVeiculo_Click(object sender, EventArgs e)
        {
            string strMensagemErro;

            if (txtPlaca.Text.ToString() != "")
            {
                if (txtChassi.Text.ToString() != "")
                {
                    if (txtRenavan.Text.ToString() != "")
                    {
                        if (txtAno.Text.ToString() != "")
                        {
                            TrocaVeiculo();
                        }
                        else
                        {
                            lblMensagemErro.Text = "Favor digitar o ANO do veículo novo!!!";
                        }
                    }
                    else
                    {
                        lblMensagemErro.Text = "Favor digitar o RENAVAN do veículo novo!!!";
                    }
                }
                else
                {
                    lblMensagemErro.Text = "Favor digitar o CHASSI do veículo novo!!!";
                }
            }
            else
            {
                lblMensagemErro.Text = "Favor digitar a PLACA do veículo novo!!!";
            }
        }

        private void TrocaVeiculo()
        {
            daoVeiculo veiculo = new daoVeiculo();

            int _nr_id_troca;
            string _ds_contrato;
            string _ds_user;
            string _ds_estacao;
            string _ds_motivo;
            int _nr_troca_veiculo;
            string _ds_placa;
            string _ds_tipo;
            string _ds_modelo;
            string _ds_chassi;
            string _ds_renavan;
            string _ds_cor;
            string _ds_comb;
            string _ds_fabricante;
            Int32 _nr_ano_veiculo;

            _nr_id_troca = 0;
            _ds_contrato = strContrato.ToString();
            _ds_user = strSessionUser.ToString();
            _ds_estacao = "10.0.0.";
            _ds_motivo = "Trocou o carro";
            _nr_troca_veiculo = 0;
            _ds_placa = txtPlaca.Text.ToString();
            _ds_tipo = ddlTipo.SelectedValue.ToString();
            _ds_modelo = ddlModelo.SelectedValue.ToString();
            _ds_chassi = txtChassi.Text.ToString();
            _ds_renavan = txtRenavan.Text.ToString();
            _ds_cor = ddlCor.SelectedValue.ToString();
            _ds_comb = ddlComb.SelectedValue.ToString();
            _ds_fabricante = ddlFabricante.SelectedValue.ToString();
            _nr_ano_veiculo = Convert.ToInt32(txtAno.Text.ToString());

            veiculo.pro_setTrocaVeiculo(_nr_id_troca, _ds_contrato, _ds_user, _ds_estacao, _ds_motivo, _nr_troca_veiculo, _ds_placa, _ds_tipo, _ds_modelo, _ds_chassi, _ds_renavan, _ds_cor, _ds_comb, _ds_fabricante, _nr_ano_veiculo);

        }
    }
}