using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("car_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PaymentMethod { get; set; } 
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Customer customer { get; set; } 
    }
}
