using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace PortalFranquia.modulos.Chamados
{
    public class ChamadoMethod
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataSet GetDetalhes(int _detalhes)
        {
            DataSet dsDetalhes = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getDetalheChamado]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_chamado", _detalhes);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsDetalhes.Clear();
                            da.Fill(dsDetalhes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dsDetalhes;
        }
        public DataSet GetEmailFranquia(int tipo,int franquia)
        {
            DataSet ds_franquia = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getEmailFranquia]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@tipo", tipo);
                            cmd.Parameters.AddWithValue("@id_franquia", franquia);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            ds_franquia.Clear();
                            da.Fill(ds_franquia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return ds_franquia;
        }
        public DataSet GetEmailArea(int area)
        {
            DataSet ds_area = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getEmailArea]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_area", area);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            ds_area.Clear();
                            da.Fill(ds_area);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return ds_area;
        }
        public DataSet GetEmailOcorrencia(int id_ocorrencia)
        {
            DataSet ds_ocorrencia = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getEmailOcorrencia]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_ocorrencia", id_ocorrencia);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            ds_ocorrencia.Clear();
                            da.Fill(ds_ocorrencia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return ds_ocorrencia;
        }
        public DataSet DadosSolicitados(string ds_nome)
        {
            DataSet ds_solic = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getDadosSolicitante]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ds_nome", ds_nome);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            ds_solic.Clear();
                            da.Fill(ds_solic);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return ds_solic;
        }
    }
}