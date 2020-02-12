using PortalFranquia.dao;
using PortalFranquia.dao.Chamados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.Chamados
{
    public partial class Chamados1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["Menu"] = 0;
                    if (Session["acessoLogin"] != null)
                    {
                        BuscaDepartamento();
                        CarregaInf();
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
            
        }
        private void BuscaMensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void CarregaInf()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            txtFranquia.Text = acessoLogin.Franquia;
            txtNome.Text = acessoLogin.Nome;
            if (acessoLogin.idFranquia == 0)
            {
                txtFranquia.Text = Session["ds_Departamento"].ToString();
            }
        }
        private void BuscaDepartamento()
        {
            DataTable dsDepartamento = new DataTable();
            daoChamados bda = new daoChamados();
            int tipo =Convert.ToInt32(Session["fl_abertura"].ToString());
            dsDepartamento = bda.GetDepartamentos(tipo);
            if (dsDepartamento.Rows.Count > 0)
            {
                dropArea.DataSource = dsDepartamento;
                dropArea.DataBind();
                dropArea.Items.Insert(0, "SELECIONE");
            }
        }

        protected void dropArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropArea.SelectedValue != "SELECIONE")
            {
                int Depto = Convert.ToInt32(dropArea.SelectedValue);
                daoChamados bda = new daoChamados();
                DataTable dt = new DataTable();
                dt = bda.GetAssuntoDepartamentos(Depto);
                if (dt.Rows.Count > 0)
                {
                    dropAsssunto.DataSource = dt;
                    dropAsssunto.DataBind();
                    dropAsssunto.Items.Insert(0, "SELECIONE");
                }
            }
        }

        protected void dropAsssunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropAsssunto.SelectedValue != "SELECIONE")
            {
                int id_assunto = Convert.ToInt32(dropAsssunto.SelectedValue);
                daoChamados bda = new daoChamados();
                DataSet dt = new DataSet();
                dt = bda.GetSla(id_assunto);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    txtSLA.Text = dt.Tables[0].Rows[0]["sla"].ToString() + ".Hs";
                }
            }
        }
        public bool CheckValidationResult(Object objeto, System.Security.Cryptography.X509Certificates.X509Certificate certificado,
                                     System.Security.Cryptography.X509Certificates.X509Chain chain,
                                     System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void EnviaEmail(string area,StringBuilder mensagem,string Sla,int chamado,int dp)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
            new System.Net.Security.RemoteCertificateValidationCallback(this.CheckValidationResult);
            //Cria objeto string builder
            StringBuilder sbBody = new StringBuilder();
             AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            txtFranquia.Text = acessoLogin.Franquia;
            txtNome.Text = acessoLogin.Nome;
            int departamento = acessoLogin.idFranquia == 0 ? Convert.ToInt32(Session["id_departamento"].ToString()) : acessoLogin.idFranquia;
            
            //Adiciona estrutura HTML do E-Mail
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>CHAMADOS CARSYSTEM</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #FFFFFF;}");
            sbBody.Append("body,td,th {font-family: Vrinda, Vrinda, sans-serif;font-size: 16px;}</style><div></div></head><body>");
            sbBody.Append("<div style=background:#98C723</div>");
            sbBody.Append("<b>Seu chamado foi aberto com sucesso no sistema de ocorrências! O número é: " + chamado  + ".Aguarde o atendimento pela equipe de suporte.</b><br/>");
            sbBody.Append("<div style=\"width:550px; margin:auto; padding:3px; border:solid 2px #17bdfa;\">");
            sbBody.Append("<div style=\"float:right;\">");
            sbBody.Append("<p><font color='#FF0000'><strong>Chamado aberto por:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + acessoLogin.Nome + " </strong></p>");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do Chamado:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + mensagem + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>ÁREA:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + area + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Tempo de Atendimento:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + Sla + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<br /></body></html>");


            //Cria novo objeto MailMessage
            MailMessage mailMessage = new MailMessage();

            //Define o remetente  
            mailMessage.From = new MailAddress("sistema@carsystem.com");

            //Define primeiro destinatário
            ChamadoMethod getEmailFranquia = new ChamadoMethod();
            int tipo = Convert.ToInt32(Session["fl_abertura"].ToString());
            DataSet ds_email = getEmailFranquia.GetEmailFranquia(tipo,departamento);
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_email"].ToString());

            //Define segundo destinatário, note que podemos adicionar infinitos destinatários
            DataSet ds_area = getEmailFranquia.GetEmailArea(dp);
            mailMessage.To.Add(ds_area.Tables[0].Rows[0]["ds_Email"].ToString());

            //Define assunto do e-mail
            mailMessage.Subject = "CHAMADO ABERTO";

            //Seta propriedade para enviar email em html como true(verdadeiro)
            mailMessage.IsBodyHtml = true;

            //Seta o corpo do e-mail com a estrutura HTML gravada na stringbuilder sbBody
            mailMessage.Body = sbBody.ToString();

            //Cria novo SmtpCliente e seta o endereço
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //Credencial para envio por SMTP Seguro (APENAS QUANDO O SERVIDOR EXIGE AUTENTICAÃ‡ÃƒO)   
            smtpClient.Credentials = new NetworkCredential("sistema@carsystem.com", "swe6709vel");
            smtpClient.EnableSsl = true;
            // Envia a mensagem   
            smtpClient.Send(mailMessage);
        }
        private void EnviaEmailEncerra(string area, StringBuilder mensagem, string Sla, int chamado, int dp)
        {
            //Cria objeto string builder
            StringBuilder sbBody = new StringBuilder();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            txtFranquia.Text = acessoLogin.Franquia;
            txtNome.Text = acessoLogin.Nome;
            int departamento = acessoLogin.idFranquia == 0 ? Convert.ToInt32(Session["id_departamento"].ToString()) : acessoLogin.idFranquia;
            //Adiciona estrutura HTML do E-Mail
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>CHAMADOS CARSYSTEM</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #FFFFFF;}");
            sbBody.Append("body,td,th {font-family: Verdana, Geneva, sans-serif;font-size: 14px;}</style><div></div></head><body>");
            sbBody.Append("<div style=background:#98C723</div>");
            sbBody.Append("<b>Seu chamado foi aberto com sucesso no sistema de ocorrências! O número é: " + chamado + ".Aguarde o atendimento pela equipe de suporte.</b><br/>");
            sbBody.Append("<div style=\"width:550px; margin:auto; padding:3px; border:solid 2px #17bdfa;\">");
            sbBody.Append("<div style=\"float:right;\">");
            sbBody.Append("<p><font color='#FF0000'><strong>Chamado aberto por:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + acessoLogin.Nome + " </strong></p>");
            sbBody.Append("<p><font color='#FF0000'><strong>Descrição do Chamado:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + mensagem + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>ÁREA:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + area + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<p><font color='#FF0000'><strong>Tempo de Atendimento:</strong></font>");
            sbBody.Append("<br />");
            sbBody.Append("<strong>" + Sla + "</strong></p>");
            sbBody.Append("<br />");
            sbBody.Append("<br /></body></html>");


            //Cria novo objeto MailMessage
            MailMessage mailMessage = new MailMessage();

            //Define o remetente  
            mailMessage.From = new MailAddress("sistema@carsystem.com");

            //Define primeiro destinatário
            ChamadoMethod getEmailFranquia = new ChamadoMethod();
            int tipo = Convert.ToInt32(Session["fl_abertura"].ToString());
            DataSet ds_email = getEmailFranquia.GetEmailFranquia(tipo,departamento);
            mailMessage.To.Add(ds_email.Tables[0].Rows[0]["ds_email"].ToString());

            //Define segundo destinatário, note que podemos adicionar infinitos destinatários
            DataSet ds_area = getEmailFranquia.GetEmailArea(dp);
            mailMessage.To.Add(ds_area.Tables[0].Rows[0]["ds_Email"].ToString());

            //Define assunto do e-mail
            mailMessage.Subject = "CHAMADO ABERTO";

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
        private void GravaChamando()
        {
            int id_grupo = 0;
            if (dropArea.SelectedValue != "SELECIONE" && dropAsssunto.SelectedValue != "SELECIONE")
            {
                if (Session["acessoLogin"] != null)
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                   // if (acessoLogin.idFranquia > 0)
                   // {
                        daogetChamados bdc = new daogetChamados();
                        DataTable dt_valida = new DataTable();
                        dt_valida = bdc.ValidaChamado(acessoLogin.idFranquia, Convert.ToInt32(dropAsssunto.SelectedValue));
                        if (dt_valida.Rows.Count > 0)
                        {
                            Mensagem("EXISTE UM CHAMADO COM O MESMO MOTIVO EM ABERTO..");

                        }
                        else
                        {
                            daoChamados bda = new daoChamados();
                            int id_motivo = Convert.ToInt32(dropAsssunto.SelectedValue);
                            StringBuilder ds_descricao = new StringBuilder(txtDescricao.Text);
                            int franquia = acessoLogin.idFranquia;
                            string userChamado = txtNome.Text;
                            int area = Convert.ToInt32(dropArea.SelectedValue);
                            int exec = 0;
                            if (Session["id_grupo"] != null)
                            {
                                 id_grupo = Convert.ToInt32(Session["id_grupo"].ToString());
                            }
                            exec = bda.pro_setGravaChamada(id_motivo, ds_descricao, franquia, userChamado, id_grupo);
                            if (exec > 0)
                            {
                                Mensagem("CHAMADO ABERTO COM SUCESSO: " + exec.ToString());
                                txtStatus.Text = "ABERTO";
                                EnviaEmail(dropArea.SelectedItem.Text, ds_descricao, txtSLA.Text, exec, area);

                            }
                            else
                            {
                                Mensagem("NÃO FOI POSSIVEL ABRIR SEU CHAMADO:");
                            }

                        }
                   // }
                   // else
                   // {
                     //   Mensagem("USUÁRIO NÃO PERTENCE A NENHUMA FRANQUIA");
                   // }
                }
                else
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
            else
            {
                Mensagem("FAVOR PREENCHER TODAS AS INFORMAÇÕES:");
            }
        }
        protected void imgSalvar_Click(object sender, ImageClickEventArgs e)
        {
            GravaChamando();
        }
    }
}