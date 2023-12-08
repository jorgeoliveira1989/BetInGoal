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
    public partial class enviaprogjogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["id_jogo"]);

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "fechar_jogo";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@id", id);

                myconn.Open();

                SqlDataReader dr = mycomm.ExecuteReader();
                if (dr.Read())
                {
                    lbl_nome_liga.Text = dr["liga"].ToString();
                    lbl_jornada.Text = dr["jornada"].ToString();
                    string dataJogoStr = dr["data_jogo"].ToString();
                    DateTime dataJogo;
                    if (DateTime.TryParse(dataJogoStr, out dataJogo))
                    {
                        lbl_data.Text = dataJogo.ToString("dd/MM/yyyy");
                    }
                    lbl_hora.Text = ((TimeSpan)dr["hora_jogo"]).ToString("hh\\:mm");
                    lbl_equipa_casa.Text = dr["equipa_casa"].ToString();
                    lbl_equipa_fora.Text = dr["equipa_fora"].ToString();
                    string valorOriginal = dr["jogo_estrela_jornada"].ToString();
                    string resultado;

                    if (valorOriginal.ToLower() == "true")
                    {
                        resultado = "Sim";
                    }
                    else
                    {
                        resultado = "Não";
                    }
                    
                    lbl_jogo_especial.Text = resultado;


                }

                myconn.Close();
            }
        }
        protected void btn_enviar_prog_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            myconn.Open();

            // Agora, buscar o id_cliente na tabela clientes usando o usernamePrognostico
            string queryCliente = "SELECT id_cliente FROM clientes WHERE username = @username";
            SqlCommand cmdCliente = new SqlCommand(queryCliente, myconn);

            // Adicionar parâmetro para o username obtido anteriormente
            cmdCliente.Parameters.AddWithValue("@username", (string)Session["utilizador"]);

            // Executar o comando SQL para obter o id_cliente
            int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

            myconn.Close();

            int id = Convert.ToInt32(Request.QueryString["id_jogo"]);
            string username = (string)Session["utilizador"];

            SqlCommand mycomm = new SqlCommand();

            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "enviar_prognostico";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@id_cliente",idCliente);
            mycomm.Parameters.AddWithValue("@id", id);
            mycomm.Parameters.AddWithValue("@username", username);
            mycomm.Parameters.AddWithValue("@resultado_casa", txt_resultado_casa.Text);
            mycomm.Parameters.AddWithValue("@resultado_fora", txt_resultado_fora.Text);

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
                lbl_mensagem.Text = "Prognóstico enviado!!";
            }
            else
            {
                lbl_mensagem.Text = "Prognóstico não foi enviado!!!";
            }
        }

        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("enviarprog.aspx");
        }
    }
}