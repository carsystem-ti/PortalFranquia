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
    public class daoPedidoVendaItens
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int _idPedido { get; set; }
        public string _idproduto { get; set; }
        public decimal _valorProduto { get; set; }
        public int _qtQuantidade { get; set; }
        public decimal _vlDesconto { get; set; }
        public int _item { get; set; }
        public int pro_setPedidoVendaItens(int pedido,int produto,decimal valor,decimal desconto)
        {
            int nr_pedidoItens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", pedido);
                        cmd.Parameters.AddWithValue("@id_produto", produto);
                        cmd.Parameters.AddWithValue("@vlProduto",valor);
                        cmd.Parameters.AddWithValue("@vl_desconto",desconto);
                        nr_pedidoItens = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoItens;
        }

        public DataSet getVendasItens(int ped)
        {
            DataSet dsPagamentos = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidoVendasItens]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_pedido", ped);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsPagamentos.Clear();
                            da.Fill(dsPagamentos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dsPagamentos;
        }
        public int pro_setExcluiItens()
        {
            int alterado = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setExcluiItensVendas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@item", _item);
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