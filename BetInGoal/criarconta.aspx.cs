using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace BetInGoal
{
    public partial class criarconta1 : System.Web.UI.Page
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

        protected void btn_criar_cliente_Click(object sender, EventArgs e)
        {

            DateTime dataNascimento = Convert.ToDateTime(txt_datanascimento.Text);
            DateTime dataAtual = DateTime.Now;

            int anos = dataAtual.Year - dataNascimento.Year;

            if (anos < 18)
            {
                lbl_info.Text = "Menor de Idade <br/>Não pode participar...";
            }
            else
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "inserir_cliente_ativacao";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@nome", txt_nome.Text);
                mycomm.Parameters.AddWithValue("@email", txt_email.Text);
                mycomm.Parameters.AddWithValue("@utilizador", txt_utilizador.Text);
                mycomm.Parameters.AddWithValue("@datanascimento", txt_datanascimento.Text);
                mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_confpasse.Text));

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
                    lbl_info.Text = "Verifique o Seu email para ativar a sua conta!";

                    SmtpClient servidor = new SmtpClient();
                    MailMessage email = new MailMessage();

                    email.From = new MailAddress("Jorge.Vieira.Oliveira@formandos.cinel.pt");
                    email.To.Add(new MailAddress(txt_email.Text));
                    email.Subject = "Ativação de Conta do Utilizador!";

                    email.IsBodyHtml = true;

                    email.Body = "<b>Obrigado pelo Registo no nosso site.<br/> Para ativar a sua conta carregue <a href='https://localhost:44398/ativacao_cliente.aspx?utilizador=" + EncryptString(txt_utilizador.Text) + "'>aqui";

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
                    lbl_info.Text = "Utilizador já existe!!!";
                }
            }
        }

        private void limparEcra()
        {
            txt_nome.Text = "";
            txt_email.Text = "";
            txt_confpasse.Text = "";
            txt_utilizador.Text = "";
            txt_datanascimento.Text = "";
            txt_passe.Text = "";
        }


        public static string EncryptString(string Message)
        {
            string Passphrase = "cinel";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();



            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below



            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));



            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();



            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;



            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);



            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }



            // Step 6. Return the encrypted string as a base64 encoded string



            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KLKLK");
            enc = enc.Replace("/", "JLJLJL");
            enc = enc.Replace("\\", "IOIOIO");
            return enc;
        }
    }
}