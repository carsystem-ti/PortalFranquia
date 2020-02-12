using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace PortalFranquia.dao
{
    public class daoVeiculo : Dados
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataTable BuscaModelo(int id)
        {
            DataTable permisao = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getModelos]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            permisao.Clear();
                            da.Fill(permisao);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return permisao;
        }
        public DataSet BuscaTipoVeiculo(int id)
        {
            DataSet dsTipoVeiculo = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getTipoVeiculo]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsTipoVeiculo.Clear();
                            da.Fill(dsTipoVeiculo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsTipoVeiculo;
        }
        public DataTable BuscaFabricante()
        {
            DataTable fabricante = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[CRM].[pro_getbuscaFabricante]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            fabricante.Clear();
                            da.Fill(fabricante);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return fabricante;
        }
        public DataTable Cores()
        {
            DataTable dtCores = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getCoresAutomotivas]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dtCores.Clear();
                            da.Fill(dtCores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dtCores;
        }
        public DataSet ValidaPlacaVeiculo(string dsPlaca)
        {
            DataSet permisao = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValidaPlaca]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ds_Placa", dsPlaca);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            permisao.Clear();
                            da.Fill(permisao);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return permisao;
        }
        public DataTable getDadosVeiculo(string strContrato)
        {
            DataTable dtVeiculo = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[dbo].[pro_getClientes]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@strContrato", strContrato);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dtVeiculo.Clear();
                            da.Fill(dtVeiculo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dtVeiculo;
        }
        public DataTable getUltimaOS(string strContrato)
        {
            DataTable dtUltimaOS = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[dbo].[pro_getVerificaOS]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@strContrato", strContrato);

                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);

                            dtUltimaOS.Clear();
                            da.Fill(dtUltimaOS);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dtUltimaOS;
        }

        public int pro_setTrocaVeiculo(int _nr_id_troca, string _ds_contrato, string _ds_user, string _ds_estacao, string _ds_motivo, int _nr_troca_veiculo, string _ds_placa, string _nr_tipo, string _ds_modelo, string _ds_chassi, string _ds_renavan, string _ds_cor, string _ds_comb, string _ds_fabricante, int _nr_ano_veiculo)
        {
            int nr_trocaVeiculo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[dbo].[pro_TDV_EfetuaTrocaVeiculo]", conn);
                        
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idTroca", _nr_id_troca);
                        cmd.Parameters.AddWithValue("@Contrato", _ds_contrato);
                        cmd.Parameters.AddWithValue("@User", _ds_user);
                        cmd.Parameters.AddWithValue("@Estacao", _ds_estacao);
                        cmd.Parameters.AddWithValue("@Motivo", _ds_motivo);
                        cmd.Parameters.AddWithValue("@TpTroca", _nr_troca_veiculo);
                        cmd.Parameters.AddWithValue("@Placa_nova", _ds_placa);
                        cmd.Parameters.AddWithValue("@Tipo_novo", _nr_tipo);
                        cmd.Parameters.AddWithValue("@Modelo_novo", _ds_modelo);
                        cmd.Parameters.AddWithValue("@Chassi_novo", _ds_chassi);
                        cmd.Parameters.AddWithValue("@Renavan_novo", _ds_renavan);
                        cmd.Parameters.AddWithValue("@Cor_nova", _ds_cor);
                        cmd.Parameters.AddWithValue("@Comb_veiculo_novo", _ds_comb);
                        cmd.Parameters.AddWithValue("@Fabricante_novo", _ds_fabricante);
                        cmd.Parameters.AddWithValue("@Ano_veiculo_novo", _nr_ano_veiculo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_trocaVeiculo = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_trocaVeiculo;
        }
    }
}