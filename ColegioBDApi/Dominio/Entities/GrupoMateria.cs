namespace Dominio.Entities
{
    public class GrupoMateria
    {
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
    }
}