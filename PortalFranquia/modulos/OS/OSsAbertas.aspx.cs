using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalFranquia.dao.OS;
using PortalFranquia.componentes.OS;
using PortalFranquia.dao;
using System.Web.Services;
using System.Data;
using System.Web.Script.Services;

namespace PortalFranquia.modulos.OS
{
    [WebService(Namespace = "http://tempuri.org/")]
    public partial class OSAbertas : System.Web.UI.Page
    {
        private daoOSsAberta OSsAbertas;
        private daoOSsAberta UltimaOsEncerrada;
        private DataTable OsAbertas;
        public object TxtTipoOS { get; set; }
        public object TxtOsStatus { get; set; }
        public object TxtInfChamado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            Utils.setNomeModulo(Page, "O.S. - O.S. Abertas");
            Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");

            try
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];

                Utils.setNomeModulo(Page, "O.S. - O.S. Abertas");
                Utils.setVoltarUrl(Page, Session, "~/modulos/OS/OS.aspx");

                
                Usuario.Value = acessoLogin.Nome;
                Cetec.Value = acessoLogin.cdCetec;
                id_grupo.Value = acessoLogin.idGrupo.ToString();

                
                //if (acessoLogin.idGrupo  == 39)
                //{
                //    OSsAbertas = new daoOSsAberta(1, acessoLogin.Codigo.ToString());

                //}
                //else
                //{
                //    OSsAbertas = new daoOSsAberta(1, acessoLogin.Codigo.ToString());
                //    exibeOS();
                //}




