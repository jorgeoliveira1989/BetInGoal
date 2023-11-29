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
    public partial class editarnoticia : System.Web.UI.Page
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
                btn_editar_noticia.Enabled = false;
            }
            else
            {
                btn_editar_noticia.Enabled = true;
            }
        }

        protected void btn_editar_noticia_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "alterar_noticia";

            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("id_noticia", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@titulo", txt_titulo.Text);
            mycomm.Parameters.AddWithValue("@noticia", txt_noticia.Text);
            
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
                lbl_mensagem.Text = "Notícia alterada com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "A Notícia não foi alterada!!!";
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
               btn_editar_noticia.Enabled = false;
            }
            else
            {
                btn_editar_noticia.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                txt_titulo.Text = "";
                txt_noticia.Text = "";
                btn_editar_noticia.Enabled = false;
                
            }
            else
            {

                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                noticia info = ObterDadosMensagemPorID(idSelecionado);

                // Preencher os labels com os dados da mensagem
                txt_noticia.Text = info.Conteudo;
                txt_titulo.Text = info.Titulo; 
            }
        }

        private noticia ObterDadosMensagemPorID(int id)
        {
            noticia info = new noticia();

            using (SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ObterDadosNoticia", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            info.Conteudo = reader["conteudo"].ToString();
                            info.Titulo = reader["titulo"].ToString();
                            
                        }
                    }
                }
            }

            return info;
        }
    }
}