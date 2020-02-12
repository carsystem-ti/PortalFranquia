using PortalFranquia.dao;
using PortalFranquia.dao.Chamados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Chamados
{
    public partial class Encerradas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Session["id_statusChamado"] = 3;
                if (Session["acessoLogin"] != null)
                {



                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string ds_tipo = acessoLogin.dsTipo;
                    if (ds_tipo == "G" || ds_tipo == "A" || ds_tipo == "C" || ds_tipo == "W")
                    {
                        BuscaAcessos();
                    }
                    else
                    {
                        Utils.SemPermissão(Response, Session);
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BuscaAcessos()
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    DataTable ds = new DataTable();
                    daogetChamados bdc = new daogetChamados();
                    ds = bdc.getPermiteAtender(acessoLogin.Nome);
                    if (ds.Rows.Count > 0)
                    {
                        foreach (DataRow dw in ds.Rows)
                        {
                            int depto = Convert.ToInt32(dw[0].ToString());
                            string ds_tipo = dw[1].ToString();
                            BuscaChamadosSuporte(depto);
                        }
                    }
                    else
                    {
                        BuscaChamados();
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void BuscaChamadosSuporte(int departamento)
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    daogetChamados bda = new daogetChamados();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    DataSet dt = new DataSet();
                    string ds_nome = acessoLogin.Nome;
                    dt = bda.getChamadosSuportes(departamento, 3);
                    if (dt.Tables.Count > 0)
                    {
                        GridChamados.DataSource = dt;
                        GridChamados.DataBind();
                    }
                    else
                    {
                        GridChamados.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void BuscaChamados()
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    daogetChamados bda = new daogetChamados();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    DataSet dt = new DataSet();
                    int id_franquia = acessoLogin.idFranquia;
                    dt = bda.GetChamados(id_franquia, 3);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        GridChamados.DataSource = dt;
                        GridChamados.DataBind();
                    }
                    else
                    {
                        GridChamados.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridChamados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = e.Row.Attributes["onmouseover"] + "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = e.Row.Attributes["onmouseout"] + "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridChamados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                  int _detalhes = Convert.ToInt32(GridChamados.SelectedRow.Cells[0].Text);
                    Session["id"] = _detalhes.ToString();
                    //lblarea.Text = GridChamados.SelectedRow.Cells[4].Text.ToString().ToUpper();
                    daogetChamados bda = new daogetChamados();
                    DataSet dt_Chamados = new DataSet();
                    dt_Chamados = bda.GetDetalhes(_detalhes);
                    if (dt_Chamados.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Imprimir()", true);
                        //  BuscaChamados();
                    }
                    else
                    {
                    }
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridChamados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridChamados.PageIndex = e.NewPageIndex;
            BuscaChamados();
        }
    }
}