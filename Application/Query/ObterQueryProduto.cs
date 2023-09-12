using Citel.Models;
using MediatR;

namespace Citel.Application.Query
{
    public class ObterQueryProduto : IRequest<List<ProdutoViewModel>>
    {
        public string Produto { get; set; }
        public int IdCategoria { get; set; }
    }
}
