using MediatR;

namespace Citel.Application.Commands
{
    public class DeletaProdutoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
