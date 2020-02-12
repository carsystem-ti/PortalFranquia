using PortalFranquia.dao.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        string strSessionUser = "";
        string strSessionGrupo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaUsuario();

            if (!IsPostBack)
            {
                strSessionUser = Request.QueryString["txtSessionUser"];
                strSessionGrupo = Request.QueryString["txtGrupo"];

                strSessionUser = (strSessionUser == null) ? "000000" : strSessionUser;
                strSessionGrupo = (strSessionGrupo == null) ? "CETEC" : strSessionGrupo;

                Session.Add("strUser", strSessionUser);
                Session.Add("strGrupo", strSessionGrupo);
            }
            else
            {
                strSessionUser = Session["strUser"].ToString();
                strSessionGrupo = Session["strGrupo"].ToString();
            }

            if (strSessionUser == "Diego Machado")
            {
                if (rdbCadastro.Checked == true)
                {
                    grvLojas.Visible = true;
                    GridView1.Visible = false;
                    lblDigiteNomeInstalador.Visible = true;
                    txtNomeInstalador.Visible = true;
                    btnCadastrar.Visible = true;
                }

                if (rdbDesativacao.Checked == true)
                {
                    grvLojas.Visible = true;
                    lblDigiteNomeInstalador.Visible = false;
                    txtNomeInstalador.Visible = false;
                    btnCadastrar.Visible = false;
                }
            } else
            {
                lblMsg.Text = "Usuário não tem permissão de acesso para cadastrar ou desativar Instalador";
                lblMsg.Visible = true;
            }
        }
        public void ValidaUsuario()
        {
            dao.AcessoLogin iAcessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            if (iAcessoLogin.Nome.ToUpper() != "SUPERVISOR" && iAcessoLogin.idGrupo != 21 && iAcessoLogin.Nome.ToUpper() != "SUPCETEC")
            {
                Response.Redirect("OS.aspx");
            }

        }
        protected void rdbCadastro_CheckedChanged(object sender, EventArgs e)
        {
            rdbDesativacao.Checked = false;
            GridView1.Visible = false;
            lblMsg.Visible = false;

            lblDigiteNomeInstalador.Visible = true;
            txtNomeInstalador.Visible = true;
            btnCadastrar.Visible = true;

        }

        protected void rdbDesativacao_CheckedChanged(object sender, EventArgs e)
        {
            rdbCadastro.Checked = false;
            lblMsg.Visible = false;
        }

        protected void grvLojas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdbCadastro.Checked == true)
            {
                grvLojas.Visible = true;

                GridViewRow row = grvLojas.SelectedRow;
                lblCodigo.Text = row.Cells[0].Text.ToString();

                txtNomeInstalador.Enabled = true;
                btnCadastrar.Enabled = true;

            }

            if (rdbDesativacao.Checked == true)
            {
                grvLojas.Visible = true;
                GridView1.Visible = true;

                GridViewRow row = grvLojas.SelectedRow;
                lblCodigo.Text = row.Cells[0].Text.ToString();

                GridView1.DataBind();

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 intIdUsuario;

            try
            {
                GridViewRow row = GridView1.SelectedRow;
                intIdUsuario = Convert.ToInt32(row.Cells[1].Text.ToString());

                daoOSConsulta daoDesativa = new daoOSConsulta();
                daoDesativa.set_DesativaTecnico(intIdUsuario);

                lblMsg.Text = "Instalador desativado com sucesso!!!";

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message.ToString();
            }

            lblMsg.Visible = true;

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nomeInstalador;
            string codigoCetec;

            GridViewRow row = grvLojas.SelectedRow;

            try
            {
                if (txtNomeInstalador.Text.Length > 5)
                {
                    nomeInstalador = txtNomeInstalador.Text.ToString();
                    codigoCetec = row.Cells[0].Text.ToString();

                    daoOSConsulta cadastro = new daoOSConsulta();
                    cadastro.set_CadastrarInstalador(nomeInstalador.ToString(), codigoCetec.ToString());

                    lblMsg.Text = "Instalador Cadastrado com Sucesso!!!";
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Favor digitar código e nome do instalador!!!";
                }

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message.ToString();
            }

            lblMsg.Visible = true;
        }
    }
}