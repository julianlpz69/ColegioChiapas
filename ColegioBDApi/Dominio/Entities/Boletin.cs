namespace Dominio.Entities
{
    public class Boletin : BaseEntity
    {
        public string Corte {get; set;}
        public DateTime FechaCorte {get; set;}
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
        public ICollection<Nota> Notas {get; set;}
    }
}