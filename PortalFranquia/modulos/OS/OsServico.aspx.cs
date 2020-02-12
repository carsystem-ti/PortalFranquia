using PortalFranquia.componentes.OS;
using PortalFranquia.dao;
using PortalFranquia.dao.OS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class OsServico : System.Web.UI.Page
    {
       // private daoOSsAberta OSsAbertas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Utils.setNomeModulo(Page, "O.S. - O.S. Abertas");
                Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");
               
            }



            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

        }
        public void exibeOSContrato(string nr_contrato)
        {
            daoOSsAberta os = new daoOSsAberta();
            // Carrega as OS
            AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
            DataTable Dtos = os.atualizaOSContrato(nr_contrato,acessoLogin.idGrupo,acessoLogin.cdCetec,2);
            
            //foreach (string tipoOS in OSsAbertas.getTipoOSAberta())
            //{
            //    /// Control controlOS = LoadControl(@"~\componentes\OS\mostraOSAbertas.ascx");
            //    // ((mostraOSAbertas)controlOS).ConfiguraGrid(tipoOS, OSsAbertas.getOSsTipo(tipoOS));


            //    grid.DataSource = OSsAbertas.getOSsTipo(tipoOS);
            //    grid.DataBind();
            //}
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (txtPesquisa.Value != "" && txtPesquisa.Value != null)
                    {
                        OSAbertas os = new OSAbertas();
                        exibeOSContrato(txtPesquisa.Value);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                    ex.Message.ToString();
                }




            }
            catch (Exception)
            {

                throw;
            }
        }
        
        //protected void btConfirmaOS_Click(object sender, ImageClickEventArgs e)
        //{

        //    idOSSelecionada.Value  = grid.SelectedDataKey[0].ToString();
        //    Session["nr_os"] = idOSSelecionada.Value;


        //}
    }
}