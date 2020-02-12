using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PortalFranquia.interfaces;

namespace PortalFranquia.dao.OS
{
    public class TrocaAprovacao : Dados
    {
        public int gravaPedido(string nrContrato, int tpPessoa, string dsNome, string nrCPFCNPJ, string nrRG, string cdCETEC)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@str_cetec", cdCETEC),
                                            new SqlParameter("@str_contrato", nrContrato),
                                            new SqlParameter("@int_tpPessoa", tpPessoa),
                                            new SqlParameter("@str_dsNome", dsNome),
                                            new SqlParameter("@str_cpfCnpj", nrCPFCNPJ),
                                            new SqlParameter("@str_rg", nrRG)
                                        };

            try
            {
                return Convert.ToInt32(getValorProc("cnxFranquia", "principal..pro_PLUS_gravaDadosAprovacao", parametros));
            }
            catch
            {
                throw;
            }
        }       
    }
}