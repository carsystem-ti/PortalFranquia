using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.Estoque
{
    public partial class tabelas : System.Web.UI.Page
    {
        public resumoEstoque[] resumos = new resumoEstoque[4];

        public string codigoLoja = "";
        public int codigoGrupo = 0;


        public struct resumoEstoque
        {
            public string detalhe;
            public string cor;
            public int quantidade;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes;

            PortalFranquia.dao.AcessoLogin acessoLogin = null;
            Utils.setVoltarUrl(Page, Session, "../HomeEstoque.aspx");
            Utils.setNomeModulo(Page, "Estoque - Produtos em Estoque");

            if (Session["acessoLogin"] == null)
                Response.Redirect("../Login.aspx");
            else
            {
                acessoLogin = (PortalFranquia.dao.AcessoLogin)Session["acessoLogin"];
                codigoLoja = acessoLogin.Codigo;                
            }

            if (Request.Form["pCodigoLoja"] != null && acessoLogin.isSupervisor)
                codigoLoja = Request.Form["pCodigoLoja"].ToString();

            codigoGrupo = acessoLogin.idGrupo;

            carregaEstoque();
        }
        private void carregaEstoque()
        {
            string iLinhaQuantidade = "<a class=\"itemLista\"><div class=\"botao@corB A\">@quantidadeEquipamento</div>";
            string iLinhaBotao = "<div class=\"botaoVerde B\"onclick=\"javascript:@funcao\"> Detalhes </div>";
            string iLinhaDescricao = "@descricaoEquipamento<span>Versao: @versaoEquipamento</span></a>";

            int iPosicao = 0;
            int iContador = 0;

            string iNome = "";

            resumos[0].detalhe = ""; resumos[0].cor = "verde"; resumos[0].quantidade = 0;
            resumos[1].detalhe = ""; resumos[1].cor = "verde"; resumos[1].quantidade = 0;
            resumos[2].detalhe = ""; resumos[2].cor = "verde"; resumos[2].quantidade = 0;
            resumos[3].detalhe = ""; resumos[3].cor = "verde"; resumos[3].quantidade = 0;


            try
            {
                string iCodigoLoja = codigoLoja;
                bool iTemLinhas = false;

                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                foreach (System.Data.DataRow iLinha in iFuncoes.getEstoqueLoja(iCodigoLoja).Rows)
                {
                    if (!Convert.ToBoolean(iLinha["isCarSystem"]) && iLinha["id_tipoEstoque"].ToString() == "1"
                        && iLinha["id_statusInventario"].ToString() == "1")
                        iPosicao = 0;
                    else if (Convert.ToBoolean(iLinha["isCarSystem"]) && iLinha["id_tipoEstoque"].ToString() == "2"
                        && iLinha["id_statusInventario"].ToString() == "1")
                        iPosicao = 1;
                    else if (Convert.ToBoolean(iLinha["isCarSystem"]) && iLinha["id_tipoEstoque"].ToString() == "1"
                        && iLinha["id_statusInventario"].ToString() == "1")
                        iPosicao = 2;
                    else if (iLinha["id_statusInventario"].ToString() == "3")
                    {
                        iPosicao = 3;
                        iContador++;
                        iNome = iFuncoes.getRandomName(iContador);
                        resumos[3].detalhe += "<div id=\"" + iNome + "\">";
                    }
                    else
                        continue;

                    
                    resumos[iPosicao].quantidade += Convert.ToInt32(iLinha["quantidade"].ToString());

                    resumos[iPosicao].detalhe += iLinhaQuantidade.Replace("@quantidadeEquipamento", iLinha["quantidade"].ToString());
                    
                    resumos[iPosicao].detalhe += iLinhaBotao.Replace("@funcao", "getDetalhes('"
                                                                                        + iCodigoLoja + "','"
                                                                                        + iLinha["item"].ToString() + "','"
                                                                                        + Convert.ToBoolean(iLinha["isCarSystem"]).ToString() + "',"
                                                                                        + iLinha["id_tipoEstoque"].ToString() + ","
                                                                                        + iLinha["id_statusInventario"].ToString() + ",'"
                                                                                        + iNome + "','"
                                                                                        + iLinha["versaoEquipamento"].ToString() + "')");
                    resumos[iPosicao].detalhe += iLinhaDescricao.Replace("@descricaoEquipamento", iLinha["item"].ToString());
                    resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@versaoEquipamento", iLinha["versaoEquipamento"].ToString());


                    if (Convert.ToInt32(iLinha["quantidade"]) >= 6 || iPosicao == 3)
                    {
                        if (iPosicao != 3)
                            resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@corB", "Verde");
                        else
                            resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@corB", "Branco");

                        resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@cor", "verde");
                        
                        if (resumos[iPosicao].cor == "")
                            resumos[iPosicao].cor = "verde";
                    }
                    else if (Convert.ToInt32(iLinha["quantidade"]) == 5)
                    {
                        resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@corB", "Amarelo");
                        resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@cor", "amarelo");                        

                        if (resumos[iPosicao].cor == "" || resumos[iPosicao].cor == "verde")
                            resumos[iPosicao].cor = "amarelo";
                    }
                    else if (Convert.ToInt32(iLinha["quantidade"]) < 5)
                    {                        
                        resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@corB", "Vermelho");
                        resumos[iPosicao].detalhe = resumos[iPosicao].detalhe.Replace("@cor", "vermelho");
                        resumos[iPosicao].cor = "vermelho";
                    }

                    if (iPosicao == 3)
                        resumos[3].detalhe += "</div>";
                }

                if (!iTemLinhas)
                {
                    iCodigoLoja = "Nennhum Registro Encontrado";

                }
            }
            catch (Exception ex)
            {
                Response.Write("Erro:" + "class:" + this.GetType().Name + "</br> Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "</br>" + ex.Message);
            }


        }
    }
}
 