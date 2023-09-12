using Aplication.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ColegioDBContext _context;
        private  BoletinRepository _boletin;
        private ColegioRepository _colegio;
        private DirectivoRepository _directivo;
        private EstudianteRepository _estudiante;
        private GrupoRepository _grupo;
        private MateriaRepository _materia;
        private MatriculaRepository _matricula;
        private NotaRepository _nota;
        private ProfesorRepository _profesor;
        private TipoDirectivoRepository _tipoDirectivo;
         private  RolRepository _rol;
        private UserRepository _user;
        
        public UnitOfWork(ColegioDBContext context){

            _context = context;
        }


        public IBoletin Boletines
        {
            get{
                if (_boletin == null)
                {
                    _boletin = new BoletinRepository(_context);
                }
                return _boletin;
            }
        }


        public IColegio Colegios
        {
            get{
                if (_colegio == null)
                {
                    _colegio = new ColegioRepository(_context);
                }
                return _colegio;
            }
        }


        public IDirectivo Directivos
        {
            get{
                if (_directivo == null)
                {
                    _directivo = new DirectivoRepository(_context);
                }
                return _directivo;
            }
        }


        public IEstudiante Estudiantes
        {
            get{
                if (_estudiante == null)
                {
                    _estudiante = new EstudianteRepository(_context);
                }
                return _estudiante;
            }
        }


        public IGrupo Grupos
        {
            get{
                if (_grupo == null)
                {
                    _grupo = new GrupoRepository(_context);
                }
                return _grupo;
            }
        }


        public IMateria Materias
        {
            get{
                if (_materia == null)
                {
                    _materia = new MateriaRepository(_context);
                }
                return _materia;
            }
        }


        public IMatricula Matriculas
        {
            get{
                if (_matricula == null)
                {
                    _matricula = new MatriculaRepository(_context);
                }
                return _matricula;
            }
        }
       

       public INota Notas
       {
        get{
            if (_nota == null)
            {
                _nota = new NotaRepository(_context);
            }
            return _nota;
        }
       }

       public IProfesor Profesores
       {
        get{
            if (_profesor == null)
            {
                _profesor = new ProfesorRepository(_context);
            }
            return _profesor;
        }
       }

       public ITipoDirectivo TiposDirectivos 
       {
        get{
            if (_tipoDirectivo == null)
            {
                _tipoDirectivo = new TipoDirectivoRepository(_context);
            }
            return _tipoDirectivo;
        }
       }

        public IRol Roles{
            get{
                if(_rol == null)
                {
                    _rol = new RolRepository(_context);
                }
                return _rol;
            }
        }


         public IUser Users{
            get{
                if(_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}