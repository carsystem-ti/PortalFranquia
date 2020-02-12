using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalFranquia.modulos.OS
{
    public class Utilitario
    {
        const string NomeBanco = "Principal";
        CarSystem.BancoDados.Dados _bancoDados;

        public CarSystem.BancoDados.Dados BancoDados
        {
            get
            {
                if (_bancoDados == null)
                    _bancoDados = new CarSystem.BancoDados.Dados(NomeBanco, CarSystem.Tipos.Servidores.Fury
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["usuarioBanco"]
                        , System.Web.Configuration.WebConfigurationManager.AppSettings["senhaBanco"]);

                return _bancoDados;
            }
            set { _bancoDados = value; }
        }
    }
}