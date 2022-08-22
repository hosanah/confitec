using System.ComponentModel.DataAnnotations;
using Confitec.Models;

namespace Confitec.ViewModels
{
    public class EditorUsuarioViewModel
    {
        [Required(ErrorMessage ="Campo nome é obrigatório!")]
        [MinLength(3, ErrorMessage ="Este campo deve contar o mínimo de 3 letras!")]
        public string Nome { get; set; }
        [MinLength(3, ErrorMessage ="Este campo deve contar o mínimo de 3 letras!")]
        [Required(ErrorMessage ="Campo sobrenome é obrigatório!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage ="Campo data de nascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage ="Campo email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Você não forneceu um e-mail válido!")]
        public string Email { get; set; }
        public EscolaridadeType EscolaridadeType { get; set; }
    }
}