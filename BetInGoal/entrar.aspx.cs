﻿using System;
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

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            string clienteEmail = clienteEmailParam.Value.ToString();
            string tipocliente = tipoclienteParam.Value.ToString();

            myconn.Close();

            if (resposta == 1)
            {
                Session["utilizador"] = txt_user.Text;
                Session["clienteEmail"] = clienteEmail;
                Session["tipocliente"] = tipocliente;
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