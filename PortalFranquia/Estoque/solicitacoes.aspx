<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="PortalFranquia.Estoque.solicitacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../css/kGrid.css" rel="stylesheet" />
    <link href="../../css/botoes.css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/jquery.js"></script>
    <!--script type="text/javascript" src="../../js/javaResumoOS.js?200220141112"></!--script-->

    <link href="../../css/kModal.css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../../js/kModal.js"></script>
    <script src="../../js/historicoEquipamentos.js"></script>


    <style>
        .LinhaBusca {
            background-color: #31BC86; /*#72951A;*/
            color: #FFFFFF;
            font-weight: bold;
            white-space: nowrap;
            padding: 0.75em 1.5em;
            margin-top: 5px;
            height: 60px;
            text-align: left;
        }

        .left {
            float: left;
        }

        .direita {
            float: right;
        }

        .rounded {
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }

        .search {
            width: 360px;
            position: relative;
            top: 2px; /* readujst in jsfiddle */
            padding: 8px 5px 8px 30px;
            border: 1px solid #ccc;
            background: white url(../../imagens/serach.png) left center no-repeat !important;
            margin-right: 5px;
        }



        .criteriosBusca {
            clear: both;
            margin-top: 5px;
        }

        .azul {
            background-color: darkblue;
        }

        .prestadora, .servico {
            width: 100px;
        }

        .contrato, .novoID, .velhoID  {
            width: 80px;
        }

        .isFranquia, .troca, .emEstoque, .efetuado {
            width: 90px;
        }

        .semEquipamento {
            width: 90px;
        }

        .mensagem, .usuario  {
            max-width: 530px;
            min-width: 200px;
        }

    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="LinhaBusca">

        <div class="direita">

            <input type="button" name="cmdBuscar" value="Buscar" id="cmdBuscar" class="botaoAzul direita" style="margin-top: 4px;" />
            <input type="text" id="criterioBusca" class="search direita rounded" placeholder="Buscar historico" value="" />

            <div class="criteriosBusca left">
                <input type="radio" name="optBuscas" value="1" id="optFranquia" />
                <label for="optFranquia">Franquia</label>

                <input type="radio" name="optBuscas" value="2" id="optNovoID" />
                <label for="optNovoID">NovoID</label>

                <input type="radio" name="optBuscas" value="3" id="optVelhoID" />
                <label for="optVelhoID">VelhoID</label>

                <input type="radio" name="optBuscas" value="4" id="optContrato" checked />
                <label for="optContrato">Contrato</label>

            </div>
        </div>
    </div>
    <div class="gridContainer">
        <table class="tabelaGrid">
            <tbody id="corpoGrid">                
            </tbody>
        </table>
    </div>
    <div>
        <table class="tabelaGrid">
            <tfoot>
                <tr>
                    <th id="totalRegistros" colspan="7" style="text-align: right;">Total: </th>
                </tr>
            </tfoot>
        </table>
    </div>
    <div>

    </div>

</asp:Content>
