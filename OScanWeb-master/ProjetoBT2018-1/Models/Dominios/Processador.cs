using System;

namespace ProjetoBT2018_1.Models.Dominios
{
    public class Processador
    {
        public int Id { get; set; }
        public int IdMaquina { get; set; }
        public int LogicalProcessorCount { get; set; }
        public DateTime Momentum { get; set; }
        public string Name { get; set; }
        public int PhysicalProcessorCount { get; set; }
        public double SystemCpuLoad { get; set; }
        public Int64 VendorFreq { get; set; }
    }
}