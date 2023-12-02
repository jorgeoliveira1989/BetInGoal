using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class backoffice : System.Web.UI.Page
    {
        int ativos = 0;
        int inativos = 0;
        int encomendasdia = 0;
        int Msgativas = 0;
        int Msginativas = 0;

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

                myconn.Open();

                // Total de Clientes
                SqlCommand cmdtotalClientes = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes", myconn);

                SqlDataReader reader = cmdtotalClientes.ExecuteReader();

                if (reader.Read())
                {
                    int totalClientes = Convert.ToInt32(reader["TotalClientes"]);
                    lbl_quant_clientes.Text = totalClientes.ToString();
                }

                reader.Close();

                // Total de Vendas
                SqlCommand cmdtotalVendas = new SqlCommand("SELECT COUNT(*) as TotalVendas FROM pagamentos", myconn);

                SqlDataReader reader1 = cmdtotalVendas.ExecuteReader();

                if (reader1.Read())
                {
                    int totalVendas = Convert.ToInt32(reader1["TotalVendas"]);
                    lbl_quant_vendas.Text = totalVendas.ToString();
                }

                reader1.Close();

                //total de mensagens

                SqlCommand cmdtotalmensagens = new SqlCommand("SELECT COUNT(*) as TotalMensagens FROM suporte where ativo='True'", myconn);

                SqlDataReader reader2 = cmdtotalmensagens.ExecuteReader();

                if (reader2.Read())
                {
                    int totalmensagens = Convert.ToInt32(reader2["TotalMensagens"]);
                    lbl_quant_mensagens.Text = totalmensagens.ToString();
                }

                reader2.Close();

                //total de Ligas

                SqlCommand cmdtotalligas = new SqlCommand("SELECT COUNT(*) as TotalLigas FROM ligas", myconn);

                SqlDataReader reader3 = cmdtotalligas.ExecuteReader();

                if (reader3.Read())
                {
                    int totalligas = Convert.ToInt32(reader3["TotalLigas"]);
                    lbl_quant_ligas.Text = totalligas.ToString();
                }

                reader3.Close();

                //os outros gráficos exemplos: 

                SqlCommand cmdClientesAtivos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE estado_conta = 'True'", myconn);

                SqlCommand cmdClientesInativos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE estado_conta = 'False'", myconn);

                // Total de pagamentos distintos
                SqlCommand cmdTotalPagamentos = new SqlCommand("SELECT COUNT(DISTINCT CONCAT(username, CONVERT(date, data_pagamento))) AS total_pagamentos_distintos FROM pagamentos", myconn);

                DateTime dataAtual = DateTime.Now.Date;

                // Pagamentos do dia atual
                SqlCommand cmdPagamentosDia = new SqlCommand(
                    "SELECT COUNT(DISTINCT id_cliente) AS total_pagamentos_distintos1 " +
                    "FROM pagamentos " +
                    "WHERE CONVERT(date, data_pagamento) = @DataAtual", myconn);

                cmdPagamentosDia.Parameters.AddWithValue("@DataAtual", dataAtual);

                DateTime dataSemanaPassada = dataAtual.AddDays(-7);

                // Pagamentos da última semana
                SqlCommand cmdPagamentosSemana = new SqlCommand(
                    "SELECT COUNT(DISTINCT id_cliente) AS total_pagamentos_distintos2 " +
                    "FROM pagamentos " +
                    "WHERE CONVERT(date, data_pagamento) BETWEEN @DataInicio AND @DataFim", myconn);

                cmdPagamentosSemana.Parameters.AddWithValue("@DataInicio", dataSemanaPassada);
                cmdPagamentosSemana.Parameters.AddWithValue("@DataFim", dataAtual);

                DateTime data30DiasAtras = dataAtual.AddDays(-30);

                // Pagamentos dos últimos 30 dias
                SqlCommand cmdPagamentos30Dias = new SqlCommand(
                    "SELECT COUNT(DISTINCT id_cliente) AS total_pagamentos_distintos3 " +
                    "FROM pagamentos " +
                    "WHERE CONVERT(date, data_pagamento) BETWEEN @DataInicio1 AND @DataFim1", myconn);

                cmdPagamentos30Dias.Parameters.AddWithValue("@DataInicio1", data30DiasAtras);
                cmdPagamentos30Dias.Parameters.AddWithValue("@DataFim1", dataAtual);


                SqlCommand cmdMensagensAtivas = new SqlCommand("SELECT COUNT(*) as TotalMensagens FROM suporte WHERE ativo = 'True'", myconn);

                SqlCommand cmdMensagensInativas = new SqlCommand("SELECT COUNT(*) as TotalMensagens FROM suporte WHERE ativo = 'False'", myconn);

                //-------------------------------------------------------------------------------------------------------------------------//

                //ativos

                SqlDataReader readerAtivos = cmdClientesAtivos.ExecuteReader();
                if (readerAtivos.Read())
                {
                    int totalClientesAtivos = Convert.ToInt32(readerAtivos["TotalClientes"]);
                    Chart1.Series["Series1"].Points.AddXY("Clientes Ativos", totalClientesAtivos);

                    ativos = totalClientesAtivos;
                }
                readerAtivos.Close();

                //inativos

                SqlDataReader readerInativos = cmdClientesInativos.ExecuteReader();
                if (readerInativos.Read())
                {
                    int totalClientesInativos = Convert.ToInt32(readerInativos["TotalClientes"]);
                    Chart1.Series["Series1"].Points.AddXY("Clientes Inativos", totalClientesInativos);

                    inativos = totalClientesInativos;

                }
                readerInativos.Close();

                //pagamentos Dia

                SqlDataReader readerEncomendasDia = cmdPagamentosDia.ExecuteReader();

                if (readerEncomendasDia.Read())
                {
                    int totalVendasDia = Convert.ToInt32(readerEncomendasDia["total_pagamentos_distintos1"]);
                    Chart2.Series["Series1"].Points.AddXY("Vendas do Dia", totalVendasDia);

                    encomendasdia = totalVendasDia;
                }

                readerEncomendasDia.Close();

                //pagamentos Semana

                SqlDataReader readerVendasSemana = cmdPagamentosSemana.ExecuteReader();

                if (readerVendasSemana.Read())
                {
                    int totalVendasSemana = Convert.ToInt32(readerVendasSemana["total_pagamentos_distintos2"]);
                    Chart2.Series["Series1"].Points.AddXY("Vendas da Semana", totalVendasSemana);
                }

                readerVendasSemana.Close();

                //pagamentos do mês

                SqlDataReader readerVendas30Dias = cmdPagamentos30Dias.ExecuteReader();

                if (readerVendas30Dias.Read())
                {
                    int totalVendas30Dias = Convert.ToInt32(readerVendas30Dias["total_pagamentos_distintos3"]);
                    Chart2.Series["Series1"].Points.AddXY("Vendas do mês", totalVendas30Dias);

                }

                readerVendas30Dias.Close();

                //Mensagens Ativas 

                SqlDataReader readerMsgAtivas = cmdMensagensAtivas.ExecuteReader();
                if (readerMsgAtivas.Read())
                {
                    int totalMensagensAtivas = Convert.ToInt32(readerMsgAtivas["TotalMensagens"]);
                    Chart3.Series["Series1"].Points.AddXY("Mensagens em Aberto", totalMensagensAtivas);

                    Msgativas = totalMensagensAtivas;
                }
                readerMsgAtivas.Close();

                //Mensagens inativas

                SqlDataReader readerMsgInativas = cmdMensagensInativas.ExecuteReader();
                if (readerMsgInativas.Read())
                {
                    int totalMensagensInativas = Convert.ToInt32(readerMsgInativas["TotalMensagens"]);
                    Chart3.Series["Series1"].Points.AddXY("Mensagens Fechadas", totalMensagensInativas);

                    Msginativas = totalMensagensInativas;

                }
                readerMsgInativas.Close();




                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart3.Series["Series1"].ChartType = SeriesChartType.Column;

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