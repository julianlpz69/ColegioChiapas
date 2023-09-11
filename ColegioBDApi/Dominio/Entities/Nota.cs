namespace Dominio.Entities
{
    public class Nota : BaseEntity
    {
        public double NotaExamenes {get; set;}
        public double NotaTalleres {get; set;}
        public double NotaAutoevaluacion {get; set;}
        public double NotaActitudinal {get; set;}
        public double NotaTareas {get; set;}

        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}
        public int IdBoletinFK {get; set;}
        public Boletin Boletin {get; set;}
    }
}