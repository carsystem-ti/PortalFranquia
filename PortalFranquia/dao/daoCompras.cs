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
    public class daoCompras
    {
        public DataTable pro_getCompras(string strContrato)
        {
            ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;

            DataTable dtCompras = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[dbo].[pro_getCompras]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@str_Contrato", strContrato);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtCompras.Clear();
                        da.Fill(dtCompras);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dtCompras;
        }
    }
}