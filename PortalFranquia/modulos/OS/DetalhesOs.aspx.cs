using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class DetalhesOs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           

                dao.AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                Usuario.Value = acessoLogin.Nome;
                Cetec.Value = acessoLogin.cdCetec;
                Session["nr_os"] = idOSSelecionada.Value;
                txtIdOs.Value = Session["nr_os"].ToString();
                dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();

                DataTable dt = os.getOSInstalador(acessoLogin.cdCetec);

                DataTable dt_os = os.pro_getAcaoOs(acessoLogin.idGrupo);

                if (acessoLogin.idGrupo == 39)
                {
                    DataTable dt_empresa = os.pro_getEmpresa();

                    dropEmpresa.DataSource = dt_empresa;
                    dropEmpresa.DataBind();
                    dropEmpresa.Items.Insert(0, "SELECIONE EMPRESA");
                    dropEmpresa.Visible = true;
                    lblEmpresa.Visible = true;
                }
                else
                {
                    dropEmpresa.Visible = false;
                    lblEmpresa.Visible = false;
                }


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

    }
}