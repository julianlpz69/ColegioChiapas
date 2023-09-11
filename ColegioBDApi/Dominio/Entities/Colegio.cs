namespace Dominio.Entities
{
    public class Colegio : BaseEntity
    {
        public string NombreColegio {get; set;}
        public string DirreccionColegio {get; set;}
        public ICollection<Directivo> Directivos { get; set; } 
        public ICollection<Estudiante> Estudiantes { get; set; }
        public ICollection<Profesor> Profesores { get; set; }
    }
}