using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("seguros")]
    public class Seguro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public double Preco { get; set; }
    }
}
