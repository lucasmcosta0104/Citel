using MediatR;

namespace Citel.Application.Commands
{
    public class CadastraProdutoCommand : IRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
