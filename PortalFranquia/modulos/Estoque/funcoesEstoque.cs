using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalFranquia.modulos.Estoque
{
    public class funcoesEstoque
    {
        const string nomeBanco = "bdPrincipal";
        CarSystem.BancoDados.Dados _bancoDados;

        struct motivos
        {
            //public string descricao;
            //public int codigoMotivo;
        }

        public CarSystem.BancoDados.Dados bancoDados
        {
            get
            {
                if (_bancoDados == null)
                    _bancoDados = new CarSystem.BancoDados.Dados(nomeBanco, CarSystem.Tipos.Servidores.Fury, "userEstoque", "7B7FB60F-B1C6-4F5B-81C6-C29B3896503C");                
                
                return _bancoDados;
            }
            set { _bancoDados = value; }
        }
        

        public System.Data.DataTable getEstoqueLoja(string pCodigoLocalizacao)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getEstoqueLoja";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@codigoLocalizacao", System.Data.SqlDbType.Char, 6, pCodigoLocalizacao);
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
        public System.Data.DataTable getProtocolo(string pCodigoLocalizacao, int pCodigoStatus)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getProtocolos";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoLocalizacao", System.Data.SqlDbType.Char, 6, pCodigoLocalizacao);
                bancoDados.Comandos.adicionaParametro("@pCodigoStatus", System.Data.SqlDbType.Int, 4, pCodigoStatus);
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

        public System.Data.DataTable getDetalhesEstoqueLoja(string pCodigoLocalizacao, string pTipoEquipamento, bool pIsCarSystem, int pTipoEstoque, int pStatusInventario, string pNumeroVersao)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getDetalhesEstoqueLoja";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@codigoLocalizacao", System.Data.SqlDbType.Char, 6, pCodigoLocalizacao);
                bancoDados.Comandos.adicionaParametro("@tipoEquipamento", System.Data.SqlDbType.VarChar, 100, pTipoEquipamento);
                bancoDados.Comandos.adicionaParametro("@isCarSystem", System.Data.SqlDbType.Bit, 1, pIsCarSystem);
                bancoDados.Comandos.adicionaParametro("@tipoEstoque", System.Data.SqlDbType.Int, 4, pTipoEstoque);
                bancoDados.Comandos.adicionaParametro("@statusInventario", System.Data.SqlDbType.Int, 4, pStatusInventario);
                bancoDados.Comandos.adicionaParametro("@numeroVersao", System.Data.SqlDbType.VarChar, 10, pNumeroVersao);
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

        public bool setStatusEquipamento(string pCodigoEquipamento, int pStatusInventario)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_setStatusEquipamento";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoEquipamento", System.Data.SqlDbType.VarChar, 10, pCodigoEquipamento);
                bancoDados.Comandos.adicionaParametro("@pCodigoStatus", System.Data.SqlDbType.Int, 4, pStatusInventario);
                bancoDados.retornaDados = false;

                bancoDados.execute();

                bool iRetorno = bancoDados.linhasAfetadas == 1;
                bancoDados.Conexoes.close();
                return iRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        public System.Data.DataTable getLojas(string pCodigoLoja)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getLojas";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                if ( pCodigoLoja != "" )
                    bancoDados.Comandos.adicionaParametro("@codigoLoja", System.Data.SqlDbType.Char, 6, pCodigoLoja);

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

        public string getRandomName(int pSeed)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random(pSeed);
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        public System.Data.DataRow setProtocolo(string pCodigoOrigem, string pCodigoDestino, string pUsuarioCriador, System.Data.SqlClient.SqlTransaction pTransacao)
        {
            try
            {
                //[Estoque].[pro_setCriarProtocolo]( @pCodigoOrigem char(6), @pCodigoDestino char(6) = null, @usuarioCriador varchar(80) )
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_setProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.comando.Transaction = pTransacao;

                bancoDados.Comandos.adicionaParametro("@pCodigoOrigem", System.Data.SqlDbType.Char, 6, pCodigoOrigem);
                bancoDados.Comandos.adicionaParametro("@pCodigoDestino", System.Data.SqlDbType.Char, 6, pCodigoDestino);
                bancoDados.Comandos.adicionaParametro("@pUsuarioCriador", System.Data.SqlDbType.VarChar, 80, pUsuarioCriador);
                bancoDados.retornaDados = true;

                System.Data.DataRow iLinhaRetorno = bancoDados.execute().Tables[0].Rows[0];
                return iLinhaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        public bool addItemProtocolo(int pCodigoProtocolo, string pCodigoEquipamento, int pTipoEstoque, string pCodigoProprietario, System.Data.SqlClient.SqlTransaction pTransacao)
        {
            try
            {
                //[Estoque].[pro_setCriarProtocolo]( @pCodigoOrigem char(6), @pCodigoDestino char(6) = null, @usuarioCriador varchar(80) )
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_addItemProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.comando.Transaction = pTransacao;

                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
                bancoDados.Comandos.adicionaParametro("@pCodigoEquipamento", System.Data.SqlDbType.VarChar, 10, pCodigoEquipamento);
                bancoDados.Comandos.adicionaParametro("@pTipoEstoque", System.Data.SqlDbType.Int, 4, pTipoEstoque);
                bancoDados.Comandos.adicionaParametro("@pCodigoProprietario", System.Data.SqlDbType.Char, 6, pCodigoProprietario);
                bancoDados.retornaDados = false;

                bancoDados.execute();

                bool iRetorno = bancoDados.linhasAfetadas == 1;
                return iRetorno;

            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        public bool delItemProtocolo(int pCodigoProtocolo, string pCodigoEquipamento)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_delItemProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
                bancoDados.Comandos.adicionaParametro("@pCodigoEquipamento", System.Data.SqlDbType.VarChar, 10, pCodigoEquipamento);
                bancoDados.retornaDados = false;

                bancoDados.execute();

                bool iRetorno = bancoDados.linhasAfetadas == 1;
                bancoDados.Conexoes.close();
                return iRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }
        public bool delProtocolo(int pCodigoProtocolo)
        {
            try
            {                
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_delProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
                bancoDados.retornaDados = false;

                bancoDados.execute();

                bool iRetorno = bancoDados.linhasAfetadas == 1; 
                bancoDados.Conexoes.close();
                return iRetorno;


            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }


        public System.Data.DataTable getDetalhesProtocolo(int pCodigoProtocolo)
        {
            try
            {                
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getDetalhesProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
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

        
        public System.Data.DataRow getVerificaEquipamento(string pCodigoEquipamento)
        {
            try
            {                
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getVerificaEquipamento";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoEquipamento", System.Data.SqlDbType.VarChar, 10, pCodigoEquipamento);
                bancoDados.retornaDados = true;

                System.Data.DataRow iLinhaRetorno = bancoDados.execute().Tables[0].Rows[0];
                bancoDados.Conexoes.close();
                return iLinhaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public bool setStatusProtocolo(int pCodigoProtocolo, int pStatusProtocolo)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_setStatusProtocolo";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
                bancoDados.Comandos.adicionaParametro("@pStatusProtocolo", System.Data.SqlDbType.Int, 4, pStatusProtocolo);
                bancoDados.retornaDados = false;

                bancoDados.execute();

                return bancoDados.linhasAfetadas == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }

        public string recebeItemProtocolo(string pCodigoEquipamento, int pCodigoProtocolo, string appName = "")
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Conexoes.nomeAplicacao = appName;
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_setRecebimento";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                
                bancoDados.Comandos.adicionaParametro("@pCodigoProtocolo", System.Data.SqlDbType.Int, 4, pCodigoProtocolo);
                bancoDados.Comandos.adicionaParametro("@pCodigoEquipamento", System.Data.SqlDbType.VarChar, 10, pCodigoEquipamento);
                bancoDados.retornaDados = true;

                string iRetorno = bancoDados.execute().Tables[0].Rows[0]["mensagem"].ToString();
                bancoDados.Conexoes.close();
                return iRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }// Estoque.pro_setRecebimento 

        public void delProtocoloVazio()
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_delProtocoloVazio";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.retornaDados = false;

                bancoDados.execute();
                bancoDados.Conexoes.close();
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
        }// Estoque.pro_setRecebimento 

        public string getMotivos(int pCodigoGrupo)
        {
            try
            {
                //System.Data.DataTable iRetorno;

                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_getMotivos";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@pCodigoGrupo", System.Data.SqlDbType.SmallInt, 2, pCodigoGrupo);
                bancoDados.retornaDados = true;

                return CarSystem.Utilidades.Rede.HTML.tableToJson(bancoDados.execute().Tables[0]);                
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
            finally{bancoDados.Conexoes.close();}
        }

        public string addOcorrencia(int pCodigoIdentificador, int pCodigoMotivo, string pUsuario)
        {
            try
            {
                bancoDados.Comandos.limpaParametros();
                bancoDados.Comandos.textoComando = nomeBanco + ".Estoque.pro_addOcorrencia";
                bancoDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;

                bancoDados.Comandos.adicionaParametro("@codigoIdentificador", System.Data.SqlDbType.Int, 4, pCodigoIdentificador);
                bancoDados.Comandos.adicionaParametro("@codigoMotivo", System.Data.SqlDbType.TinyInt, 10, pCodigoMotivo);
                bancoDados.Comandos.adicionaParametro("@usuario", System.Data.SqlDbType.VarChar, 30, pUsuario);
                bancoDados.retornaDados = true;

                return bancoDados.execute().Tables[0].Rows[0]["numeroOcorrencia"].ToString() + " -- Ocorrencia criada";
            }
            catch (Exception ex)
            {
                throw new Exception("class:" + this.GetType().Name + "\r\n Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\r\n" + ex.Message);
            }
            finally { bancoDados.Conexoes.close(); }
        }// Estoque.pro_setRecebimento 
    }
}
