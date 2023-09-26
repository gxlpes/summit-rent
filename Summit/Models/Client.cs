using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("client_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }
    }
}
