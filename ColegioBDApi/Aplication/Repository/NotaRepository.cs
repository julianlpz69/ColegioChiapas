using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class NotaRepository : GenericRepository<Nota>, INota
    {
       
        private readonly ColegioDBContext _context;

        public NotaRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    
    }
}