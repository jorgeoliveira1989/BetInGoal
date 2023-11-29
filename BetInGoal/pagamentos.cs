using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetInGoal
{
    public class pagamentos
    {
        public int IdPagamento { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public int DuracaoDias { get; set; }
        public int TotalDiasFalta { get; set; }
        public string EstilosCSS { get; set; }
    }
}