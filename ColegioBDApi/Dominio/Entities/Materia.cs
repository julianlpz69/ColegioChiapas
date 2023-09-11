namespace Dominio.Entities
{
    public class Materia : BaseEntity
    {
        public string NombreMateria {get; set;}
        public int HorasSemanales {get; set;}
        public ICollection<ProfesorMateria> ProfesoresMaterias {get; set;}
        public ICollection<GrupoMateria> GruposMaterias {get; set;}
        public ICollection<Nota> Notas {get; set;}
    }
}