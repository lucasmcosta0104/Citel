using Citel.Application.Models;
using Citel.Infra.Context;
using Citel.Interface;

namespace ProdutoApi.Infra.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Produto item, CancellationToken cancellationToken)
        {
            _context.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Add(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var produto = await Get(id, cancellationToken);
            _context.Remove(produto);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(Produto item, CancellationToken cancellationToken)
        {
            _context.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Produto?> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<Produto>().FindAsync(id, cancellationToken);
        }   

        public async Task<IEnumerable<Produto>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<Produto>().ToListAsync(cancellationToken);
        }
    }
}
