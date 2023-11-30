using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace BetInGoal
{
    public partial class detalhe_liga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["IdLiga"]);

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
                myconn.Close();

                string query = "SELECT ligas.nome_liga AS NomeLiga,amigos.nome_amigo AS NomeAmigo,pontuacao.pontos_individuais AS PontosIndividuais,pontuacao.pontos_jornada AS PontosJornada FROM pontuacao INNER JOIN amigos ON pontuacao.id_amigo = amigos.id_amigo INNER JOIN ligas ON pontuacao.id_liga = ligas.id_liga ORDER BY pontuacao.pontos_individuais DESC";

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


                    lst_classAmigos.Add(lst);
                }

                myconn.Close();

                rpt_amigos_liga.DataSource = lst_classAmigos;
                rpt_amigos_liga.DataBind();

                lbl_total_clientes_liga.Text = lst_classAmigos.Count.ToString();

            }
        }
    }
}