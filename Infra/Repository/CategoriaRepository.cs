using Citel.Application.Models;
using Citel.Infra.Context;
using Citel.Interface;
namespace Citel.Infra.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Categoria item, CancellationToken cancellationToken)
        {
            _context.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var produto = await Get(id, cancellationToken);
            _context.Remove(produto);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(Categoria item, CancellationToken cancellationToken)
        {
            _context.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Categoria?> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<Categoria>().FindAsync(id, cancellationToken);
        }   

        public async Task<IEnumerable<Categoria>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<Categoria>().ToListAsync(cancellationToken);
        }
    }
}
