using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBancoDeDados.Models
{
    public class FornecedorModel : EnderecoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "CNPJ é obrigatorio.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "caracteres mínimo 18")]
        public string CNPJ { get; set; } = string.Empty;

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é obrigatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 100")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(15, MinimumLength = 0, ErrorMessage = "caracteres mínimo 0 máximo de 15")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Data de Inclusão é obrigatoria.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
