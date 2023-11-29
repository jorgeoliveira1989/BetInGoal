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
    public partial class aceitarupgrades : System.Web.UI.Page
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
                btn_alterar_tipo_cliente.Enabled = false;
            }
            else
            {
                btn_alterar_tipo_cliente.Enabled = true;
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
                btn_alterar_tipo_cliente.Enabled = false;
            }
            else
            {
                btn_alterar_tipo_cliente.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                lbl_nome.Text = "";
                lbl_altera_cliente.Text = "";
                lbl_tipoConta.Text = "";
                btn_alterar_tipo_cliente.Enabled = false;
            }
            else
            {
                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                // Chamar a stored procedure para obter o tipo de conta e o nome
                Tuple<string, string> dados = ObterDadosPorID(idSelecionado);

                if (dados != null)
                {
                    string tipoConta = dados.Item1;
                    string nome = dados.Item2;

                    lbl_tipoConta.Text = tipoConta;

                    if (lbl_tipoConta.Text == "FREE")
                    {
                        lbl_altera_cliente.Text = "PRO";
                        lbl_nome.Text = nome;
                    }
                    else
                    {
                        lbl_altera_cliente.Text = "FREE";
                        lbl_nome.Text = nome;
                    }

                    // Agora você também tem o nome disponível (variável 'nome')
                }
            }
        }
        private Tuple<string, string> ObterDadosPorID(int id)
        {
            Tuple<string, string> dados = null;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);
            {
                using (SqlCommand command = new SqlCommand("dadosTipoConta", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tipoConta = reader.GetString(0);
                            string nome = reader.GetString(1);

                            dados = Tuple.Create(tipoConta, nome);
                        }
                    }
                }
            }

            return dados;
        }

        protected void btn_alterar_tipo_cliente_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "alterar_upgrade";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("@id_cliente", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@tipo_cliente", lbl_altera_cliente.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Subscrição Terminada!!!";
            }
            else
            {
                lbl_mensagem.Text = "A subscrição não foi alterada!!!";
            }
        }
    }
   
}