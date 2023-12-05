using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetInGoal
{
    public class jogos
    {
        public int id_jogo { get; set; }
        public string liga { get; set; }
        public int jornada { get; set; }
        public string data_jogo { get; set; }
        public string hora_jogo { get; set; }
        public string equipa_casa { get; set; }
        public int resultado_casa { get; set; }
        public int resultado_fora { get; set; }
        public string equipa_fora { get; set; }
        public bool jogo_estrela_jornada { get; set; }
        public int id_admin { get; set; }
        public bool ativo { get; set; }
    }
}