                //if (TxtTipoOS.ToString() != "Retirada")
                //{
                //    primeiraTela.Visible = true;
                //}
                //else
                //{
                //    primeiraTela.Visible = false;
                //}
                




            }
            catch (Exception ex)
            {
                exibeMensagem(ex.Message);                
            } 
        }
        public void CarregaMotivosCancelamentos()
        {
            //Carrega os motivos do cancelamento

            dao.OS.daoOSsAberta OSsAbertas = new dao.OS.daoOSsAberta();
            DataTable dt = OSsAbertas.getMotivoCancelamento();
          //  dropMotivosCancelamento.DataSource = dt;
           // dropMotivosCancelamento.DataBind();
          //  dropMotivosCancelamento.Items.Insert(0, "Selecione");


            slcMotivos.DataSource = dt;
            slcMotivos.DataBind();
            slcMotivos.Items.Insert(0, "Selecione");

        }

        [System.Web.Services.WebMethod]
        public static string atende(string descricao)
        {

            return descricao;
        }

        [System.Web.Services.WebMethod]
        public void InfoEncerramento(int nr_os)
        {

            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            System.Data.DataTable iPedido = os.pro_getAMotivoOs(nr_os);
            dropMotivosAtendimento.DataSource = iPedido;
            dropMotivosAtendimento.DataBind();
            dropMotivosAtendimento.Items.Insert(0, "Selecione");
        }

        [System.Web.Services.WebMethod]
        public void  ItensEncerramento(string id)
        {
            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            System.Data.DataTable iPedido = os.pro_getItensMotivoOs(Convert.ToInt32(id));
            dropDetalhesMotivos.DataSource = iPedido;
            dropDetalhesMotivos.DataBind();
            dropDetalhesMotivos.Items.Insert(0, "Selecione");

            //return CarSystem.Utilidades.Rede.HTML.tableToJson(iPedido);

        }
        [System.Web.Services.WebMethod]
        public static string detalhesOs(int nr_os)
        {

            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            System.Data.DataTable iPedido = os.pro_getDetalhesEncerramento(nr_os);

            return CarSystem.Utilidades.Rede.HTML.tableToJson(iPedido);

        }

        [System.Web.Services.WebMethod]
        public static string set_detalhe(int nr_os,int id_motivo)
        {

            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();

            os.pro_setItensOs(nr_os, id_motivo);
            System.Data.DataTable iPedido = os.pro_getDetalhesEncerramento(nr_os);

            return CarSystem.Utilidades.Rede.HTML.tableToJson(iPedido);

        }
        
        public  void set_Excluirdetalhe()
        {
            try
            {
                if (txtIdOs.Value != "" && dropDetalhesMotivos.SelectedValue != "Selecione")
                {

                    dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
                    os.pro_setExcluirItensOs(Convert.ToInt32(txtIdOs.Value),Convert.ToInt32(dropDetalhesMotivos.SelectedValue));
                    System.Data.DataTable iPedido = os.pro_getDetalhesEncerramento(Convert.ToInt32(txtIdOs.Value));
                    if (iPedido.Rows.Count > 0)
                    {
                        foreach (var item in iPedido.Rows)
                        {
                            messageos.Value = messageos.Value + ((System.Data.DataRow)item).ItemArray[0].ToString().ToString() + "\n";
                        }

                    
                    }
                    else
                    {
                        messageos.Value = "";
                    }
                }
   
            }
            catch (Exception)
            {

                throw;
            }
         

        }

        [System.Web.Services.WebMethod]
        public static string getTecnicos(int nr_os)
        {

            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            System.Data.DataTable iPedido = os.getTecnicoslOJAS(nr_os);

            return CarSystem.Utilidades.Rede.HTML.tableToJson(iPedido);

        }

        [System.Web.Services.WebMethod]
        // Miguel - inicio - 21/02
        // public string set_EncerraOs(int id_status, int nr_os, string problemaResolvido, string ds_medidaAdotada, string ds_acaoServico, string ds_trocaID, string ds_resolvidoPor, string tecnico)
        // Miguel - fim - 21/02

        public int set_EncerraOs(int id_status,int nr_os,string ds_medidaAdotada,string ds_acaoServico,string tecnico)
        {

            try
            {
                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

                    dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
                if (dropVisita.SelectedValue == "1")
                {
                    ds_acaoServico = "VISITA";
                }
                // Miguel - inicio - 25/02
                // Miguel - inicio - 21/02
                // var retorno = os.pro_setOs(id_status, nr_os, problemaResolvido, ds_medidaAdotada, ds_acaoServico, ds_trocaID, ds_resolvidoPor, tecnico, acessoLogin.Nome);
                var retorno = os.pro_setOs(id_status, nr_os, ds_medidaAdotada, ds_acaoServico, tecnico, acessoLogin.Nome);
                // Miguel - fim - 21/02
                //int retorno = 0;
                // Miguel - fim - 25/02
                if (retorno > 0)
                {
                    if (txtPesquisa.Value != "")
                    {
                        exibeOSContrato(txtPesquisa.Value, 2);
                    }
                    

                    System.Data.DataTable iPedido = os.pro_getInfOS(Convert.ToInt32(nr_os));

                    return retorno;
                    

                }
                else
                {
                    return retorno;
                }
                
                //     exibeOSContrato(txtPesquisa.Value);

                //  return CarSystem.Utilidades.Rede.HTML.tableToJson(iPedido);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [System.Web.Services.WebMethod]
        public static string set_CancelaOs(int nr_os,string usuariologado,string ds_motivoCancelamento)
        {
            // Convert.ToInt32(idOSSelecionada.Value),acessoLogin.cdCetec == "" ? acessoLogin.Nome.Substring(0, 6) : acessoLogin.cdCetec, acessoLogin.Nome, ddlMotivoCancelamento.SelectedValue)
            try
            {
                string retorno = "";
                dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
                retorno = os.CancelaOS(nr_os,usuariologado,ds_motivoCancelamento);
                if (retorno == "S")
                {
                    //System.Data.DataTable iPedido = os.pro_getInfOS(Convert.ToInt32(nr_os));
                    return "S";
                    
                }
                else
                {

                    return "N";
                }
            }
            catch (Exception ex )
            {

               return ex.Message.ToString();
            }
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
          
                try
                {
                divRecado.Visible = false;
                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                    Usuario.Value = acessoLogin.Nome;
                    if (txtPesquisa.Value != "" && txtPesquisa.Value != null && Convert.ToInt32(slcPesquisa.Items[slcPesquisa.SelectedIndex].Value) > 0)
                    {
                        OSAbertas os = new OSAbertas();
                        exibeOSContrato(txtPesquisa.Value, Convert.ToInt32(slcPesquisa.Items[slcPesquisa.SelectedIndex].Value));
                        CarregaMotivosCancelamentos();

                    if (txtIdOs.Value != null && txtIdOs.Value != "")
                    {
                        buscaTecnico(Convert.ToInt32(txtIdOs.Value));
                        buscaDetalheAtendimento(Convert.ToInt32(txtIdOs.Value));
                        buscaDetalheMotivo(Convert.ToInt32(txtIdOs.Value));
                    }

                }
                else
                {

                }

                if (TxtOsStatus.ToString() != "0" || TxtOsStatus.ToString() != "4")
                {
                    primeiraTela.Visible = true;
                }

                else
                {
                    primeiraTela.Visible = false;
                }

            }
                catch (Exception ex)
                {

                    ex.Message.ToString();
                }




         
        }
        //btnEncerramento_Click();
       
        protected void btnEncerramento_Click(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
            OSsAbertas.atualizaOS(acessoLogin.cdCetec,2);
            exibeOS();
        }

        public void exibeOS()
        {
            // Carrega as OS
            foreach (string tipoOS in OSsAbertas.getTipoOSAberta())
            {
                Control controlOS = LoadControl(@"~\componentes\OS\mostraOSAbertas.ascx");
                ((mostraOSAbertas)controlOS).ConfiguraGrid(tipoOS, OSsAbertas.getOSsTipo(tipoOS));
                gridsOS.Controls.Add(controlOS);
            }
        }
        //protected void Delete(object sender, EventArgs e)
        //{
        //    dao.OS.daoOSsAberta cancela = new daoOSsAberta();
        //    AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
        //    idOSSelecionada.Value = (sender as Button).CommandArgument;
        //    string motivo = dropMotivosCancelamento.SelectedValue;
        //   bool retorno  =  cancela.CancelaOS(Convert.ToInt32(idOSSelecionada.Value), acessoLogin.Nome, acessoLogin.Nome, motivo);



        //}

        public void exibeOSContrato(string nr_contrato,int tipo)
        {
            // Carrega as OS
            
            daoOSsAberta os = new daoOSsAberta();
            AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
            DataTable  OSAbertas = os.getCliente(tipo,nr_contrato,acessoLogin.idGrupo,acessoLogin.cdCetec);
            Session["dt_os"]= OSAbertas;
            DivResumo.Visible = false;
            divOs.Visible = false;
            DivResumo.Visible = false;
            divVisita.Visible = false;
            
            if (OSAbertas.Rows.Count > 0)
            {
                
                slcMotivos.Visible = true;
                btnEncerrarOs.Visible = true;
                //lblCancelarOs.Visible = true;
                btnEncerrarOs.Visible = true;
                btVoucher.Visible = true;
                btCancelarOrdem.Visible = true;
                btnUltimoPacote.Visible = true;

                primeiraTela.Visible = true;
                txtPesquisaVoucher.Visible = true;

                btVoucher.Visible = true;
                ///lbl_volcher.Visible = true;

                gridsOS.DataSource = OSAbertas;
                gridsOS.DataBind();
                txtIdOs.Value = OSAbertas.Rows[0][6].ToString();
                EtxtNumeroOS.Value = OSAbertas.Rows[0][6].ToString();
                txtUltimoId.Value = OSAbertas.Rows[0][9].ToString();
                EtxtNumeroPeca.Value = OSAbertas.Rows[0][9].ToString();
                TxtTipoOS = OSAbertas.Rows[0][8].ToString();
                EtxtTecnico.Value = OSAbertas.Rows[0][5].ToString();
                TxtOsStatus = OSAbertas.Rows[0][13].ToString();
                TxtInfChamado = OSAbertas.Rows[0][14].ToString();
                int tp_Produto = 0;
                tp_Produto = Convert.ToInt32(OSAbertas.Rows[0][15].ToString());
                if (tp_Produto == 0)
                {
                    btnUltimoPacote.Visible = false;
                }
                else
                {
                    btnUltimoPacote.Visible = true;
                }
                // Miguel - inicio - 21 / 02
                //txtResolvidoPor.Value = OS.Rows[0][12].ToString();
                //Miguel - fim - 21 / 02

                    //EtxtDetalheAtendimento.Value = OS.Rows[0][8].ToString();
                    EtxtMedidaAdotada.Value = OSAbertas.Rows[0][11].ToString();
                if (txtIdOs.Value != "")
                {

                  
                    dao.OS.daoOSConsulta daoOs = new dao.OS.daoOSConsulta();
                    int nr_os = Convert.ToInt32(txtIdOs.Value);
                    System.Data.DataTable iPedido = daoOs.pro_getDetalhesEncerramento(nr_os);

                    if (iPedido.Rows.Count > 0)
                    {
                        EtxtDetalheOs.Value = iPedido.Rows[0][0].ToString();
                    }

                }
            }
            else
            {
                slcMotivos.Visible = false;
                btCancelarOrdem.Visible = false;
                
                primeiraTela.Visible = false;
                divOs.Visible = false;
                // Carrega as OS
                daoOSsAberta UltimaOsEncerrada = new daoOSsAberta();
                DataTable UOS = UltimaOsEncerrada.getUltimaOsContrato(nr_contrato);
                gridsOS.DataSource = OSAbertas;
                gridsOS.DataBind();
                //dropMotivosCancelamento.Visible = false;
                btnEncerrarOs.Visible = false;
                ///lblCancelarOs.Visible =false;
                btVoucher.Visible = false;
                btCancelarOrdem.Visible = false;
                
                if (UOS.Rows.Count > 0)
                {
                    txtPesquisaVoucher.Visible = false;
                    btVoucher.Visible = false;
                    ///lbl_volcher.Visible = false;

                    EtxtNumeroOS.Value = UOS.Rows[0][0].ToString();
                    EtxtNumeroPeca.Value = UOS.Rows[0][1].ToString();
                    EtxtTecnico.Value = UOS.Rows[0][2].ToString();
                    EtxtDetalheOs.Value = UOS.Rows[0][3].ToString();
                    EtxtMedidaAdotada.Value = UOS.Rows[0][4].ToString();
                }
            }

        }


        private void exibeMensagem(string mensagem)
        {
            lbMensErro.Text = mensagem;
            lbMensErro.Visible = true;
        }

        protected void btCancelarOS_Click1(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void getOs(string nr_contrato)
        {

            try
            {
                try
                {
                    if (nr_contrato != "" && nr_contrato != null)
                    {
                        OSAbertas os = new OSAbertas();
                        os.exibeOSContrato(nr_contrato,2);
                    }
                    else
                    {
                       
                    }
                }
                catch (Exception ex)
                {

                     ex.Message.ToString();
                }




            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            set_Excluirdetalhe();
            
            
        }

        protected void btConfirmaOS_Click(object sender, ImageClickEventArgs e)
        {
            daoOSConsulta os = new daoOSConsulta();
      
            DataTable dt_os = os.pro_getAcaoOs(Convert.ToInt32(id_grupo.Value));
            
        }

        private void buscaTecnico(int id_os)
        {
            daoOSConsulta os = new daoOSConsulta();
            DataTable dt = os.getTecnicoslOJAS(id_os);
            dropTecnico.DataSource = dt;
            dropTecnico.DataBind();
            dropTecnico.Items.Insert(0, "Selecione");
        }

        private void buscaDetalheAtendimento(Int32 nr_os)
        {
            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            DataTable dt_osMotivo = os.pro_getAMotivoOs(nr_os);
            dropMotivosAtendimento.DataSource = dt_osMotivo;
            dropMotivosAtendimento.DataBind();
            dropMotivosAtendimento.Items.Insert(0, "Selecione");
        }

        private void buscaDetalheMotivo(Int32 nr_os)
        {
            dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
            System.Data.DataTable iPedido = os.pro_getItensMotivoOs(nr_os);
            dropDetalhesMotivos.DataSource = iPedido;
            dropDetalhesMotivos.DataBind();
            dropDetalhesMotivos.Items.Insert(0, "Selecione");
        }

        protected void dropTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIdOs.Value != null && txtIdOs.Value != "")
                {
                    InfoEncerramento(Convert.ToInt32(txtIdOs.Value));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void dropMotivosAtendimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMotivosAtendimento.SelectedItem.Text != "Selecione")
            {
                ItensEncerramento(dropMotivosAtendimento.SelectedValue);
            }
        }

        protected void dropDetalhesMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIdOs.Value != "" && dropDetalhesMotivos.SelectedValue != "Selecione")
                {


                    dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();
                    int nr_os = Convert.ToInt32(txtIdOs.Value);
                    os.pro_setItensOs(nr_os, Convert.ToInt32(dropDetalhesMotivos.SelectedValue));
                    System.Data.DataTable iPedido = os.pro_getDetalhesEncerramento(nr_os);
                    if (iPedido.Rows.Count > 0)
                    {
                        foreach (var item in iPedido.Rows)
                        {
                            messageos.Value = messageos.Value + ((System.Data.DataRow)item).ItemArray[0].ToString().ToString() + "\n";
                        }


                    }
                    else
                    {
                        messageos.Value = "";
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gridsOS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string teste = gridsOS.DataKeys[gridsOS.SelectedRow.RowIndex].Values[0].ToString();
            }
        }

        protected void btnEncerrarOs_Click(object sender, EventArgs e)
        {
            // Miguel - inicio - 21/02
            //var retorno  = set_EncerraOs(1,Convert.ToInt32(txtIdOs.Value), slcResolvido.Value, message.Value, gridsOS.Rows[0].Cells[7].Text, slcpeca.Value, slcResolvidopor.SelectedValue, dropTecnico.SelectedItem.Text);
            try
            {
                if (message.Value != "" && txtIdOs.Value != "" && dropTecnico.SelectedValue != "Selecione")
                {
                    int retorno = 0;
                    retorno = set_EncerraOs(1, Convert.ToInt32(txtIdOs.Value), message.Value, gridsOS.Rows[0].Cells[7].Text, dropTecnico.SelectedItem.Text);
                    if (retorno > 0)
                    {
                        lbMensErro.Visible = true;
                        lbMensErro.Text = "OS Encerrada com sucesso!!!";
                        divRecado.Visible = false;
                    }
                    else
                    {
                        lbMensErro.Visible = true;
                        lbMensErro.Text = "" +
                            "" +
                            "Ordem de serviço não foi Encerrada!!!";
                        divRecado.Visible = true;
                    }
                }
                

            }
            catch (Exception ex)
            {
                lbMensErro.Visible = true;
                lbMensErro.Text = ex.Message.ToString();

            }
            // Miguel - fim - 21/02

        }

        protected void btVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                dao.OS.daoOSConsulta os = new dao.OS.daoOSConsulta();

                

                if (txtPesquisaVoucher.Value != "")
                {
                    object retorno = os.set_Voucher(Convert.ToInt32(txtIdOs.Value), Convert.ToInt32(txtPesquisaVoucher.Value), acessoLogin.Nome);

                    if (retorno != null)
                    {
                        lbMensErro.Visible = true;
                        lbMensErro.Text = retorno.ToString();
                    }
                    else
                    {
                        lbMensErro.Visible = true;
                        lbMensErro.Text = "Erro ao vincular Voucher...";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMensErro.Visible = true;
                lbMensErro.Text = ex.Message.ToString();
            }
        }
        
        protected void btnUltimoPacote_Click(object sender, EventArgs e)
        {
            string urlMapa;

            urlMapa = "https://portal.carsystem.com/mapa/#/login?chave=EG3PB4ZhY4mX8Z9M21xKJtvlGy2H4OqO7qBEVZQPlnvCu8H7&contrato=" + txtPesquisa.Value.ToString();

            // System.Diagnostics.Process.Start("notepad.exe");
            //System.Diagnostics.Process.Start("Chrome.exe",urlMapa.ToString());

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "abrir-1", "window.open('" + urlMapa.ToString() + "')", true);
        }

        protected void gridsOS_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            string teste = "teste";

            string b = teste;
        }

        public void btCancelarOS()
        {
            AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];

            try
            {
                daoOSsAberta dao = new daoOSsAberta();



                DataTable dt = (DataTable)Session["dt_os"];
                if (dao.CancelaOS(Convert.ToInt32(txtIdOs.Value), acessoLogin.cdCetec == "" ? acessoLogin.Nome.Substring(0, 6) : acessoLogin.cdCetec, acessoLogin.Nome,slcMotivos.Items[slcMotivos.SelectedIndex].Value, dt))
                {
                    lbMensErro.Visible = true;
                    lbMensErro.Text = "OS cancelada com sucesso !";
                }
                else
                {
                    lbMensErro.Visible = true;
                    lbMensErro.Text = "Não foi possivel cancelar a OS !";
                }
            }
            catch (Exception ex)
            {
                lbMensErro.Visible = true;
                lbMensErro.Text = "Erro ao cancelar OS: " + ex.Message;
            }
            if ((txtPesquisa.Value == null || txtPesquisa.Value == "") && acessoLogin.cdCetec != "")
            {
                daoOSsAberta dao = new daoOSsAberta();

                dao.atualizaOS(acessoLogin.cdCetec,2);
                exibeOS();
            }
            else
            {
                daoOSsAberta dao = new daoOSsAberta();
                if (txtPesquisa.Value != null && txtPesquisa.Value != "")
                    dao.atualizaOSContrato(txtPesquisa.Value, acessoLogin.idGrupo, acessoLogin.cdCetec == "" ? acessoLogin.Nome.Substring(0, 6) : acessoLogin.cdCetec,2);
                    exibeOSContrato(txtPesquisa.Value,2);
            }
        }
        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                lbMensErro.Visible = false;

                AcessoLogin acessoLogin = (dao.AcessoLogin)Session["acessoLogin"];
                Usuario.Value = acessoLogin.Nome;
                if (txtPesquisa.Value != "" && txtPesquisa.Value != null)
                {
                    OSAbertas os = new OSAbertas();
                    exibeOSContrato(txtPesquisa.Value,2);
                    CarregaMotivosCancelamentos();

                    if (txtIdOs.Value != null && txtIdOs.Value != "")
                    {
                        buscaTecnico(Convert.ToInt32(txtIdOs.Value));
                        buscaDetalheAtendimento(Convert.ToInt32(txtIdOs.Value));
                        buscaDetalheMotivo(Convert.ToInt32(txtIdOs.Value));
                    }

                }
                else
                {

                }

                if (TxtOsStatus.ToString() != "0" || TxtOsStatus.ToString() != "4")
                {
                    primeiraTela.Visible = true;
                }

                else
                {
                    primeiraTela.Visible = false;
                }

            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }


        }
        protected void btCancelarOrdem_Click(object sender, EventArgs e)
        {
            lbMensErro.Text = "";
            if (slcMotivos.Items[slcMotivos.SelectedIndex].Text != "" && slcMotivos.Items[slcMotivos.SelectedIndex].Text != "Selecione")
            {
                btCancelarOS();
            }
            else
            {
                lbMensErro.Visible = true;
                lbMensErro.Text = "Favor preencher todos os dados...";
            }
        }

        protected void btnDetalhes_ServerClick(object sender, EventArgs e)
        {
            string teste  = gridsOS.DataKeys[gridsOS.SelectedRow.RowIndex].Values[0].ToString();
        }

        protected void gridsOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_os = Convert.ToInt32(gridsOS.SelectedDataKey[0].ToString());
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int id_status = Convert.ToInt32(gridsOS.SelectedDataKey[1].ToString());

            if (id_status == 0 || id_status == 4)
            {
                divOs.Visible = true;
                DivResumo.Visible = false;
                if (acessoLogin.idGrupo == 39)
                {
                    divVisita.Visible = true;
                }
                else
                {
                    divVisita.Visible = false;
                }
            }
            else
            {
                divOs.Visible = false;
                DivResumo.Visible = true;
                BuscaOsEncerrada(id_os);
            }

        }
        private void BuscaOsEncerrada(int id_os)
        {
            daoOSsAberta dao = new daoOSsAberta();

            DataTable dt_encerramento= dao.getOsHistorico(id_os);

            if (dt_encerramento.Rows.Count > 0)
            {
                EtxtNumeroOS.Value = dt_encerramento.Rows[0][0].ToString();
                EtxtNumeroPeca.Value = dt_encerramento.Rows[0][1].ToString();
                EtxtTecnico.Value = dt_encerramento.Rows[0][2].ToString();
                ///EtxtDetalheOs.Value = dt_encerramento.Rows[0][3].ToString();
                EtxtInfoOS.Value = dt_encerramento.Rows[0][3].ToString();
                EtxtMedidaAdotada.Value = dt_encerramento.Rows[0][4].ToString() + dt_encerramento.Rows[0][7].ToString();
                EtxtDataEncerramento.Value = dt_encerramento.Rows[0][5].ToString();
                EtxtDataAbertura.Value = dt_encerramento.Rows[0][6].ToString();


            }
            else
            {
                EtxtNumeroOS.Value = "";
                EtxtNumeroPeca.Value = "";
                EtxtTecnico.Value = "";
                EtxtInfoOS.Value = "";
                EtxtMedidaAdotada.Value = "";
                EtxtDataEncerramento.Value = "";
                EtxtDataAbertura.Value = "";
            }
            daoOSConsulta daoConsulta = new daoOSConsulta();
            System.Data.DataTable iPedido = daoConsulta.pro_getDetalhesEncerramento(id_os);
            {
                if (iPedido.Rows.Count > 0)
                {
                    foreach (var item in iPedido.Rows)
                    {
                        EtxtDetalheOs.Value = EtxtDetalheOs.Value + ((System.Data.DataRow)item).ItemArray[0].ToString().ToString() + "\n";
                    }
                }
                else
                {
                    EtxtDetalheOs.Value = "";
                }
                
            }


        }
    }
}

