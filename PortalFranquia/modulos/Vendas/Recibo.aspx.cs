using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;
using System.Data;
using System.Configuration;

namespace PortalFranquia
{
    public partial class Recibo : System.Web.UI.Page
    {
        daoRecibo bdr = new daoRecibo();
        
        int pedido = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            pedido=Convert.ToInt32(Session["pedido"].ToString());
            ImprimiRecibo();
        }
        private void ImprimiRecibo()
        {
            int pedido = Convert.ToInt32(Session["pedido"].ToString()); ;
            DataSet ds = new DataSet();
            ds = bdr.getRecibo(pedido);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblcontrato.Text = ds.Tables[0].Rows[0]["nr_contrato"].ToString();
                lbldataEmissao.Text = ds.Tables[0].Rows[0]["dt_pedido"].ToString();
                lblnome.Text = ds.Tables[0].Rows[0]["ds_cliente"].ToString();
                lblendereco.Text = ds.Tables[0].Rows[0]["ds_endereco"].ToString();
                lblBairro.Text = ds.Tables[0].Rows[0]["ds_bairro"].ToString();
                lblCidade.Text = ds.Tables[0].Rows[0]["ds_cidade"].ToString();
                lbldocumento.Text = ds.Tables[0].Rows[0]["ds_documento"].ToString();
                lbldocumento.Text = ds.Tables[0].Rows[0]["ds_documento"].ToString();
                lbluf.Text = ds.Tables[0].Rows[0]["ds_uf"].ToString();
                lblrg.Text = ds.Tables[0].Rows[0]["nr_rg"].ToString();
                DataTable dtItens = new DataTable();
                dtItens = bdr.getReciboItens(pedido);
                if (dtItens.Rows.Count > 0)
                {
                    gridDetalhes.DataSource=dtItens;
                    gridDetalhes.DataBind();
                    decimal totalcar=0;
                    decimal totalFranquia=0;
                    decimal porcentagem=0;
                    decimal percentual=0;
                    decimal adicional = 0;
                    decimal sobra = 0;
                    foreach (DataRow dw in dtItens.Rows)
                    {
                        string tpOrigem = dw[2].ToString();
                        if (tpOrigem == "C")
                        {
                            lblNFcar.Visible = true;
                            lblValorCarsystem.Visible = true;
                            decimal valor = Convert.ToDecimal(dw[1].ToString());
                            int produto=Convert.ToInt32(dw[3].ToString());
                            switch (produto)
                            {
                                case 22:
                                     porcentagem = Convert.ToDecimal(ConfigurationManager.AppSettings[("pcHabilitacao")].ToString());
                                     percentual = porcentagem / Convert.ToInt32("100"); // 2%
                                     adicional = valor - (percentual * valor);
                                    totalcar += adicional;
                                     sobra = valor - adicional;
                                    totalFranquia += sobra;
                                    break;
                                case 21:
                                    porcentagem = Convert.ToDecimal(ConfigurationManager.AppSettings[("pcAss24hs")].ToString());
                                    percentual  = porcentagem / Convert.ToInt32("100"); // 2%
                                     adicional = valor - (percentual * valor);
                                    totalcar += adicional;
                                     sobra = valor - adicional;
                                    totalFranquia += sobra;
                                    break;
                                case 23:
                                    porcentagem = Convert.ToDecimal(ConfigurationManager.AppSettings[("pcAss24hs")].ToString());
                                    percentual = porcentagem / Convert.ToInt32("100"); // 2%
                                    adicional = valor - (percentual * valor);
                                    totalcar += adicional;
                                    sobra = valor - adicional;
                                    totalFranquia += sobra;
                                    break;
                                default:
                                    totalcar += valor;
                                    break;
                            }
                        }
                        else
                        {
                            lblNFFranquia.Visible = true;
                            lblValorFranquia.Visible = true;
                            decimal valorFranquia = Convert.ToDecimal(dw[1].ToString());
                            totalFranquia +=valorFranquia;
                        }
                    }
                    lblValorCarsystem.Text = Decimal.Round(Convert.ToDecimal(totalcar), 2).ToString();
                    lblValorFranquia.Text = Decimal.Round(Convert.ToDecimal(totalFranquia), 2).ToString();
                    
                }
                VisibleTrue();
            }


        
        }
        private void VisibleTrue()
        {
            lblcontrato.Visible = true;
            lbldataEmissao.Visible = true;
            lblnome.Visible = true;
            lblendereco.Visible = true;
            lblBairro.Visible = true;
            lblCidade.Visible = true;
            lbldocumento.Visible = true;
            lbldocumento.Visible = true;
            lbluf.Visible = true;
            lblrg.Visible = true;
        }
    }
}