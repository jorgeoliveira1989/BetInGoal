using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class criarliga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_criar_liga_Click(object sender, EventArgs e)
        {
            string utilizador = (string)Session["utilizador"];

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            string queryCliente = "SELECT id_cliente FROM clientes WHERE username = @username";
            SqlCommand cmdCliente = new SqlCommand(queryCliente, myconn);

            cmdCliente.Parameters.AddWithValue("@username", utilizador);

            myconn.Open();

            int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());
            myconn.Close();

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "criar_liga_cliente";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
            mycomm.Parameters.AddWithValue("@nome_liga", txt_nome_liga.Text);
            mycomm.Parameters.AddWithValue("@nome_cliente", utilizador);

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
                lbl_mensagem.Text = "A liga foi criada!";
                btn_criar_liga.Enabled = false;
            }
            else
            {
                lbl_mensagem.Text = "A liga não foi criada!";
            }
        }
    }
}