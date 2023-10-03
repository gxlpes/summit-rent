using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("carros")]
    public class Carro
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("placa")]
        public string Placa { get; set; }

        [Required]
        [Column("alugado")]
        public bool Alugado { get; set; }

        [Required]
        [Column("concessionaria")]
        public Concessionaria Concessionaria;
    }
}