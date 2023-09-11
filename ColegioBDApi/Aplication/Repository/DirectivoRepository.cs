using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class DirectivoRepository : GenericRepository<Directivo>, IDirectivo
    {
        private readonly ColegioDBContext _context;

        public DirectivoRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}