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
    public partial class visualizarclientes : System.Web.UI.Page
    {
        string estilo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }
            else
            {

                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "lista_clientes_detalhes";
                mycomm.Connection = myconn;

                List<ver_clientes> lst_cliente = new List<ver_clientes>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    ver_clientes cliente = new ver_clientes();
                    cliente.id_cliente = reader.GetInt32(0);
                    cliente.nome = reader.GetString(1);
                    cliente.email = reader.GetString(2);
                    cliente.username = reader.GetString(3);
                    cliente.tipo_cliente = reader.GetString(4);
                    cliente.estado_conta = reader.GetBoolean(5);
                    cliente.data_registo = reader.GetDateTime(6);
                    cliente.data_nascimento = reader.GetDateTime(7);
                    cliente.data_nascimento_formatada = reader.GetDateTime(7).ToString("dd/MM/yyyy");

                    if (cliente.estado_conta.ToString() == "True")
                    {
                        estilo = Convert.ToString("ativo");
                    }
                    else
                    {
                        estilo = Convert.ToString("desativo");
                    }

                    cliente.estilosCSS = estilo;


                    lst_cliente.Add(cliente);
                }

                myconn.Close();

                rptClientes.DataSource = lst_cliente;
                rptClientes.DataBind();
            }
        }

        protected void txt_pesquisa_TextChanged(object sender, EventArgs e)
        {
            string query = "select id_cliente,nome,email,username,tipo_cliente,estado_conta,data_registo,datanascimento from clientes where username LIKE '%" +txt_pesquisa.Text+ "%'";

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<ver_clientes> lst_cliente = new List<ver_clientes>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                ver_clientes cliente = new ver_clientes();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.username = reader.GetString(3);
                cliente.tipo_cliente = reader.GetString(4);
                cliente.estado_conta = reader.GetBoolean(5);
                cliente.data_registo = reader.GetDateTime(6);
                cliente.data_nascimento = reader.GetDateTime(7);
                cliente.data_nascimento_formatada = reader.GetDateTime(7).ToString("dd/MM/yyyy");

                if (cliente.estado_conta.ToString() == "True")
                {
                    estilo = Convert.ToString("ativo");
                }
                else
                {
                    estilo = Convert.ToString("desativo");
                }

                cliente.estilosCSS = estilo;


                lst_cliente.Add(cliente);
            }

            myconn.Close();

            rptClientes.DataSource = lst_cliente;
            rptClientes.DataBind();
        }
    }
}