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
    public partial class verclassfree : System.Web.UI.Page
    {
        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
            else
            {
                if (ddl_filtro.SelectedItem.ToString() == "------------")
                {
                    query = "SELECT * FROM viewclassificacaofree_index";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 100")
                {
                    query = "SELECT TOP 100 * FROM viewclassificacaofree_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 50")
                {
                    query = "SELECT TOP 50 * FROM viewclassificacaofree_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 10")
                {
                    query = "SELECT TOP 10 * FROM viewclassificacaofree_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 3")
                {
                    query = "SELECT TOP 3 * FROM viewclassificacaofree_index ORDER BY total_pontos DESC";
                }
                else
                {
                    query = "SELECT * FROM viewclassificacaofree_index";
                }

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand(query, myconn);


                List<classificacao> lst_classificacaoFree = new List<classificacao>();

                myconn.Open();

                var classFree = mycomm.ExecuteReader();

                while (classFree.Read())
                {
                    classificacao free = new classificacao();

                    free.Classificacao = classFree.GetInt64(0);
                    free.Username = classFree.GetString(1);
                    free.TipoCliente = classFree.GetString(2);
                    free.TotalPontos = classFree.GetInt32(3);


                    lst_classificacaoFree.Add(free);
                }

                myconn.Close();

                rpt_classificacao.DataSource = lst_classificacaoFree;
                rpt_classificacao.DataBind();

            }
        }
    }
}