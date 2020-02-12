using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao.Bordero
{
    public class DaoBordero
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataTable pro_getCarteiraBordero(int franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getDadosBordero", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_franquia",franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public DataTable pro_getCarteiraBorderoTroca(int franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getDadosBorderoTroca", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_franquia", franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public int pro_setBordero(int _franquia,DateTime _dtBase, string _dsUsuario, string _usuarioEnvio)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setBordero]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        cmd.Parameters.AddWithValue("@dt_base", _dtBase);
                        cmd.Parameters.AddWithValue("@ds_usuario", _usuarioEnvio);
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
        public int pro_setBorderoItens(int tipo,int Bordero,DateTime dt_vencimento,string nr_cheque,decimal vlValor,string Cmc7,string nr_contrato,decimal vl_liquido,
            string ds_nometitular,int id_pedido,string banco,string agencia,string conta,string documento,string usuarioEnvio)
        {
            int nr_itens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setBorderoItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo",tipo);
                        cmd.Parameters.AddWithValue("@id_bordero", Bordero);
                        cmd.Parameters.AddWithValue("@id_pedido", id_pedido);
                        cmd.Parameters.AddWithValue("@nr_contrato", nr_contrato);
                        cmd.Parameters.AddWithValue("@dt_vencimento",dt_vencimento);
                        cmd.Parameters.AddWithValue("@nr_cheque", nr_cheque);
                        cmd.Parameters.AddWithValue("@nr_banco", banco);
                        cmd.Parameters.AddWithValue("@nr_agencia", agencia);
                        cmd.Parameters.AddWithValue("@nr_conta", conta);
                        cmd.Parameters.AddWithValue("@nr_documento", documento);
                        cmd.Parameters.AddWithValue("@vl_cheque", vlValor);
                        cmd.Parameters.AddWithValue("@nr_ccm7",Cmc7);
                        cmd.Parameters.AddWithValue("@vl_liquido",vl_liquido);
                        cmd.Parameters.AddWithValue("@ds_titularCheque", ds_nometitular);
                        cmd.Parameters.AddWithValue("@usuarioEnvio", usuarioEnvio);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_itens = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_itens;
        }
        public int fl_chequesFranquia(int pedido,string cheque)
        {
            int retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_set_flChequeFranquia]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        cmd.Parameters.AddWithValue("@cheque", cheque);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        retorno =cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return retorno;
        }
        public DataTable pro_getDadosBordero(int tp,int _bordero,int _franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getBordero", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tp", tp);
                        cmd.Parameters.AddWithValue("@id",_bordero);
                        cmd.Parameters.AddWithValue("@idFranquia",_franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public DataTable getBorderoContrato(int tp,string nr_contrato,int _franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getBorderoPorContrato", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tp", tp);
                        cmd.Parameters.AddWithValue("@contrato", nr_contrato);
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public DataTable pro_getBorderopedido(int tp,int pedido,int _franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getBorderoPorPedido", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tp",tp);
                        cmd.Parameters.AddWithValue("@id", pedido);
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public int pro_seGeraContasReceber(string nr_documento,string ds_cliente,string ds_TitularContrato,string Cpf,string banco,string conta,string cheque,DateTime dt_vencimento,decimal vl_cheque,string usuario,string agencia)
        {
            int retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setChequeFranquia]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@doc",nr_documento);
                        cmd.Parameters.AddWithValue("@cli", ds_cliente);
                        cmd.Parameters.AddWithValue("@tit",ds_TitularContrato);
                        cmd.Parameters.AddWithValue("@cpf",Cpf);
                        cmd.Parameters.AddWithValue("@ban",banco);
                        cmd.Parameters.AddWithValue("@con",conta);
                        cmd.Parameters.AddWithValue("@che",cheque);
                        cmd.Parameters.AddWithValue("@dtv",dt_vencimento);
                        cmd.Parameters.AddWithValue("@val",vl_cheque);
                        cmd.Parameters.AddWithValue("@usu",usuario);
                        cmd.Parameters.AddWithValue("@age",agencia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        retorno=cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return retorno;
        }
        public DataSet getObsBordero(int bordero,string cheque)
        {
            DataSet ds_bordero = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getObsBordero", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_bordero", bordero);
                        cmd.Parameters.AddWithValue("@cheque", cheque);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_bordero.Clear();
                        da.Fill(ds_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_bordero;
        }
        public int pro_setRecusaCheque(int bordero,string cheque)
        {
            int retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setRecusaChequeBordero]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idBordero", bordero);
                        cmd.Parameters.AddWithValue("@cheque", cheque);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        retorno=cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return retorno;
        }
        public int pro_setObsCheque(int bordero, string cheque,string obs)
        {
            int retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_SetObsBordero]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_bodero", bordero);
                        cmd.Parameters.AddWithValue("@cheque", cheque);
                        cmd.Parameters.AddWithValue("@obs", obs);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return retorno;
        }
        public DataTable pro_getCorrigirCheque(int pedido,int franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getCorrigiChequeVenda", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id",pedido);
                        cmd.Parameters.AddWithValue("@id_franquia",franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
        public DataTable pro_getCorrigirChequeTroca(int pedido, int franquia)
        {
            DataTable dt_bordero = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getCorrigiChequeTroca", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", pedido);
                        cmd.Parameters.AddWithValue("@id_franquia", franquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_bordero.Clear();
                        da.Fill(dt_bordero);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_bordero;
        }
    }
}