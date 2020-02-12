using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PortalFranquia.interfaces;
using System.Web.Configuration;
using System.Configuration;

namespace PortalFranquia.dao.OS
{
    public class daoOSConsulta : Dados
    {
        #region Propriedades Lidas
        public string dsPlaca { get; private set; }
        public string nrPedido { get; private set; }
        public string dsNome { get; private set; }
        public string dsModelo { get; private set; }
        public int nrTotOS { get; private set; }
        public string nrUltOS { get; private set; }
        public string dsTipoOS { get; private set; }
        public string dsTipoProduto { get; private set; }
        public string nrVersao { get; private set; }
        public string dsStatusSinistro { get; private set; }
        public int? tpVigencia { get; private set; }
        public DateTime? dtAtualizacao { get; private set; }
        public string dsStatusOS { get; private set; }
        public string dsTecnico { get; private set; }

        public bool OSinstalacao
        {
            get
            {
                return nrTotOS == 0;
            }
        }
        public bool OSsuporte
        {
            get
            {
                return nrTotOS > 0 && dsStatusOS != "0";
            }
        }
        public bool OSretirada
        {
            get
            {
                return dsTipoOS != "Retirada" && dsStatusOS != "0";
            }
        }
        public bool OSreinstalacao
        {
            get
            {
                return dsTipoOS == "Retirada" && dsStatusOS != "0";
            }
        }
        public bool OStroca
        {
            get
            {
                return dsTipoProduto.IndexOf("NS") > 0 && dsStatusOS != "0";
            }
        }
        public bool OSrecall
        {
            get
            {
                try
                {
                    return Convert.ToInt32(nrVersao.Substring(1, 1)) <= 4 && dsStatusOS != "0";
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool OSrevisaoPlus
        {
            get
            {
                return dsTipoProduto.IndexOf("PLUS") > -1 && dsStatusOS != "0";
            }
        }
        public bool OSconstatacao
        {
            get
            {
                return dsStatusOS != "0";
            }
        }
        public string nrIDAtual { get; private set; }
        public string nrTelefoneRastreador { get; private set; }
        public string dsAtivoOperadora { get; private set; }
        public string dsStatusCliente { get; private set; }
        public string nrCPFCNPJ { get; private set; }
        public string nrRGInsEstadual { get; private set; }
        public DateTime? dtNascimento { get; private set; }
        public DateTime? dtVenda { get; private set; }
        public DateTime? dtConfirmacao { get; private set; }
        public string dsFabricanteVeiculo { get; private set; }
        public string dsTipoVeiculo { get; private set; }
        public int? nrAno { get; private set; }
        public string nrRENAVAN { get; private set; }
        public string nrChassi { get; private set; }
        public string dsCombustivel { get; private set; }
        public string dsCorVeiculo { get; private set; }
        public string dsStatusAtendimento { get; private set; }
        public string dsVendaStatus { get; private set; }
        #endregion

        #region Propriedades para gravação
        public string nw_dsTipoOS { get; set; }
        public string nw_nrNovoID { get; set; }
        public string nw_dsMotivoTroca { get; set; }
        public string nw_nrOSStatus { get; set; }
        public string nw_dsInformacoesOS { get; set; }
        public string nw_dsNomeUsuario { get; set; }
        public string nw_cdEmpInstaladora { get; set; }
        public string nw_dsNomeInstalador { get; set; }
        public string nw_dsEnderecoOS { get; set; }
        public string nw_dsBairroOS { get; set; }
        public string nw_dsCidadeOS { get; set; }
        public string nw_dsUFOS { get; set; }
        public string nw_FoneContatoOS { get; set; }
        public string nw_PontoReferenciaOS { get; set; }
        public string nw_RegiaoOS { get; set; }
        public string nw_EnderecoNumeroOS { get; set; }
        public string nw_dsCidadeKMOS { get; set; }
        public string nw_cdCidadeKMOS { get; set; }
        public string nw_cdMotivoCancelamentoOS { get; set; }
        #endregion

        #region Retorno de Pesquisas
        public DataTable dtRetornoCPF { get; private set; }
        #endregion
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        protected override void leReader(SqlDataReader dataReader)
        {
            if (dataReader.Read())
            {
                dsPlaca = dataReader["ds_Placa"].ToString();
                nrPedido = dataReader["nr_Pedido"].ToString();
                dsNome = dataReader["ds_Nome"].ToString();
                dsModelo = dataReader["ds_Modelo"].ToString();
                nrTotOS = Convert.ToInt32(dataReader["nr_TotOS"]);
                nrUltOS = dataReader["nr_UltOS"].ToString();
                dsTipoOS = dataReader["ds_TipoOS"].ToString();
                dsTipoProduto = dataReader["ds_TipoProduto"].ToString();
                nrVersao = dataReader["nr_Versao"].ToString();
                dsStatusSinistro = dataReader["ds_StatusSinistro"].ToString();
                tpVigencia = dataReader["tp_Vigencia"] as int?;
                dtAtualizacao = dataReader["dt_Atualizacao"] as DateTime?;
                nrIDAtual = dataReader["nr_IDAtual"].ToString();
                nrTelefoneRastreador = dataReader["nr_TelefoneRastreador"].ToString();
                dsAtivoOperadora = dataReader["ds_RastreadorAtivoOperadora"].ToString();
                dsStatusCliente = dataReader["ds_StatusCliente"].ToString();
                nrCPFCNPJ = dataReader["nr_CPFCNPJ"].ToString();
                nrRGInsEstadual = dataReader["nr_RGInsEstadual"].ToString();
                dtNascimento = dataReader["dt_Nascimento"] as DateTime?;
                dtVenda = dataReader["dt_Venda"] as DateTime?;
                dtConfirmacao = dataReader["dt_Confirmacao"] as DateTime?;
                dsFabricanteVeiculo = dataReader["ds_FabricanteVeiculo"].ToString();
                dsTipoVeiculo = dataReader["ds_TipoVeiculo"].ToString();
                nrAno = dataReader["nr_Ano"] as int?;
                nrRENAVAN = dataReader["nr_RENAVAN"].ToString();
                nrChassi = dataReader["nr_Chassi"].ToString();
                dsCombustivel = dataReader["ds_Combustivel"].ToString();
                dsCorVeiculo = dataReader["ds_CorVeiculo"].ToString();
                dsStatusOS = dataReader["ds_StatusOS"].ToString();
                dsStatusAtendimento = dataReader["ds_StatusAtendimento"].ToString();
                dsVendaStatus = dataReader["ds_VendaStatus"].ToString();
                dsTecnico = dataReader["Os instalador"].ToString();
            }
            else
                throw new Exception("Cliente não encontrado !");
        }

        public void getOSPlaca(string dsPlaca)
        {
            dtRetornoCPF = null;

            SqlParameter[] parametros = {
                                            new SqlParameter("@ds_Placa", dsPlaca),
                                            new SqlParameter("@nr_Contrato", "")
                                        };

            try
            {
                getDataReaderProc("cnxFranquia", "OrdemServico.pro_getCliente", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getOSInstalador(string cd_cetec)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@cd_CETEC", cd_cetec)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "OrdemServico.pro_getTecnicos", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getAcaoOs(int id_grupo)
        {
            SqlParameter[] parametros = {
                                        new SqlParameter("@id_grupo", id_grupo)

                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "OrdemServico.pro_getAcaoOs", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getEmpresa()
        {
            SqlParameter[] parametros = {

                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getLojas]", null);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getAMotivoOs(int nr_os)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@nr_os", nr_os)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getProcedimentoServico]", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getDetalhesEncerramento(int nr_os)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@nr_os", nr_os)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getDetalheEncerramento]", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getDetalhesMotivoOs(int id_detalhe)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@intServico", id_detalhe)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "dbo.Proc_CX_CETEC_Get_ProcedimentoServico_Itens", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getItensMotivoOs(int id_detalhe)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@id_itens", id_detalhe)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getItensEncerramento]", parametros);
            }
            catch
            {
                throw;
            }

        }
        public DataTable pro_getInfOS(int nr_os)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@nr_os", nr_os)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getOs]", parametros);
            }
            catch
            {
                throw;
            }

        }

        public DataTable pro_getLead(int id_os)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@id_itens", id_os)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "[OrdemServico].[pro_getItensEncerramento]", parametros);
            }
            catch
            {
                throw;
            }

        }

        public string set_CadastrarInstalador(string nomeInstalador, string codigoCetec)
        {
            string nr_retorno = "";
            try
            {

                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[Principal].[dbo].[pro_setCadastrarInstalador]", conn);
                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nomeInstalador", nomeInstalador);
                    cmd.Parameters.AddWithValue("@codigoCetec", codigoCetec);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    nr_retorno = cmd.ExecuteScalar().ToString();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return nr_retorno;
        }
        public object set_DesativaTecnico(Int32 intIdUsuario)
        {
            object nr_retorno = "";
            try
            {

                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[Principal].[dbo].[pro_setDesativaTecnico]", conn);
                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_usuario", intIdUsuario);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    nr_retorno = cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return nr_retorno;
        }
        public object set_Voucher(int idOS, int nr_voucher, string usuario)
        {
            object nr_retorno = "";
            try
            {

                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AgendaWeb.pro_setVoucherOS", conn);
                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@numeroVoucher", nr_voucher);
                    cmd.Parameters.AddWithValue("@numeroOS", idOS);
                    cmd.Parameters.AddWithValue("@ds_usuario", usuario);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    nr_retorno = cmd.ExecuteScalar();


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return nr_retorno;
        }
        // Miguel - inicio - 21/02

        // public string pro_setOs(int id_status, int nr_os, string problemaResolvido, string ds_medidaAdotada, string ds_acaoServico, string ds_trocaID, string ds_resolvidoPor, string tecnico, string usuariologado)
        public int pro_setOs(int id_status, int nr_os, string ds_medidaAdotada, string ds_acaoServico, string tecnico, string usuariologado)

        // Miguel - fim - 21/02



        {
            if (ds_acaoServico == "Revis&#227;o-PLUS")
            {
                ds_acaoServico = "Revisão-PLUS";
            }
            if (ds_acaoServico == "Instala&#231;ao")
            {
                ds_acaoServico = "Instalaçao";
            }

            //if (ds_acaoServico == "Instala&#231;ao")
            //{
            //    ds_acaoServico = "Instalaçao";
            //}

            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[OrdemServico].[pro_setEncerraOS]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Os_status", id_status);
                        cmd.Parameters.AddWithValue("@IDOS", nr_os);
                        cmd.Parameters.AddWithValue("@Usuario_Logado", usuariologado);

                        // Miguel - inicio - 21/02
                        // cmd.Parameters.AddWithValue("@Problema_foi_resolvido",problemaResolvido);
                        // Miguel - fim - 21/02

                        cmd.Parameters.AddWithValue("@Medida_adotada", ds_medidaAdotada);
                        cmd.Parameters.AddWithValue("@Acao_do_serviço", ds_acaoServico);

                        // Miguel - inicio - 21/02
                        // cmd.Parameters.AddWithValue("@Houvi_troca_equip",ds_trocaID);
                        // cmd.Parameters.AddWithValue("@Resolvido_por",ds_resolvidoPor);
                        // Miguel - fim - 21/02

                        // cmd.Parameters.AddWithValue("@Emp_instala", ds_empresa);
                        cmd.Parameters.AddWithValue("@Os_instalador", tecnico);
                        //cmd.Parameters.AddWithValue("@id_motivoOs", id_motivo);
                        string x = "";
                        foreach (SqlParameter a in cmd.Parameters)
                        {
                            x += a.ParameterName + "= '" + a.Value + "',";
                        }
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
        public string CancelaOS(int idOS, string usuario, string motivoCancelamento)
        {
            string nr_retorno = "";
            try
            {

                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[OrdemServico].[pro_setCancelaOs]", conn);
                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDOS", idOS);
                    cmd.Parameters.AddWithValue("@Usuario_Logado", usuario);
                    cmd.Parameters.AddWithValue("@Motivo_Cancelamento", motivoCancelamento);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    nr_retorno = cmd.ExecuteScalar().ToString();


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return nr_retorno;
        }
        public int pro_setItensOs(int nr_os, int id_motivo)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[OrdemServico].[pro_set_DetalheOs]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_os", nr_os);
                        cmd.Parameters.AddWithValue("@id_motivo", id_motivo);
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
        public int pro_setExcluirItensOs(int nr_os, int id_motivo)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[OrdemServico].[pro_set_ExcluiDetalheOs]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_os", nr_os);
                        cmd.Parameters.AddWithValue("@id_motivo", id_motivo);
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
        public void getOSPedido(string dsPedido)
        {
            dtRetornoCPF = null;

            SqlParameter[] parametros = {
                                            new SqlParameter("@nr_Contrato", dsPedido),
                                            new SqlParameter("@ds_Placa", "")
                                        };

            try
            {
                getDataReaderProc("cnxFranquia", "OrdemServico.pro_getCliente", parametros);
            }
            catch
            {
                throw;
            }
        }

        public void getClientesCPF(string CPFCNPJ)
        {
            // Coloca mascara no campo
            if (CPFCNPJ.Length == 11)
                CPFCNPJ = CPFCNPJ.Substring(0, 3) + '.' + CPFCNPJ.Substring(3, 3) + '.' + CPFCNPJ.Substring(6, 3) + '-' + CPFCNPJ.Substring(9, 2);
            else
                if (CPFCNPJ.Length == 14)
                CPFCNPJ = CPFCNPJ.Substring(0, 2) + '.' + CPFCNPJ.Substring(2, 3) + '.' + CPFCNPJ.Substring(5, 3) + '/' + CPFCNPJ.Substring(8, 4) + '-' + CPFCNPJ.Substring(12, 2);

            SqlParameter[] parametros = {
                                            new SqlParameter("@CPFCNPJ", CPFCNPJ)
                                        };

            try
            {
                dtRetornoCPF = getDataTableProc("cnxFranquia", "OrdemServico.pro_getClientesCPF", parametros);
            }
            catch
            {
                throw;
            }
        }

        public bool find(string parametro, string valor)
        {
            try
            {
                dtRetornoCPF = null;
                nrPedido = "";
                if (parametro == "nr_Contrato")
                    getOSPedido(valor);
                else
                    if (parametro == "nr_Placa")
                    getOSPlaca(valor);
                else
                    getClientesCPF(valor);

                if ((nrPedido != "") || (parametro == "nr_CPF" && dtRetornoCPF.Rows.Count > 0))
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getEquipamentosDisponiveis(string IDFranquia)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@servicoExecutado", nw_dsTipoOS),
                                            new SqlParameter("@empresaInstaladora", IDFranquia),
                                            new SqlParameter("@contratoCliente", nrPedido)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "Franquia.pro_getEquipamentosDisponiveis", parametros);
            }
            catch
            {
                throw;
            }

        }

        public DataTable getMotivosTroca()
        {
            try
            {
                return getDataTableProc("cnxFranquia", "Troca.pro_getMotivosTroca", null);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getTecnicos(string cd_CETEC)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@cd_CETEC", cd_CETEC)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "OrdemServico.pro_getTecnicos", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getTecnicoslOJAS(int nr_os)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@nr_os", nr_os)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "OrdemServico.pro_getLojasTecnicos", parametros);
            }
            catch
            {
                throw;
            }
        }
        public bool setGravaOS()
        {
            string dsTipo;

            switch (nw_dsTipoOS)
            {
                case "Instalacao":
                    dsTipo = "Instalaçao";
                    break;

                case "Suporte":
                    dsTipo = "SUPORTE";
                    break;

                case "Reinstalacao":
                    dsTipo = "Reinstalação";
                    break;

                case "RevisaoPlus":
                    dsTipo = "Revisão-PLUS";
                    break;

                case "Constatacao":
                    dsTipo = "Constatação";
                    break;

                default:
                    dsTipo = nw_dsTipoOS;
                    break;
            }

            SqlParameter[] parametros = {
                                            new SqlParameter("@Os_status", nw_nrOSStatus),
                                             new SqlParameter("@Os_pedido", nrPedido),
                                             new SqlParameter("@Chamado_de", dsTipo),
                                             new SqlParameter("@Informações_chamado", nw_dsInformacoesOS),
                                             new SqlParameter("@Usuario_Logado", nw_dsNomeUsuario),
                                             new SqlParameter("@Emp_instala", nw_cdEmpInstaladora),
                                             new SqlParameter("@Os_instalador", nw_dsNomeInstalador),
                                             new SqlParameter("@Visita_marcada_para", DateTime.Now.ToString("dd/MM/yyyy")),
                                             new SqlParameter("@Hora_marcada_ou_prometida", DateTime.Now.ToString("hh:mm:ss")),
                                             new SqlParameter("@Hora_maxima_atender", DateTime.Now),
                                             new SqlParameter("@End_do_chamado", nw_dsEnderecoOS),
                                             new SqlParameter("@Bairro_do_chamado", nw_dsBairroOS),
                                             new SqlParameter("@Cid_do_chamado", nw_dsCidadeOS),
                                             new SqlParameter("@Est_do_chamado", nw_dsUFOS),
                                             new SqlParameter("@F_para_contato_no_chamado", nw_FoneContatoOS),
                                             new SqlParameter("@Ref_para_o_chamado", nw_PontoReferenciaOS),
                                             new SqlParameter("@Inf_regiao", nw_RegiaoOS),
                                             new SqlParameter("@N_do_chamado", nw_EnderecoNumeroOS),
                                             new SqlParameter("@Saida_destino", nw_dsCidadeKMOS),
                                             new SqlParameter("@Cod_cidades", nw_cdCidadeKMOS),
                                             new SqlParameter("@IDOS", ""),
                                             new SqlParameter("@Motivo_Cancelamento", nw_cdMotivoCancelamentoOS)
                                        };
            try
            {
                if (getValorProc("cnxFranquia", "principal.dbo.pro_setGravaOSAberta", parametros) == "S")
                    return true;
            }
            catch
            {
                throw;
            }

            return false;
        }

        public void preencheEnderecoCETEC(string cd_CETEC)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@cd_CETEC", cd_CETEC)
                                        };
            try
            {
                nw_PontoReferenciaOS = "";
                nw_dsCidadeKMOS = "";
                nw_cdCidadeKMOS = "";
                DataTable dt = getDataTableProc("cnxFranquia", "principal.OrdemServico.getEnderecoEmpresa", parametros);
                if (dt.Rows.Count > 0)
                {
                    nw_dsEnderecoOS = dt.Rows[0]["ds_Endereco"].ToString();
                    nw_dsBairroOS = dt.Rows[0]["ds_Bairro"].ToString();
                    nw_dsCidadeOS = dt.Rows[0]["ds_Cidade"].ToString();
                    nw_dsUFOS = dt.Rows[0]["ds_UF"].ToString();
                    nw_FoneContatoOS = dt.Rows[0]["nr_Telefone"].ToString();
                    nw_RegiaoOS = dt.Rows[0]["ds_Regiao"].ToString();
                    nw_EnderecoNumeroOS = dt.Rows[0]["nr_Numero"].ToString();
                }
                else
                {
                    nw_dsEnderecoOS = "";
                    nw_dsBairroOS = "";
                    nw_dsCidadeOS = "";
                    nw_dsUFOS = "";
                    nw_FoneContatoOS = "";
                    nw_RegiaoOS = "";
                    nw_EnderecoNumeroOS = "";
                }
            }
            catch
            {
                throw;
            }
        }

        public string trocaPeca(string novoID, string usuario, string motivoTroca)
        {
            SqlParameter[] parametros = {
                                             new SqlParameter("@str_nr_novoId", novoID),
                                             new SqlParameter("@str_pedido_OS", this.nrPedido),
                                             new SqlParameter("@str_produto_OS", this.dsTipoProduto),
                                             new SqlParameter("@str_seqdaOS", this.nrUltOS),
                                             new SqlParameter("@str_instalador_OS", "0"),
                                             new SqlParameter("@str_vgPWds_usuario", usuario),
                                             new SqlParameter("@ds_MotivoTroca", motivoTroca),
                                        };
            try
            {
                return getValorProc("cnxFranquia", "[Troca].[pro_setTrocaPecas]", parametros).ToString();
            }
            catch
            {
                throw;
            }
        }

        public void solicitaAlteracaoSGB(string nome, string CPFCNPJ, string RGInsEstadual, string DtNasc, string veiculo, string fabricante, string categoria, string ano,
                                         string renavan, string chassi, string combustivel, string cor, string usuario)
        {
            SqlParameter[] parametros = {
                                             new SqlParameter("@PEDIDO", this.nrPedido),
                                             new SqlParameter("@SOLICITA",  "Alteração dados cadastrais (CETEC)"  +
                                                                            " Nome: " + nome +
                                                                            " CPF/CNPJ: " + CPFCNPJ +
                                                                            " RG/Inscrição Estadual: " + RGInsEstadual +
                                                                            " Data de Nascimento: " + DtNasc +
                                                                            " Veiculo: " + veiculo +
                                                                            " Fabricante: " + fabricante +
                                                                            " Categoria: " + categoria +
                                                                            " Ano: " + ano +
                                                                            " RENAVAN: " + renavan +
                                                                            " CHASSI: " + chassi +
                                                                            " Combustivel: " + combustivel +
                                                                            " Cor: " + cor),
                                             new SqlParameter("@usuario", usuario),
                                             new SqlParameter("@departamento", "CETEC")
                                        };
            try
            {
                ExecNonQuery("cnxFranquia", "[PR_SOLICITA_SGB]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public string voucher(string numeroVoucher)
        {

            SqlParameter[] parametros = {
                                             new SqlParameter("@numeroVoucher", numeroVoucher),
                                             new SqlParameter("@numeroOS", this.nrUltOS)
                                        };
            try
            {
                return getValorProc("cnxFranquia", "[AgendaWeb].[pro_setVoucherOS]", parametros).ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}