using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("rents")]
    public class Rent
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("name")]
        public Car Car { get; set; }

        [Column("cpf")]
        public Client Client { get; set; }


    }
}
