using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;

namespace PortalFranquia.componentes.OS
{
    public partial class dadosCliente : System.Web.UI.UserControl
    {

        public string setTituloTipoOS
        {
            private get
            {
                return txtTipoOS.Text;
            }

            set
            {
                txtTipoOS.Text = value;
            }
        }

        public void PreencheDados(daoOSConsulta DAOConsulta)
        {
            txtPlaca.Text = DAOConsulta.dsPlaca;
            txtContrato.Text = DAOConsulta.nrPedido;
            txtCliente.Text = DAOConsulta.dsNome;
            txtVeiculo.Text = DAOConsulta.dsModelo;
            txtIDAtual.Text = DAOConsulta.nrIDAtual;
            txtTipoOS.Text = DAOConsulta.nw_dsTipoOS;
            Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}