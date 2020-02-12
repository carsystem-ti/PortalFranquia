using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
namespace PortalFranquia.dao
{
    public class daoProdutos
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataSet pro_getProdutos()
        {
            DataSet dsProd = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getProdutos]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsProd.Clear();
                        da.Fill(dsProd);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsProd;
        }
        public DataSet pro_getvlProduto(string cd_prod)
        {
            DataSet dsVlProd = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValorProduto]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cdproduto", cd_prod);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsVlProd.Clear();
                        da.Fill(dsVlProd);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsVlProd;
        }
        public DataSet pro_getCep(string _nrCep)
        {
            DataSet ds_Cep = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getCep", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cep", _nrCep);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_Cep.Clear();
                        da.Fill(ds_Cep);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_Cep;
        }
        public DataTable pro_getProdutosVendas(int _isAprovacao,string nr_cep,string _nrCetec,int ano,int _cdmodelo)
        {
            DataTable dsProd = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                      //  SqlCommand cmd = new SqlCommand("[Franquia].[pro_getProdutosDisponiveis]", conn);
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getListaProdutos]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@isAprovado",_isAprovacao);
                        cmd.Parameters.AddWithValue("@numeroCep",nr_cep);
                        cmd.Parameters.AddWithValue("@codigoCetec",_nrCetec);
                        cmd.Parameters.AddWithValue("@anoVeiculo",ano);
                        cmd.Parameters.AddWithValue("@codigoModelo ",_cdmodelo);
                        //cmd.Parameters.AddWithValue("@tipo", _tipo);
                        // cmd.Parameters.AddWithValue("@cdmodelo", _cdmodelo);
                        //cmd.Parameters.AddWithValue("@tipoVeiculo", _tipoveiculo);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsProd.Clear();
                        da.Fill(dsProd);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsProd;
        }
        public DataTable ValidaModeloProdutos(int _cdmodelo)
        {
            DataTable dsProd = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValidaModelo]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cdmodelo", _cdmodelo);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsProd.Clear();
                        da.Fill(dsProd);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsProd;
        }
        public DataSet pro_getValorProdutoVenda(int _produto)
        {
            DataSet dsProd = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValorProdutoVenda]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@produto",_produto);
                        dsProd.Clear();
                        da.Fill(dsProd);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsProd;
        }
    }
}