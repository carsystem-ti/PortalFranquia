using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalFranquia.dao
{
    public class resumoOS
    {
        const string nomeBanco = "Principal";
        CarSystem.BancoDados.Dados _bancoDados;

        public CarSystem.BancoDados.Dados bancoDados
        {
            get
            {
                if (_bancoDados == null)
                    _bancoDados = new CarSystem.BancoDados.Dados(nomeBanco, CarSystem.Tipos.Servidores.Fury
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["usuarioBanco"]
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["senhaBanco"]);

                return _bancoDados;
            }
            set { _bancoDados = value; }
        }

        //Franquia.pro_getResumoOS ( @dataInicial datetime,  @dataFinal datetime, @codigoCetec char(6) )
        public System.Data.DataTable getResumoOS(DateTime pDataInicial, DateTime pDataFinal, string pCodigoCetec)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getResumoOS";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@dataInicial", System.Data.SqlDbType.DateTime, 6, pDataInicial);
                bancoDados.Comandos.adicionaParametro("@dataFinal", System.Data.SqlDbType.DateTime, 6, pDataFinal);
                bancoDados.Comandos.adicionaParametro("@codigoCetec", System.Data.SqlDbType.Char, 6, pCodigoCetec);
                bancoDados.retornaDados = true;

                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        public System.Data.DataTable getDetalhesOS(string pCodigoCetec, int pLocalOS, object pStatusOS, DateTime pData, object pServicoOS)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getDetalhesOS";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoCetec", System.Data.SqlDbType.Char, 6, pCodigoCetec);

                if (pLocalOS == 3)
                    bancoDados.Comandos.adicionaParametro("@pLocalOS", System.Data.SqlDbType.Int, 4, DBNull.Value);
                else
                    bancoDados.Comandos.adicionaParametro("@pLocalOS", System.Data.SqlDbType.Int, 4, pLocalOS);

                if (pStatusOS.ToString() == "")
                    bancoDados.Comandos.adicionaParametro("@pStatusOS", System.Data.SqlDbType.VarChar, 30, DBNull.Value);
                else
                    bancoDados.Comandos.adicionaParametro("@pStatusOS", System.Data.SqlDbType.VarChar, 30, pStatusOS);

                bancoDados.Comandos.adicionaParametro("@pData", System.Data.SqlDbType.DateTime, 6, Convert.ToDateTime(pData));

                if (pServicoOS.ToString() == "" || pServicoOS.ToString().Trim() == "Todas")
                    bancoDados.Comandos.adicionaParametro("@pServicoOS", System.Data.SqlDbType.VarChar, 30, DBNull.Value);
                else
                    bancoDados.Comandos.adicionaParametro("@pServicoOS", System.Data.SqlDbType.VarChar, 30, pServicoOS.ToString().Trim());

                bancoDados.retornaDados = true;

                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }//Franquia.pro_getDetalhesOS ( @pCodigoCetec char(6), @pIsVisita bit,  @pStatusOS int, @data datetime, @servicoOS varchar(30) )

        public System.Data.DataTable getDetalhesOSFiltros(string pCodigoCetec, DateTime pData, int pLocalOS)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getDetalhesOSFiltros";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoCetec", System.Data.SqlDbType.Char, 6, pCodigoCetec);
                bancoDados.Comandos.adicionaParametro("@pData", System.Data.SqlDbType.DateTime, 6, pData);

                if (pLocalOS == 3)
                    bancoDados.Comandos.adicionaParametro("@pLocalOS", System.Data.SqlDbType.Int, 4, DBNull.Value);
                else
                    bancoDados.Comandos.adicionaParametro("@pLocalOS", System.Data.SqlDbType.Int, 4, pLocalOS);

                bancoDados.retornaDados = true;
                
                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }//Franquia.pro_getDetalhesOSFiltros ( @pCodigoCetec char(6), @pData datetime)

        public System.Data.DataTable getFranquiasRegiao()
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getFranquiasRegiao";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                bancoDados.retornaDados = true;

                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }//Franquia.pro_getDetalhesOSFiltros ( @pCodigoCetec char(6), @pData datetime)

        public System.Data.DataTable getOS(Int64 pCodigoOS)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Franquia.pro_getOS";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                bancoDados.retornaDados = true;

                bancoDados.Comandos.adicionaParametro("@pCodigoOS", System.Data.SqlDbType.BigInt, 8, pCodigoOS);
                
                System.Data.DataTable iTabelaRetorno = bancoDados.execute().Tables[0];
                bancoDados.Conexoes.close();
                return iTabelaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }//Franquia.pro_getDetalhesOSFiltros ( @pCodigoCetec char(6), @pData datetime)

        protected static string GetMD5HashFromFile(string fileName)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

    }
}