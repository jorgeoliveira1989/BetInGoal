using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace BetInGoal
{
    public partial class criarAdmins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
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

        protected void btn_criar_conta_Click(object sender, EventArgs e)
        {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "inserir_admin";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@nome", txt_nome.Text);
                mycomm.Parameters.AddWithValue("@email", txt_email.Text);
                mycomm.Parameters.AddWithValue("@utilizador", txt_utilizador.Text);
                mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_conf_palavra_passe.Text));

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

                    lbl_info.Text = "Conta admin Criada!!!";

                    SmtpClient servidor = new SmtpClient();
                    MailMessage email = new MailMessage();

                    email.From = new MailAddress("Jorge.Vieira.Oliveira@formandos.cinel.pt");
                    email.To.Add(new MailAddress(txt_email.Text));
                    email.Subject = "Dados de Registo da conta de Administrador do site BetinGoal!";

                    email.IsBodyHtml = true;
                    email.Body = "<b>Obrigado pelo Registo no nosso site.<br/> Aqui enviamos os seus dados: <br/><br/> utilizador: " + txt_utilizador.Text + "<br/> Palavra-passe: " + EncryptString(txt_conf_palavra_passe.Text) + ".";

                    servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                    servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);


                    string utilizador = ConfigurationManager.AppSettings["SMTP_USER"];
                    string passe = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                    servidor.Credentials = new NetworkCredential(utilizador, passe);
                    servidor.EnableSsl = true;

                    servidor.Send(email);

                }
                else
                {
                    lbl_info.Text = "Aconteceu erro e a conta não foi criada!!!";
                }
        }
    }
}