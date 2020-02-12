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
    public partial class AberturaOs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

            try
            {
                
                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                daoOSsAberta os = new daoOSsAberta();
                if (txtPesquisa.Value != "" && txtPesquisa.Value != null)
                {


                    DataTable dt =    os.getContrato(txtPesquisa.Value);

                    if (dt.Rows.Count > 0)
                    {

                    }
                    else
                    {

                    }


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
    }
}