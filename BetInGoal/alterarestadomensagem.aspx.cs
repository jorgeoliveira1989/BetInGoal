using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace BetInGoal
{
    public partial class alterarestadomensagem : System.Web.UI.Page
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
                btn_desativar_mensagem.Enabled = false;
            }
            else
            {
                btn_desativar_mensagem.Enabled = true;
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
                btn_desativar_mensagem.Enabled = false;
            }
            else
            {
                btn_desativar_mensagem.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                lbl_nome.Text = "";
                lbl_email.Text = "";
                lbl_mensagem.Text = "";
                lbl_situacao.Text = "";
                lt_mensagem.Text = "";
                btn_desativar_mensagem.Enabled = false;
            }
            else
            {

                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                // Chamar a stored procedure para obter os dados da mensagem
               suporte mensagem = ObterDadosMensagemPorID(idSelecionado);

                // Preencher os labels com os dados da mensagem
                lbl_nome.Text = mensagem.nome;
                lbl_email.Text = mensagem.email;
                lbl_situacao.Text = mensagem.assunto;
                lt_mensagem.Text = mensagem.mensagem;
            }
        }

        private suporte ObterDadosMensagemPorID(int id)
        {
            suporte mensagem = new suporte();

            using (SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ObterDadosMensagem", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mensagem.nome = reader["nome"].ToString();
                            mensagem.email = reader["email"].ToString();
                            mensagem.assunto = reader["assunto"].ToString();
                            mensagem.mensagem = reader["mensagem"].ToString();
                        }
                    }
                }
            }

            return mensagem;
        }

        protected void btn_desativar_mensagem_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "desativar_mensagem";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("id_suporte", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@nome", lbl_nome.Text);
            mycomm.Parameters.AddWithValue("@email", lbl_email.Text); 
            mycomm.Parameters.AddWithValue("@situacao", lbl_situacao.Text);
            mycomm.Parameters.AddWithValue("@mensagem", lt_mensagem.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Mensagem desativada com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Mensagem não foi desativada!!!";
            }
        }
    }
}