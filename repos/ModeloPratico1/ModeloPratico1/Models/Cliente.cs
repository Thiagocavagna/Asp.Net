namespace ModeloPratico1.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        //Relação pro EF

        public IEnumerable<Servico> Servicos { get; set; }

    }
}
