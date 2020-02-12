using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao;
using PortalFranquia.interfaces;

namespace PortalFranquia.componentes
{
    public class BuscaDados : Dados
    {
        public DataTable getPesquisa(string parametroTipoPesquisa, string valorTipoPesquisa, string parametroValorPesquisa, string valorPesquisa, string conexao, string procedure)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter(parametroTipoPesquisa, valorTipoPesquisa),
                                            new SqlParameter(parametroValorPesquisa, valorPesquisa)
                                        };
            return getDataTableProc(conexao, procedure, parametros);
        }
    }

    public partial class BuscaCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public delegate void EventoPesquisa(DataTable dados);
        public delegate void EventoPesquisaObject(Object retorno);

        public delegate void EventoErroPesquisa(Exception ex);

        public event EventoPesquisa RetornoPesquisa;
        public event EventoPesquisaObject RetornoPesquisaObject;

        public event EventoErroPesquisa ErroRetorno;

        private string conexao;
        private string procedure;
        private string parametroValorPesquisa;
        private string parametroTipoPesquisa;

        private void PreencheDDLPesquisa(Dictionary<string, string> campos)
        {
            ddlPesquisa.Items.Clear();

            foreach (string chave in campos.Keys)
                ddlPesquisa.Items.Add(new ListItem(chave, campos[chave]));
        }

        public void ConfiguraBusca(Dictionary<string, string> campos, string parametroTipoPesquisa, string parametroValorPesquisa, string conexao, string procedure)
        {
            PreencheDDLPesquisa(campos);

            this.conexao = conexao;
            this.procedure = procedure;
            this.parametroTipoPesquisa = parametroTipoPesquisa;
            this.parametroValorPesquisa = parametroValorPesquisa;

            Visible = true;
        }

        public void ConfiguraBusca(Dictionary<string, string> campos, Busca busca)
        {
            if (busca == null)
                throw new Exception("Objeto de busca não definido !");

            Session["clienteBusca"] = busca;
            PreencheDDLPesquisa(campos);

            Visible = true;
        }

        public void setTitulo(string value)
        {
            lbTitulo.Text = value;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["clienteBusca"] == null)
                {
                    BuscaDados buscaDados = new BuscaDados();
                    RetornoPesquisa(buscaDados.getPesquisa(parametroTipoPesquisa, ddlPesquisa.SelectedValue, parametroValorPesquisa, txtValorPesquisa.Text, conexao, procedure));
                }
                else
                {
                    Busca busca = (Busca)Session["clienteBusca"];
                    if (busca.find(ddlPesquisa.SelectedValue, txtValorPesquisa.Text))
                        RetornoPesquisaObject(busca);
                    else
                        ErroRetorno(new Exception("Registro não encontrado !"));
                }
            }
            catch (Exception ex)
            {
                if (ErroRetorno != null)
                    ErroRetorno(ex);
                else
                    throw;
            }

        }

        public void setValorFocus()
        {
            txtValorPesquisa.Focus();
        }

        public void setLimpaValor()
        {
            txtValorPesquisa.Text = "";
        }

    }
}