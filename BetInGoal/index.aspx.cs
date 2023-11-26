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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] != null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("cliente.aspx");
            }
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "apresenta_resultados_index";

            mycomm.Connection = myconn;

            SqlParameter totalPrognosticosParam = new SqlParameter("@totalprognosticos", SqlDbType.Int);
            totalPrognosticosParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(totalPrognosticosParam);

            SqlParameter quantidadeRegistosParam = new SqlParameter("@quantidaderegistos", SqlDbType.Int);
            quantidadeRegistosParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(quantidadeRegistosParam);

            SqlParameter quantidadeRegistosHojeParam = new SqlParameter("@quantidaderegistoshoje", SqlDbType.Int);
            quantidadeRegistosHojeParam.Direction = ParameterDirection.Output;
            mycomm.Parameters.Add(quantidadeRegistosHojeParam);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            // Verifica se o valor retornado é DBNull antes de converter
            int totalprognosticos = (totalPrognosticosParam.Value == DBNull.Value) ? 0 : Convert.ToInt32(totalPrognosticosParam.Value);
            int quantidaderegistos = (quantidadeRegistosParam.Value == DBNull.Value) ? 0 : Convert.ToInt32(quantidadeRegistosParam.Value);
            int quantidaderegistoshoje = (quantidadeRegistosHojeParam.Value == DBNull.Value) ? 0 : Convert.ToInt32(quantidadeRegistosHojeParam.Value);

            myconn.Close();

            lbl_quantidade_prognosticos.Text = totalprognosticos.ToString();
            lbl_total_users.Text = quantidaderegistos.ToString();
            lbl_novos_users_dia.Text = quantidaderegistoshoje.ToString();
        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("entrar.aspx");
        }

        protected void btn_criar_conta_Click(object sender, EventArgs e)
        {
            Response.Redirect("criarconta.aspx");
        }

        protected void btn_criar_conta1_Click(object sender, EventArgs e)
        {
            Response.Redirect("criarconta.aspx");
        }
    }
}