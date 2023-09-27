using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("ratings")]
    public class Rating
    {
        [Key]
        [Column("car_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("rent")]
        public Rent Rent { get; set; }

        [Column("comment")]
        public string Comment { get; set; }

        [Column("grade")]
        public double Grade { get; set; } 

    }
}
