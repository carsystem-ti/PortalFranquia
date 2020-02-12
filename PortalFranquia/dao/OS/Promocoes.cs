using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao.OS
{
    public class Promocoes: Dados
    {
        public string verificaVoucher(string contrato, string voucher, string usuario)
        {
            SqlParameter[] parametros = {
                                             new SqlParameter("@nr_contrato", contrato),                     
                                             new SqlParameter("@nr_voucher", voucher),                                                   
                                             new SqlParameter("@ds_usuario", usuario)
                                        };
            try
            {
                return getValorProc("cnxFranquia", "[Principal]..[pro_setBaixaVoucher]", parametros).ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}