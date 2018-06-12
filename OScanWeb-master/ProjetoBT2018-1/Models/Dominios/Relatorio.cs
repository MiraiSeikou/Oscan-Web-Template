using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ProjetoBT2018_1.Models.Dominios
{
    public class Relatorio
    {
        public IEnumerable<double> Processador { get; set; }
        public string NomeMaquina { get; set; }
        public IEnumerable<double> Disco { get; set; }
        public IEnumerable<double> MemoriaRam { get; set; }
        public IEnumerable<double> MemoriaSwap { get; set; }
        public IEnumerable<DateTime> Momento { get; set; }
    }
}