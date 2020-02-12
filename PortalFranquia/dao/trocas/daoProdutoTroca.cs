using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao.trocas
{
    public class daoProdutoTroca
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataTable pro_getProdutosTrocas(int produto,string cetec)
        {
            DataTable ds_dados = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getProdutosTrocas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_produto", produto);
                        cmd.Parameters.AddWithValue("@cd_franquia", cetec);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_dados.Clear();
                        da.Fill(ds_dados);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_dados;
        }
        public DataSet pro_getValorTroca(int produtotroca, int id_produtoAtual)
        {
            DataSet ds_valor = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValorTroca]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_produto", produtotroca);
                        cmd.Parameters.AddWithValue("@id_produtoAtual", id_produtoAtual);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_valor.Clear();
                        da.Fill(ds_valor);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_valor;
        }
        public DataTable getMeusPedidosTroca(int tipo, DateTime dtInicial, DateTime dt_final, int franquia)
        {
            DataTable dtMeusPedidos = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidosTrocas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@dataInicial", dtInicial);
                        cmd.Parameters.AddWithValue("@dataFinal", dt_final);
                        cmd.Parameters.AddWithValue("@idfranquia", franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtMeusPedidos.Clear();
                        da.Fill(dtMeusPedidos);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dtMeusPedidos;
        }
        public int ValidaEstoque(int produto,string cetec)
        {
            int testeExecucao = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[fun_getEstoqueDisponivel]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoCompra", produto);
                        cmd.Parameters.AddWithValue("@codigoCetec", cetec);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        testeExecucao = cmd.ExecuteNonQuery();
                        

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return testeExecucao;
        }
    }
}