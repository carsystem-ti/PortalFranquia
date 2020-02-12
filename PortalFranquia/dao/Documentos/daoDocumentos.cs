using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao.Documentos
{
    public class daoDocumentos : Dados
    {
        public System.Data.DataTable getDadosCertificado(string pContrato, string pUser)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@contrato", pContrato),
                                                    new SqlParameter("@usuario", pUser)
                                                };
                return getDataTableProc("cnxFranquia", "[Principal].[dbo].[pro_getDadosCertificadoPortal]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataTable getDadosCertificadoCAC(string pContrato)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@strContrato", pContrato)
                                                };
                return getDataTableProc("cnxFranquia", "[Principal].[dbo].[pro_getContratoCAC]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataTable getNrOs(string pContrato)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@contrato", pContrato)
                                                };
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getUltimoNrOs]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataTable getDadosReciboEntrega(string pNrOs)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@nrOS", pNrOs)
                                                };
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getDadosReciboEntrega]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataTable getDadosCadastro(string pstrContrato, string pstrPlaca, string pstrDocumento)
        {
            try
            {
                SqlParameter[] parametros =
                                                {
                                                    new SqlParameter("@strContrato", pstrContrato),
                                                    new SqlParameter("@strPlaca", pstrPlaca),
                                                    new SqlParameter("@strDocumento", pstrDocumento)
                                                };
                return getDataTableProc("cnxFranquia", "[Principal].[dbo].[pro_getClientes]", parametros);
            }
            catch
            {
                throw;
            }
        }


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
    }
}