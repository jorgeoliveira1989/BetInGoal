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
        int resultadocertoFree = 0;
        int resultadocertoPro = 0;
        int quantidadeGolosFree = 0;
        int quantidadeGolosPro = 0;
        int acertaambosFree = 0;
        int acertaambosPro = 0;
        int acertaambosespecialFree = 0;
        int acertaambosespecialPro = 0;
        int pontosIndividuais = 0;
        int totalpontos = 0;

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
                    string valorOriginal = dr["jogo_estrela_jornada"].ToString();
                    string resultado;

                    if (valorOriginal.ToLower() == "true")
                    {
                        resultado = "Sim";
                    }
                    else 
                    {
                        resultado = "Não";
                    }
                    

                    lbl_jogo_especial.Text = resultado;
                }

                myconn.Close();
            }
        }

        protected void btn_fechar_jogo_Click(object sender, EventArgs e)
        {
            
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
                lbl_mensagem.Text = "Resultado Final atribuido ao jogo";

            }
            else
            {
                lbl_mensagem.Text = "Não foi atualizado o resultado final";
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

            // fechar a conexão
            myconn2.Close();

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            myconn.Open();

            string queryPrognostico = "SELECT username FROM prognosticos WHERE id_jogo = @id_jogo";
            SqlCommand cmdPrognostico = new SqlCommand(queryPrognostico, myconn);

            // Adicionar parâmetro
            cmdPrognostico.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));

            // Executar o comando SQL para obter o username
            string usernamePrognostico = cmdPrognostico.ExecuteScalar()?.ToString();

            // Agora, buscar o id_cliente na tabela clientes usando o usernamePrognostico
            string queryCliente = "SELECT id_cliente FROM clientes WHERE username = @username";
            SqlCommand cmdCliente = new SqlCommand(queryCliente, myconn);

            // Adicionar parâmetro para o username obtido anteriormente
            cmdCliente.Parameters.AddWithValue("@username", usernamePrognostico);

            // Executar o comando SQL para obter o id_cliente
            int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

            myconn.Close();

            if (resultadosPrognosticos.Count > 0)
            {
                foreach (var resultado in resultadosPrognosticos)
                {
                    int prognosticoCasa = resultadosPrognosticos[0].Item1;
                    int prognosticoFora = resultadosPrognosticos[0].Item2;
                    int resultadoCasa = Convert.ToInt32(txt_resultado_casa.Text);
                    int resultadoFora = Convert.ToInt32(txt_resultado_fora.Text);

                    if (((prognosticoCasa > prognosticoFora && resultadoCasa > resultadoFora && Math.Abs(prognosticoCasa - prognosticoFora) == Math.Abs(resultadoCasa - resultadoFora) && (lbl_jogo_especial.Text == "True")) || (prognosticoCasa < prognosticoFora && resultadoCasa < resultadoFora && Math.Abs(prognosticoCasa - prognosticoFora) == Math.Abs(resultadoCasa - resultadoFora) && lbl_jogo_especial.Text == "True")))
                    {
                        acertaambosespecialFree = 10;
                        acertaambosespecialPro = 12;

                        SqlCommand mycomm = new SqlCommand();
                        mycomm.CommandType = CommandType.StoredProcedure;
                        mycomm.CommandText = "acertaambosespecial";

                        mycomm.Connection = myconn;

                        mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
                        mycomm.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));
                        mycomm.Parameters.AddWithValue("@acertaambosespecialfree", acertaambosespecialFree);
                        mycomm.Parameters.AddWithValue("@acertaambosespecialpro", acertaambosespecialPro);

                        myconn.Open();
                        mycomm.ExecuteNonQuery();
                        myconn.Close();
                    }

                    else if ((prognosticoCasa > prognosticoFora && resultadoCasa > resultadoFora && Math.Abs(prognosticoCasa - prognosticoFora) == Math.Abs(resultadoCasa - resultadoFora)) || (prognosticoCasa < prognosticoFora && resultadoCasa < resultadoFora && Math.Abs(prognosticoCasa - prognosticoFora) == Math.Abs(resultadoCasa - resultadoFora)))
                    {
                        // Acertar ambos
                        acertaambosFree = 7;
                        acertaambosPro = 9;

                        SqlCommand mycomm = new SqlCommand();
                        mycomm.CommandType = CommandType.StoredProcedure;
                        mycomm.CommandText = "acertaambos";

                        mycomm.Connection = myconn;

                        mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
                        mycomm.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));
                        mycomm.Parameters.AddWithValue("@acertaambosfree", acertaambosFree);
                        mycomm.Parameters.AddWithValue("@acertaambospro", acertaambosPro);

                        myconn.Open();
                        mycomm.ExecuteNonQuery();
                        myconn.Close();
                    }

                    else if (Math.Abs(prognosticoCasa - prognosticoFora) == Math.Abs(resultadoCasa - resultadoFora))
                    {
                        // Quantidade de gols
                        quantidadeGolosFree = 4;
                        quantidadeGolosPro = 6;

                        SqlCommand mycomm = new SqlCommand();
                        mycomm.CommandType = CommandType.StoredProcedure;
                        mycomm.CommandText = "quantidadeGolos";

                        mycomm.Connection = myconn;

                        mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
                        mycomm.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));
                        mycomm.Parameters.AddWithValue("@quantidadegolosfree", quantidadeGolosFree);
                        mycomm.Parameters.AddWithValue("@quantidadegolospro", quantidadeGolosPro);

                        myconn.Open();
                        mycomm.ExecuteNonQuery();
                        myconn.Close();
                    }

                    else if ((prognosticoCasa > prognosticoFora && resultadoCasa > resultadoFora) || (prognosticoCasa < prognosticoFora && resultadoCasa < resultadoFora))
                    {
                        // Resultado certo
                        resultadocertoFree = 2;
                        resultadocertoPro = 3;

                        SqlCommand mycomm = new SqlCommand();
                        mycomm.CommandType = CommandType.StoredProcedure;
                        mycomm.CommandText = "resultadocerto";

                        mycomm.Connection = myconn;

                        mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
                        mycomm.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));
                        mycomm.Parameters.AddWithValue("@resultadocertofree", resultadocertoFree);
                        mycomm.Parameters.AddWithValue("@resultadocertopro", resultadocertoPro);

                        myconn.Open();
                        mycomm.ExecuteNonQuery();
                        myconn.Close();
                    }

                    myconn.Open();

                    // Agora, buscar o id_cliente na tabela clientes usando o usernamePrognostico
                    string queryCliente1 = "SELECT id_cliente FROM clientes WHERE username = @username";
                    SqlCommand cmdCliente1 = new SqlCommand(queryCliente1, myconn);

                    // Adicionar parâmetro para o username obtido anteriormente
                    cmdCliente1.Parameters.AddWithValue("@username", usernamePrognostico);

                    // Executar o comando SQL para obter o id_cliente
                    int idCliente1 = Convert.ToInt32(cmdCliente1.ExecuteScalar());

                    // Agora, buscar o id_amigo na tabela amigos usando o id_cliente
                    string queryAmigo = "SELECT id_amigo FROM amigos WHERE id_cliente = @id_cliente";
                    SqlCommand cmdAmigo = new SqlCommand(queryAmigo, myconn);

                    // Adicionar parâmetro para o id_cliente obtido anteriormente
                    cmdAmigo.Parameters.AddWithValue("@id_cliente", idCliente1);

                    // Executar o comando SQL para obter o id_amigo
                    int idAmigo = Convert.ToInt32(cmdAmigo.ExecuteScalar());

                    // Agora, buscar os pontos_individuais na tabela pontuacao usando o id_amigo
                    string queryPontosIndividuais = "SELECT pontos_individuais FROM pontuacao WHERE id_amigo = @id_amigo";
                    SqlCommand cmdPontosIndividuais = new SqlCommand(queryPontosIndividuais, myconn);

                    // Adicionar parâmetro para o id_amigo obtido anteriormente
                    cmdPontosIndividuais.Parameters.AddWithValue("@id_amigo", idAmigo);

                    // Executar o comando SQL para obter os pontos_individuais
                    int pontosIndividuais = Convert.ToInt32(cmdPontosIndividuais.ExecuteScalar());

                    // Agora, buscar o tipo_cliente na tabela clientes usando o idCliente1
                    string queryTipoCliente = "SELECT tipo_cliente FROM clientes WHERE id_cliente = @id_cliente";
                    SqlCommand cmdTipoCliente = new SqlCommand(queryTipoCliente, myconn);

                    // Adicionar parâmetro para o id_cliente obtido anteriormente
                    cmdTipoCliente.Parameters.AddWithValue("@id_cliente", idCliente1);

                    // Executar o comando SQL para obter o tipo_cliente
                    string tipoCliente = cmdTipoCliente.ExecuteScalar()?.ToString();

                    myconn.Close();

                    int totalpontos = 0;

                    if (tipoCliente == "FREE")
                    {
                        totalpontos = pontosIndividuais + resultadocertoFree + quantidadeGolosFree + acertaambosFree + acertaambosespecialFree;
                    }
                    else if (tipoCliente == "PRO")
                    {
                        totalpontos = pontosIndividuais + resultadocertoPro + quantidadeGolosPro + acertaambosPro + acertaambosespecialPro;
                    }

                    SqlCommand mycomm4 = new SqlCommand();
                    mycomm4.CommandType = CommandType.StoredProcedure;
                    mycomm4.CommandText = "CalcularResultadosPontuacao";

                    mycomm4.Connection = myconn;
                    mycomm4.Parameters.AddWithValue("@id_amigo", idAmigo);
                    mycomm4.Parameters.AddWithValue("@jornada", lbl_jornada.Text);
                    mycomm4.Parameters.AddWithValue("@pontos_individuais", totalpontos);

                    myconn.Open();
                    mycomm4.ExecuteNonQuery();
                    myconn.Close();

                    myconn.Open();

                    // Buscar a jornada na tabela jogo usando o id_jogo
                    string queryJornada = "SELECT jornada FROM jogos WHERE id_jogo = @id_jogo";
                    SqlCommand cmdJornada = new SqlCommand(queryJornada, myconn);

                    // Adicionar parâmetro para o id_jogo obtido anteriormente
                    cmdJornada.Parameters.AddWithValue("@id_jogo", Convert.ToInt32(Request.QueryString["id_jogo"]));

                    // Executar o comando SQL para obter a jornada
                    string jornadaDoJogo = cmdJornada.ExecuteScalar()?.ToString();

                    // Agora, buscar o id_cliente na tabela clientes usando o usernamePrognostico
                    string queryCliente2 = "SELECT id_cliente FROM clientes WHERE username = @username";
                    SqlCommand cmdCliente2 = new SqlCommand(queryCliente2, myconn);

                    // Adicionar parâmetro para o username obtido anteriormente
                    cmdCliente2.Parameters.AddWithValue("@username", usernamePrognostico);

                    // Executar o comando SQL para obter o id_cliente
                    int idCliente2 = Convert.ToInt32(cmdCliente2.ExecuteScalar());

                    // Agora, buscar o id_amigo na tabela amigos usando o id_cliente
                    string queryAmigo1 = "SELECT id_amigo FROM amigos WHERE id_cliente = @id_cliente";
                    SqlCommand cmdAmigo1 = new SqlCommand(queryAmigo1, myconn);

                    // Adicionar parâmetro para o id_cliente obtido anteriormente
                    cmdAmigo1.Parameters.AddWithValue("@id_cliente", idCliente2);

                    // Executar o comando SQL para obter o id_amigo
                    int idAmigo1 = Convert.ToInt32(cmdAmigo1.ExecuteScalar());

                    // Agora, verificar se a jornada é a mesma
                    string queryVerificarJornada = "SELECT pontos_jornada FROM pontuacao WHERE id_amigo = @id_amigo AND jornada = @jornada";
                    SqlCommand cmdVerificarJornada = new SqlCommand(queryVerificarJornada, myconn);

                    // Adicionar parâmetros para o id_amigo e a jornada obtidos anteriormente
                    cmdVerificarJornada.Parameters.AddWithValue("@id_amigo", idAmigo1);
                    cmdVerificarJornada.Parameters.AddWithValue("@jornada", jornadaDoJogo);

                    // Executar o comando SQL para verificar se a jornada já existe na tabela pontuacao
                    object pontosJornadaExistente = cmdVerificarJornada.ExecuteScalar();

                    myconn.Close();

                    if (pontosJornadaExistente != null)
                    {
                        // Já existem pontos para esta jornada, então você pode adicionar ou atualizar os pontos existentes.
                        int pontosJornada = Convert.ToInt32(pontosJornadaExistente);

                        // Verificar se a jornada atual é a mesma que a jornada na tabela pontuacao
                        if (jornadaDoJogo == lbl_jornada.Text)
                        {
                            // A jornada é a mesma, adicione os pontos existentes aos novos pontos
                            pontosJornada = pontosJornada + totalpontos;
                        }
                        else
                        {
                            pontosJornada = 0;
                            // A jornada é diferente, então atualize a tabela pontuacao com os novos pontos e a nova jornada
                            pontosJornada = pontosJornada + totalpontos;
                        }

                        SqlCommand mycomm5 = new SqlCommand();
                        mycomm5.CommandType = CommandType.StoredProcedure;
                        mycomm5.CommandText = "AtualizarPontosJornada";

                        mycomm5.Connection = myconn;
                        mycomm5.Parameters.AddWithValue("@id_amigo", idAmigo1);
                        mycomm5.Parameters.AddWithValue("@jornada", lbl_jornada.Text);
                        mycomm5.Parameters.AddWithValue("@pontos_jornada", pontosJornada);

                        myconn.Open();
                        mycomm5.ExecuteNonQuery();
                        myconn.Close();

                    }
                    else
                    {
                        // Não há pontos para esta jornada, insere uma nova entrada na tabela pontuacao.
                        // substituir totalpontos pelo valor correto que é para adicionar à jornada.
                        int pontosJornada = totalpontos;

                        SqlCommand mycomm5 = new SqlCommand();
                        mycomm5.CommandType = CommandType.StoredProcedure;
                        mycomm5.CommandText = "InserirPontosJornada";

                        mycomm5.Connection = myconn;
                        mycomm5.Parameters.AddWithValue("@id_amigo", idAmigo1);
                        mycomm5.Parameters.AddWithValue("@jornada", lbl_jornada.Text);
                        mycomm5.Parameters.AddWithValue("@pontos_jornada", pontosJornada);

                        myconn.Open();
                        mycomm5.ExecuteNonQuery();
                        myconn.Close();
                    }
                }
            }
        }
    }
}