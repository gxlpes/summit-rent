using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("insurances")]
    public class Insurance
    {
        [Key]
        [Column("car_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string name { get; set; }

        public double price { get; set; }
    }
}
