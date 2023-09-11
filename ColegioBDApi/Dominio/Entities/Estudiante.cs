namespace Dominio.Entities
{
    public class Estudiante : PersonaClass
    {   public string NivelAcceso = "Estudiante";
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
        public int IdColegioFK {get; set;}
        public Colegio Colegio {get; set;}
        public ICollection<Nota> Notas {get; set;}
        public ICollection<Boletin> Boletines {get; set;}
        public ICollection<Matricula> Matriculas {get; set;}

    }
}