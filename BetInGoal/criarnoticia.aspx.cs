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

namespace BetInGoal
{
    public partial class criarnoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
        }

        protected void btn_criar_noticia_Click(object sender, EventArgs e)
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
            mycomm.CommandText = "criar_noticia";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@id_admin", idAdmin);
            mycomm.Parameters.AddWithValue("@titulo", txt_titulo.Text);
            mycomm.Parameters.AddWithValue("@conteudo", txt_conteudo.Text);

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
                lbl_mensagem.Text = "A notícia foi criada!";
            }
            else
            {
                lbl_mensagem.Text = "A notícia não foi criada!";
            }
        }
    }
}