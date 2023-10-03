namespace Summit.Requests
{
    public class AluguelRequest
    {
        public DateTime Data { get; set; }
        public Guid CarroId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid PagamentoId { get; set; }
        public Guid SeguroId { get; set; }
        public Guid SaidaId { get; set; }
        public Guid ChegadaId { get; set; }
    }
}
