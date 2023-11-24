using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetInGoal
{
    public partial class cliente : System.Web.UI.Page
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
                lbl_utilizador.Text = (string)Session["utilizador"];
                lbl_email.Text = (string)Session["clienteEmail"];
                lbl_tipo_conta.Text = (string)Session["tipocliente"];
            }

            if (Session["tipocliente"] != null)
            {
                string tipocliente = Session["tipocliente"].ToString();

                // Atribuir a cor com base no tipo_conta
                if (tipocliente.Equals("Free", StringComparison.OrdinalIgnoreCase))
                {
                    lbl_tipo_conta.ForeColor = System.Drawing.Color.Green;
                }
                else if (tipocliente.Equals("PRO", StringComparison.OrdinalIgnoreCase))
                {
                    lbl_tipo_conta.ForeColor = System.Drawing.Color.Red;
                }

                // Atualizar o texto do Label com o valor do tipo_conta
                lbl_tipo_conta.Text = tipocliente;

                if(tipocliente == "FREE")
                {

                    lbl_alterar_passe.Visible = true;
                }
            }

        }
    }
}