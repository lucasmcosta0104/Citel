using MediatR;

namespace Citel.Application.Commands
{
    public class EditaCategoriaCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
