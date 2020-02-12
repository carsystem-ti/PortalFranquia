using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.componentes.OS;
using PortalFranquia.dao;
using PortalFranquia.dao.OS;

namespace PortalFranquia.modulos.OS
{
    public partial class aprovaTroca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.setNomeModulo(Page, "O.S. - Aprovação Plus");
            Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            daoOSConsulta DaoConsultaOS = new daoOSConsulta();
           // Utils.ConfiguraPesquisaMasterPage(Master, new Dictionary<string, string>() { { "Contrato", "nr_Contrato" }, { "Placa", "nr_Placa" } }, DaoConsultaOS, RetornoPesquisa, RetornoErro);
        }

        private void RetornoPesquisa(Object retorno)
        {
            daoOSConsulta DaoConsulta = (daoOSConsulta)retorno;

            txtNomeProp.Text = DaoConsulta.dsNome;
            txtCPFCNPJProp.Text = DaoConsulta.nrCPFCNPJ;
            txtRGProp.Text = DaoConsulta.nrRGInsEstadual;
            txtContrato.Value = DaoConsulta.nrPedido;
            
        }

        private void RetornoErro(Exception ex)
        {
            lbMensErro.Text = ex.Message;
            lbMensErro.Visible = true;
        }

        protected void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string retorno = null;
                TrocaAprovacao trocaAprovacao = new TrocaAprovacao();
                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                retorno= trocaAprovacao.gravaPedido(txtContrato.Value, rbFisica.Checked == true ? 0 : 1, txtNomeNovo.Text, txtCPFCNPJ.Text, txtRG.Text, acessoLogin.cdCetec).ToString();
                CarSystem.Banco.BoaVista.BoaVista bv = new CarSystem.Banco.BoaVista.BoaVista("userFranquia", "2FACA908-D931-4DA8-BC99-497C7B515021", "principal", CarSystem.Tipos.Servidores.Fury);
                CarSystem.Banco.BoaVista.BoaVista.Consulta c = bv.efetuaConsultaWS(txtCPFCNPJ.Text.Replace(".","").Replace("-","").Replace("/",""), false);
                txtNomeNovo.Text = c.nome;
                lbProtocoloEnvio.Text = "Consulta enviada com sucesso ! Numero do envio: " + retorno.ToString() + "Status: " + c.statusConsulta.ToString();
            }
            catch (Exception ex)
            {
                lbMensErro.Text = "Erro ao enviar consulta: " + ex.Message;
                lbMensErro.Visible = true;
            }
        }
    }
}