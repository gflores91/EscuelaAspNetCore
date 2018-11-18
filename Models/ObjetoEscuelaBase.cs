namespace EscuelaAspNetCore.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; private set; }
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}