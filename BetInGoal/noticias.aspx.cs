using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class noticias1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] != null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("cliente.aspx");
            }
            else
            {
                string query = "SELECT noticias.titulo, noticias.conteudo,admins.username,noticias.ativo FROM noticias INNER JOIN admins ON noticias.id_admin = admins.id_admin where noticias.ativo='True'";
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand(query, myconn);


                List<noticia> lst_noticia = new List<noticia>();

                myconn.Open();

                var not = mycomm.ExecuteReader();

                while (not.Read())
                {
                    noticia ntc = new noticia();

                    ntc.Titulo = not.GetString(0);
                    ntc.Conteudo = not.GetString(1);
                    ntc.Nomeadmin = not.GetString(2);

                    lst_noticia.Add(ntc);
                }

                myconn.Close();

                rpt_noticias.DataSource = lst_noticia;
                rpt_noticias.DataBind();

            }
        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("entrar.aspx");
        }

        protected void btn_criar_conta_Click(object sender, EventArgs e)
        {
            Response.Redirect("criarconta.aspx");
        }
    }
}