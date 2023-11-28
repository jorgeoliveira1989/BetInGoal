using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetInGoal
{
    public class suporte
    {
       public int id_suporte {  get; set; }
       public string nome { get; set; }
       public string email { get; set; }
       public string assunto { get; set; }
       public string mensagem { get; set; }
       public string mensagem_resposta {  get; set; } 
    }
}