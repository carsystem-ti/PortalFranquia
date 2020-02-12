using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PortalFranquia.dao;

namespace PortalFranquia.dao
{


    public class AcessoLogin : Dados
    {
        public int idUsuario { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public int idFranquia { get; private set; }
        public string Franquia { get; private set; }
        public string cdCetec { get; private set; }
        public string cdVendedor { get; private set; }
        public int idGrupo { get; private set; }
        public int cdVendedorInterno { get; private set; }
        public string dsTipo { get; private set; }

        public AcessoLogin()
        {
        }

        public AcessoLogin(string usuario, string senha)
        {
            try
            {
                SqlParameter[] parametros = {
                                                    new SqlParameter("@ds_nome", usuario),
                                                    new SqlParameter("@ds_senha", senha)
                                            };
                getDataReaderProc("cnxFranquia", "Franquia.pro_getLogin", parametros);
                Codigo = usuario.Substring(0, usuario.Length > 5 ? 6 : usuario.Length);
                Nome = usuario;
            }
            catch
            {
                throw;
            }
        }

        protected override void leReader(SqlDataReader dataReader)
        {
            if (dataReader.Read())
            {
                idFranquia = dataReader.GetInt32(0); // id_franquia
                Franquia = dataReader.GetString(1); // ds_franquia                
                cdCetec = dataReader.GetString(2); // cd_cetec
                cdVendedor = dataReader.GetString(3); // cd_Vendedor
                idGrupo = dataReader.GetInt16(4); // id_Grupo
                idUsuario = dataReader.GetInt16(5); // id_usuario
                cdVendedorInterno = dataReader.GetInt16(6); // cd_vendedorInterno
                dsTipo = dataReader.GetString(7); // ds_Tipo
            }
            else
                throw new Exception("Usuário não encontrado !");
        }

        public bool isSupervisor
        {
            get
            {
                return idGrupo == 38 || idGrupo == 33 || idGrupo == 21 || Nome.ToUpper() == "SUPERVISOR";
            }
        }

    }
}