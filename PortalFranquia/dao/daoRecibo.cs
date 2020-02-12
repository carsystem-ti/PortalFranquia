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
    public class daoRecibo
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public DataSet getRecibo(int pedido)
        {
            DataSet ds_recibo = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getRecibo]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_recibo.Clear();
                        da.Fill(ds_recibo);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_recibo;
        }
        public DataTable getReciboItens(int pedido)
        {
            DataTable ds_recibo = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getReciboItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_recibo.Clear();
                        da.Fill(ds_recibo);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_recibo;
        }
    }
}