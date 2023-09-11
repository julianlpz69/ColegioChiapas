using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class TipoDirectivoRepository : GenericRepository<TipoDirectivo>, ITipoDirectivo
    {
        private readonly ColegioDBContext _context;

        public TipoDirectivoRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}