using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("pagamentos")]
    public class Pagamento
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("metodo")]
        public string Metodo { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_pagamento")]
        public DateTime DataPagamento { get; set; }

        [Column("cliente")]
        public Cliente Cliente { get; set; } 
    }
}
