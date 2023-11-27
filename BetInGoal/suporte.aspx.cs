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
    public partial class suporte1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] != null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("cliente.aspx");
            }
        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("entrar.aspx");
        }

        protected void btn_criar_conta_Click(object sender, EventArgs e)
        {
            Response.Redirect("criarconta.aspx");
        }

        protected void btn_submeter_Click(object sender, EventArgs e)
        {

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "criar_ticket";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@nome", txt_nome.Text);
            mycomm.Parameters.AddWithValue("@email", txt_email.Text);
            mycomm.Parameters.AddWithValue("@assunto", ddl_assunto.Text);
            mycomm.Parameters.AddWithValue("@mensagem", txt_mensagem.Text);

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
                lbl_info.Text = "Mensagem enviada para o Suporte!";

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();

                email.From = new MailAddress("Jorge.Vieira.Oliveira@formandos.cinel.pt");
                email.To.Add(new MailAddress(txt_email.Text));
                email.Subject = "Mensagem enviada para o suporte";

                email.IsBodyHtml = true;

                email.Body = "<b>Obrigado pela mensagem que enviou para o Suporte.<br/> Em breve vamos responder...<br/><br/><br/>Situação: " + ddl_assunto.Text+"<br/>Mensagem enviada: "+txt_mensagem.Text;

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);


                string utilizador = ConfigurationManager.AppSettings["SMTP_USER"];
                string passe = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(utilizador, passe);
                servidor.EnableSsl = true;

                servidor.Send(email);

                limparEcra();
            }
            else
            {
                lbl_info.Text = "Aconteceu um erro e a mensagem não foi enviada!";
            }
        }

        private void limparEcra()
        {
            txt_nome.Text = "";
            txt_mensagem.Text = "";
            txt_email.Text = "";
            ddl_assunto.Text = "-------------";
        }
    }
}