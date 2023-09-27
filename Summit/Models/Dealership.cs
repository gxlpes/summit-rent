using Summit.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("dealerships")]
    public class Dealership:Location
    {
        [Key]
        [Column("dealership_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }

        [Column("name")]
        public new string Name { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("estado")]
        public string State { get; set; }
    }
}
