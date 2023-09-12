using AutoMapper;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Application.Query;
using Citel.Interface;
using Citel.Models;
using MediatR;

namespace Citel.Application.Handlers
{
    public class ObterQueryProdutoHandler : IRequestHandler<ObterQueryProduto, List<ProdutoViewModel>>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public ObterQueryProdutoHandler(IMediator mediator, IRepository<Produto> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoViewModel>> Handle(ObterQueryProduto request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<List<ProdutoViewModel>>(_repository
                    .GetAll(cancellationToken).Result
                    .Where(x => ((String.IsNullOrWhiteSpace(request.Produto) || x.Nome.Contains(request.Produto)) && request.IdCategoria == 0) || (request.IdCategoria == x.CategoriaId))
                    .ToList());
            }catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
                return new List<ProdutoViewModel>();
            }
        }
    }
}
