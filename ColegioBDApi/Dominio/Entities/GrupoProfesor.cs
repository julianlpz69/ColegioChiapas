namespace Dominio.Entities
{
    public class GrupoProfesor
    {
        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
    }
}