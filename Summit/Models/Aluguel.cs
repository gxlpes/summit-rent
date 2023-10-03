using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("alugueis")]
    public class Aluguel

    {
        public Aluguel() { }


        public Aluguel(DateTime data, Carro carro, Cliente cliente, Pagamento pagamento, Seguro seguro, Saida saida, Chegada chegada)
        {
            Data = data;
            Carro = carro;
            Cliente = cliente;
            Pagamento = pagamento;
            Seguro = seguro;
            Saida = saida;
            Chegada = chegada;
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("data")]
        public DateTime Data { get; set; }

        [Required]
        [Column("carro")]
        public Carro Carro { get; set; }

        [Required]
        [Column("cpf")]
        public Cliente Cliente { get; set; }

        [Required]
        [Column("pagamento")]
        public Pagamento Pagamento { get; set; }

        [Required]
        [Column("seguro")]
        public Seguro Seguro { get; set; }

        [Required]
        [Column("saida")]
        public Saida Saida { get; set; }

        [Required]
        [Column("chegada")]
        public Chegada Chegada { get; set; }
    }
}
