using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("intents")]
    public class Intent
    {
        [Key]
        [Column("intent_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }

        [Column("client_id")]
        public string ClientId { get; set; }

        [Column("car_id")]
        public string CarId { get; set; }

    }
}
