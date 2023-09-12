using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        public readonly ColegioDBContext _context;
        public  RolRepository(ColegioDBContext context) : base(context)
        {
            _context = context;
        }

    }
}