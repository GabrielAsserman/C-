using System.ComponentModel.DataAnnotations;

namespace AvaliacaoAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}