using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao
{
    public class daoRelatorioVendas : Dados
    {
        public DataTable getOSPendenteFranquia(int idFranquia)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 4),                                            
                                            new SqlParameter("@id_franquia", idFranquia),    
                                            new SqlParameter("@ds_franquia", dsFranquia),
                                            new SqlParameter("dt_confirmacao", dtconfirmacao),
                                            new SqlParameter("ds_vendedor", dsvendedor),
                                            new SqlParameter("nr_contrato", nrcontrato),
                                            new SqlParameter("ds_cliente", dscliente),
                                            new SqlParameter("id_pedido", idpedido),
                                            new SqlParameter("id_item", iditem),
                                            new SqlParameter("ds_produto", dsproduto),
                                            new SqlParameter("vl_unitario", vlunitario)


                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getPedidoVendasPorVendedor] ", parametros);
            }
            catch
            {
                throw;
            }
        }

        public object dsFranquia { get; set; }

        public object dtconfirmacao { get; set; }

        public object dsvendedor { get; set; }

        public object idpedido { get; set; }

        public object iditem { get; set; }

        public object dsproduto { get; set; }

        public object vlunitario { get; set; }

        public object nrcontrato { get; set; }

        public object dscliente { get; set; }
    }
}