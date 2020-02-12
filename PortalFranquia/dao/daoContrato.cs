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
    public class daoContrato
    {
        public string  _dsNome { get; set; }
        public int _tpPessoa { get; set; }
        public string _dsCpf { get; set; }
        public string  _dsCnpj { get; set; }
        public string  _dsRg { get; set; }
        public DateTime _dtNascimento { get; set; }
        public string _dsEndereco { get; set; }
        public string  _nrResidencia { get; set; }
        public string  _dsComplemento { get; set; }
        public string _dsCep { get; set; }
        public string _dsBairro { get; set; }
        public string _dsCidade { get; set; }
        public string _dsUF { get; set; }
        public string  _nrTelResidencial { get; set; }
        public string  _nrTelCelular { get; set; }
        public string  _dsRefTelResidencial { get; set; }
        public string _dsCepCom { get; set; }
        public string _dsBairroComercial { get; set; }
        public string _dsCidadeComercial { get; set; }
        public string _dsUFComercial { get; set; }
        public string  _dsFoneComercial { get; set; }
        public string  _dsFaxComercial { get; set; }
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
        public string  _ds_modelo { get; set; }
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
        public string _id_produto { get; set; }
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public string pro_setGeraContrato()
        {
            string nr_contrato=null;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[dbo].[pro_CRM_getContratoPreVenda]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter sqp = new SqlParameter();
                        cmd.Parameters.Add("@cd_contrato", SqlDbType.VarChar,10);
                        cmd.Parameters["@cd_contrato"].Direction=ParameterDirection.Output;
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
                        cmd.Parameters.AddWithValue("@ds_Fabricante",_ds_fabricante);
                        cmd.Parameters.AddWithValue("@ds_modelo",_ds_modelo);
                        cmd.Parameters.AddWithValue("@ds_Placa",_ds_placa);
                        cmd.Parameters.AddWithValue("@ds_Ano", _ds_anoVeiculo);
                        cmd.Parameters.AddWithValue("@ds_Cor", _ds_cor);
                        cmd.Parameters.AddWithValue("@ds_Combustivel", _ds_combustivel);
                        cmd.Parameters.AddWithValue("@ds_Renavan", _ds_Renavam);
                        cmd.Parameters.AddWithValue("@ds_Chassi", _ds_Chassi);
                        cmd.Parameters.AddWithValue("@ds_Produto", _ds_Produto);
                        cmd.Parameters.AddWithValue("@cd_vendedor",_ds_vendedor);
                        cmd.Parameters.AddWithValue("@id_midia", _idmidia);
                        cmd.Parameters.AddWithValue("@tp_sexo", _ds_sexo);
                        cmd.Parameters.AddWithValue("@cd_profissao",_ds_Profissao);
                        cmd.Parameters.AddWithValue("@dt_renovacao", _dt_Renova);
                        SqlDataReader reader = cmd.ExecuteReader();
                      //  cmd.ExecuteNonQuery();
                        nr_contrato=cmd.Parameters["@cd_contrato"].Value.ToString();
                        }
                }
                catch
                {
                    throw;
                    
                }
            }
            return nr_contrato;
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
                        cmd.Parameters.AddWithValue("@nr_doc", _tpPessoa == 0 ? _dsCpf : _dsCnpj);
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
        public DataSet getPedido()
        {
            DataSet dsPedido = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidoVendas]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_pedido",_idPedido);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsPedido.Clear();
                            da.Fill(dsPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dsPedido;
        }
        public DataSet getPedidoItens()
        {
            DataSet dsPedido = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidoVendas]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_pedido", _idPedido);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsPedido.Clear();
                            da.Fill(dsPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return dsPedido;
        }
        public int pro_setVinculaPedidoContrato()
        {
            int alterado = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setVinculaContrato]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _idPedido);
                        cmd.Parameters.AddWithValue("@placa", _ds_placa);
                        cmd.Parameters.AddWithValue("@contrato",_nrcontrato);
                        alterado=cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return alterado;
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
                        using (SqlCommand cmd = new SqlCommand("[Franquia].[pro_getVerificaHabilitacao]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@placa", _ds_placa);
                            cmd.CommandTimeout = 160;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            dsHabit.Clear();
                            da.Fill(dsHabit);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsHabit;
        }
    }
}