namespace Dominio.Entities
{
    public class Profesor : PersonaClass
    {
        public string NivelAcceso = "Profesor";
        public int IdColegioFK {get; set;}
        public Colegio Colegio {get; set;}
        public ICollection<GrupoProfesor> GruposProfesores {get; set;}
        public ICollection<ProfesorMateria> ProfesoresMaterias {get; set;}
        public ICollection<Nota> Notas {get; set;}
    }
}