using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                pnlJogos.Controls.Add(new LiteralControl("---------------------------------------------------------------------------"));
                pnlJogos.Controls.Add(new LiteralControl("<br />"));
            }
        }



        protected void btn_criar_jogo_Click(object sender, EventArgs e)
        {
            
        }
    }
}