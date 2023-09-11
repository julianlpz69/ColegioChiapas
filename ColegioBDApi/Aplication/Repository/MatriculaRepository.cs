using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class MatriculaRepository : GenericRepository<Matricula>, IMatricula
    {
        private readonly ColegioDBContext _context;

        public MatriculaRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}