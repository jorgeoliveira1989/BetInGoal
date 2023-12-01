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
    public partial class entrarliga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("index.aspx");
            }
            else
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "ver_ligas";
                mycomm.Connection = myconn;

                List<ver_liga> lst_ligas = new List<ver_liga>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    ver_liga dadosLiga = new ver_liga();

                    dadosLiga.IdLiga = reader.GetInt32(0);
                    dadosLiga.NomeLiga = reader.GetString(1);
                    dadosLiga.NomeCliente = reader.GetString(3);

                    lst_ligas.Add(dadosLiga);
                }
                myconn.Close();

               rptEntrarLiga.DataSource = lst_ligas;
                rptEntrarLiga.DataBind();
            }
        }
    }
}