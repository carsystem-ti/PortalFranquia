using PortalFranquia.dao;
using PortalFranquia.dao.Chamados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace PortalFranquia.modulos.Chamados
{
    public partial class PegarChamado : System.Web.UI.Page
    {
        public static string usuario;
        public static int franquia;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    if (!IsPostBack)
                    {
                        getDados();
                        ValidaAcesso();
                        ValidaChamado();
                    }
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    usuario = acessoLogin.Nome.ToString();
                    franquia = acessoLogin.idFranquia;
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void ValidaAcesso()
        {
            try
            {
                if (Session["acessoLogin"] != null)
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string ds_tipo = acessoLogin.dsTipo;

                    switch (ds_tipo)
                    {
                        case "A":
                            btnAceite.Visible = false;
                            btnEncerrar.Visible = false;
                            break;
                        case "G":
                            btnAceite.Visible = false;
                            btnEncerrar.Visible = false;
                            break;
                        case "W":
                            btnAceite.Visible = true;
                            btnEncerrar.Visible = true;
                            break;
                        case "C":
                            btnReabrir.Visible = false;
                            break;
                    }

                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ValidaChamado()
        {
           // string ds_status = Session["id_statusChamado"].ToString();

            switch (lblstatus.Text)
            {
                case "ABERTO":
                    btnAceite.Visible = true;
                    break;
                case "EM ATENDIMENTO":
                    btnAceite.Visible = false;
                    btnEncerrar.Visible = true;
                    break;
                case "ENCERRADO":
                    btnAceite.Visible = false;
                    btnEncerrar.Visible = false;
                    break;
                case "CANCELADO":
                    btnAceite.Visible = false;
                    btnEncerrar.Visible = false;
                    break;
             
               case "REABERTO":
                    btnAceite.Visible = false;
                    btnEncerrar.Visible =true;
                    break;
                default:
                    btnAceite.Visible = false;
                    btnEncerrar.Visible = false;
                    break;
            }
        }
        [System.Web.Services.WebMethod]
        public static void EnviaEmail(string ds_descricao, string ds_encerramento, string Sla, int chamado)
        {
            //Cria objeto string builder
            StringBuilder sbBody = new StringBuilder();
            //Adiciona estrutura HTML do E-Mail
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>CHAMADOS CARSYSTEM</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #FFFFFF;}");
            sbBody.Append("body,td,th {font-family: Vrinda, Verdana, sans-serif;font-size: 16px;}</style><div></div></head><body>");
            sbBody.Append("<div style=background:#98C723</div>");
            sbBody.Append("<b>Seu chamado de nrº: " + chamado + " foi encerrado com sucesso no sistema de ocorrências.Verifique abaixo descrição da solução pela equipe de suporte.</b><br/>");
            sbBody.Append("<div style=\"width:550px; margin:auto; padding:3px; border:solid 2px #17bdfa;\">");
            sbBody.Append("<div style=\"float:right;\">");
            sbBody.Append("<p><font color='#FF0000'><strong>Chamado Encerrado por:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + usuario + " </strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do chamado:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_descricao + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição da solução:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_encerramento + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<br />");
            sbBody.Append("<br /></body></html>");


            //Cria novo objeto MailMessage
            MailMessage mailMessage = new MailMessage();

            //Define o remetente  
            mailMessage.From = new MailAddress("sistema@carsystem.com");

            //Define primeiro destinatário
            ChamadoMethod getEmailFranquia = new ChamadoMethod();
            DataSet ds_email = getEmailFranquia.GetEmailOcorrencia(chamado);
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailDP"].ToString());
            //Define segundo destinatário, note que podemos adicionar infinitos destinatários
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailfranquia"].ToString());

            //Define assunto do e-mail
            mailMessage.Subject = "CHAMADO " + chamado + " ENCERRADO COM SUCESSO";

            //Seta propriedade para enviar email em html como true(verdadeiro)
            mailMessage.IsBodyHtml = true;

            //Seta o corpo do e-mail com a estrutura HTML gravada na stringbuilder sbBody
            mailMessage.Body = sbBody.ToString();

            //Cria novo SmtpCliente e seta o endereço
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //Credencial para envio por SMTP Seguro (APENAS QUANDO O SERVIDOR EXIGE AUTENTICAÃ‡ÃƒO)   
            smtpClient.Credentials = new NetworkCredential("sistema@carsystem.com", "swe6709vel");

            // Envia a mensagem   
            smtpClient.Send(mailMessage);
        }
        public static bool CheckValidationResult(Object objeto, System.Security.Cryptography.X509Certificates.X509Certificate certificado,
                                     System.Security.Cryptography.X509Certificates.X509Chain chain,
                                     System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        [System.Web.Services.WebMethod]
        public static void EnviaComentarioEmail(string ds_descricao, string ds_comentario, string Sla, int chamado)
        {
            
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>CHAMADOS CARSYSTEM</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #FFFFFF;}");
            sbBody.Append("body,td,th {font-family:Vrinda, Verdana, sans-serif;font-size: 16px;}</style><div></div></head><body>");
            sbBody.Append("<div style=background:#98C723</div>");
            sbBody.Append("<b>Foi inserido um novo comentário no chamado de nrº: " + chamado + " .Verifique abaixo descrição do comentário.</b><br/>");
            sbBody.Append("<div style=\"width:550px; margin:auto; padding:3px; border:solid 2px #17bdfa;\">");
            sbBody.Append("<div style=\"float:right;\">");
            sbBody.Append("<p><font color='#FF0000'><strong>Comentário feito por:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + usuario + " </strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Comentários anteriores:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_descricao + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do novo comentário:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_comentario + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<br />");
            sbBody.Append("<br /></body></html>");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("sistema@carsystem.com");
            ChamadoMethod getEmailFranquia = new ChamadoMethod();
            DataSet ds_email = getEmailFranquia.GetEmailOcorrencia(chamado);
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailDP"].ToString());
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailfranquia"].ToString());
            mailMessage.Subject = "Comentário chamado: " + chamado;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbBody.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("sistema@carsystem.com", "swe6709vel");

            smtpClient.Send(mailMessage);
        }
        [System.Web.Services.WebMethod]
        public static void EmailReabrirEmail(string ds_descricao, string ds_comentario, string Sla, int chamado)
        {
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>CHAMADOS CARSYSTEM</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #FFFFFF;}");
            sbBody.Append("body,td,th {font-family: Vrinda, Verdana, sans-serif;font-size: 16px;}</style><div></div></head><body>");
            sbBody.Append("<div style=background:#98C723</div>");
            sbBody.Append("<b>Foi inserido um novo comentário no chamado de nrº: " + chamado + " .Verifique abaixo descrição do comentário.</b><br/>");
            sbBody.Append("<div style=\"width:550px; margin:auto; padding:3px; border:solid 2px #17bdfa;\">");
            sbBody.Append("<div style=\"float:right;\">");
            sbBody.Append("<p><font color='#FF0000'><strong>Comentário feito por:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + usuario + " </strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do chamado:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_descricao + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do comentário:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + ds_comentario + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<br />");
            sbBody.Append("<br /></body></html>");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("sistema@carsystem.com");
            ChamadoMethod getEmailFranquia = new ChamadoMethod();
            DataSet ds_email = getEmailFranquia.GetEmailOcorrencia(chamado);
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailDP"].ToString());
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_emailfranquia"].ToString());
            mailMessage.Subject = "Comentário chamado: " + chamado;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbBody.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("sistema@carsystem.com", "swe6709vel");
            smtpClient.Send(mailMessage);
        }
        [System.Web.Services.WebMethod]
        public static string AtenderChamado(int numeroDetalhes)
        {
            string ds_retorno = "Erro entre em contato com Administrador do sistema";
            try
            {
                if (numeroDetalhes > 0)
                {
                    int retorno = 0;
                    daoChamados bdc = new daoChamados();
                    retorno = bdc.pro_setAceitaChamado(numeroDetalhes, usuario);
                    if (retorno > 0)
                    {
                        ds_retorno = "CHAMADO ACEITO";
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ds_retorno;
        }
        [System.Web.Services.WebMethod]
        public static string ReabrirChamado(int numeroDetalhes, string ds_encerramento, string ds_abertura)
        {
            string ds_retorno = "Não foi possível Gravar dados";
            try
            {
                if (numeroDetalhes > 0)
                {
                    int retorno = 0;
                    daoChamados bdc = new daoChamados();
                    retorno = bdc.pro_setReabrirChamado(numeroDetalhes);
                    if (retorno > 0)
                    {
                        ds_retorno = "CHAMADO REABERTO";
                        EmailReabrirEmail(ds_abertura, ds_encerramento, "", numeroDetalhes);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ds_retorno;
        }
        [System.Web.Services.WebMethod]
        public static string FinalizarChamado(int numeroDetalhes, string ds_encerramento, string ds_abertura, string ds_observacao)
        {
            string ds_retorno = "Não foi possível Gravar dados";
            try
            {
                if (numeroDetalhes > 0 && ds_encerramento != "")
                {
                    int retorno = 0;
                    daoChamados bdc = new daoChamados();
                    retorno = bdc.pro_setEncerraChamado(numeroDetalhes, ds_encerramento);
                    if (retorno > 0)
                    {
                        EnviaEmail(ds_abertura, ds_encerramento, "", numeroDetalhes);
                        GravaComentarios(numeroDetalhes, ds_encerramento, ds_observacao);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ds_retorno;
        }


        [System.Web.Services.WebMethod(true)]
        public static string GravaComentarios(int numero, string novomen, string antigamen)
        {
            if (numero > 0 && novomen != "")
            {
                daoChamados bdc = new daoChamados();
                string obs = novomen + " Data: " + DateTime.Now + " Usuario: " + usuario + " " + "\r\n" + antigamen + "\r\n";
                int exec = bdc.pro_setGravaObs(numero, obs);
                if (exec > 0)
                {
                    EnviaComentarioEmail(antigamen, novomen, "", Convert.ToInt32(numero));
                }
            }
            else
            {
 
            }
            return DateTime.Now.ToString() + " Usuario: " + usuario;
        }

        public void getDados()
        {
            if (Session["id"] != null)
            {
                int _detalhes = Convert.ToInt32(Session["id"].ToString());
                lblNrChamado.Text = _detalhes.ToString();
                numero.Value = _detalhes.ToString();
                //txtNr.Text = _detalhes.ToString();
                daogetChamados bda = new daogetChamados();
                DataSet dt_Chamados = new DataSet();
                dt_Chamados = bda.GetDetalhes(_detalhes);
                if (dt_Chamados.Tables[0].Rows.Count > 0)
                {
                    TxtDescricao.Text = dt_Chamados.Tables[0].Rows[0]["ds_Descricao"].ToString();
                    txtComentarios.Text = dt_Chamados.Tables[0].Rows[0]["ds_comentarios"].ToString();
                    int id_status = Convert.ToInt32(dt_Chamados.Tables[0].Rows[0]["id_status"].ToString());
                    switch (id_status)
                    {
                        case 1:
                            btnAceite.Visible = true;
                            btnReabrir.Visible = false;
                            lblstatus.Text = "ABERTO";
                            break;
                        case 2:
                            btnAceite.Visible = false;
                            btnReabrir.Visible = false;
                            lblstatus.Text = "EM ATENDIMENTO";
                            break;
                        case 3:
                            btnAceite.Visible = false;
                            btnEncerrar.Visible = false;
                            btnReabrir.Visible = true;
                            lblstatus.Text = "ENCERRADO";
                            break;

                        case 4:
                            btnAceite.Visible = false;
                            btnEncerrar.Visible = false;
                            btnReabrir.Visible = false;
                            lblstatus.Text = "CANCELADO";
                            break;

                        case 5:
                            btnAceite.Visible = false;
                            btnEncerrar.Visible = true;
                            btnReabrir.Visible = false;
                            lblstatus.Text = "REABERTO";
                            break;
                    }
                }
                else
                {


                }
            }
        }
    }
}