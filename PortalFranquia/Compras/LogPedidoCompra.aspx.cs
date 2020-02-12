using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;

namespace PortalFranquia
{
    public partial class LogPedidoCompra : System.Web.UI.Page
    {
        daoPedido bdpc = new daoPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                txtnome.Text = acessoLogin.Nome;
                txtCT.Text = Session["pedido"].ToString();
                BuscaLog();
            }
        }
        private void BuscaLog()
        {
            bdpc._pedido= Convert.ToInt32(Session["pedido"].ToString());
            DataSet log = bdpc.getLogCompra();
            if (log.Tables[0].Rows.Count > 0)
            {
                txtRetornaMensagem.Text = log.Tables[0].Rows[0]["ds_observacao"].ToString();
                txtCT.Text = Session["pedido"].ToString();
                
            }
            else
            {
               // lblmensagem.Text = "Não consta Log para essa CT";
              //  txtNovaMensagem.Text = "";
            }

        }
        public void EnviaMensagem()
        {
            if (txtNovaMensagem.Text != "")
            {
                bdpc._pedido = Convert.ToInt32(txtCT.Text);
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                bdpc._mensagem = "Usuario: " + txtnome.Text + " DataLog: " + DateTime.Now + "-" + txtNovaMensagem.Text + "\r\n" + "-----------------------" + " \r\n " + txtRetornaMensagem.Text;
                bool retorna = bdpc.GravaLogCompra();
                if (retorna == true)
                {
                    BuscaLog();
                }
                else
                {
                }
            }
            else
            {
                
                
            }

        }
        
        protected void btnMensagem_Click(object sender, EventArgs e)
        {
            EnviaMensagem();    
        }

       

       
    }
}