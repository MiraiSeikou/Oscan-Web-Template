namespace ProjetoBT2018_1.Models.Dominios
{
    public class Maquina
    {
        public DominioMaquina Dominio { get; set; }
        public Processador Processador { get; set; }
        public Memoria Memoria { get; set; }
        public FileStore Disco { get; set; }
    }
}