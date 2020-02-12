using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace PortalFranquia.dao
{
    public class daoPedidoVendaVeiculo
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        #region Atributos Veiculos
        public int _idPedido { get; set; }
        public int _idItem { get; set; }
        public int _idmodelo { get; set; }
        public string _dsplaca { get; set; }
        public string _dsCor { get; set; }
        public string _dsCombustivel { get; set; }
        public string _dsAno { get; set; }
        public string _dsRenavan { get; set; }
        public string _dsChassi { get; set; }
        public string _anoVeiculo { get; set; }
        public int _tipoveiculo { get; set; }
        #endregion

        public int pro_setPedidoVendaVeiculo(int pedido,int item,int idmodelo,string placa,string cor,string combustivel,string ano,string renavan,string chassi)
        {
            int nr_pedidoVeiculo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraVeiculo]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", pedido);
                        cmd.Parameters.AddWithValue("@id_item", item);
                        cmd.Parameters.AddWithValue("@id_modelo", idmodelo);
                        cmd.Parameters.AddWithValue("@ds_placa", placa);
                        cmd.Parameters.AddWithValue("@ds_cor", cor);
                        cmd.Parameters.AddWithValue("@ds_combustivel", combustivel);
                        cmd.Parameters.AddWithValue("@ds_ano", ano);
                        cmd.Parameters.AddWithValue("@ds_Renavan", renavan);
                        cmd.Parameters.AddWithValue("@ds_Chassi", chassi);
                        nr_pedidoVeiculo = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoVeiculo;
        }
    }
}