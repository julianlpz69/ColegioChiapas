using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor> , IProfesor
    {
        private readonly ColegioDBContext _context;

        public ProfesorRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}