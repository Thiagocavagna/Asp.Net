namespace ModeloPratico1.Models
{
    public class Servico : Entity
    {
        public Guid ClienteId { get; set; } //chave estrangeira pro Entity

        public TipoServico TipoServico { get; set; }

    }

    public enum TipoServico
    {
        Corte = 1,
        Sobrancelha,
        Barba,
        Pezinho,
        
    }
}
