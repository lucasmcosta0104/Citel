using Citel.Application.Models;
using MediatR;

namespace Citel.Application.Query
{
    public class ObterQueryCategoria : IRequest<List<Categoria>>
    {
        public string Categoria { get; set; }
    }
}
