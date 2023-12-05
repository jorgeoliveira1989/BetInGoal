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
    public partial class addjogo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
        }

        protected void btn_criar_jornada_Click(object sender, EventArgs e)
        {
            // Configurar a string de conexão. Ajuste conforme necessário.
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            string utilizador = (string)Session["utilizador"];

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
            mycomm.CommandText = "criar_jornada";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@liga", txt_nome_liga.Text);
            mycomm.Parameters.AddWithValue("@jornada", txt_jornada.Text);
            mycomm.Parameters.AddWithValue("@data_jogo", txt_data.Text);
            mycomm.Parameters.AddWithValue("@hora_jogo", txt_hora.Text);
            mycomm.Parameters.AddWithValue("@equipa_casa", txt_equipa_casa.Text);
            mycomm.Parameters.AddWithValue("@resultado_equipa_casa", txt_resultado_casa.Text);
            mycomm.Parameters.AddWithValue("@equipa_fora", txt_equipa_fora.Text);
            mycomm.Parameters.AddWithValue("@resultado_equipa_fora", txt_resultado_fora.Text);
            mycomm.Parameters.AddWithValue("@jogo_especial", ckb_jogoEspecial.Checked);
            mycomm.Parameters.AddWithValue("@id_admin", idAdmin);



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
                lbl_mensagem.Text = "O Jogo foi criado!";

            }
 
            limpardados();
        }

        private void limpardados()
        {
            txt_data.Text = "dd/mm/aaaa";
            txt_hora.Text = "--:--";
            txt_equipa_casa.Text = "";
            txt_equipa_fora.Text = "";
            txt_resultado_casa.Text = "";
            txt_resultado_fora.Text = "";
            ckb_jogoEspecial.Checked = false;

        }
    }
}