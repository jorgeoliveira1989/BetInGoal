using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace BetInGoal
{
    public partial class tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["id_suporte"]);

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "ticket_detalhe";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@id", id);

                myconn.Open();

                SqlDataReader dr = mycomm.ExecuteReader();
                if (dr.Read())
                {
                  lbl_nome.Text = dr["nome"].ToString();
                  lbl_email.Text = dr["email"].ToString();
                  lbl_assunto.Text = dr["assunto"].ToString();
                  lt_mensagem.Text = dr["mensagem"].ToString();
                }

                myconn.Close();
            }
        }

        protected void btn_responder_ticket_Click(object sender, EventArgs e)
        {
            pnl_resposta.Visible = true;
            btn_responder_ticket.Visible = false;
        }

        protected void btn_responder_Click(object sender, EventArgs e)
        {
            string utilizador = (string)Session["utilizador"];

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            // Usar parâmetros para evitar problemas de segurança e erros de sintaxe
            string queryAdmin = "SELECT id_admin FROM admins WHERE username = @username";
            SqlCommand cmdAdmin = new SqlCommand(queryAdmin, myconn);

            // Adicionar parâmetro
            cmdAdmin.Parameters.AddWithValue("@username", utilizador);

            myconn.Open();
            // Executar o comando SQL para obter o resultado
            int idAdmin = Convert.ToInt32(cmdAdmin.ExecuteScalar());
            myconn.Close();


            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "responder_cliente";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@id_suporte", Request.QueryString["id_suporte"]);
            mycomm.Parameters.AddWithValue("@id_admin", idAdmin);
            mycomm.Parameters.AddWithValue("@resposta", txt_resposta.Text);
            

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_info.Text = "A mensagem foi respondida!";

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();

                email.From = new MailAddress("Jorge.Vieira.Oliveira@formandos.cinel.pt");
                email.To.Add(new MailAddress(lbl_email.Text));
                email.Subject = "Resposta ao Pedido de Suporte";

                email.IsBodyHtml = true;

                email.Body = "Em resposta ao seu email: " + lt_mensagem.Text + "<br/><br/> Enviamos a nossa resposta: " +txt_resposta.Text+ "<br/> Desejamos ter respondido a sua pergunta... Caso isso não aconteceu envie novo pedido de suporte.<br/> Equipa BetinGoal";

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);


                string utilizador1 = ConfigurationManager.AppSettings["SMTP_USER"];
                string passe = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(utilizador1, passe);
                servidor.EnableSsl = true;

                servidor.Send(email);

            }
            else
            {
                lbl_info.Text = "Erro! Não enviou resposta!";
            }
        }
    }
}