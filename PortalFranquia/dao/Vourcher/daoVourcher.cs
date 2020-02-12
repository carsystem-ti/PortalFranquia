using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PortalFranquia.dao.Vourcher
{
    public class daoVourcher
    {
        public string _dsNome { get; set; }
        public int _tpPessoa { get; set; }
        public string _dsCpf { get; set; }
        public string _dsCnpj { get; set; }
        public string _dsRg { get; set; }
        public DateTime _dtNascimento { get; set; }
        public string _dsEndereco { get; set; }
        public string _nrResidencia { get; set; }
        public string _dsComplemento { get; set; }
        public string _dsCep { get; set; }
        public string _dsBairro { get; set; }
        public string _dsCidade { get; set; }
        public string _dsUF { get; set; }
        public string _nrTelResidencial { get; set; }
        public string _nrTelCelular { get; set; }
        public string _dsRefTelResidencial { get; set; }
        public string _dsCepCom { get; set; }
        public string _dsBairroComercial { get; set; }
        public string _dsCidadeComercial { get; set; }
        public string _dsUFComercial { get; set; }
        public string _dsFoneComercial { get; set; }
        public string _dsFaxComercial { get; set; }
        public string _dsRefComercial { get; set; }
        public string _dsEndCobranca { get; set; }
        public string _dsNrCobranca { get; set; }
        public string _dsComplementoCobranca { get; set; }
        public string _ds_CepCobranca { get; set; }
        public string _dsBairroCobranca { get; set; }
        public int _idPedido { get; set; }
        public string _ds_pontoReferencia { get; set; }
        public string _dsEmail { get; set; }
        public string _tpVeiculo { get; set; }
        public string _ds_fabricante { get; set; }
        public string _ds_modelo { get; set; }
        public string _ds_placa { get; set; }
        public string _ds_anoVeiculo { get; set; }
        public string _ds_cor { get; set; }
        public string _ds_combustivel { get; set; }
        public string _ds_Renavam { get; set; }
        public string _ds_Chassi { get; set; }
        public string _ds_Produto { get; set; }
        public string _ds_vendedor { get; set; }
        public string _ds_sexo { get; set; }
        public string _ds_Profissao { get; set; }
        public int _nrPedido { get; set; }
        public string _nrcontrato { get; set; }
        public string _idmidia { get; set; }
        public DateTime _dt_Renova { get; set; }
        public int _id_veiculo { get; set; }
        public DateTime _dt_vencimento { get; set; }
        public decimal _vl_Boleto { get; set; }
        public string _docReferencia { get; set; }
        public string _cd_Debito  { get; set; }
        public string _nrInterno { get; set; }
        public string _ds_usuario { get; set; }
        public int _cdConta { get; set; }
        public int _tipo { get; set; }
        public string _dsFiltro { get; set; }
        public string tp_venda { get; set; }
        public int _tpPagamento { get; set; }
        public int _situacaoConta { get; set; }
        public string _id_produto { get; set; }
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        
        public DataSet get_Vourcher()
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getVourcher]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo", _tipo);
                        cmd.Parameters.AddWithValue("@filtro", _dsFiltro);
                        cmd.Parameters.AddWithValue("@pedido", _idPedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataSet getValidaStatusOS(int id_pedido)
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getValidaOSMotoboy]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pedido", id_pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataTable getVeiculos()
        {
            DataTable iTable = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getProdutosVourcher]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _idPedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public int pro_seQbe()
        {
            int alterado = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setQbe]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_contrato", _nrcontrato);
                        cmd.Parameters.AddWithValue("@ds_cliente", _dsNome);
                        cmd.Parameters.AddWithValue("@nr_doc", _tpPessoa  == 0 ? _dsCpf : _dsCnpj);
                        cmd.Parameters.AddWithValue("@dt_nascimento", _dtNascimento);
                        cmd.Parameters.AddWithValue("@ds_produto", _ds_Produto);
                        cmd.Parameters.AddWithValue("@nr_cep", _dsCep);
                        cmd.Parameters.AddWithValue("@ds_endereco", _dsEndereco);
                        cmd.Parameters.AddWithValue("@nr_residencial", _nrResidencia);
                        cmd.Parameters.AddWithValue("@ds_complemento", _dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_cidade", _dsCidade);
                        cmd.Parameters.AddWithValue("@ds_bairro", _dsBairro);
                        cmd.Parameters.AddWithValue("@ds_uf", _dsUF);
                        cmd.Parameters.AddWithValue("@ds_fabricante", _ds_fabricante);
                        cmd.Parameters.AddWithValue("@ds_modelo", _ds_modelo);
                        cmd.Parameters.AddWithValue("@nr_placa", _ds_placa);
                        cmd.Parameters.AddWithValue("@ds_cor", _ds_cor);
                        cmd.Parameters.AddWithValue("@tpCombustivel", _ds_combustivel);
                        cmd.Parameters.AddWithValue("@nr_ano", _ds_anoVeiculo);
                        cmd.Parameters.AddWithValue("@nr_renavan", _ds_Renavam);
                        cmd.Parameters.AddWithValue("@nr_chassi", _ds_Chassi);
                        cmd.Parameters.AddWithValue("@cd_vendedor", _ds_vendedor);
                        cmd.Parameters.AddWithValue("@id_produto", _id_produto);
                        alterado = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return alterado;
        }
        public int pro_setVinculaContrato(string nr_contrato)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_setVinculaContrato]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_veiculo", _id_veiculo);
                        cmd.Parameters.AddWithValue("@contrato", nr_contrato);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return nr_retorno;
        }
        public int pro_setGeraBoleto()
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SGB.[Boleto].[pro_criaBoleto]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@dataVencimento ", _dt_vencimento);
                        cmd.Parameters.AddWithValue("@valorBoleto", _vl_Boleto);
                        cmd.Parameters.AddWithValue("@contrato", _nrcontrato);
                        cmd.Parameters.AddWithValue("@documentoReferencia",_nrcontrato);
                        cmd.Parameters.AddWithValue("@codigoDebito", _cd_Debito);
                        cmd.Parameters.AddWithValue("@nomeCliente", _dsNome);
                        cmd.Parameters.AddWithValue("@numeroInterno", 1);
                        cmd.Parameters.AddWithValue("@usuarioGerador", _ds_usuario);
                        cmd.Parameters.AddWithValue("@codigoConta", 0);
                        cmd.Parameters.AddWithValue("@tipoPagamento", _tpPagamento);
                        cmd.Parameters.AddWithValue("@situacaoConta", _situacaoConta);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return nr_retorno;
        }
        public string getExecuteBoleto(int pNumeroPedido)
        {
            CarSystem.Banco.NetBoleto iBoleto = new CarSystem.Banco.NetBoleto(6);
            System.Data.DataTable iTabela = new System.Data.DataTable();
            string iRetorno = "";
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Venda.pro_getBoletoVendas", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pNumeroPedido", pNumeroPedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(iTabela);
                        Int64[] ret = new Int64[iTabela.Rows.Count];
                        int i = 0;
                        foreach (DataRow dw in iTabela.Rows)
                        {
                            ret[i] = Convert.ToInt64(dw[0].ToString());
                             i++;
                        }
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
                                 
                                 iRetorno = iBoleto.getHTML(ret).Replace("<style body=>", "<style>" + iRetorno);
                            
                        return iRetorno;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
                }
            }

            return "";
        }
        public string getBoletos(int pNumeroPedido)
        {
            string iRetorno = "";

            CarSystem.Banco.NetBoleto iBoleto = new CarSystem.Banco.NetBoleto(6);

           // Int64[] iCodigo = new Int64[1];
            //Int64[] iCodigo=new Int64[];
            Int64[] iCodigo=new Int64[12];
            DataTable iret = new DataTable();

            //iCodigo[0] = getExecuteBoleto(pNumeroPedido);

          //if (t[0] == 0)
          //      return "";

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
        public DataSet ValidaPlaca(string ds_placa)
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getValidaPlaca]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ds_Placa", ds_placa);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataTable getPagamentos(int pedido)
        {
            DataTable iTable = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getPedidoPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataSet get_Monitoramento()
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getVlMonitoramento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ds_produto", _ds_Produto);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataTable get_InfPagamentos(int pedido)
        {
            DataTable iTable = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getPedidoPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public string pro_setGeraContrato()
        {
            string nr_contrato = null;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_setContrato]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter sqp = new SqlParameter();
                        cmd.Parameters.Add("@cd_contrato", SqlDbType.VarChar, 10);
                        cmd.Parameters["@cd_contrato"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@ds_nome", _dsNome);
                        cmd.Parameters.AddWithValue("@tp_Pessoa", _tpPessoa);
                        cmd.Parameters.AddWithValue("@cpf", _dsCpf);
                        cmd.Parameters.AddWithValue("@cnpj", _dsCnpj);
                        cmd.Parameters.AddWithValue("@ds_rg", _dsRg);
                        cmd.Parameters.AddWithValue("@dt_Nascimento", _dtNascimento);
                        cmd.Parameters.AddWithValue("@ds_Endereco", _dsEndereco);
                        cmd.Parameters.AddWithValue("@ds_Numero", _nrResidencia);
                        cmd.Parameters.AddWithValue("@ds_Complemento", _dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_CEP", _dsCep);
                        cmd.Parameters.AddWithValue("@ds_Bairro", _dsBairro);
                        cmd.Parameters.AddWithValue("@ds_Cidade", _dsCidade);
                        cmd.Parameters.AddWithValue("@ds_UF", _dsUF);
                        cmd.Parameters.AddWithValue("@ds_FoneRes", _nrTelResidencial);
                        cmd.Parameters.AddWithValue("@ds_FoneCel", _nrTelCelular);
                        cmd.Parameters.AddWithValue("@ds_RefResidencia", _dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_Email", _dsEmail);
                        cmd.Parameters.AddWithValue("@ds_TipoVeiculo", _tpVeiculo);
                        cmd.Parameters.AddWithValue("@ds_Fabricante", _ds_fabricante);
                        cmd.Parameters.AddWithValue("@ds_modelo", _ds_modelo);
                        cmd.Parameters.AddWithValue("@ds_Placa", _ds_placa);
                        cmd.Parameters.AddWithValue("@ds_Ano", _ds_anoVeiculo);
                        cmd.Parameters.AddWithValue("@ds_Cor", _ds_cor);
                        cmd.Parameters.AddWithValue("@ds_Combustivel", _ds_combustivel);
                        cmd.Parameters.AddWithValue("@ds_Renavan", _ds_Renavam);
                        cmd.Parameters.AddWithValue("@ds_Chassi", _ds_Chassi);
                        cmd.Parameters.AddWithValue("@ds_Produto", _ds_Produto);
                        cmd.Parameters.AddWithValue("@cd_vendedor", _ds_vendedor);
                        cmd.Parameters.AddWithValue("@id_midia", _idmidia);
                        cmd.Parameters.AddWithValue("@tp_sexo", _ds_sexo);
                        cmd.Parameters.AddWithValue("@cd_profissao", _ds_Profissao);
                        cmd.Parameters.AddWithValue("@dt_renovacao", _dt_Renova);
                        cmd.Parameters.AddWithValue("@StrCT", _nrPedido);
                        cmd.Parameters.AddWithValue("@ds_usuarioCadastro", _ds_usuario);

                        string x = "";
                        foreach (SqlParameter a in cmd.Parameters)
                        {
                            x += a.ParameterName + "= '" + a.Value + "',";
                        }

                        SqlDataReader reader = cmd.ExecuteReader();
                          //cmd.ExecuteNonQuery();
                        nr_contrato = cmd.Parameters["@cd_contrato"].Value.ToString();
                    }
                }
                catch
                {
                    throw;

                }
            }
            return nr_contrato;
        }
        public DataTable getProdutos(int  pedido)
        {
            DataTable iTable = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getProdutosVourcher]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataTable getCoresAutomotivas()
        {
            DataTable iTable = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getCoresAutomotivas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return iTable;
        }
        public DataSet ValidaHabilitacao()
        {
            DataSet dsHabit = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Venda].[pro_getVerificaHabilitacao]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_veiculo", _id_veiculo);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsHabit.Clear();
                            da.Fill(dsHabit);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return dsHabit;
        }
        public DataSet ValidaGeracaoPedidos(string _nrDocumento,string _ds_placa)
        {
            DataSet dsValida = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getValidaPedido]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nrDocumento", _nrDocumento);
                        cmd.Parameters.AddWithValue("@placa", _ds_placa);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsValida.Clear();
                        da.Fill(dsValida);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return dsValida;
        }
        public DataTable getTpVenda(int pedido)
        {
            DataTable ds_tp = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getTpVenda]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", pedido);
                        //cmd.Parameters.AddWithValue("@id_veiculo", id_veiculo);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_tp.Clear();
                        da.Fill(ds_tp);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return ds_tp;
        }
        public DataSet getItensVeiculo()
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getItensVourcher]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo", _tipo);
                        cmd.Parameters.AddWithValue("@pedido", _idPedido);
                        cmd.Parameters.AddWithValue("@id_veiculo", _id_veiculo);
                        cmd.Parameters.AddWithValue("@filtro", _dsFiltro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
        public DataSet getVourcherPedidos()
        {
            DataSet iTable = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_getItensVourcher]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipo", _tipo);
                        cmd.Parameters.AddWithValue("@pedido", _idPedido);
                        cmd.Parameters.AddWithValue("@id_veiculo", _id_veiculo);
                        cmd.Parameters.AddWithValue("@filtro", _dsFiltro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        iTable.Clear();
                        da.Fill(iTable);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return iTable;
        }
    }
}