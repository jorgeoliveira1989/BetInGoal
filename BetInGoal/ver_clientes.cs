using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetInGoal
{
    public class ver_clientes
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string tipo_cliente { get; set; }
        public bool estado_conta { get; set; }
        public DateTime data_registo { get; set; }
        public DateTime data_nascimento { get; set; }
        public string estilosCSS { get; set; }
        public string data_nascimento_formatada { get; set; }
    }
}