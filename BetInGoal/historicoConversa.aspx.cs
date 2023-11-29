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
    public partial class historicoConversa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["id_suporte"]);

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "mensagem_resposta_detalhe";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@id", id);

                myconn.Open();

                SqlDataReader dr = mycomm.ExecuteReader();
                if (dr.Read())
                {
                    lbl_nome.Text = dr["nome"].ToString();
                    lbl_email.Text = dr["email"].ToString();
                    lbl_assunto.Text = dr["assunto"].ToString();
                    lt_mensagem.Text = dr["mensagem"].ToString();
                    lt_mensagem_respondida.Text = dr["mensagem_resposta"].ToString();
                }

                myconn.Close();
            }
        }
        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("mensagensrespondidas.aspx");
        }
    }
}