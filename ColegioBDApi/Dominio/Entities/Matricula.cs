namespace Dominio.Entities
{
    public class Matricula : BaseEntity
    {
        public DateTime FechaMatricula {get; set;}
        public string CodigoMatricula {get; set;}
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
    }
}