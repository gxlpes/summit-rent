using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Common
{
    public class Deslocamento
    {
        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}
