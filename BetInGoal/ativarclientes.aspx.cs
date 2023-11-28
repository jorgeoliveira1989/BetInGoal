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
    public partial class ativarclientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }

            if(ddl_id.Items.Count == 1)
            {
                btn_ativar_cliente.Enabled = false;
            }
            else
            {
                btn_ativar_cliente.Enabled = true;
            }
        }

        protected void btn_ativar_cliente_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "ativar_cliente";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("@id_cliente", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@username", lbl_cliente.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Cliente ativado com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Cliente não foi ativado!!!";
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
                btn_ativar_cliente.Enabled = false;
            }
            else
            {
                btn_ativar_cliente.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                lbl_cliente.Text = "";
                btn_ativar_cliente.Enabled = false;
            }
            else
            {

                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                // Chamar a stored procedure para obter o utilizador
                string utilizador = ObterNomePorID(idSelecionado); // Método para chamar a stored procedure

                // Preencher a TextBox com o utilizador
                lbl_cliente.Text = utilizador;
            }
        }
        private string ObterNomePorID(int id)
        {
            string utilizador = string.Empty;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);
            {
                using (SqlCommand command = new SqlCommand("ObterDadosCliente", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    utilizador = (string)command.ExecuteScalar();
                }
            }

            return utilizador;
        }
    }
}