using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Text;
namespace PortalFranquia.dao.Chamados
{
    public class daoChamados
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;

        public DataTable GetDepartamentos(int tipo)
        {
            DataTable DSdp = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getDepartamentos]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@tipo", tipo);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DSdp.Clear();
                            da.Fill(DSdp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return DSdp;
        }
        public DataTable GetAssuntoDepartamentos(int Depto)
        {
            DataTable dt_assunto = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getDeptoAssunto]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_depto",Depto);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dt_assunto.Clear();
                            da.Fill(dt_assunto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dt_assunto;
        }
        public DataSet GetSla(int assunto)
        {
            DataSet dt_assunto = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getSla]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_assunto", assunto);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dt_assunto.Clear();
                            da.Fill(dt_assunto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dt_assunto;
        }
        public int pro_setGravaChamada(int _motivo,StringBuilder ds_descricao,int franquia,string ds_franqueado,int id_grupo)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setGravaChamado]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_motivo", _motivo);
                        cmd.Parameters.AddWithValue("@ds_descricao", ds_descricao.ToString());
                        cmd.Parameters.AddWithValue("@id_Franquia",franquia);
                        cmd.Parameters.AddWithValue("@ds_franqueado", ds_franqueado);
                        cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        public int pro_setAceitaChamado(int _idChamado,string usuario)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setAtendeChamado]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_chamado",_idChamado);
                        cmd.Parameters.AddWithValue("@ds_atendente",usuario);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno=cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        public int pro_setReabrirChamado(int _idChamado)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setReabrirChamado]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_chamado", _idChamado);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        public int pro_setEncerraChamado(int _idChamado,string ds_encerra)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setEncerraChamado]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_chamado", _idChamado);
                        cmd.Parameters.AddWithValue("@ds_comentario", ds_encerra);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        public int pro_setGravaObs(int _idChamado, string descricao)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setObsChamado]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_chamado", _idChamado);
                        cmd.Parameters.AddWithValue("@ds_comentario", descricao);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
    }
}