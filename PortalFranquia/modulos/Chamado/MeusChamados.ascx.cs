using PortalFranquia.dao;
using PortalFranquia.dao.Chamados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Chamado
{
    public partial class MeusChamados : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] != null)
            {

                Utils.setVoltarUrl(Page, Session);
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                string ds_tipo = acessoLogin.dsTipo;
                if (ds_tipo == "G" || ds_tipo == "A" || ds_tipo == "C" || ds_tipo == "W")
                {
                    BuscaAcessos();
                    if(!IsPostBack)
                    {
                        BuscaStatus();
                    }
                    
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
        private void BuscaStatus()
        {
               daogetChamados bdc = new daogetChamados();
               DataSet ds = bdc.geStatusChamados();
               dropFiltros.DataSource = ds;
               dropFiltros.DataBind();
               dropFiltros.Items.Insert(0, "Selecione"); 
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

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BuscaChamados()
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    daogetChamados bda = new daogetChamados();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    DataSet dt = new DataSet();
                    int id_franquia = acessoLogin.idFranquia;
                    dt = bda.GetChamadosEmAtendimento(id_franquia);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                       GridMeusChamados.DataSource = dt;
                       GridMeusChamados.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void BuscaChamadosSuporte(int departmento)
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {

                    daogetChamados bda = new daogetChamados();
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    DataSet dt = new DataSet();
                    string ds_nome = acessoLogin.Nome;
                    dt = bda.getChamadosSuportes(departmento, 2);
                    if (dt.Tables.Count > 0)
                    {
                        GridMeusChamados.DataSource = dt;
                        GridMeusChamados.DataBind();
                    }
                    else
                    {
                        GridMeusChamados.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dropFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropFiltros.SelectedValue != "Selecione" && Session["id_grupo"] != null)
            {
                int id_status = Convert.ToInt32(dropFiltros.SelectedValue);
                int id_grupo = Convert.ToInt32(Session["id_grupo"].ToString());
                daogetChamados bdc = new daogetChamados();
                DataTable dt = bdc.getMeusChamados(id_grupo, id_status);
                if (dt.Rows.Count > 0)
                {
                    GridMeusChamados.DataSource = dt;
                    GridMeusChamados.DataBind();
                }
                else
                {
                    GridMeusChamados.DataBind();
                    
                }
             
            }
        }
     
    }
}