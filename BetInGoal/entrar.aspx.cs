using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data.Common;

namespace BetInGoal
{
    public partial class entrar : System.Web.UI.Page
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

        protected void btn_entra_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "autenticacao_cliente";

            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("@user", txt_user.Text);
            mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_passe.Text));
            

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);

            SqlParameter clienteEmailParam = new SqlParameter("@clienteEmail", SqlDbType.VarChar, 50);
            clienteEmailParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(clienteEmailParam);

            SqlParameter tipoclienteParam = new SqlParameter("@tipocliente", SqlDbType.VarChar, 50);
            tipoclienteParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(tipoclienteParam);

            SqlParameter nomeclienteParam = new SqlParameter("@nome", SqlDbType.VarChar, 50);
            nomeclienteParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(nomeclienteParam);

            SqlParameter dataNascimentoParam = new SqlParameter("@datanascimento", SqlDbType.Date);
            dataNascimentoParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(dataNascimentoParam);

            SqlParameter dataPagamentoParam = new SqlParameter("@datapagamento", SqlDbType.Date);
            dataPagamentoParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(dataPagamentoParam);

            SqlParameter totalPontosParam = new SqlParameter("@totalpontos", SqlDbType.Int);
            totalPontosParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(totalPontosParam);

            SqlParameter totalPrognosticosParam = new SqlParameter("@totalprognosticos", SqlDbType.Int);
            totalPrognosticosParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(totalPrognosticosParam);

            SqlParameter classificacaogeralParam = new SqlParameter("@classificacaoGeral", SqlDbType.Int);
            classificacaogeralParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(classificacaogeralParam);

            SqlParameter classificacaogeralfreeParam = new SqlParameter("@classificacaoGeralFREE", SqlDbType.Int);
            classificacaogeralfreeParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(classificacaogeralfreeParam);

            SqlParameter classificacaogeralproParam = new SqlParameter("@classificacaoGeralPRO", SqlDbType.Int);
            classificacaogeralproParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(classificacaogeralproParam);


            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            string clienteEmail = clienteEmailParam.Value.ToString();
            string tipocliente = tipoclienteParam.Value.ToString();
            string nome = nomeclienteParam.Value.ToString() ;
            DateTime dataNascimento = Convert.ToDateTime(dataNascimentoParam.Value);
            int totalPontos = Convert.IsDBNull(totalPontosParam.Value) ? 0 : Convert.ToInt32(totalPontosParam.Value);
            int totalprognosticos = Convert.IsDBNull(totalPrognosticosParam.Value) ? 0 : Convert.ToInt32(totalPrognosticosParam.Value);
            int classificacaogeral = Convert.IsDBNull(classificacaogeralParam.Value) ? 0 : Convert.ToInt32(classificacaogeralParam.Value);
            int classificacaogeralfree = Convert.IsDBNull(classificacaogeralfreeParam.Value) ? 0 : Convert.ToInt32(classificacaogeralfreeParam.Value);
            int classificacaogeralpro = Convert.IsDBNull(classificacaogeralproParam.Value) ? 0 : Convert.ToInt32(classificacaogeralproParam.Value);

            // Verificar se é PRO e a data de pagamento está definida
            if (tipocliente == "PRO" && mycomm.Parameters["@datapagamento"].Value != DBNull.Value)
            {
                DateTime dataPagamento = Convert.ToDateTime(mycomm.Parameters["@datapagamento"].Value);
                Session["datapagamento"] = dataPagamento;
            }

            
            

            myconn.Close();

            if (resposta == 1)
            {
                Session["utilizador"] = txt_user.Text;
                Session["clienteEmail"] = clienteEmail;
                Session["tipocliente"] = tipocliente;
                Session["nome"] = nome;
                Session["datanascimento"] = dataNascimento;
                Session["totalpontos"] = totalPontos;
                Session["totalprognosticos"]= totalprognosticos;
                Session["classificacaoGeral"] = classificacaogeral;
                Session["classificacaoGeralFREE"] = classificacaogeralfree;
                Session["classificacaoGeralPRO"] = classificacaogeralpro;

                Response.Redirect("cliente.aspx");

            }
            else if (resposta == 0)
            {
                lbl_info.Text = "Utilizador e/ou Password não existem!!!";
            }
            else if (resposta == 2)
            {
                lbl_info.Text = "Conta está inativa!!!";
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
    }
}