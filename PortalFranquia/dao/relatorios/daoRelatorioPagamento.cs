﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao
{
    public class daoRelatorioPagamento: Dados
    {
        public string totCredito { get; private set; }
        public string totComissoes { get; private set; }
        public string nomeFranquia { get; private set; }
        public string periodo { get; private set; }
        public string totAjusteCredito { get; private set;}
        public string totAjusteDebito { get; private set; }
        public string totGeral { get; private set; }                        
        public string totDebitosGerais { get; private set; }
        public string totCreditosGerais { get; private set; }

        public Object getSintetico(int idFranquia, int mes, int ano, out Object dVendaSintetica, out Object dDescontosDiversos, out Object dDebitosGerais, out Object dCreditosGerais)
        {
            DateTime dtIni = new DateTime(ano, mes, 1);
            DateTime dtFim = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            this.periodo = dtIni.ToString("dd/MM/yyyy") + " a " + dtFim.ToString("dd/MM/yyyy");

            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 1),
                                            new SqlParameter("@dataInicial", dtIni),
                                            new SqlParameter("@dataFinal", dtFim),
                                            new SqlParameter("@idfranquia", idFranquia)
                                        };
            try
            {
                DataTable dTableAux = getDataTableProc("cnxFranquia", "Principal.[Franquia].[pro_getFolhaLoja]", parametros);

                if (dTableAux.Rows.Count > 0)
                {
                    // Serviços
                    var aux = from row in dTableAux.AsEnumerable()
                              where row.Field<String>("ds_Lancamento") == "SERVIÇOS" || row.Field<String>("ds_Lancamento") == "BONUS POR VENDA"
                              select new
                              {
                                  Periodo = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + (row.Field<String>("ds_Lancamento") == "SERVIÇOS"?"SERVIÇOS DE ":"VENDAS DE ") + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Ini")) + " A " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime>("dt_fim")),
                                  Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_folha")),
                                  NotaFiscal = row.Field<String>("nr_NotaFiscal"),
                                  DataLiberacao = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Liberacao")),
                                  DataPagamento = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Pagamento")),
                                  Responsavel = row.Field<String>("ds_Responsavel"),
                                  idAgenda = row.Field<int?>("id_agenda")
                              };

                    var totCredito = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") == "SERVIÇOS" || x.Field<String>("ds_Lancamento") == "BONUS POR VENDA").Sum(x => x.Field<Decimal?>("vl_folha"));
                    this.totComissoes = String.Format("{0:###,###,###,##0.00}", totCredito);
                    this.nomeFranquia = dTableAux.Rows[0]["ds_franquia"].ToString();

                    // Ajuste de Crédito
                    dVendaSintetica = from row in dTableAux.AsEnumerable()
                                      where row.Field<String>("ds_Lancamento") == "AJUSTE-CRÉDITO"
                                      select new
                                      {
                                        Periodo = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOLHA DE " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Ini")) + " A " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime>("dt_fim")),
                                        Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_folha")),
                                        NotaFiscal = row.Field<String>("nr_NotaFiscal"),
                                        DataLiberacao = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Liberacao")),
                                        DataPagamento = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Pagamento")),
                                        Responsavel = row.Field<String>("ds_Responsavel"),
                                        idAgenda = row.Field<int?>("id_agenda"),
                                        idLancamento = row.Field<Int16?>("id_lancamento")
                                      };
                    var totAjusteCredito = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") == "AJUSTE-CRÉDITO").Sum(x => x.Field<Decimal?>("vl_folha"));
                    this.totAjusteCredito = String.Format("{0:###,###,###,##0.00}", totAjusteCredito);

                    // Descontos Diversos
                    dDescontosDiversos = from row in dTableAux.AsEnumerable()
                                         where row.Field<String>("ds_Lancamento") == "DESCONTO DIVERSOS"                                        
                                         select new
                                         {
                                            Periodo = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOLHA DE " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Ini")) + " A " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime>("dt_fim")),
                                            Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_folha")),
                                            NotaFiscal = row.Field<String>("nr_NotaFiscal"),
                                            DataLiberacao = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Liberacao")),
                                            DataPagamento = String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Pagamento")),
                                            Responsavel = row.Field<String>("ds_Responsavel"),                                        
                                            idAgenda = row.Field<int?>("id_agenda"),
                                            idLancamento = row.Field<Int16?>("id_lancamento")
                                        };
                    var totAjusteDebito = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") == "DESCONTO DIVERSOS").Sum(x => x.Field<Decimal?>("vl_folha"));                    
                    
                    
                    // Pega o restante dos débitos
                    dDebitosGerais = from row in dTableAux.AsEnumerable()
                                     where (row.Field<String>("ds_Lancamento") != "DESCONTO DIVERSOS") && (row.Field<String>("tp_Lancamento") == "D")
                                         select new
                                         {
                                             Lancamento = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row.Field<String>("ds_Lancamento"),
                                             Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_folha")),
                                             NotaFiscal = "",
                                             DataLiberacao = "",
                                             DataPagamento = "",
                                             Responsavel = "",                                             
                                             idAgenda = row.Field<int?>("id_agenda"),
                                             idLancamento = row.Field<Int16?>("id_lancamento")                                             
                                         };                    
                    var totDebitosGerais = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") != "DESCONTO DIVERSOS" && x.Field<String>("tp_Lancamento") == "D").Sum(x => x.Field<Decimal?>("vl_folha"));
                    this.totDebitosGerais = String.Format("{0:###,###,###,##0.00}", totDebitosGerais);                    

                    // Pega o restante dos creditos
                    dCreditosGerais = from row in dTableAux.AsEnumerable()
                                      where (row.Field<String>("ds_Lancamento") != "BONUS POR VENDA") && (row.Field<String>("ds_Lancamento") != "SERVIÇOS") && (row.Field<String>("ds_Lancamento") != "AJUSTE-CRÉDITO")  && (row.Field<String>("tp_Lancamento") == "C")
                                      select new
                                      {
                                         Lancamento = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row.Field<String>("ds_Lancamento"),
                                         Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_folha")),
                                         NotaFiscal = "",
                                         DataLiberacao = "",
                                         DataPagamento = "",
                                         Responsavel = "",
                                         idAgenda = "",
                                         botao = ""
                                     };
                    var totCreditosGerais = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") != "BONUS POR VENDA" && x.Field<String>("ds_Lancamento") != "SERVIÇOS" && x.Field<String>("ds_Lancamento") != "AJUSTE-CRÉDITO" && x.Field<String>("tp_Lancamento") == "C").Sum(x => x.Field<Decimal?>("vl_folha"));
                    this.totCreditosGerais = String.Format("{0:###,###,###,##0.00}", totCreditosGerais);

                    // Desconto NF Serviços
                    //dVendaSintetica = from row in dTableAux.AsEnumerable()
                    //                  where row.Field<String>("ds_Lancamento") == "DESCONTOS NOTAS FISCAIS DE SERVIÇOS"
                    //                  select new
                    //                  {
                    //                      Periodo = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOLHA DE " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime?>("dt_Ini")) + " A " + String.Format("{0:dd/MM/yyyy}", row.Field<DateTime>("dt_fim")),
                    //                      IdPedido = row.Field<int?>("id_pedido"),
                    //                      IdItem = row.Field<int?>("is_item"),
                    //                      Vendedor = row.Field<String>("ds_vendedor"),
                    //                      Contrato = row.Field<String>("nr_contrato"),
                    //                      Cliente = row.Field<String>("ds_nome"),
                    //                      Produto = row.Field<String>("ds_produto"),
                    //                      Venda = String.Format("{0:dd/MM/yyyy", row.Field<DateTime?>("dt_Confirmacao")),
                    //                      Valor = String.Format("{0:###,###,###,##0.00}", row.Field<Decimal?>("vl_notaFiscalCS")),
                    //                      idAgenda = row.Field<int?>("id_agenda"),
                    //                      idLancamento = row.Field<Int16?>("id_lancamento")
                    //                  };
                    //var totAjusteCredito = dTableAux.AsEnumerable().Where(x => x.Field<String>("ds_Lancamento") == "AJUSTE-CRÉDITO").Sum(x => x.Field<Decimal?>("vl_folha"));
                    //this.totAjusteCredito = String.Format("{0:###,###,###,##0.00}", totAjusteCredito);

                    /* Calculo de totais */
                    // Total de créditos
                    totCredito = totCredito + totAjusteCredito + totCreditosGerais;
                    this.totCredito = String.Format("{0:###,###,###,##0.00}", totCredito);

                    //  Total de Débitos
                    totAjusteDebito = totAjusteDebito + +totDebitosGerais;
                    this.totAjusteDebito = String.Format("{0:###,###,###,##0.00}", totAjusteDebito);

                    // Total geral
                    this.totGeral = String.Format("{0:###,###,###,##0.00}", totCredito + totAjusteDebito);

                    return aux;
                }
                else
                {
                    dVendaSintetica = null;
                    dDescontosDiversos = null;
                    dDebitosGerais = null;
                    dCreditosGerais = null;
                    return dTableAux;
                }
            }
            catch
            {
                throw;
            }
        }        

        public DataTable getAnaliticoPoliticaVenda(int idFranquia, int idAgenda)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 2),
                                            new SqlParameter("@dataInicial", null),
                                            new SqlParameter("@dataFinal", null),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAnaliticoForaPoliticaVenda(int idFranquia, int idAgenda)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 3),
                                            new SqlParameter("@dataInicial", null),
                                            new SqlParameter("@dataFinal", null),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getFranquias(int idFranquia)
        {
            // Miguel - inicio - 28/10/2019

            //return getDataTableSQL("cnxFranquia", "select id_franquia,ds_franquia from Principal.Franquia.tbl_Franqueado where fl_ativo = 'S' and tp_franquia = 'C'");

            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", idFranquia)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
            // Miguel - fim - 28/10/2019
        }

        public DataTable getAnaliticoAjusteCredito(int idFranquia, int idAgenda, int idLancamento, int tp)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", tp),
                                            new SqlParameter("@dataInicial", null),
                                            new SqlParameter("@dataFinal", null),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda),
                                            new SqlParameter("@id_lancamento", idLancamento)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAnaliticoServicoInterno(int idFranquia, int idAgenda)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 4),
                                            new SqlParameter("@dataInicial", null),
                                            new SqlParameter("@dataFinal", null),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAnaliticoServicoExterno(int idFranquia, int idAgenda)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 5),
                                            new SqlParameter("@dataInicial", null),
                                            new SqlParameter("@dataFinal", null),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAnaliticoNF(int ano, int mes, int idFranquia, int idAgenda, int idLancamento)
        {
            DateTime dtIni = new DateTime(ano, mes, 1);
            DateTime dtFim = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            this.periodo = dtIni.ToString("dd/MM/yyyy") + " a " + dtFim.ToString("dd/MM/yyyy");

            SqlParameter[] parametros = {
                                            new SqlParameter("@tp", 12),
                                            new SqlParameter("@dataInicial", dtIni),
                                            new SqlParameter("@dataFinal", dtFim),
                                            new SqlParameter("@idfranquia", idFranquia),
                                            new SqlParameter("@id_agenda", idAgenda),
                                            new SqlParameter("@id_lancamento", idLancamento)
                                        };
            try
            {
                return getDataTableProc("cnxFranquia", "[Principal].[Franquia].[pro_getFolhaLoja]", parametros);
            }
            catch
            {
                throw;
            }
        }
    }
}