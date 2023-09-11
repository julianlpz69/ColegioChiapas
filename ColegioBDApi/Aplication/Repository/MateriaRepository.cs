using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data.Configurations;

namespace Aplication.Repository
{
    public class MateriaRepository : GenericRepository<Materia>, IMateria
    {
        private readonly ColegioDBContext _context;

        public MateriaRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}