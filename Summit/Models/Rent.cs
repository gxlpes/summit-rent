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
        public Customer Client { get; set; }

        [Column("payment")]
        public Payment Payment { get; set; }

        [Column("insurance")]
        public Insurance insurance { get; set; }

        [Column("departure")]
        public Departure departure { get; set; }

        [Column("destination")]
        public Destination destination { get; set; }

    }
}
