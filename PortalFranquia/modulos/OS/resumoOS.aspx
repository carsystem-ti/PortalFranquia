<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="resumoOS.aspx.cs" Inherits="PortalFranquia.modulos.OS.resumoOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="../../css/fullcalendar.css" rel="stylesheet" />
    <link href="../../css/kModal.css" rel="stylesheet" />
    <link href="../../css/resumoOS.css?200220141112" rel="stylesheet" />    
    <link href="../../css/cbpHorizontalMenu.css" rel="stylesheet" />
    <link href="../../css/combo.css" rel="stylesheet" />
    <link href="../../css/kGrid.css" rel="stylesheet" />
    <link href="../../css/kEmail.css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../../js/kModal.js"></script>
    <script type="text/javascript" src="../../js/jquery.PrintArea.js"></script>
     <script type="text/javascript" src="../../js/jquery-ui.js"></script>

    <script type="text/javascript" src="../../js/javaResumoOS.js?200220141112"></script>
    <script type="text/javascript" src="../../js/moment.min.js"></script>
    <script type="text/javascript" src="../../js/fullcalendar.min.js"></script>
    <script type="text/javascript" src="../../js/combo.js"></script>   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<div id='script-warning'>
		<code>php/get-events.php</code> must be running.
	</div>	

	<div class="divPrincipal" >
		<div class="container">
			<div class="main">
				<nav id="cbp-hrmenu" class="cbp-hrmenu">
					<ul>
						<li>
							<a id="titFranquia" href="#">Franquias</a>
							<div class="cbp-hrsub">
								<div id="divFranquiasRegiao" class="cbp-hrsub-inner"> 
								</div><!-- /cbp-hrsub-inner -->
							</div><!-- /cbp-hrsub -->
						</li>
						<li>
							<a id="titCalendario" href="#">Calendário</a>
						</li>
						<li>
							<a id="titulo" href="#">Loja</a>
							<div class="cbp-hrsub">
							<div style="height:5px; width:100%;"></div>
								<div class="barraOS">
								<style>
									#itemCombo{
										background-color:white;
										color:black;
									}								
									#itemCombo:hover {
										color:#4CBEFF;
									}									
								</style>
									<div id="comboLocal" class="wrapper-dropdown-5" tabindex="1">Local
										<ul class="dropdown">
											<li><a id="itemCombo" href="#">&nbsp;&nbsp;&nbsp;&nbsp; Loja</a></li>
											<li><a id="A1" href="#">&nbsp;&nbsp;&nbsp;&nbsp; Externa</a></li>		
										</ul>
									</div>
									<div id="comboAberta" class="wrapper-dropdown-5" tabindex="1">Abertas
									</div>
									<div id="comboAtendimento" class="wrapper-dropdown-5" tabindex="1">Em Atendimento
									</div>
									<div id="comboEncerrada" class="wrapper-dropdown-5" tabindex="1">Encerradas
									</div>
									<div id="comboCancelada" class="wrapper-dropdown-5" tabindex="1">Canceladas
									</div>									
								</div>
								<div>
									<table class="tabelaGrid">
										<thead>
											<tr>
												<th></th>
 											</tr>
										</thead>
									</table>
								</div>
								<div class="gridContainer">
                                    <div class="printImg"></div>
                                    <div class="download"></div>
                                    <div id="printOS">
									    <table class="tabelaGrid">
										    <tbody id="corpoGrid">
										    </tbody>
									    </table>	
								    </div>
                                </div>
								<div>
									<table class="tabelaGrid">
										<tfoot>
											<tr>
												<th id="totalRegistros" colspan="7" style="text-align:right;">Total: 32</th>													
											</tr>
										</tfoot>											
									</table>	
								</div>
								
							</div><!-- /cbp-hrsub -->
						</li>
					</ul>
				</nav>
			</div>
		</div>
		
			

	<div id='calendar'></div>

	<div id="emailBox" style="display:none;">	
	    <div class="emailBox" >
		    <h1><span class="titulo">Enviar por Email</span></h1>
		    <p class="float">
			    <label for="textEmail">Email</label>						
			    <input type="text" name="textEmail" id="textEmail" placeholder="EMAIL"/>
		    </p>
		    <p class="clearfix"> 						
			    <input type="button" id="cmdEnviar" value="Enviar" class="enviar"/>
		    </p>
	    </div>​​
	</div>
</div>		

		<script src="../../js/cbpHorizontalMenu.min.js"></script>
		<script>
		    $(function () {
		        cbpHorizontalMenu.init();
		        titCalendario.click();
		        $("#titulo").html(moment().format("DD/MM/YYYY"));
		        getDetalhesOS(null, moment().format("DD/MM/YYYY"), null);
		        getFiltros(moment().format("DD/MM/YYYY"));
		    });

		    //INICIALIZA COMBOS -- INICIO

		    function DropDown(el) {
		        this.dd = el;
		        this.initEvents();
		    }
		    DropDown.prototype = {
		        initEvents: function () {
		            var obj = this;

		            obj.dd.on('click', function (event) {
		                //$('.active').toggleClass('active');
		                $(this).toggleClass('active');
		                event.stopPropagation();
		            });
		        }
		    }

		    $(function () {

		        var dd = new DropDown($('#comboLocal'));
		        var dd = new DropDown($('#comboAberta'));
		        var dd = new DropDown($('#comboAtendimento'));
		        var dd = new DropDown($('#comboEncerrada'));
		        var dd = new DropDown($('#comboCancelada'));

		        $(".barraOS a").on('click', function (event) {
		            alert($(this).html());
		        });

		        $(document).click(function () {
		            // all dropdowns
		            $('.wrapper-dropdown-5').removeClass('active');
		        });

		    });
		    //INICIALIZA COMBOS -- FIM

		</script>


</asp:Content>

