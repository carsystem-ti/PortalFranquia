using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;
using System.IO;

namespace PortalFranquia
{
    public partial class RelOSPendente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

            if (acessoLogin.dsTipo != "G")
            {
                Utils.SemPermissão(Response, Session);
            }

            if (!IsPostBack)
            {
                Utils.setVoltarUrl(Page, Session, "Relatorio.aspx");
                Utils.setNomeModulo(Page, "Relatórios - Pendências");

                if (acessoLogin.cdCetec == "")
                {
                    ddlFranquia.Visible = true;
                    daoFranquia DaoFranquia = new daoFranquia();
                    ddlFranquia.DataSource = DaoFranquia.getFranquiasRelatorio();
                    ddlFranquia.DataValueField = "id_franquia";
                    ddlFranquia.DataTextField = "ds_franquia";
                    ddlFranquia.DataBind();

                    lbFranquia.Visible = true;
                }
                else
                {
                    btnBuscar.Visible = false;
                    btnBuscar_Click(null, null);
                }
            }
            lbMensErro.Visible = false;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            daoRelatorioOSPendente DaoRelatorio = new daoRelatorioOSPendente();
            try
            {
                AcessoLogin acessoLogin = ((AcessoLogin)Session["acessoLogin"]);

                int idFranquia;
                lbTitulo.Text = "RELATÓRIO DE ORDEM DE SERVIÇO - Franquia - ";

                if (acessoLogin.idFranquia == 0)
                {
                    idFranquia = Convert.ToInt32(ddlFranquia.SelectedValue);
                    lbTitulo.Text = lbTitulo.Text + ddlFranquia.SelectedItem;
                }
                else
                {
                    idFranquia = acessoLogin.idFranquia;
                    lbTitulo.Text = lbTitulo.Text + acessoLogin.Franquia;
                }

                DataTable dt = DaoRelatorio.getOSPendenteFranquia(idFranquia);
                gridOSPendente.DataSource = dt;
                gridOSPendente.DataBind();

                decimal tot = dt.AsEnumerable().Sum(x => x.Field<decimal>("Valor"));
                gridOSPendente.FooterRow.Cells[5].Text = tot.ToString("###,###,##0.00");
                gridOSPendente.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                               
                pnRelatorio.Visible = true;
                pnTitulo.Visible = true;
                lbexportar.Visible = true;
                imgexportgridOSPendente.Visible = true;
            }
            catch (Exception ex)
            {
                lbMensErro.Text = ex.Message;
                lbMensErro.Visible = true;
            }
        }

        protected void gridOSPendente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 5;
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Font.Bold = true;
            }
        }



        protected void imgexportgridOSPendente_Click(object sender, ImageClickEventArgs e)
        {

            Response.Clear();
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_OS_Pendente.xls");
            Response.Charset = "";
            Response.ContentType = "application/Relatorio_OS_Pendente.xlsx";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gridOSPendente.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }



       

    }
}