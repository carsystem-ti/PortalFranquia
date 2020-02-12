using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao.OS
{
    public class daoOSsAberta : Dados
    {
        private DataTable OSAbertas;

        public DataTable getCliente(int tipo,string cd_Cetec,int id_grupo,string cd_cetec)
        {
            DataTable dt = new DataTable();
            try
            {
                switch (tipo)
                {
                    case 1 :
                        return OSAbertas = atualizaOS(cd_Cetec, tipo);
                    case 2:
                        return OSAbertas = atualizaOSContrato(cd_Cetec, id_grupo, cd_cetec,tipo);
                    case 3:
                        if(id_grupo == 4)
                           return OSAbertas = atualizaOS(cd_Cetec, tipo);
                        else
                            return OSAbertas = atualizaOSContrato(cd_Cetec, id_grupo, cd_cetec,tipo);

                    default:
                        return OSAbertas;
                }
            }
            catch
            {
                throw;
            }
        }
      
        public DataTable atualizaOS(string cd_Cetec,int tipo)
        {
            try
            {   if(tipo == 3 )
                    return OSAbertas = getOSsHistorico(cd_Cetec);
                else
                return   OSAbertas = getOSsAbertas(cd_Cetec);
            }
            catch
            {
                throw;
            }
        }
        public DataTable atualizaOSContrato(string nr_contrato,int id_grupo,string cd_cetec,int tipo)
        {
            try
            {
                // return OSAbertas = getOs(nr_contrato,id_grupo,cd_cetec);
                if (tipo == 3)
                    return OSAbertas = getOsHistoricoPorContrato(nr_contrato, id_grupo, cd_cetec);
                else
                    return OSAbertas = getOs(nr_contrato, id_grupo, cd_cetec);
            }
            catch
            {
                throw;
            }
        }
        public DataTable ultimaOSContrato(string nr_contrato)
        {
            try
            {
                return OSAbertas = getUltimaOsContrato(nr_contrato);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getOSsAbertas(string cd_Cetec)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@cd_Cetec", cd_Cetec)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "OrdemServico.pro_getOSAbertaCetec", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getOSsHistorico(string cd_Cetec)
        {
            SqlParameter[] parametros = {
                                            new SqlParameter("@cd_Cetec", cd_Cetec)
                                        };

            try
            {
                return getDataTableProc("cnxFranquia", "pro_getOSHistoricoCetec", parametros);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<string> getTipoOSAberta()
        {
            if (OSAbertas != null && OSAbertas.Rows.Count > 0)
            {
                IEnumerable<string> query = from OS in OSAbertas.AsEnumerable()
                                            select OS.Field<string>("tipoOS");
                return query.Distinct();
            }
            else
                return null;
        }

        public DataTable getOSsTipo(string tipoOS)
        {
            var query = from OS in OSAbertas.AsEnumerable()
                        where OS.Field<string>("tipoOS") == tipoOS
                        select OS;
            return query.CopyToDataTable<DataRow>();
        }

        public DataTable getMotivoCancelamento()
        {
            try
            {
                return getDataTableProc("cnxFranquia", "Principal.OrdemServico.pro_getMotivosCancelamento", null);   
            }
            catch
            {
                throw;
            }
        }
        public DataTable getOs(string nr_contrato,int id_grupo,string cetec)
        {
            try
            {
                SqlParameter[] parametros = {

                                            new SqlParameter("@id_grupo", id_grupo),
                                            new SqlParameter("@nr_contrato", nr_contrato),
                                            new SqlParameter("@cd_Cetec", cetec)
                };
                return getDataTableProc("cnxFranquia", "Principal.[OrdemServico].[pro_getOSAbertaContrato]", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getContrato(string nr_contrato)
        {
            try
            {
                SqlParameter[] parametros = {

                                            new SqlParameter("@nr_contrato", nr_contrato)
                };
                return getDataTableProc("cnxFranquia", "Principal.[OrdemServico].[pro_getContrato]", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getOsHistoricoPorContrato(string nr_contrato, int id_grupo, string cetec)
        {
            try
            {
                SqlParameter[] parametros = {

                                            new SqlParameter("@id_grupo", id_grupo),
                                            new SqlParameter("@nr_contrato", nr_contrato),
                                            new SqlParameter("@cd_Cetec", cetec)
                };
                return getDataTableProc("cnxFranquia", "Principal.[OrdemServico].[pro_getOSHistoricoContrato]", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getOsHistorico(int id_os)
        {
            try
            {
                SqlParameter[] parametros = {

                                            new SqlParameter("@id_os", id_os),
                };
                return getDataTableProc("cnxFranquia", "Principal.[OrdemServico].[pro_getDadosEncerramento]", parametros);
            }
            catch
            {
                throw;
            }
        }
        public DataTable getUltimaOsContrato(string nr_contrato)
        {
            try
            {
                SqlParameter[] parametros = {

                                            new SqlParameter("@nr_contrato", nr_contrato)
                };
                return getDataTableProc("cnxFranquia", "Principal.[OrdemServico].[pro_getUltimaOsContrato]", parametros);
            }
            catch
            {
                throw;
            }
        }
        public bool CancelaOS(int idOS, string empInstaladora, string usuario, string motivoCancelamento,DataTable dt)
        {
            try
            {
                var query = from OS in dt.AsEnumerable()
                            where OS.Field<int>("id_OS") == idOS
                            select OS;

                var result = query.FirstOrDefault();

                if (result != null)
                {
                    SqlParameter[] parametros = {
                                            new SqlParameter("@Os_pedido", result.Field<string>("Contrato")),
                                            new SqlParameter("@IDOS", idOS),
                                            new SqlParameter("@Emp_instala", empInstaladora),
                                            new SqlParameter("@Os_instalador", result.Field<string>("Instalador")),
                                            new SqlParameter("@Os_status", '2'),
                                            new SqlParameter("@Usuario_Logado", usuario),
                                            new SqlParameter("@Motivo_Cancelamento", motivoCancelamento)
                                        };
                    // exec pro_setGravaOSCancelada '143996', '959590', 'ti-adm', 'CAR SYSTEM SP', '2', 'ti-adm', '4'

                    string resp = getValorProc("cnxFranquia", "principal..pro_setGravaOSCancelada", parametros);
                    if (resp == "S")
                        return true;
                    else
                        return false;

                }
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

    }
}