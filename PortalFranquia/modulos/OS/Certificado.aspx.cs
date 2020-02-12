using PortalFranquia.dao.Documentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.modulos.OS
{
    public partial class Certificado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUser;
            string strContrato;

            int fl_guincho =0;
            int fl_guinchoUnico=0;
            int fl_MartVidro=0;
            int fl_res=0;

            strUser = Session["strUser"].ToString();
            strContrato = Request["txtContrato"].ToString();

            daoDocumentos docto = new daoDocumentos();
            DataTable dsCertificado = new DataTable();
            DataTable dsCertificadoCAC = new DataTable();

            dsCertificado = docto.getDadosCertificado(strContrato.ToString(), Session["strUser"].ToString());
            dsCertificadoCAC = docto.getDadosCertificadoCAC(strContrato.ToString());

            if (dsCertificadoCAC.Rows.Count == 0)
            {
                lblMensagem.Text = "Cliente não Encontrado !!!";
            }
            else {

                if (dsCertificadoCAC.Rows[0]["ds_status"].ToString() == "ATIVO" || dsCertificadoCAC.Rows[0]["ds_status"].ToString() == "PRE-ATIVO" || dsCertificadoCAC.Rows[0]["ds_status"].ToString() == "PLUS SEM VISTORIA" || dsCertificadoCAC.Rows[0]["ds_status"].ToString() == "SEM VISTORIA")
                {

                    lblContrato.Text = strContrato.ToString();
                    lblNome.Text = dsCertificadoCAC.Rows[0]["Nome"].ToString();
                    lblEndereco.Text = dsCertificadoCAC.Rows[0]["Endereço"].ToString() + ", " + dsCertificadoCAC.Rows[0]["Numero Residencial"].ToString();
                    lblCidade.Text = dsCertificadoCAC.Rows[0]["Cidade"].ToString();
                    lblCEP.Text = dsCertificadoCAC.Rows[0]["Cep"].ToString();
                    lblBairro.Text = dsCertificadoCAC.Rows[0]["Bairro"].ToString();
                    lblEmail.Text = dsCertificadoCAC.Rows[0]["email"].ToString();
                    lblCelular.Text = dsCertificadoCAC.Rows[0]["Celular"].ToString();
                    lblTelefone.Text = dsCertificadoCAC.Rows[0]["Telefone"].ToString();
                    lblUF.Text = dsCertificadoCAC.Rows[0]["UF"].ToString();

                    if (dsCertificadoCAC.Rows[0]["Tipo Pessoa"].ToString() == "0")
                    {
                        lblCPF.Text = dsCertificadoCAC.Rows[0]["CPF"].ToString();
                    }
                    else
                    {
                        lblCPF.Text = dsCertificadoCAC.Rows[0]["Cnpj"].ToString();
                    };

                    foreach (DataRow rowProduto in dsCertificado.Rows)
                    {

                        if (rowProduto[1].ToString() == "ASSISTÊNCIA 24Hs-000175" || rowProduto[1].ToString() == "ASSISTÊNCIA 24Hs PROMO I-000186" || rowProduto[1].ToString() == "ASSISTÊNCIA 24Hs PROMO II-000187" || rowProduto[1].ToString() == "ASSISTÊNCIA COMBO-000188")
                        {
                            fl_guincho = 1;
                        }

                        if (rowProduto[1].ToString() == "ASSISTÊNCIA 24Hs 1 UTILIZAÇÃO-000189")
                        {
                            fl_guinchoUnico = 1;
                        }

                        if (rowProduto[1].ToString() == "ASSISTÊNCIA REPAROS E MARTELINHO-000216" || rowProduto[1].ToString() == "ASSISTÊNCIA VIDROS-000215")
                        {
                            fl_MartVidro = 1;
                        }

                        if (rowProduto[1].ToString() == "ASSISTÊNCIA RESIDENCIAL-000801")
                        {
                            fl_res = 1;
                        }
                    }

                    var valor = string.Format("{0:F}", dsCertificado.Rows[0]["vl_total"]);

                    lblValorTotal.Text = valor.ToString();

                    grdProdutos.DataBind();

                    if (dsCertificado.Rows[0]["fl_br"].ToString() != "0")
                    {
                        lblTitulo.Text = "Para agendar a instalação do seu Rastreador, ligue para <span class='green'>4003-4213</span>";
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000431")
                    {
                        lblProduto431.Text = "   Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   sombra (cláusula 2ª)." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   fidelidade (cláusula 3ª, §2º e 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   término do prazo." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Tenho ciência que o pagamento ocorre de forma prévia, ou seja, que deve ser efetuado o pagamento da" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   respectiva parcela mensal para garantir o direito de utilização do serviço pelos trinta dias subsequentes," + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   bem como o direito à indenização em caso de furto/roubo ocorrido no mesmo período, sendo que, em" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   caso de inadimplemento, mesmo que de apenas um dia, ficará isenta a CONTRATADA de realizar o" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   cumprimento de suas obrigações." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada e a Seguradora do" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   compromisso de indenização, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes," + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   além de efetuar o devido Registro da Ocorrência." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Que a Contratada não cumprirá com a obrigação de indenização, caso, na data do furto/roubo, o" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   equipamento não estiver adequadamente instalado; OU estiver em atraso qualquer pagamento de" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   qualquer das mensalidades; OU não tiver sido efetuado o respectivo teste mensal para aferição do" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   funcionamento do aparelho no mês em que se der o furto ou roubo; OU não tiverem sido realizadas as" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   vistorias determinadas em contrato; OU o condutor não for devidamente habilitado." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - O pagamento da indenização pelo veículo em caso de não recuperação do mesmo, é de 100% do valor" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   do bem em caso de automóvel comum e 75% para automóvel Taxi, limitado a R$ 40.000,00, e, 80% do" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   - Constatado a qualquer momento, anotação no documento do veículo do cliente, dos órgãos de controle" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   valor de mercado do bem, será pago apenas 70% do valor da tabela FIPE (Cláusula 9.1, §2º)." + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado" + "\r\n";
                        lblProduto431.Text = lblProduto431.Text + "   no cartório de registro de documentos da cidade de São Paulo/SP." + "<br />";
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000429")
                    {
                        if (dsCertificadoCAC.Rows[0]["Tipo Pessoa"].ToString() == "0")
                        {
                            //CPF
                            lblProduto429CPF.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam: " + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo, bem como a obrigatoriedade de restituir o aparelho, nos termos da cláusula 3ª, após o encerramento da prestação de serviços." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada do compromisso de compra dos documentos do veículo, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência, sob pena de não cumprimento do pacto de compra do documento." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Que a Contratada não cumprirá com a obrigação de Compra sobre Documentos na data do furto/roubo, caso o equipamento não tiver sido instalado, estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- O cumprimento da promessa adjeto de compra de documento do veículo em caso de não recuperação do mesmo, é de 70% do valor do bem em caso de automóvel comum limitado a R$ 40.000,00, e, 70% do valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "- Por ser um plano para veículos com anotação no documento, dos órgãos de controle de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o valor de mercado do bem, será pago apenas 70% do valor da tabela FIPE, ou, sobre o limite contratual, caso o valor de mercado seja superior a limitação. (Cláusula 9.1, §2º)." + "\r\n" + "<br>";
                            lblProduto429CPF.Text = lblProduto429CPF.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "<br>";

                            if (fl_guincho == 1)
                            {
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "ASSISTÊNCIA 24HS" + "\r\n";
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) acionamentos anuais, para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Ultrapassados tais limites, o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, conforme a região do acionamento. (Cláusula 8.3)" + "<br />";
                            }

                            if (fl_res == 1)
                            {
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "ASSISTENCIA RESIDENCIAL" + "\r\n";
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente. (Cláusula 8.4)" + "<br />";
                            }

                            if (fl_MartVidro == 1)
                            {
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "ASSISTENCIA VIDROS E REPAROS RÁPIDOS" + "\r\n";
                                lblProduto429CPF.Text = lblProduto429CPF.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização. (Cláusula 8.5)" + "<br />";
                            }
                        }
                        else
                        {
                            //CNPJ
                            lblProduto429CNPJ.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Possuo ciência que devo cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo, bem como a obrigatoriedade de restituir o aparelho, nos termos da cláusula 3ª, após o encerramento da prestação de serviços." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada do compromisso de compra dos documentos do veículo, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência, sob pena de não cumprimento do pacto de compra do documento." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Que a Contratada não cumprirá com a obrigação de Compra sobre Documentos na data do furto/roubo, caso o equipamento não tiver sido instalado; estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- O cumprimento da promessa adjeto de compra de documento do veículo em caso de não recuperação do mesmo, é de 70% do valor do bem em caso de automóvel comum limitado a R$ 40.000,00, e, 70% do valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "- Por ser um plano para veículos com anotação no documento, dos órgãos de controle de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o valor de mercado do bem, será pago apenas 70% do valor da tabela FIPE, ou, sobre o limite contratual, caso o valor de mercado seja superior a limitação. (Cláusula 9.1, §2º)." + "\r\n";
                            lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "\r\n" + "<br>";

                            if (fl_guincho == 1)
                            {
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "ASSISTÊNCIA 24HS" + "\r\n";
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) acionamentos anuais, para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Ultrapassados tais limites, o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, conforme a região do acionamento. (Cláusula 8.3)<br />" + "\r\n";
                            }
                            if (fl_res == 1)
                            {
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "ASSISTENCIA RESIDENCIAL" + "\r\n";
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente. (Cláusula 8.4)<br />" + "\r\n";
                            }
                            if (fl_MartVidro == 1)
                            {
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "ASSISTENCIA VIDROS E REPAROS RÁPIDOS" + "\r\n";
                                lblProduto429CNPJ.Text = lblProduto429CNPJ.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização. (Cláusula 8.5)<br />" + "\r\n";
                            }
                        }
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000428")
                    {
                        if (dsCertificadoCAC.Rows[0]["Tipo Pessoa"].ToString() == "0")
                        {
                            //CPF
                            lblProduto428CPF.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo, bem como a obrigatoriedade de restituir o aparelho, nos termos da cláusula 3ª, após o encerramento da prestação de serviços." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada do compromisso de compra dos documentos do veículo, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência, sob pena de não cumprimento do pacto de compra do documento." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Que a Contratada não cumprirá com a obrigação de Compra sobre Documentos na data do furto/roubo, caso o equipamento não tiver sido instalado, estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- O cumprimento da promessa adjeto de compra de documento do veículo em caso de não recuperação do mesmo, é de 60% do valor do bem em caso de automóvel comum limitado a R$ 40.000,00, e, 60% do valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "- Por ser um plano para veículos com anotação no documento, dos órgãos de controle de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o valor de mercado do bem, será pago apenas 60% do valor da tabela FIPE, ou, sobre o limite contratual, caso o valor de mercado seja superior a limitação. (Cláusula 9.1, §2º)." + "\r\n";
                            lblProduto428CPF.Text = lblProduto428CPF.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "\r\n";

                            if (fl_guincho == 1)
                            {
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "ASSISTÊNCIA 24HS" + "\r\n";
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) acionamentos anuais, para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Ultrapassados tais limites, o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, conforme a região do acionamento. (Cláusula 8.3)<br />" + "\r\n";
                            }
                            if (fl_res == 1)
                            {
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "ASSISTENCIA RESIDENCIAL" + "\r\n";
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente. (Cláusula 8.4)" + "\r\n";
                            }
                            if (fl_MartVidro == 1)
                            {
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "ASSISTENCIA VIDROS E REPAROS RÁPIDOS" + "\r\n";
                                lblProduto428CPF.Text = lblProduto428CPF.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização. (Cláusula 8.5)" + "\r\n";
                            }
                        }
                        else
                        {
                            //CNPJ
                            lblProduto428CNPJ.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo, bem como a obrigatoriedade de restituir o aparelho, nos termos da cláusula 3ª, após o encerramento da prestação de serviços." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada do compromisso de compra dos documentos do veículo, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência, sob pena de não cumprimento do pacto de compra do documento." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Que a Contratada não cumprirá com a obrigação de Compra sobre Documentos na data do furto/roubo, caso o equipamento não tiver sido instalado, estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- O cumprimento da promessa adjeto de compra de documento do veículo em caso de não recuperação do mesmo, é de 60% do valor do bem em caso de automóvel comum limitado a R$ 40.000,00, e, 60% do valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "- Por ser um plano para veículos com anotação no documento, dos órgãos de controle de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o valor de mercado do bem, será pago apenas 60% do valor da tabela FIPE, ou, sobre o limite contratual, caso o valor de mercado seja superior a limitação. (Cláusula 9.1, §2º)." + "\r\n";
                            lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "\r\n" + "<br />";

                            if (fl_guincho == 1)
                            {
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "ASSISTÊNCIA 24HS" + "\r\n";
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) acionamentos anuais, para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Ultrapassados tais limites, o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, conforme a região do acionamento. (Cláusula 8.3)" + "\r\n";
                            }
                            if (fl_res == 1)
                            {
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "ASSISTENCIA RESIDENCIAL" + "\r\n";
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente. (Cláusula 8.4)" + "\r\n";
                            }
                            if (fl_MartVidro == 1)
                            {
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "ASSISTENCIA VIDROS E REPAROS RÁPIDOS" + "\r\n";
                                lblProduto428CNPJ.Text = lblProduto428CNPJ.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização. (Cláusula 8.5)" + "\r\n" + "<br />";
                            }
                        }
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000417" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000419" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000421" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000600" && dsCertificado.Rows[0]["tp_produto"].ToString() != "000420" && dsCertificado.Rows[0]["tp_produto"].ToString() != "000422" && dsCertificado.Rows[0]["tp_produto"].ToString() == "000431" && dsCertificado.Rows[0]["tp_produto"].ToString() != "000430")
                    {
                        lblProdutosDiversos.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                        lblProdutosDiversos.Text = lblProdutosDiversos.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n" + "<br />";

                        if (dsCertificadoCAC.Rows[0]["Tipo Pessoa"].ToString() == "0")
                        {
                            //CPF
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 3ª, §2º e 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo." + "<br />";
                        }
                        else
                        {
                            //CNPJ
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "- Possuo ciência que devo cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo." + "<br />";
                        }

                        lblProdutosDiversos.Text = lblProdutosDiversos.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência." + "\r\n";
                        lblProdutosDiversos.Text = lblProdutosDiversos.Text + "- Está ciente que a Contratada não é empresa de seguros, bem como não está obrigada a reembolsar ou indenizar, caso o veículo não seja recuperado, pois optou pelo plano Standard, concordando com os serviços escolhidos e os valores por eles pagos, nada mais podendo reclamar a respeito." + "\r\n";
                        lblProdutosDiversos.Text = lblProdutosDiversos.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo / SP." + "<br>";

                        if (fl_guincho == 1)
                        {
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) " + "\r\n";
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "acionamentos anuais para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. " + "\r\n";
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "Ultrapassados tais limites,o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, " + "\r\n";
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "conforme a região do acionamento." + "\r\n" + "<br>";
                        }

                        if (fl_guinchoUnico == 1)
                        {
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, ora incluso em caráter promocional, possui limitação de 1 (um) acionamento anual, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Após a utilização, caso o cliente deseje o pacote completo, no termos já descritos no contrato de prestação de serviços, o mesmo deverá entrar em contato com a Empresa." + "\r\n" + "<br />";
                        }

                            if (fl_res == 1)
                        {
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + " - A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de" + "\r\n";
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + " Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e" + "\r\n";
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + " materiais para execução do serviço, que ficará a cargo do cliente." + "\r\n" + "<br />";
                        }

                        if (fl_MartVidro == 1)
                        {
                            lblProdutosDiversos.Text = lblProdutosDiversos.Text + " -  A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização." + "\r\n" + "<br>";
                        }
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000420" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000422")
                    {
                        lblProduto420422.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n" + "<br />";


                        if (dsCertificadoCAC.Rows[0]["Tipo Pessoa"].ToString() == "0")
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 3ª, §2º e 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo." + "\r\n" + "<br />";
                        }
                        else
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "- Possuo ciência que devo cumprir com o compromisso de fidelidade (cláusula 5ª), disposto no contrato, adimplindo com as parcelas vincendas até o término do prazo." + "\r\n" + "<br />";
                        }

                        lblProduto420422.Text = lblProduto420422.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, exonera a Contratada do compromisso de compra dos documentos do veículo, independentemente do cumprimento das demais obrigações contratuais." + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência." + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "- Que a Contratada não cumprirá com a obrigação de Compra sobre Documentos na data do furto/roubo, caso o equipamento não tiver sido instalado; estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "- O cumprimento da promessa adjeto de compra de documento do veículo em caso de não recuperação do mesmo, é de 100% do valor do bem em caso de automóvel comum e 75% para automóvel Taxi, limitado a R$ 40.000,00, e, 80% do valor do bem em caso de motocicleta em até R$ 10.000,00, conforme avaliação da tabela FIPE da época da ocorrência, devendo antes, ser entregue o DUT livre e desimpedido de quaisquer ônus e obrigações." + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "- Constatado a qualquer momento, anotação no documento do veículo do cliente, dos órgãos de controle de documentação veicular, tais como BIN, DETRAN, DENATRAN, ETC, que aponte ser ele recuperado de seguradora, financeira, acidente natural, chassi remarcado ou qualquer outra anotação que deprecie o valor de mercado do bem, será pago apenas 70% do valor da tabela FIPE (Cláusula 9.1, §2º)." + "\r\n";
                        lblProduto420422.Text = lblProduto420422.Text + "A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "\r\n" + "<br>";

                        if (fl_guincho == 1)
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) " + "\r\n";
                            lblProduto420422.Text = lblProduto420422.Text + "acionamentos anuais para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. " + "\r\n";
                            lblProduto420422.Text = lblProduto420422.Text + "Ultrapassados tais limites,o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, " + "\r\n";
                            lblProduto420422.Text = lblProduto420422.Text + "conforme a região do acionamento." + "\r\n" + "<br />";
                        }

                        if (fl_guinchoUnico == 1)
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, ora incluso em caráter promocional, possui limitação de 1 (um) acionamento anual, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Após a utilização, caso o cliente deseje o pacote completo, no termos já descritos no contrato de prestação de serviços, o mesmo deverá entrar em contato com a Empresa." + "\r\n" + "<br />";
                        }

                        if (fl_res == 1)
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "-  A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de" + "\r\n";
                            lblProduto420422.Text = lblProduto420422.Text + "Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e" + "\r\n";
                            lblProduto420422.Text = lblProduto420422.Text + "materiais para execução do serviço, que ficará a cargo do cliente." + "\r\n" + "<br />";
                        }

                        if (fl_MartVidro == 1)
                        {
                            lblProduto420422.Text = lblProduto420422.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização." + "\r\n" + "<br>";
                        }
                    }

                    if (dsCertificado.Rows[0]["tp_produto"].ToString() == "000436" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000437" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000438" || dsCertificado.Rows[0]["tp_produto"].ToString() == "000439")
                    {
                        lblProduto436437438.Text = "Declaro ter lido e recebido cópia integral do contrato, concordando com as principais cláusulas limitativas do produto, principalmente que lhe geram obrigações adicionais, quais sejam:" + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- Tenho conhecimento que o sistema não é infalível, pois a natureza móvel do veículo não será modificada pelo equipamento, além de que os sinais enviados poderão não ser recebidos em razão de interferências ocasionadas pela topografia, túneis e condições atmosféricas, ocasionando áreas de sombra (cláusula 2ª)." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- Possuo ciência do prazo para de desistência, de 7 (sete) dias corridos a partir do recebimento do produto, sendo que havendo desistência após este período, deverá cumprir com o compromisso de fidelidade (cláusula 3ª, §2º), disposto no contrato." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- Que se compromete a realizar o teste mensal e obrigatório do aparelho, podendo fazê-lo pelos meios eletrônicos (APP / Site) e telefônicos, disponibilizados pela Contratada, estando de pleno acordo que a falta do teste no mês da ocorrência do roubo ou furto, acarretará a negativa da Seguradora em efetuar o pagamento da indenização prevista na apólice, independentemente do cumprimento das demais obrigações contratuais. " + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- Que deverá de forma imediata, comunicar o furto ou roubo à Contratada e às autoridades competentes, além de efetuar o devido Registro da Ocorrência." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- Que poderá ser causa de negativa de indenização pela Seguradora, se na data do furto/roubo, o equipamento não tiver sido instalado; estar em atraso os pagamentos das mensalidades; não efetuar os testes mensais para aferição do funcionamento do aparelho; não realizar as vistorias determinadas em contrato; o condutor não for devidamente habilitado." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- No caso de não recuperação do veículo, o valor da indenização será paga pela QBE Seguros, conforme estipulado na apólice e certificado de venda, não tendo a ora Contratada, gerência sobre as exigências e prazos estipulados pela Seguradora." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- A indenização prevista na apólice, é de 100% do valor do bem, conforme avaliação da tabela FIPE da época da ocorrência, limitado a R$ 80.000,00, de acordo com o plano contratado." + "\r\n" + "<br />";
                        lblProduto436437438.Text = lblProduto436437438.Text + "- A Contratada informa que as condições gerais do Contrato de Prestação de Serviços firmado entre as partes, está disponível no site da Empresa, na área do cliente, sendo ainda documento público, registrado no cartório de registro de documentos da cidade de São Paulo/SP." + "\r\n" + "<br />";

                        if (fl_guincho == 1)
                        {
                            lblProduto436437438.Text = lblProduto436437438.Text + "   Os serviços de guincho, auxílio mecânico e borracheiro, possui limitação de 1 (um) acionamento mensal e 12 (doze) acionamentos anuais para veículos leves e 3 (três) " + "\r\n";
                            lblProduto436437438.Text = lblProduto436437438.Text + "acionamentos anuais para veículos pesados, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. " + "\r\n";
                            lblProduto436437438.Text = lblProduto436437438.Text + "Ultrapassados tais limites,o cliente está ciente que deverá efetuar o pagamento adicional, que será ajustado no ato da solicitação, " + "\r\n";
                            lblProduto436437438.Text = lblProduto436437438.Text + "conforme a região do acionamento." + "\r\n" + "<br>";

                        }

                        if (fl_guinchoUnico == 1)
                        {
                            lblProduto436437438.Text = lblProduto436437438.Text + "Os serviços de guincho, auxílio mecânico e borracheiro, ora incluso em caráter promocional, possui limitação de 1 (um) acionamento anual, para utilização em um raio de até 120 (cento e vinte) quilômetros do local do evento. Após a utilização, caso o cliente deseje o pacote completo, no termos já descritos no contrato de prestação de serviços, o mesmo deverá entrar em contato com a Empresa." + "\r\n" + "<br>";
                        }

                        if (fl_res == 1)
                        {
                            lblProduto436437438.Text = lblProduto436437438.Text + "A assistência residencial com serviços contratados e disponibilizados em nosso site e Comprovante de Vendas, possui limitação de 3 (três) acionamentos anuais, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente." + "\r\n" + "<br>";
                        }

                        if (fl_MartVidro == 1)
                        {
                            lblProduto436437438.Text = lblProduto436437438.Text + "A assistência de martelinho de ouro e pequenos reparos, vidros e para-brisas, possui limitação anual de uso, de acordo com o serviço contratado, conforme termo de utilização entregue neste ato e disponibilizados pela empresa que prestará o referido serviço, não estando inclusos o uso de peças e materiais para execução do serviço, que ficará a cargo do cliente, devendo ainda, arcar com o valor da franquia de utilização." + "\r\n" + "<br>";
                        }

                    }
                }
                else
                {
                    lblMensagem.Text = "CLIENTE NÃO TEM PERMISSÃO PARA IMPRESSÃO DE CERTIFICADO!!!";
                }
            }
        }

    }
}