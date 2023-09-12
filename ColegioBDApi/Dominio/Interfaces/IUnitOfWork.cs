namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
         Task<int> SaveAsync();
         IBoletin Boletines {get;}
         IColegio Colegios {get;}
         IDirectivo Directivos {get;}
         IEstudiante Estudiantes {get;}
         IGrupo Grupos {get;}
         IMateria Materias {get;}
         IMatricula Matriculas {get;}
         INota Notas {get;}
         IProfesor Profesores {get;}
         ITipoDirectivo TiposDirectivos {get;}
         IRol Roles { get; }
         IUser Users { get; }


    }
}