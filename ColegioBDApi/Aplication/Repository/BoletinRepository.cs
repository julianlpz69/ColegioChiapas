using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class BoletinRepository : GenericRepository<Boletin>, IBoletin
    {
        private readonly ColegioDBContext _context;

        public BoletinRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}