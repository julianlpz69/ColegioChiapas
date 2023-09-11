namespace Dominio.Entities
{
    public class Grupo : BaseEntity
    {
        public string NombreGrupo {get; set;}
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<GrupoMateria> GruposMaterias { get; set; } 
        public ICollection<GrupoProfesor> GruposProfesores { get; set; }

        public int CantidadDeEstudiantes
        {
            get { return Estudiantes.Count; }
        }
    }
}