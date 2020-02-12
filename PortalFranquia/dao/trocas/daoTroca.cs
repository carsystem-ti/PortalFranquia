using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace PortalFranquia.dao.daoTroca
{
    public class daoTrocas
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int _idtroca { get; set; }
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
        public DataSet pro_getDados(int tipo,string _contrato)
        {
            DataSet ds_dados = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getDadosTrocas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tp", tipo);
                        cmd.Parameters.AddWithValue("@doc", _contrato);
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
        public int pro_setTroca(string _contrato,int _franquia,string _ds_produtoAnterior ,string _dsusuario)
        {
            int nr_troca = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setTrocaProduto]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_contrato", _contrato);
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        cmd.Parameters.AddWithValue("@ds_produtoAnterior",_ds_produtoAnterior);
                        cmd.Parameters.AddWithValue("@usuarioTroca", _dsusuario);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_troca = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_troca;
        }
        public int pro_setTrocaItens(int _nr_troca, int _id_novoProduto,decimal vl_troca, decimal vl_cobrado)
        {
            int nr_trocaitens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setTrocaItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_troca", _nr_troca);
                        cmd.Parameters.AddWithValue("@id_novoProduto",_id_novoProduto);
                        cmd.Parameters.AddWithValue("@vl_Valor",vl_troca);
                        cmd.Parameters.AddWithValue("@vlCobrado",vl_cobrado);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_trocaitens = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_trocaitens;
        }
        public int pro_setTrocaPagamento()
        {
            int nr_pagamento = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setTrocaPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtroca", _idtroca);
                        cmd.Parameters.AddWithValue("@tp_forma",_idTipo);
                        cmd.Parameters.AddWithValue("@vl_pagamento",_vlPagamento);
                        cmd.Parameters.AddWithValue("@dt_vencimento",_dataVenc);
                        cmd.Parameters.AddWithValue("@pc_pagamento",_pcParcela);
                        cmd.Parameters.AddWithValue("@ds_titular",_dsTitular);
                        cmd.Parameters.AddWithValue("@nragencia",_nrAgencia);
                        cmd.Parameters.AddWithValue("@nr_conta",_nrConta);
                        cmd.Parameters.AddWithValue("@nr_documento",_dsDoc);
                        cmd.Parameters.AddWithValue("@nr_cheque",_nr_cheque);
                        cmd.Parameters.AddWithValue("@nr_autorizacao",_nrAutorizacao);
                        cmd.Parameters.AddWithValue("@nr_banco",_nrBanco);
                        cmd.Parameters.AddWithValue("@nr_ccm7",_ccm);
                        nr_pagamento = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pagamento;
        }
        public int pro_setAtualizaClientes(string contrato,string produto,string usuario)
        {
            int nr_Contrato = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setDadosTrocas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_contrato",contrato);
                        cmd.Parameters.AddWithValue("@ds_produto", produto);
                        cmd.Parameters.AddWithValue("@ds_usuario", usuario);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_Contrato = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_Contrato;
        }
    }
}