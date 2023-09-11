using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class GrupoRepository : GenericRepository<Grupo>, IGrupo
    {
        private readonly ColegioDBContext _context;

        public GrupoRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}
