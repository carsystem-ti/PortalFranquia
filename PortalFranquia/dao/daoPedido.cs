﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace PortalFranquia.dao
{
    public class daoPedido
    {
        public int _tipo { get; set; }
        public string _nrDocumento { get; set; }
        public int _pedido { get; set; }
        public string _mensagem { get; set; }

        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;

        public Int64 getCodigoBoleto(int pNumeroPedido, bool pIsTaxa)
        {

            System.Data.DataTable iTabela = new System.Data.DataTable();

            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getCodigoBoleto", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pNumeroPedido", pNumeroPedido);
                        cmd.Parameters.AddWithValue("@pIsTaxa", pIsTaxa);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(iTabela);

                        if (iTabela.Rows.Count > 0)
                            return Convert.ToInt64(iTabela.Rows[0][0]);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
                }
            }

            return 0;            
        }
        

        public int pro_setPedido(int _franquia, string _dsusuario, string _nrcep, string _nrEndereco, string _dsEndereco, string _dsComplemento, string _dsBairro, string _dsCidade, int _tpEntrega, string _Observacao, string _dsUF, string _Obs)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedido]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        cmd.Parameters.AddWithValue("@usuarioPedido", _dsusuario);
                        cmd.Parameters.AddWithValue("@cep", _nrcep);
                        cmd.Parameters.AddWithValue("@ds_endereco", _dsEndereco);
                        cmd.Parameters.AddWithValue("@ds_complemento", _dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_Bairro", _dsBairro);
                        cmd.Parameters.AddWithValue("@nr_Endereco", _nrEndereco);
                        cmd.Parameters.AddWithValue("@ds_cidade", _dsCidade);
                        cmd.Parameters.AddWithValue("@ds_uf", _dsUF);
                        cmd.Parameters.AddWithValue("@tpEntrega", _tpEntrega);
                        cmd.Parameters.AddWithValue("@ds_Obs", _Obs);
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
        public DataTable pro_getPedidos(int _status)
        {
            DataTable dt_data = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidosStatus]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", _status);
                        //cmd.Parameters.AddWithValue("@dataInicial", dt_inicial);
                        //cmd.Parameters.AddWithValue("@dataFinal", dt_final);
                        // cmd.Parameters.AddWithValue("@idfranquia", idFranquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_data.Clear();
                        da.Fill(dt_data);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_data;
        }
        public DataTable pro_getFiltroPedidos(int status, int idFranquia)
        {
            DataTable dt_data = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getFiltroPedidos", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idfranquia", idFranquia);
                        cmd.Parameters.AddWithValue("@status", status);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_data.Clear();
                        da.Fill(dt_data);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_data;
        }
        public int pro_setAlteraStatus(int _pedido, int _status)
        {
            int nr_altera = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setAlteraStatus]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _pedido);
                        cmd.Parameters.AddWithValue("@status", _status);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_altera = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_altera;
        }
        public int pro_setVinculaNota(int _pedido,int _Nrnota,string nr_serie,DateTime dt_nota)
        {
            int nr_altera = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setVinculaNota]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _pedido);
                        cmd.Parameters.AddWithValue("@nr_nota", _Nrnota);
                        cmd.Parameters.AddWithValue("@nr_serie", nr_serie);
                        cmd.Parameters.AddWithValue("@dtnota", dt_nota);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_altera = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_altera;
        }
        public DataTable PedidosContrato(int _pedido)
        {
            DataTable dt_pedidos = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidosGerados]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pedido",_pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_pedidos.Clear();
                        da.Fill(dt_pedidos);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_pedidos;
        }
        public DataSet ValidaGeracaoPedidos()
        {
            DataSet dsValida = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValidaGeracaoPedido]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nrDocumento",_nrDocumento);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsValida.Clear();
                        da.Fill(dsValida);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsValida;
        }
        public DataSet getLogCompra()
        {
            DataSet dsLog = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getLogPedidoCompra]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pedido", _pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsLog.Clear();
                        da.Fill(dsLog);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsLog;
        }
        public bool GravaLogCompra()
        {
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[franquia].[pro_setLogPedidoCompra]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpedido", _pedido);
                        cmd.Parameters.AddWithValue("@Observacao", _mensagem);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return true;
        }
        public string executaBoleto(int pNumeroPedido, bool pIsTaxa)
        {
            string iRetorno = "";

            CarSystem.Banco.NetBoleto iBoleto = new CarSystem.Banco.NetBoleto(6);

            Int64[] iCodigo = new Int64[1];
            iCodigo[0] = getCodigoBoleto(pNumeroPedido, pIsTaxa);

            if (iCodigo[0] == 0)
                return "";

            iRetorno = "td{"
                + "margin: 0;"
                + "padding: 0;"
                + "border: 0;"
                + "outline: 0;"
                + "font-weight: inherit;"
                + "font-style: inherit;"
                + "font-size: 100%;"
                + "font-family: inherit;"
                + "vertical-align: none;"
                + "background-color: white;"
                + "}"
                + "";

            iRetorno = iBoleto.getHTML(iCodigo).Replace("<style>", "<style>" + iRetorno);

            return iRetorno;
        }
    }

}