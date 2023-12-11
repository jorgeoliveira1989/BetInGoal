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
    public partial class enviarprog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
            else
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "ver_jogos_disponiveis";
                mycomm.Connection = myconn;

                List<jogos> lst_jogos = new List<jogos>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    int id_jogo = reader.GetInt32(0);
                    string username = (string)Session["utilizador"];

                    
                    if (!ExistePrognosticoParaJogo(id_jogo, username))
                    {
                        jogos jogo = new jogos();
                        jogo.id_jogo = id_jogo;
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

                        // Verifica se falta menos de 2 horas para o jogo começar
                        DateTime dataHoraJogo = DateTime.ParseExact(jogo.data_jogo + " " + jogo.hora_jogo, "dd/MM/yyyy HH:mm", null);
                        TimeSpan diferenca = dataHoraJogo - DateTime.Now;

                        // Se a diferença for menor que 2 horas, não adicionar à lista
                        if (diferenca.TotalHours >= 2)
                        {
                            lst_jogos.Add(jogo);
                        }
                     
                    }
                }

                myconn.Close();

                rptprogdisponiveis.DataSource = lst_jogos;
                rptprogdisponiveis.DataBind();
            }
        }

        private bool ExistePrognosticoParaJogo(int idJogo, string username)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 1 FROM prognosticos WHERE id_jogo = @id_jogo AND username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_jogo", idJogo);
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}