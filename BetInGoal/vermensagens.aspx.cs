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
    public partial class vermensagens : System.Web.UI.Page
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
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "ver_suporte";
                mycomm.Connection = myconn;

                List<suporte> lst_suporte = new List<suporte>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    suporte ticket = new suporte();
                    ticket.id_suporte = reader.GetInt32(0);
                    ticket.nome = reader.GetString(1);
                    ticket.email = reader.GetString(2);
                    ticket.assunto = reader.GetString(3);
                    ticket.mensagem = reader.GetString(4);

                    lst_suporte.Add(ticket);
                }

                myconn.Close();

                rptvermensagens.DataSource = lst_suporte;
                rptvermensagens.DataBind();
            }
        }
    }
}