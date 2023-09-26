using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Summit.Data;
using Microsoft.EntityFrameworkCore;

namespace Summit.Models
{
    [Table("cars")]
    public class Car
    {
        [Key]
        [Column("car_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("plate")]
        public string Plate { get; set; }

        [Column("rented")]
        public bool isRented { get; set; }

        public Client client;
    }


}