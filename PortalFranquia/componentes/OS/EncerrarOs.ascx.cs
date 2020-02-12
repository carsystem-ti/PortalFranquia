using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.componentes.OS
{
    public partial class EncerrarOs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {
                Utils.setNomeModulo(Page, "O.S. - O.S. Abertas");
                Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");

                dao.AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                Usuario.Value = acessoLogin.Nome ;
                Cetec.Value = acessoLogin.cdCetec;

                dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();

                DataTable dt = os.getOSInstalador(acessoLogin.cdCetec);

                DataTable dt_os = os.pro_getAcaoOs(acessoLogin.idGrupo);

                //if (acessoLogin.idGrupo == 39)
                //{
                //    DataTable dt_empresa = os.pro_getEmpresa();

                //    dropEmpresa.DataSource = dt_empresa;
                //    dropEmpresa.DataBind();
                //    dropEmpresa.Items.Insert(0, "SELECIONE EMPRESA");
                //    dropEmpresa.Visible = true;
                //    lblEmpresa.Visible = true;
                //}
                //else
                //{
                //    dropEmpresa.Visible = false;
                //    lblEmpresa.Visible = false;
                //}
                

                dropTecnico.DataSource = dt;
                dropTecnico.DataBind();
                dropTecnico.Items.Insert(0, "SELECIONE TECNICO");

                dropAcaoOs.DataSource = dt_os;
                dropAcaoOs.DataBind();
                dropAcaoOs.Items.Insert(0, "SELECIONE AÇÃO");

             
            }

        }
        public static string atende(string descricao)
        {

            return descricao;
        }
     
        //protected void dropMotivosAtendimento_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
        //   DataTable dt_itensMotivos =os.pro_getDetalhesMotivoOs(Convert.ToInt32(dropMotivosAtendimento.SelectedValue));
        //    dropDetalhesMotivos.DataSource = dt_itensMotivos;
        //    dropDetalhesMotivos.DataBind();
        //    dropDetalhesMotivos.Items.Insert(0,"SELECIONE DETALHE");
        //}
    }
}