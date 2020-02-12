using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao
{
    public class daoPedidoVenda
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;

        public int pro_setPedidoVenda(int idFranquia,int id_vendedor,string dsnome,string tpCliente,string dsCep,string dsEndereco,string nr_endereco,string dsComplemento,string dsBairro,string dsCidade,string dsUf,string dsDoc,string dddTel,string dsTelResidencial,string dddCel,string nr_cel,string dddComerc,string nr_comercial,int id_consulta,DateTime dt_consulta,string statusConsulta,string rg,string tiposexo,DateTime dt_nascimento,string email,int cd_profisao,string midia)
        {
            int nr_pedido = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoVenda]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idFranquia",idFranquia);
                        cmd.Parameters.AddWithValue("@id_vendedor", id_vendedor);
                        cmd.Parameters.AddWithValue("@ds_nome", dsnome);
                        cmd.Parameters.AddWithValue("@tp_cliente", tpCliente);
                        cmd.Parameters.AddWithValue("@nr_cep", dsCep);
                        cmd.Parameters.AddWithValue("@ds_endereco", dsEndereco);
                        cmd.Parameters.AddWithValue("@nr_endereco", nr_endereco);
                        cmd.Parameters.AddWithValue("@ds_complemento",dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_bairro",dsBairro);
                        cmd.Parameters.AddWithValue("@ds_cidade",dsCidade);
                        cmd.Parameters.AddWithValue("@ds_uf",dsUf);
                        cmd.Parameters.AddWithValue("@ds_documento",dsDoc);
                        cmd.Parameters.AddWithValue("@ddTel",dddTel);
                        cmd.Parameters.AddWithValue("@nr_Tel",dsTelResidencial);
                        cmd.Parameters.AddWithValue("@dddCel",dddCel);
                        cmd.Parameters.AddWithValue("@nr_Cel",nr_cel);
                        cmd.Parameters.AddWithValue("@dddComercial",dddComerc);
                        cmd.Parameters.AddWithValue("@nr_Comercial",nr_comercial);
                        cmd.Parameters.AddWithValue("@id_ConsultaCredito", id_consulta);
                        cmd.Parameters.AddWithValue("@dtConsultaCredito", dt_consulta.Date);
                        cmd.Parameters.AddWithValue("@ds_statusConsulta",statusConsulta);
                        cmd.Parameters.AddWithValue("@nr_RG",rg);
                        cmd.Parameters.AddWithValue("@tpSexo",tiposexo );
                        cmd.Parameters.AddWithValue("@dt_nascimento",dt_nascimento.Date);
                        cmd.Parameters.AddWithValue("@dsEmail",email);
                        cmd.Parameters.AddWithValue("@cdProfissao",cd_profisao);
                        cmd.Parameters.AddWithValue("@idmidia",midia);
                        nr_pedido = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch 
                {
                    throw;
                }
            }
            return nr_pedido;
        }
        public DataTable getProfisao()
        {
            DataTable dt_ocup = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getOcupacao]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_ocup.Clear();
                        da.Fill(dt_ocup);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_ocup;
        }
        public DataTable getMeusPedidos(int tipo,DateTime dtInicial ,DateTime dt_final, int franquia)
        {
            DataTable dtMeusPedidos = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getMeusPedidosVendas]", conn);
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
        public DataTable getMeusPedidosCompras(int tipo, DateTime dtInicial, DateTime dt_final, int franquia)
        {
            DataTable dtMeusPedidos = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getMeusPedidosCompras]", conn);
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
        public DataTable getFranquiaCetecs()
        {
            DataTable dtMeusPedidos = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getFranquiasCetes]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
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
        public DataSet  ValorRepasse(int id_produto)
        {
            DataSet dt_tecnologia = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getVlRepasseVenda]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idproduto",id_produto);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dt_tecnologia.Clear();
                            da.Fill(dt_tecnologia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_tecnologia;
        }
        public DataSet ValorHabilitacaoMonitoramento(string dsProduto)
        {
            DataSet dt_tecnologia = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getVlMonitoramento]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@dsproduto", dsProduto);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dt_tecnologia.Clear();
                            da.Fill(dt_tecnologia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_tecnologia;
        }
        public DataSet Midias()
        {
            DataSet dt_tecnologia = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getMidiasFraquias]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dt_tecnologia.Clear();
                            da.Fill(dt_tecnologia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_tecnologia;
        }
     
    }
}