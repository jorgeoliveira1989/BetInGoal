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
    public partial class backoffice : System.Web.UI.Page
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
                lbl_utilizador.Text = (string)Session["utilizador"];
            }

            if (!IsPostBack)
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

                SqlCommand cmdtotalClientes = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes", myconn);

                lbl_quant_clientes.Text=cmdtotalClientes.ToString();
            }
        }
        protected void btn_sair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("administrador.aspx");
        }
    }
}