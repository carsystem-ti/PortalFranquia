using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao.Cadastro
{
    public class daoCadastro
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int pro_setIncluirObs(string strContrato, string strUser, string strObs)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[dbo].[pro_CAC_incObs]", conn);

                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nr_pedido", strContrato);
                        cmd.Parameters.AddWithValue("@ds_user", strUser);
                        cmd.Parameters.AddWithValue("@ds_obs", strObs);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = Convert.ToInt32(cmd.ExecuteNonQuery());
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