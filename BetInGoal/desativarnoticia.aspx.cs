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
    public partial class desativarnoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }

            if (ddl_id.Items.Count == 1)
            {
                btn_desativar_noticia.Enabled = false;
            }
            else
            {
                btn_desativar_noticia.Enabled = true;
            }
        }

        protected void btn_desativar_noticia_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "desativar_noticia";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("id_noticia", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@titulo", lbl_titulo.Text);


            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Notícia desativada com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "A Notícia não foi desativada!!!";
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
                btn_desativar_noticia.Enabled = false;
            }
            else
            {
                btn_desativar_noticia.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                lbl_titulo.Text = "";
                btn_desativar_noticia.Enabled = false;
            }
            else
            {

                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                // Chamar a stored procedure para obter o utilizador
                string titulo = ObterNomePorID(idSelecionado); // Método para chamar a stored procedure

                // Preencher a TextBox com o utilizador
                lbl_titulo.Text = titulo;
            }
        }

        private string ObterNomePorID(int id)
        {
            string titulo = string.Empty;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            {
                using (SqlCommand command = new SqlCommand("ObterDadosNoticia", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    titulo = (string)command.ExecuteScalar();
                }
            }

            return titulo;
        }


    }
}