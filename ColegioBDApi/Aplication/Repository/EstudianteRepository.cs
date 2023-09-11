using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudiante
    {
        private readonly ColegioDBContext _context;

        public EstudianteRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}