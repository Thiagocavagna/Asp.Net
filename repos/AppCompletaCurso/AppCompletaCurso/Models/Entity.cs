namespace AppCompletaCurso.Models
{
    public abstract class Entity
        //abstrata pois todas as outras classes vão herdar dessa base, não é pra ser instanciada
    {
        public Guid Id { get; set; }

        protected Entity() //protected em vez de public porque é uma classe abstrata
        {
            Id = Guid.NewGuid();
        }
    }
}
