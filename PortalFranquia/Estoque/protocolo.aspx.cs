using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.Estoque
{
    public partial class protocolo : System.Web.UI.Page
    {
        public string codigoLoja = "";
        string _usuarioLogado = "";
        public bool isSupervisor;
        public PortalFranquia.dao.AcessoLogin acessoLogin
        {
            get
            {
                return (PortalFranquia.dao.AcessoLogin)Session["acessoLogin"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PortalFranquia.dao.AcessoLogin acessoLogin = null;
            Utils.setVoltarUrl(Page, Session, "../HomeEstoque.aspx");

            if (Session["acessoLogin"] == null)
                Response.Redirect("../Login.aspx");
            else
            {
                acessoLogin = (PortalFranquia.dao.AcessoLogin)Session["acessoLogin"];
                codigoLoja = acessoLogin.Codigo;
                _usuarioLogado  = acessoLogin.Nome;
                isSupervisor = acessoLogin.isSupervisor;
            }

            if (isSupervisor)
                codigoLoja = "CARSYS";

            if (Request.Form["funcao"] == null)
                return;

            switch (Request.Form["funcao"].ToString())
            {
                case "getEquipamento":
                    getEquipamento();
                    break;
                case "setProtocolo":
                    setProtocolo();
                    break;
                case "setStatusEquipamento":
                    setStatusEquipamento(Request.Form["pCodigoEquipamento"].ToString(), Convert.ToInt32(Request.Form["pCodigoStatus"]));
                    break;
                case "setStatusProtocolo":
                    setStatusProtocolo();
                    break;
                case "recebeItemProtocolo":
                    recebeItemProtocolo();
                    break;
                case "delItemProtocolo":
                    delItemProtocolo();
                    break;
                case "addOcorrencia":
                    addOcorrencia();
                    break;
                case "getMotivos":
                    getMotivos();
                    break;
                default:
                    Response.Write("Função Inválida");
                    break;
            }

            Response.End();
        }

        public string getProtocolo(int pCodigoStatus)
        {
            /*
            string iLinhaDescricao = "<div class=\"detalheEstoque\">@nomeFranquia</div> ";
            string iLinhaQuantidade = "<div class=\"quantidadeEstoque verde\">@numeroProtocolo</div>";
            string iLinhaBotao = "<a href='#' class='botaoVerdeFlat' onclick=\"javascript:@funcao\"> @quantidade </a>";
            */

            string iLinhaQuantidade = "<a class=\"itemLista\"><div class=\"botaoBranco numeroProtocolo\">@numeroProtocolo</div>";
            string iLinhaBotao = "<div class=\"botaoVerde B\"onclick=\"javascript:@funcao\"> Detalhes </div>";
            string iLinhaDescricao = "@nomeFranquia <span>Tipo: @tipoProtocolo / QTD: @quantidade /  Data: @Data</span></a>";



            string iRetorno = "";

            try
            {
                string iCodigoLoja = codigoLoja;

                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                foreach (System.Data.DataRow iLinha in iFuncoes.getProtocolo(iCodigoLoja, pCodigoStatus).Rows)
                {

                    iRetorno += iLinhaQuantidade.Replace("@numeroProtocolo", iLinha["codigoProtocolo"].ToString());
                    iRetorno += iLinhaBotao.Replace("@funcao", "getDetalhesProtocolo('" + iLinha["codigoProtocolo"].ToString() + "'," + pCodigoStatus.ToString() + ")");
                    iRetorno += iLinhaDescricao.Replace("@nomeFranquia", iLinha["nomeFranquia"].ToString());
                    
                    iRetorno = iRetorno.Replace("@quantidade", iLinha["quantidade"].ToString());
                    iRetorno = iRetorno.Replace("@tipoProtocolo", iLinha["tipoProtocolo"].ToString());
                    iRetorno = iRetorno.Replace("@Data", iLinha["dataRegistro"].ToString());
                }

                if (iRetorno == "")
                    iRetorno = "Nenhum Registro Encontrado";

                return iRetorno;

            }
            catch (Exception ex)
            {
                return "Erro:" + "class:" + this.GetType().Name + "</br> Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "</br>" + ex.Message;
            }
        }
        private void getEquipamento()
        {

            string iRetorno;
            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes;

            iFuncoes = new modulos.Estoque.funcoesEstoque();

            System.Data.DataRow iLinha = iFuncoes.getVerificaEquipamento(Request.Form["pCodigoEquipamento"].ToString());

            if (Convert.ToBoolean(iLinha["fl_ok"]))
            {
                iRetorno = "OK;" + iFuncoes.getRandomName(DateTime.Now.Millisecond) + ";" + iLinha["mensagem"].ToString();
            }
            else
            {
                iRetorno = "nOK;;" + iLinha["mensagem"].ToString();
            }

            Response.Write(iRetorno);
        }
        private void setProtocolo()
        {
            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();
            System.Data.SqlClient.SqlTransaction iTransacao = iFuncoes.bancoDados.Conexoes.conexao.BeginTransaction(); ;

            try
            {
                if (codigoLoja != "CARSYS")
                {
                    Response.Write(iFuncoes.setProtocolo(codigoLoja, "", _usuarioLogado, iTransacao)["mensagem"].ToString());
                    iTransacao.Commit();
                    iFuncoes.bancoDados.Conexoes.close();
                    return;
                }

                string iProprietario;
                string[] iCodigos = Request.Form["pCodigos"].ToString().Split(';');
                int iTipoEstoque = Convert.ToInt32(Request.Form["pTipoEstoque"]);

                switch (iTipoEstoque)
                {
                    case 1:
                        iProprietario = Request.Form["pCodigoFranquia"].ToString();
                        break;
                    default:
                        iProprietario = "CARSYS";
                        break;
                }

                System.Data.DataRow iLinha;

                iLinha = iFuncoes.setProtocolo("CARSYS", Request.Form["pCodigoFranquia"].ToString(), _usuarioLogado, iTransacao);

                foreach (string iCodigoEquipamento in iCodigos)
                {
                    if (iCodigoEquipamento == "")
                        continue;

                    if (iFuncoes.addItemProtocolo(Convert.ToInt32(iLinha["codigoProtocolo"]), iCodigoEquipamento, iTipoEstoque, iProprietario, iTransacao))
                        continue;

                    iTransacao.Rollback();
                    Response.Write("nOK");
                    Response.End();

                }

                iTransacao.Commit();
                iFuncoes.bancoDados.Conexoes.close();

                Response.Write("OK");
            }
            catch (Exception ex)
            {
                iTransacao.Rollback();
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        private void setStatusEquipamento(string pCodigoEquipamento, int pStatusInventario)
        {
            try
            {
                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                if (iFuncoes.setStatusEquipamento(pCodigoEquipamento, pStatusInventario))
                    Response.Write("efetuado");
                else
                    Response.Write("Não enviado ao protocolo!!!");
            }
            catch (Exception ex)
            {
                Response.Write("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }

            Response.End();
        }
        private void setStatusProtocolo()
        {
            try
            {
                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                if (iFuncoes.setStatusProtocolo( Convert.ToInt32(Request.Form["pCodigoProtocolo"]),  Convert.ToInt32(Request.Form["pCodigoStatus"])) )
                    Response.Write("OK");
                else
                    Response.Write("Protocolo não alterado!!!");
            }
            catch (Exception ex)
            {
                Response.Write("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        private void recebeItemProtocolo()
        { 
            try
            { 
                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();
                Response.Write(iFuncoes.recebeItemProtocolo(Request.Form["pCodigoEquipamento"].ToString(), Convert.ToInt32(Request.Form["pCodigoProtocolo"]),"PF: " + ((dao.AcessoLogin)Session["acessoLogin"]).Nome));
            }
            catch (Exception ex)
            {
                Response.Write("Error recebeItemProtocolo: " + ex.Message);
            }
            
        }

        private void addOcorrencia()
        {
            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();
            Response.Write(iFuncoes.addOcorrencia(Convert.ToInt32(Request.Form["pCodigoIdentificador"]), Convert.ToInt32(Request.Form["pCodigoMotivo"]), acessoLogin.Nome));
        }

        private void getMotivos()
        {
            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();
            Response.Write(iFuncoes.getMotivos(Convert.ToInt32(Request.Form["pCodigoGrupo"])));
        }

        private void delItemProtocolo()
        {
            try
            {
                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                if (iFuncoes.delItemProtocolo(Convert.ToInt32(Request.Form["pCodigoProtocolo"]), Request.Form["pCodigoEquipamento"].ToString()))
                {
                    iFuncoes.delProtocoloVazio();
                    Response.Write("OK");
                }
                else
                    Response.Write("Item não removido!!!");
            }
            catch (Exception ex)
            {
                Response.Write("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

    }

}