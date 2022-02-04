using System.ComponentModel.DataAnnotations;

namespace Blazor.back.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        public string Data { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo cep é obrigatório")]
        public string Cep { get; set; }


    }

}