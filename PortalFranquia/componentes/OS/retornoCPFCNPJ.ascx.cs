using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;

namespace PortalFranquia.componentes.OS
{
    public partial class retornoCPFCNPJ : System.Web.UI.UserControl
    {
        public delegate void EventoRetornoCPFCNPJ();

        public event EventoRetornoCPFCNPJ RetornoPesquisaCPFCNPJ;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PreencheGrid(DataTable dados)
        {
            grdCPF.DataSource = dados;
            grdCPF.DataBind();
        }
        
        protected void grdCPF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCPF.PageIndex = e.NewPageIndex;
            PreencheGrid(((daoOSConsulta)Session["OSAberta"]).dtRetornoCPF);
        }        

        protected void grdCPF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.grdCPF, "Select$" + e.Row.RowIndex);
            }
        }

        protected void grdCPF_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            daoOSConsulta DaoOSConsulta = (daoOSConsulta) Session["OSAberta"];

            DaoOSConsulta.getOSPedido(grdCPF.Rows[e.NewSelectedIndex].Cells[0].Text);
            RetornoPesquisaCPFCNPJ();
        }
    }
}