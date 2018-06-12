using System.ComponentModel.DataAnnotations;

namespace ProjetoBT2018_1.Models.Dominio
{
    public class Usuario
    {
        private int id;
        private string nome, email, senha, confSenha;

        public int Id { get => id; set => id = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Nome { get => nome; set => nome = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email Inválido!")]
        public string Email { get => email; set => email = value.ToLower(); }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Senha { get => senha; set => senha = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string ConfSenha { get => confSenha; set => confSenha = value; }
    }
}
