using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class addjogo : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CriarControlesDinamicos();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("administrador.aspx");
            }

            if (!IsPostBack)
            {
                CriarControlesDinamicos();
            }
        }

        protected void ddl_quantidadeJogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriarControlesDinamicos();
        }

        private void CriarControlesDinamicos()
        {
            pnlJogos.Controls.Clear();

            if (ddl_quantidadeJogos.SelectedItem.ToString() == "---------")
            {
                return;
            }

            int quantidadeJogos = Convert.ToInt32(ddl_quantidadeJogos.SelectedValue);

            for (int i = 1; i <= quantidadeJogos; i++)
            {
                // Criação de controles para o jogo

                // TextBox para inserir a data
                TextBox txtData = new TextBox();
                txtData.ID = "txtData_" + i;
                txtData.Attributes["type"] = "date";

                // TextBox para inserir a hora
                TextBox txtHora = new TextBox();
                txtHora.ID = "txtHora_" + i;
                txtHora.Attributes["type"] = "time";

                // TextBox para inserir o nome da equipe da casa
                TextBox txtEquipaCasa = new TextBox();
                txtEquipaCasa.ID = "txtEquipaCasa_" + i;

                // ddl para inserir o resultado da equipe da casa
                DropDownList ddlResultadoCasa = new DropDownList();
                ddlResultadoCasa.ID = "ddlResultadoCasa_" + i;
                for (int j = 0; j <= 15; j++)
                {
                    ddlResultadoCasa.Items.Add(new ListItem(j.ToString(), j.ToString()));
                }

                // dropdownlist para inserir o resultado da equipe de fora
                DropDownList ddlResultadoFora = new DropDownList();
                ddlResultadoFora.ID = "ddlResultadoFora_" + i;
                for (int j = 0; j <= 15; j++)
                {
                    ddlResultadoFora.Items.Add(new ListItem(j.ToString(), j.ToString()));
                }

                // TextBox para inserir o nome da equipe de fora
                TextBox txtEquipaFora = new TextBox();
                txtEquipaFora.ID = "txtEquipaFora_" + i;

                // CheckBox para indicar jogo especial
                CheckBox chkJogoEspecial = new CheckBox();
                chkJogoEspecial.ID = "chkJogoEspecial_" + i;
                chkJogoEspecial.Attributes.Add("onclick", "toggleControlesJogoEspecial(this)");

                // Adiciona os controles ao painel pnlJogos
                pnlJogos.Controls.Add(new LiteralControl("Data: "));
                pnlJogos.Controls.Add(txtData);
                pnlJogos.Controls.Add(new LiteralControl(" Hora: "));
                pnlJogos.Controls.Add(txtHora);
                pnlJogos.Controls.Add(new LiteralControl("<br /><br />"));

                pnlJogos.Controls.Add(txtEquipaCasa);
                pnlJogos.Controls.Add(ddlResultadoCasa);

                pnlJogos.Controls.Add(new LiteralControl(" VS "));

                pnlJogos.Controls.Add(ddlResultadoFora);
                pnlJogos.Controls.Add(txtEquipaFora);

                pnlJogos.Controls.Add(new LiteralControl("<br />"));

                pnlJogos.Controls.Add(new LiteralControl("Jogo Especial: "));
                pnlJogos.Controls.Add(chkJogoEspecial);
                pnlJogos.Controls.Add(new LiteralControl("<br />"));
                pnlJogos.Controls.Add(new LiteralControl("<br />"));
                pnlJogos.Controls.Add(new LiteralControl("---------------------------------------------------------------------------"));
                pnlJogos.Controls.Add(new LiteralControl("<br />"));
                pnlJogos.Controls.Add(new LiteralControl("<br />"));
            }
        }



        protected void btn_criar_jogo_Click(object sender, EventArgs e)
        {

            CriarControlesDinamicos();

            int quantidadeJogos = Convert.ToInt32(ddl_quantidadeJogos.SelectedValue);

            // Agora, você pode acessar os valores dos TextBoxes criados dinamicamente
            for (int i = 1; i <= quantidadeJogos; i++)
            {
                // Encontrar os controles dinâmicos
                TextBox txtEquipaCasa = pnlJogos.FindControl("txtEquipaCasa_" + i) as TextBox;
                TextBox txtData = pnlJogos.FindControl("txtData_" + i) as TextBox;
                TextBox txtHora = pnlJogos.FindControl("txtHora_" + i) as TextBox;
                DropDownList ddlResultadoCasa = pnlJogos.FindControl("ddlResultadoCasa_" + i) as DropDownList;
                DropDownList ddlResultadoFora = pnlJogos.FindControl("ddlResultadoFora_" + i) as DropDownList;
                TextBox txtEquipaFora = pnlJogos.FindControl("txtEquipaFora_" + i) as TextBox;
                CheckBox chkJogoEspecial = pnlJogos.FindControl("chkJogoEspecial_" + i) as CheckBox;

                // Verificar se os controles foram encontrados
                if (txtEquipaCasa != null && txtData != null && txtHora != null &&
                    ddlResultadoCasa != null && ddlResultadoFora != null &&
                    txtEquipaFora != null && chkJogoEspecial != null)
                {
                    // Obter os valores dos controles
                    string nomeEquipaCasa = txtEquipaCasa.Text;
                    string data = txtData.Text;
                    string hora = txtHora.Text;
                    string resultadoCasa = ddlResultadoCasa.SelectedValue;
                    string resultadoFora = ddlResultadoFora.SelectedValue;
                    string nomeEquipaFora = txtEquipaFora.Text;
                    bool jogoEspecial = chkJogoEspecial.Checked;

                    // Chamar o método para guardar no SQL
                    GuardarnoSQL(nomeEquipaCasa, data, hora, resultadoCasa, resultadoFora, nomeEquipaFora, jogoEspecial);
                }
            }
        }

        private void GuardarnoSQL(string nomeEquipaCasa, string data, string hora, string resultadoCasa, string resultadoFora, string nomeEquipaFora, bool jogoEspecial) {
            
            // Configurar a string de conexão. Ajuste conforme necessário.
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["BetinGoalConnectionString"].ConnectionString);

            string utilizador = (string)Session["utilizador"];

            // Usar parâmetros para evitar problemas de segurança e erros de sintaxe
            string queryAdmin = "SELECT id_admin FROM admins WHERE username = @username";
            SqlCommand cmdAdmin = new SqlCommand(queryAdmin, myconn);

            // Adicionar parâmetro
            cmdAdmin.Parameters.AddWithValue("@username", utilizador);

            myconn.Open();
            // Executar o comando SQL para obter o resultado
            int idAdmin = Convert.ToInt32(cmdAdmin.ExecuteScalar());
            myconn.Close();


            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "criar_jornada";

            mycomm.Connection = myconn;

            mycomm.Parameters.AddWithValue("@liga", txt_nome_liga.Text);
            mycomm.Parameters.AddWithValue("@jornada", txt_jornada.Text);
            mycomm.Parameters.AddWithValue("@data_jogo", data);
            mycomm.Parameters.AddWithValue("@hora_jogo", hora);
            mycomm.Parameters.AddWithValue("@equipa_casa", nomeEquipaCasa);
            mycomm.Parameters.AddWithValue("@resultado_equipa_casa", resultadoCasa);
            mycomm.Parameters.AddWithValue("@equipa_fora", nomeEquipaFora);
            mycomm.Parameters.AddWithValue("@resultado_equipa_fora", resultadoFora);
            mycomm.Parameters.AddWithValue("@jogo_especial", jogoEspecial);
            mycomm.Parameters.AddWithValue("@id_admin", idAdmin);



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
               // lbl_mensagem.Text = "A Jornada foi criada!";
            }

        }
    }

}
