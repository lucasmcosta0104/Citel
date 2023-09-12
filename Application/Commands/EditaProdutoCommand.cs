using MediatR;

namespace Citel.Application.Commands
{
    public class EditaProdutoCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int Status { get; set; }
        public int categoriaId { get; set; }
    }
}
