using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class ReciboEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUser;
            string strContrato;

            string strNrRecibo;
            string strDsNome;
            string strNrDocumento;
            string strDsProduto;
            string strNrProduto;
            string strNrPlaca;
            string strDsModelo;
            string strDsCidade;
            string strNrDia;
            string strDsMes;
            string strDsAno;
            string strDsNomeEmpresa;

            strUser = Session["strUser"].ToString();
            strContrato = Request["txtContrato"].ToString();

            daoDocumentos docto = new daoDocumentos();
            DataTable dsNrOs = new DataTable();
            DataTable dsDadosReciboEntrega = new DataTable();

            dsNrOs = docto.getNrOs(strContrato.ToString());
            if (dsNrOs.Rows.Count == 0)
            {
                lblMensagem.Text = "NÃO EXISTEM DADOS PARA GERAR O RECIBO DE ENTREGA !!!";
            }
            else
            {
                dsDadosReciboEntrega = docto.getDadosReciboEntrega(dsNrOs.Rows[0]["NrOs"].ToString());

                if (dsDadosReciboEntrega.Rows.Count == 0)
                {
                    lblMensagem.Text = "NÃO EXISTEM DADOS PARA GERAR O RECIBO DE ENTREGA !!!";
                }
                else
                {
                    strNrRecibo = dsDadosReciboEntrega.Rows[0]["nr_Recibo"].ToString();

                    strDsNome = dsDadosReciboEntrega.Rows[0]["ds_Nome"].ToString();
                    strNrDocumento = dsDadosReciboEntrega.Rows[0]["nr_Documento"].ToString();
                    strDsProduto = dsDadosReciboEntrega.Rows[0]["ds_Produto"].ToString();
                    strNrProduto = dsDadosReciboEntrega.Rows[0]["nr_Produto"].ToString();

                    strNrPlaca = dsDadosReciboEntrega.Rows[0]["nr_Placa"].ToString();
                    strDsModelo = dsDadosReciboEntrega.Rows[0]["ds_Modelo"].ToString();

                    strDsCidade = dsDadosReciboEntrega.Rows[0]["ds_Cidade"].ToString();
                    strNrDia = dsDadosReciboEntrega.Rows[0]["nr_Dia"].ToString();
                    strDsMes = dsDadosReciboEntrega.Rows[0]["ds_Mes"].ToString();
                    strDsAno = dsDadosReciboEntrega.Rows[0]["nr_Ano"].ToString();
                    strDsNomeEmpresa = dsDadosReciboEntrega.Rows[0]["ds_NomeEmpresa"].ToString();

                    lblNroRecibo.Text = strNrRecibo.ToString();
                    lblNroRecibo2.Text = lblNroRecibo.Text.ToString();

                    lblDsNome.Text = strDsNome.ToString();
                    lblDsNome2.Text = lblDsNome.Text.ToString();

                    lblNrDocumento.Text = strNrDocumento.ToString();
                    lblNrDocumento2.Text = lblNrDocumento.Text.ToString();

                    lblDsProduto.Text = strDsProduto.ToString() + " - " + strNrProduto.ToString();
                    lblDsProduto2.Text = lblDsProduto.Text.ToString();

                    lblNrPlaca.Text = strNrPlaca.ToString();
                    lblNrPlaca2.Text = lblNrPlaca.Text.ToString();

                    lblDsModelo.Text = strDsModelo.ToString();
                    lblDsModelo2.Text = lblDsModelo.Text.ToString();

                    lblDsCidade.Text = strDsCidade.ToString();
                    lblDsCidade2.Text = lblDsCidade.Text.ToString();

                    lblNrDia.Text = strNrDia.ToString();
                    lblNrDia2.Text = lblNrDia.Text.ToString();

                    lblDsMes.Text = strDsMes.ToString();
                    lblDsMes.Text = lblDsMes.Text.ToString();

                    lblDsAno.Text = strDsAno.ToString();
                    lblDsAno2.Text = lblDsAno.Text.ToString();

                    lblDsNomeEmpresa.Text = strDsNomeEmpresa.ToString();
                    lblDsNomeEmpresa2.Text = lblDsNomeEmpresa.Text.ToString();

                    lblNomeAssinatura.Text = lblDsNome.Text.ToString() + " - " + lblNrDocumento.Text.ToString();
                    lblNomeAssinatura2.Text = lblNomeAssinatura.Text.ToString();
                }
            }
        }
    }
}