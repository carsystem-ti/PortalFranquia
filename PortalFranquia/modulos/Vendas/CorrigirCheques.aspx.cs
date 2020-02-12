using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.Bordero;
using System.Data;
using PortalFranquia.dao;
namespace PortalFranquia.modulos.Vendas
{
    public partial class CorrigirCheques : System.Web.UI.Page
    {
        daoPedidoVendaPagamento bdvp = new daoPedidoVendaPagamento();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                if ((acessoLogin.dsTipo != "G") && (acessoLogin.dsTipo != "X"))
                {
                    Utils.SemPermissão(Response, Session);
                    
                }

                ValidaAcesso();
                getFranquiasCetecs();
                Utils.setVoltarUrl(Page, Session, "HomeVendas.aspx");
            }
        }

        private void getFranquiasCetecs()
        {
            daoPedidoVenda bdpv = new daoPedidoVenda();
            DataTable dtFranquias = new DataTable();
            dtFranquias = bdpv.getFranquiaCetecs();
            if (dtFranquias.Rows.Count > 0)
            {
                dropfranquias.DataSource = dtFranquias;
                dropfranquias.DataBind();
                dropfranquias.Items.Insert(0, "Selecione");

            }

        }

        private void Buscar()
        {
            int pedido = Convert.ToInt32(txtConsulta.Text);
            DataTable dt = new DataTable();
            DaoBordero dados = new DaoBordero();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int id_franquia = acessoLogin.idFranquia;
            if (id_franquia == 0 && dropfranquias.SelectedValue != "Selecione")
            {
                id_franquia = Convert.ToInt32(dropfranquias.SelectedValue);
            }

            dt = dados.pro_getCorrigirCheque(pedido,id_franquia);
            if (dt.Rows.Count > 0)
            {
                GvBordero.DataSource = dt;
                GvBordero.DataBind();
            }
            else
            {

                dt = dados.pro_getCorrigirChequeTroca(pedido, id_franquia);
                if (dt.Rows.Count > 0)
                {
                    GvBordero.DataSource = dt;
                    GvBordero.DataBind();
                }
                else
                {
                    dvLeitura.Visible = false;
                    dadosCheques.Visible = false;
                    GvBordero.DataBind();
                }
            }

        }
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar();

        }
        private void ValidaAcesso()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idGrupo == 7 || acessoLogin.idGrupo == 12 || acessoLogin.idGrupo == 2 || acessoLogin.idGrupo == 33)
            {
                dropfranquias.Visible = true;
            }
            else
            {
                dropfranquias.Visible = false;
            }
        }
        protected void chkSelecioner_CheckedChanged(object sender, EventArgs e)
        {
            int contador = 0;  
            foreach (GridViewRow row in GvBordero.Rows)
            {

                CheckBox ch = (CheckBox)row.FindControl("chkSelecionar");
                if (ch.Checked != false && ch != null)
                {
                        contador = contador + 1;
                        if (contador == 1)
                        {
                            txtCodigo.Text = row.Cells[2].Text;
                            txtParcela.Text = Server.HtmlDecode(row.Cells[4].Text);
                            txtBanco.Text = Server.HtmlDecode(row.Cells[12].Text);
                            txtConta.Text = Server.HtmlDecode(row.Cells[13].Text);
                            txtAgencia.Text = Server.HtmlDecode(row.Cells[8].Text);
                            txtCheque.Text = Server.HtmlDecode(row.Cells[11].Text);
                            txtVencimento.Text = Server.HtmlDecode(row.Cells[6].Text);
                            dadosCheques.Visible = true;
                            dvLeitura.Visible = true;
                            txtValor.Text = Server.HtmlDecode(row.Cells[5].Text);
                        }
                        else
                        {
                            ch.Checked = false;
                        }
                 
                }
            }
        }
         protected void txtLeitura_TextChanged(object sender, EventArgs e)
        {
            if (txtLeitura.Text != "")
            {
                txtBanco.Text = txtLeitura.Text.Substring(1, 3);
                txtConta.Text = txtLeitura.Text.Substring(23, 9);
                txtAgencia.Text = txtLeitura.Text.Substring(4, 4);
                txtCheque.Text = txtLeitura.Text.Substring(13, 6);
                txtLeitura.Focus();
              
            }
            else
            {
            }
        }

         protected void Button1_Click(object sender, EventArgs e)
         {

             txtBanco.Text = txtLeitura.Text.Substring(1, 3);
             txtConta.Text = txtLeitura.Text.Substring(23, 9);
             txtAgencia.Text = txtLeitura.Text.Substring(4, 4);
             txtCheque.Text = txtLeitura.Text.Substring(13, 6);
             txtLeitura.Focus();
         }

         protected void btnAtualizar_Click(object sender, EventArgs e)
         {

             if (txtCodigo.Text != "" && txtConsulta.Text != "" && txtParcela.Text != "" && txtLeitura.Text != "" && txtCheque.Text != "" && txtBanco.Text != "" && txtConta.Text != "")
             {
                 bdvp._idTipo = 1;
                 if (chktroca.Checked == true)
                 {
                     bdvp._idTipo = 2;
                 }
                 bdvp._id_parcela = Convert.ToInt32(txtCodigo.Text);
                 bdvp._idPedido = Convert.ToInt32(txtConsulta.Text);
                 bdvp._pcParcela = Convert.ToInt32(txtParcela.Text);
                 bdvp._nrAgencia = txtAgencia.Text;
                 bdvp._nrConta = txtConta.Text;
                 bdvp._ccm = Server.HtmlDecode(txtLeitura.Text);
                 bdvp._nrBanco = txtBanco.Text;
                 bdvp._nr_cheque = txtCheque.Text;
                 bdvp.pro_setAlterVendaPagamento();
                 Buscar();
             }
             else
             {
                 
             }
         }
    }
}