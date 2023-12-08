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
    public partial class classificacao1 : System.Web.UI.Page
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
                    query = "SELECT * FROM viewclassificacaogeral_index";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 100")
                {
                    query = "SELECT TOP 100 * FROM viewclassificacaogeral_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 50")
                {
                    query = "SELECT TOP 50 * FROM viewclassificacaogeral_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 10")
                {
                    query = "SELECT TOP 10 * FROM viewclassificacaogeral_index ORDER BY total_pontos DESC";
                }
                else if (ddl_filtro.SelectedItem.ToString() == "TOP 3")
                {
                    query = "SELECT TOP 3 * FROM viewclassificacaogeral_index ORDER BY total_pontos DESC";
                }
                else
                {
                    query = "SELECT * FROM viewclassificacaogeral_index";
                }


                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand(query, myconn);


                List<classificacao> lst_classificacaoGeral = new List<classificacao>();

                myconn.Open();

                var classGeral = mycomm.ExecuteReader();

                while (classGeral.Read())
                {
                    classificacao geral = new classificacao();

                    geral.Classificacao = classGeral.GetInt64(0);
                    geral.Username = classGeral.GetString(1);
                    geral.TipoCliente = classGeral.GetString(2);
                    geral.TotalPontos = classGeral.GetInt32(3);


                    lst_classificacaoGeral.Add(geral);
                }

                myconn.Close();

                rpt_classificacao.DataSource = lst_classificacaoGeral;
                rpt_classificacao.DataBind();

            }
        }
    }
}