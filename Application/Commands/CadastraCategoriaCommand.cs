using MediatR;

namespace Citel.Application.Commands
{
    public class CadastraCategoriaCommand : IRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
