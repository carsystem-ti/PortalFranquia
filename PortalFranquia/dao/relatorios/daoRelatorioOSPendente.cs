using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao
{
    public class daoRelatorioOSPendente: Dados
    {
        public DataTable getOSPendenteFranquia(int idFranquia)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 4),                                            
                                            new SqlParameter("@id_franquia", idFranquia)                                            
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getOSAnalise]", parametros);
            }
            catch
            {
                throw;
            }
        }
    }
}