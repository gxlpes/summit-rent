using Summit.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("concessionarias")]
    public class Concessionaria
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("cidade")]
        [Required]
        public string Cidade { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }
    }
}
