using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Contexts;

namespace BetInGoal
{
    public partial class detalhe_ligas : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request.QueryString["id_liga"]);

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "liga_detalhes";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@id", id);

                myconn.Open();

                SqlDataReader dr = mycomm.ExecuteReader();

                if (dr.Read())
                {
                    lbl_nome_liga.Text = dr["nome_liga"].ToString();
                    lbl_criador_liga.Text = dr["nome_cliente"].ToString();
                    lbl_limite_liga.Text = dr["limite_amigos"].ToString();
                }

                if(lbl_limite_liga.Text == lbl_total_clientes_liga.Text)
                {
                    btn_adiciona_liga.Visible = false;
                }

                myconn.Close();

                string query = "SELECT ligas.nome_liga AS NomeLiga,amigos.nome_amigo AS NomeAmigo,pontuacao.pontos_individuais AS PontosIndividuais,pontuacao.pontos_jornada AS PontosJornada FROM pontuacao INNER JOIN amigos ON pontuacao.id_amigo = amigos.id_amigo INNER JOIN ligas ON pontuacao.id_liga = ligas.id_liga WHERE ligas.nome_liga ='"+lbl_nome_liga.Text+"' ORDER BY pontuacao.pontos_individuais DESC";

                SqlCommand mycomm1 = new SqlCommand(query, myconn);


                List<lista_amigos> lst_classAmigos = new List<lista_amigos>();

                myconn.Open();

                var classAmigos = mycomm1.ExecuteReader();

                while (classAmigos.Read())
                {
                    lista_amigos lst = new lista_amigos();

                    lst.NomeLiga = classAmigos.GetString(0);
                    lst.NomeAmigo = classAmigos.GetString(1);
                    lst.PontosIndividuais = classAmigos.GetInt32(2);
                    lst.PontosJornada = classAmigos.GetInt32(3);

                    // Verifica se o utilizador já está na liga
                    if (lst.NomeAmigo == (string)Session["utilizador"]) 
                    {

                        // Esconde o botão para entrar em outra liga
                        btn_adiciona_liga.Visible = false;

                    }

                    lst_classAmigos.Add(lst);
                }

                myconn.Close();

                rpt_amigos_liga.DataSource = lst_classAmigos;
                rpt_amigos_liga.DataBind();

                lbl_total_clientes_liga.Text = lst_classAmigos.Count.ToString();

            }
        }
        protected void btn_adiciona_liga_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id_liga"]);

            string utilizador = (string)Session["utilizador"];

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            string queryCliente = "SELECT id_cliente FROM clientes WHERE username = @username";
            SqlCommand cmdCliente = new SqlCommand(queryCliente, myconn);

            cmdCliente.Parameters.AddWithValue("@username", utilizador);

            myconn.Open();

            int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());
            myconn.Close();

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "cliente_entrar_liga";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@id_cliente", idCliente);
            mycomm.Parameters.AddWithValue("@id_liga", id);
            mycomm.Parameters.AddWithValue("@nome_amigo", utilizador);


            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Entrou na Liga!";
                btn_adiciona_liga.Visible = false;
            }
            else
            {
                lbl_mensagem.Text = "Não Entrou em nenhuma Liga!";
            }

        }

        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("entrarliga.aspx");
        }
    }
}