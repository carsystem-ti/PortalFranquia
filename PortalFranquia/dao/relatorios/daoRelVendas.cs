using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao.relatorios
{
    public class daoRelVendas
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        #region atributos
        public int _idfranquia { get; set; }
        public string _dsfranquia { get; set; }
        public DateTime _dtconfirmacao { get; set; }
        public string _dsvendedor { get; set; }
        public int _nrcontrato { get; set; }
        public int _dscliente { get; set; }
        public int _idpedido { get; set; }
        public string _iditem { get; set; }
        public string _dsproduto { get; set; }
        public string _vlunitario { get; set; }
        public DateTime _dateinicial { get; set; }
        public DateTime _datefinal { get; set; }
        public static string nomeFranquia { get; set; }
        public string periodo { get; private set; }
        


        #endregion



        public DataTable franquiarelatoriovendas(int ano, int mes, int franquia)
        {
            DateTime _dateinicial = new DateTime(ano, mes, 1);
            DateTime _datefinal = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            this.periodo = _dateinicial.ToString("dd/MM/yyyy") + " a " + _datefinal.ToString("dd/MM/yyyy");

            DataTable dtretorno = new DataTable();

            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidoVendasPorVendedor]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_franquia", franquia);
                        cmd.Parameters.AddWithValue("@dt_ini", _dateinicial);
                        cmd.Parameters.AddWithValue("@dt_fim", _datefinal);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtretorno.Clear();
                        da.Fill(dtretorno);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return dtretorno;
        }
        
    }
}