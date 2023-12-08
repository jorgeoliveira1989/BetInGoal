using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class comprarsubscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("index.aspx");
            }

        }

        protected void btn_comprar_Click(object sender, EventArgs e)
        {

            string username = (string)Session["utilizador"];

            DateTime dataAtual = DateTime.Now;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            myconn.Open();

            // Obter o ID do cliente
            string queryCliente = "SELECT id_cliente FROM clientes WHERE username = @username";
            SqlCommand cmdCliente = new SqlCommand(queryCliente, myconn);
            cmdCliente.Parameters.AddWithValue("@username", username);
            int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());
            myconn.Close();

            // Chamar a stored procedure comprar_subscricao
            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "comprar_subscricao";
            mycomm.Connection = myconn;

            // Adicionar parâmetros
            mycomm.Parameters.AddWithValue("@id_cliente", idCliente);

            // Use SqlDbType.Date para evitar problemas de conversão
            mycomm.Parameters.Add("@data_pagamento", SqlDbType.Date).Value = dataAtual;

            // Parâmetro de saída para capturar o retorno da stored procedure
            SqlParameter retorno = new SqlParameter();
            retorno.ParameterName = "@retorno";
            retorno.Direction = ParameterDirection.Output;
            retorno.SqlDbType = SqlDbType.Int;
            mycomm.Parameters.Add(retorno);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            // Capturar o valor de retorno
            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();

            // Verificar o valor de retorno
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Subscrição Adquirida!!";
            }
            else
            {
                lbl_mensagem.Text = "Ocorreu um erro ao adquirir a subscrição!!";
            }

        }
    }
}