using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class ColegioRepository : GenericRepository<Colegio>, IColegio
    {
        private readonly ColegioDBContext _context;

        public ColegioRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}