using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BetInGoal
{
    public partial class visualizarjogospassados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para administrador.aspx
                Response.Redirect("administrador.aspx");
            }
            else
            {
                    SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                    SqlCommand mycomm = new SqlCommand();

                    mycomm.CommandType = CommandType.StoredProcedure;
                    mycomm.CommandText = "ver_jogos_passados";
                    mycomm.Connection = myconn;

                    List<jogos> lst_jogos = new List<jogos>();

                    myconn.Open();

                    var reader = mycomm.ExecuteReader();

                    while (reader.Read())
                    {
                        jogos jogo = new jogos();
                        jogo.id_jogo = reader.GetInt32(0);
                        jogo.liga = reader.GetString(1);
                        jogo.jornada = reader.GetInt32(2);
                        jogo.data_jogo = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                        jogo.hora_jogo = reader.GetTimeSpan(4).ToString("hh\\:mm");
                        jogo.equipa_casa = reader.GetString(5);
                        jogo.resultado_casa = reader.GetInt32(6);
                        jogo.resultado_fora = reader.GetInt32(7);
                        jogo.equipa_fora = reader.GetString(8);
                        jogo.jogo_estrela_jornada = reader.GetBoolean(9);
                        bool valorOriginal = reader.GetBoolean(9);
                        string resultado = valorOriginal ? "Sim" : "Não";

                    lst_jogos.Add(jogo);
                    }

                    myconn.Close();

                    rptjogospassados.DataSource = lst_jogos;
                    rptjogospassados.DataBind();
            }
            
        }
    }
}