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
    public partial class fecharjogos : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request.QueryString["id_jogo"]);

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "fechar_jogo";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@id", id);

                myconn.Open();

                SqlDataReader dr = mycomm.ExecuteReader();
                if (dr.Read())
                {
                    lbl_nome_liga.Text = dr["liga"].ToString();
                    lbl_jornada.Text = dr["jornada"].ToString();
                    string dataJogoStr = dr["data_jogo"].ToString();
                    DateTime dataJogo;
                    if (DateTime.TryParse(dataJogoStr, out dataJogo))
                    {
                        lbl_data.Text = dataJogo.ToString("dd/MM/yyyy");
                    }
                    lbl_hora.Text = ((TimeSpan)dr["hora_jogo"]).ToString("hh\\:mm");
                    lbl_equipa_casa.Text = dr["equipa_casa"].ToString();
                    lbl_equipa_fora.Text = dr["equipa_fora"].ToString();
                    lbl_jogo_especial.Text = dr["jogo_estrela_jornada"].ToString();
                }

                myconn.Close();
            }
        }

        protected void btn_fechar_jogo_Click(object sender, EventArgs e)
        {
            /*
             Na tabela prognosticos, vai ver o respetivo id_jogo e vai comparar com resultadofinal_casa com o resultado da tabela jogos resultado_casa
             e também o resultado_fora.
                Aqui nesta situação vai ter opções para comparar:
                   ->Se é o resultado certo 2 pontos contas free /3 pontos contas PRO
                   ->Acertar na quantidade de golos 4 pontos free/6 pontos contas PRO
                   ->Acertar em ambos resultado certo + quantidade de golos 7 pontos FREE/ 9 pontos PRO
                   ->Acertar em ambos e jogo da jornada 10 pontos free/12 pontos conta PRO
             Depois de ver os ifs, agora ainda na tabela prognosticos guardar o valor somando o valor do
             resultado dos ifs ao valor atual no campo pontos_obtidos
             
             Por fim, na tabela pontuação, identificar a jornada atual e nos pontos individuiais ir buscar os
             pontos total_obtidos na jornada e adicionar aos pontos que já tinha. No campo pontos_jornada, guardar
             o total dos pontos obtidos na respetiva jornada.
             
              Realizado: Atualizar a tabela jogos
             */
            SqlConnection myconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm1 = new SqlCommand();

            int id = Convert.ToInt32(Request.QueryString["id_jogo"]);

            mycomm1.CommandType = CommandType.StoredProcedure;
            mycomm1.CommandText = "encerrar_jogo";

            mycomm1.Connection = myconn1;
            mycomm1.Parameters.AddWithValue("@id_jogo", id);
            mycomm1.Parameters.AddWithValue("@resultado_casa", txt_resultado_casa.Text);
            mycomm1.Parameters.AddWithValue("@resultado_fora", txt_resultado_fora.Text);

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm1.Parameters.Add(valor);

            myconn1.Open();
            mycomm1.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm1.Parameters["@retorno"].Value);
            myconn1.Close();
            if (resposta == 1)
            {
                //lbl_mensagem.Text = "Resultado Final atribuido ao jogo";

            }
            else
            {
                //lbl_mensagem.Text = "Não foi atualizado o resultado final";
            }

            //-------------------------//
            //Agora na tabela prognosticos: 

            SqlConnection myconn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            // Consulta SQL para obter os campos desejados da tabela prognosticos
            string queryPrognosticos = "SELECT id_jogo,resultadoFinal_casa,resultadoFinal_fora FROM prognosticos where id_jogo='" + id + "'";

            // Criar comando SQL com a consulta e a conexão
            SqlCommand cmdPrognosticos = new SqlCommand(queryPrognosticos, myconn2);

            // Lista para armazenar os resultados
            List<Tuple<int, int>> resultadosPrognosticos = new List<Tuple<int, int>>();


            // Abrir a conexão
            myconn2.Open();

            // Executar o comando SQL
            SqlDataReader reader = cmdPrognosticos.ExecuteReader();

            // Ler os resultados e armazenar na lista
            while (reader.Read())
            {
                int resultadoFinalCasa = Convert.ToInt32(reader["resultadoFinal_casa"]);
                int resultadoFinalFora = Convert.ToInt32(reader["resultadoFinal_fora"]);
                resultadosPrognosticos.Add(new Tuple<int, int>(resultadoFinalCasa, resultadoFinalFora));
            }

            // Certificar-se de fechar a conexão, mesmo em caso de exceção
            myconn2.Close();

            if (resultadosPrognosticos.Count > 0)
            {
                int prognosticoCasa = resultadosPrognosticos[0].Item1;
                int prognosticoFora = resultadosPrognosticos[0].Item2;
                int resultadoCasa = Convert.ToInt32(txt_resultado_casa.Text);
                int resultadoFora = Convert.ToInt32(txt_resultado_fora.Text);

                if (prognosticoCasa > prognosticoFora && resultadoCasa > resultadoFora)
                {
                    //guardar na base de dados mas antes ver a situação se
                    //for conta free ou PRO
                }
            }

        }
    }
}