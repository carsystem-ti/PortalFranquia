using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao.Estoque
{
    public class DaoMovimentacao : Dados
    {
        public DataTable getPosicoes()
        {
            try
            {
                return getDataTableSQL("cnxFranquia", "select * from [bdPrincipal].[Estoque].[vwe_MovimentacaoPecas] where id_statusLocalizacao != 9 order by [id_statusLocalizacao]");
            }
            catch
            {
                throw;
            }
        }

        public DataTable getPosicoesContabilidade()
        {
            try
            {
                return getDataTableSQL("cnxFranquia", "select * from [bdPrincipal].[Estoque].[vwe_MovimentacaoPecas] where id_statusLocalizacao in (3, 11) order by [id_statusLocalizacao]");
            }
            catch
            {
                throw;
            }
        }

        public DataTable getPosicoesCQP()
        {
            try
            {
                return getDataTableSQL("cnxFranquia", "select * from [bdPrincipal].[Estoque].[vwe_MovimentacaoPecas] where id_statusLocalizacao in (5, 6, 10, 16) order by [id_statusLocalizacao]");
            }
            catch
            {
                throw;
            }
        }

        public DataTable getPosicoesCadastro()
        {
            try
            {
                return getDataTableSQL("cnxFranquia", "select * from [bdPrincipal].[Estoque].[vwe_MovimentacaoPecas] where id_statusLocalizacao in (12, 13) order by [id_statusLocalizacao]");
            }
            catch
            {
                throw;
            }
        }

        public DataTable getListaEquipamentosByLocalizacao(int idLocalizacao, out string nomeLocalizacao)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("idLocalizacao", idLocalizacao)
                                                };
                SqlParameter[] parametros2 =
                                                {
                                                    new SqlParameter("idLocalizacao", idLocalizacao)
                                                };
                if (idLocalizacao != 99999)
                    nomeLocalizacao = getValorSQL("cnxFranquia", "select ds_statusLocalizacao + '-' + ds_Sigla from [bdPrincipal].[Estoque].[tbl_statusLocalizacao] where id_statusLocalizacao = @idLocalizacao", parametros2);
                else
                    nomeLocalizacao = "Peças Paradas no CETEC";
                return getDataTableProc("cnxFranquia", "[bdPrincipal].[Estoque].[pro_getEquipamentosPorLocalizacao]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getListaLocalizacaoEquipamento(int idGrupo)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@idGrupo", idGrupo)
                                                };
                return getDataTableProc("cnxFranquia", "[bdPrincipal].[Estoque].[pro_getStatusLocalizacaoByGrupo]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAlertasEstoque()
        {
            try
            {
                return getDataTableSQL("cnxFranquia", "select * from [bdPrincipal].[Estoque].[vwe_PecasParadasCETECs]");
            }
            catch
            {
                throw;
            }
        }

        public void setStatusLocalizacao(string idEquipamento, int idLocalizacao, int? nrNotaFiscal = null)
        {
            try
            {
                SqlParameter[] parametros =
                                               {
                                                    new SqlParameter("@idEquipamento", idEquipamento),
                                                    new SqlParameter("@idStatusLocalizacao", idLocalizacao),
                                                    new SqlParameter("@nrNotaFiscal", nrNotaFiscal)
                                                };
                ExecNonQuery("cnxFranquia", "[bdPrincipal].[Estoque].[pro_InsUpdLocalizacaoPeca]", parametros);                
            }
            catch
            {
                throw;
            }
        }
    }
}