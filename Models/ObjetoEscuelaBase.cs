namespace EscuelaAspNetCore.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public int Id { get; set; }
        public virtual string Nombre { get; set; }

        // public ObjetoEscuelaBase()
        // {
        //     Id = System.Guid.NewGuid().ToString();
        // }
    }
}