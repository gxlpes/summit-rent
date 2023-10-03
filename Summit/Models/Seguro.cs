using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("seguros")]
    public class Seguro
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public double Preco { get; set; }
    }
}
