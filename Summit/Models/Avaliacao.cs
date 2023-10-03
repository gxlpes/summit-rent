using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("avaliacoes")]
    public class Avaliacao
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("comentario")]
        public string Comentario { get; set; }

        [Column("estrelas")]
        [Range(1, 5, ErrorMessage = "Stars must be between 1 and 5")]
        public int Estrelas { get; set; }

        [Column("aluguel")]
        public Aluguel Aluguel { get; set; }

    }
}
