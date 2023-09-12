using MediatR;

namespace Citel.Application.Notifications
{
    public class ProdutoCriadoNotification : INotification
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int Status { get; set; }
        public int categoriaId { get; set; }
        public DateTime DataCriado { get; set;}
    }
}
