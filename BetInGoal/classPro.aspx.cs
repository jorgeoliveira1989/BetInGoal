using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class classPro : System.Web.UI.Page
    {
        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] != null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("cliente.aspx");
            }
            else
            {
                if (ddl_filtro.SelectedItem.ToString() == "------------")
                {
                    query = "SELECT * FROM viewclassificacaopro_index";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 100")
                {
                    query = "SELECT TOP 100 * FROM viewclassificacaopro_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 50")
                {
                    query = "SELECT TOP 50 * FROM viewclassificacaopro_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 10")
                {
                    query = "SELECT TOP 10 * FROM viewclassificacaopro_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 3")
                {
                    query = "SELECT TOP 3 * FROM viewclassificacaopro_index ORDER BY total_pontos DESC";
                }
                else
                {
                    query = "SELECT * FROM viewclassificacaopro_index";
                }

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand(query, myconn);


                List<classificacao> lst_classificacaoPro = new List<classificacao>();

                myconn.Open();

                var classPro = mycomm.ExecuteReader();

                while (classPro.Read())
                {
                    classificacao pro = new classificacao();

                    pro.Classificacao = classPro.GetInt64(0);
                    pro.Username = classPro.GetString(1);
                    pro.TipoCliente = classPro.GetString(2);
                    pro.TotalPontos = classPro.GetInt32(3);


                    lst_classificacaoPro.Add(pro);
                }

                myconn.Close();

                rpt_classificacao.DataSource = lst_classificacaoPro;
                rpt_classificacao.DataBind();

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