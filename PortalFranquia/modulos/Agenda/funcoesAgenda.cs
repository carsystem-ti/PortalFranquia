using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalFranquia.modulos.Agenda
{
    public class funcoesAgenda
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

    }
    
}