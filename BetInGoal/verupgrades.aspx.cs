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
    public partial class verupgrades : System.Web.UI.Page
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
                mycomm.CommandText = "lista_pagamentos_detalhes";
                mycomm.Connection = myconn;

                List<pagamentos> lst_pagamentos = new List<pagamentos>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    pagamentos pagamento = new pagamentos();
                    pagamento.IdPagamento = reader.GetInt32(0);
                    pagamento.NomeCliente = reader.GetString(1);
                    pagamento.DataPagamento = reader.GetDateTime(2);
                    pagamento.Valor = reader.GetDecimal(3);
                    pagamento.DuracaoDias = reader.GetInt32(4);

                    // Calculando os dias em falta
                    DateTime dataFimSubscricao = pagamento.DataPagamento.AddDays(pagamento.DuracaoDias);
                    TimeSpan diferenca = dataFimSubscricao - DateTime.Now;
                    pagamento.TotalDiasFalta = (int)diferenca.TotalDays;

                    if(pagamento.TotalDiasFalta <= 30)
                    {
                        estilo = Convert.ToString("terminar");
                    }else if(pagamento.TotalDiasFalta >30 && pagamento.TotalDiasFalta <= 100)
                    {
                        estilo = Convert.ToString("meio prazo");
                    }else if (pagamento.TotalDiasFalta > 100)
                    {
                        estilo = Convert.ToString("recente");
                    }

                    pagamento.EstilosCSS = estilo;

                    lst_pagamentos.Add(pagamento);
                }

                myconn.Close();

                rptupgrade.DataSource = lst_pagamentos;
                rptupgrade.DataBind();
            }
        }
    }
}