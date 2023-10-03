using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("tentativas")]
    public class Tentativa
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }

        [Column("id_cliente")]
        public Guid ClientId { get; set; }

        [Column("id_carro")]
        public Guid CarId { get; set; }

    }
}
