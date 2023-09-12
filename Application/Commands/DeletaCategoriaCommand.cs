using MediatR;

namespace Citel.Application.Commands
{
    public class DeletaCategoriaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
