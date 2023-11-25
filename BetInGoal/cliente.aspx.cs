using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("index.aspx");
            }
            else
            {
                
                lbl_utilizador.Text = (string)Session["utilizador"];
                lbl_email.Text = (string)Session["clienteEmail"];
                lbl_tipo_conta.Text = (string)Session["tipocliente"];
                lbl_nome_completo.Text = (string)Session["nome"];
                DateTime dataNascimento = (DateTime)Session["datanascimento"];
                lbl_data_nascimento.Text = dataNascimento.ToShortDateString();

                // Verificar se a Session["totalPontos"] existe antes de acessá-la
                if (Session["totalPontos"] != null)
                {
                   lbl_total_pontos.Text = Session["totalPontos"].ToString();
                }
                else
                {
                    // Se a Session["totalPontos"] for nula, definir o texto como "0"
                    lbl_total_pontos.Text = "0";
                }
                
                //Verificar se a Session["totalprognosticos"] existe antes de acessá-la
                if (Session["totalprognosticos"] != null)
                {
                    lbl_total_prognosticos.Text = Session["totalprognosticos"].ToString();
                }
                else
                {
                    // Se a Session["totalprognosticos"] for nula, definir o texto como "0"
                    lbl_total_prognosticos.Text = "0";
                }

                //Verificar se a Session["totalprognosticos"] existe antes de acessá-la
                if (Session["classificacaoGeral"] != null)
                {
                    lbl_res_class.Text = Session["classificacaoGeral"].ToString() + "º Lugar";
                }
                else
                {
                    // Se a Session["totalprognosticos"] for nula, definir o texto como "0"
                    lbl_res_class.Text = "0º Lugar";
                }

                if (Session["classificacaoGeralFREE"] != null && int.TryParse(Session["classificacaoGeralFREE"].ToString(), out int classificacao))
                {
                    // A conversão foi bem-sucedida, e você pode usar o valor de classificacao.
                    lbl_class.Text = classificacao.ToString() + "º Lugar";
                }
                else
                {
                    // Lidar com a situação em que a sessão não tem um valor adequado.
                    lbl_class.Text = "0º Lugar"; // ou outro valor padrão, mensagem de erro, etc.
                }

                if (Session["classificacaoGeralPRO"] != null && int.TryParse(Session["classificacaoGeralPRO"].ToString(), out int classificacaoPRO))
                {
                    // A conversão foi bem-sucedida, e você pode usar o valor de classificacao.
                    lbl_class.Text = classificacaoPRO.ToString() + "º Lugar";
                }
                else
                {
                    // Lidar com a situação em que a sessão não tem um valor adequado.
                    lbl_class.Text = "0º Lugar"; // ou outro valor padrão, mensagem de erro, etc.
                }

                string conta = (string)Session["tipocliente"];

                if (conta == "PRO")
                {
                    DateTime pagamento = (DateTime)Session["datapagamento"];
                    lbl_data_compra_subscricao.Text = pagamento.ToShortDateString();

                    DateTime dataCompra = (DateTime)Session["datapagamento"];
                    int duracaoSubscricaoDias = 365;

                    DateTime dataTerminoSubscricao = dataCompra.AddDays(duracaoSubscricaoDias);

                    DateTime dataAtual = DateTime.Now;

                    int diasRestantes = (dataTerminoSubscricao - dataAtual).Days;

                    lbl_total_dias_subscricao.Text = diasRestantes.ToString() + " Dias";

                    if (diasRestantes >= 244)
                    {
                        lbl_total_dias_subscricao.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (diasRestantes < 244 && diasRestantes >= 213)
                    {
                        lbl_total_dias_subscricao.ForeColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        lbl_total_dias_subscricao.ForeColor = System.Drawing.Color.Red;
                    }


                }

                if (Session["tipocliente"] != null)
                {
                    string tipocliente = Session["tipocliente"].ToString();

                    // Atribuir a cor com base no tipo_conta
                    if (tipocliente.Equals("Free", StringComparison.OrdinalIgnoreCase))
                    {
                        lbl_tipo_conta.ForeColor = System.Drawing.Color.Green;
                        lbl_classificacao.Text = "Classificação FREE:";
                        
                    }
                    else if (tipocliente.Equals("PRO", StringComparison.OrdinalIgnoreCase))
                    {
                        lbl_tipo_conta.ForeColor = System.Drawing.Color.Red;
                        lbl_classificacao.Text = "Classificação PRO:";
                    }

                    // Atualizar o texto do Label com o valor do tipo_conta
                    lbl_tipo_conta.Text = tipocliente;

                    if (tipocliente == "FREE")
                    {

                        lbl_enviar_prog_pro.Visible = false;
                        lbl_ver_class_pro.Visible = false;
                        lbl_criar_liga.Visible = false;
                        lbl_data_subscricao.Visible = false;
                        lbl_total_Subscricao.Visible = false;

                    }
                    else if (tipocliente == "PRO")
                    {
                        lbl_comprar_subscricao.Visible = false;
                        lbl_enviar_prog_free.Visible = false;
                        lbl_ver_class_free.Visible = false;
                    }
                }
            }
        }

        protected void btn_sair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}