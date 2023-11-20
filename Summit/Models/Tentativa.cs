using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("tentativas")]
    public class Tentativa
    {
        [Key]
        [Column("cliente_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClienteId { get; set; }

        [Column("id_carro")]
        public Guid CarroId { get; set; }

        [Column("date")]
        public DateTime DataTentativa { get; set; }

    }
}
