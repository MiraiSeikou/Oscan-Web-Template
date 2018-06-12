namespace ProjetoBT2018_1.Models.Dominios
{
    public class DominioMaquina
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string MacAddr { get; set; }
        public string Nome { get; set; }
        public string OSName { get; set; }
    }
}