using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace PortalFranquia.dao
{
    public class daoPedidoVendaPagamento
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int _idPedido { get; set; }
        public int _id_parcela { get; set; }
        public int _idTipo { get; set; }
        public decimal _vlPagamento { get; set; }
        public DateTime _dataVenc { get; set; }
        public int _pcParcela { get; set; }
        public string _dsTitular { get; set; }
        public string _nrAgencia { get; set; }
        public string _nrConta { get; set; }
        public string _dsDoc { get; set; }
        public string _nr_cheque { get; set; }
        public string _nrAutorizacao { get; set; }
        public string _nrBanco { get; set; }
        public string _ccm { get; set; }
        public int _id_pagamento { get; set; }
        public int _tipo { get; set; }
        public int pro_setPedidoVendaPagamento()
        {
            int nr_pedidoItens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido",_idPedido);
                        cmd.Parameters.AddWithValue("@tp_forma",_idTipo);
                        cmd.Parameters.AddWithValue("@vl_pagamento",_vlPagamento);
                        cmd.Parameters.AddWithValue("@dt_vencimento",_dataVenc);
                        cmd.Parameters.AddWithValue("@pc_pagamento",_pcParcela);
                        cmd.Parameters.AddWithValue("@ds_titular",_dsTitular);
                        cmd.Parameters.AddWithValue("@nragencia",_nrAgencia);
                        cmd.Parameters.AddWithValue("@nr_conta",_nrConta);
                        cmd.Parameters.AddWithValue("@nr_documento",_dsDoc);
                        cmd.Parameters.AddWithValue("@nr_cheque", _nr_cheque);
                        cmd.Parameters.AddWithValue("@nr_autorizacao",_nrAutorizacao);
                        cmd.Parameters.AddWithValue("@nr_banco",_nrBanco);
                        cmd.Parameters.AddWithValue("@nr_ccm7",_ccm);
                        nr_pedidoItens = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoItens;
        }
        public int pro_setAlterVendaPagamento()
        {
            int nr_pedidoItens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setAlteraPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo",_tipo);
                        cmd.Parameters.AddWithValue("@id_parcela",_id_parcela);
                        cmd.Parameters.AddWithValue("@idPedido",_idPedido);
                        cmd.Parameters.AddWithValue("@pc_pagamento", _pcParcela);
                        cmd.Parameters.AddWithValue("@nragencia", _nrAgencia);
                        cmd.Parameters.AddWithValue("@nr_conta", _nrConta);
                        cmd.Parameters.AddWithValue("@nr_cheque", _nr_cheque);
                        cmd.Parameters.AddWithValue("@nr_banco", _nrBanco);
                        cmd.Parameters.AddWithValue("@nr_ccm7", _ccm);
                        nr_pedidoItens = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoItens;
        }
        public DataTable getPagamentos()
        {
            DataTable dt_pag = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getVendasPagamento]", conn);
                        cmd.Parameters.AddWithValue("@idpedido",_idPedido);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_pag.Clear();
                        da.Fill(dt_pag);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_pag;
        }
        public int pro_setExcluiItensPagamentos()
        {
            int alterado = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setExcluiVendaPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpagamento", _id_pagamento);
                        alterado = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return alterado;
        }
    }
}