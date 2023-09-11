namespace Dominio.Entities
{
    public class ProfesorMateria
    {
        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}
    }
}