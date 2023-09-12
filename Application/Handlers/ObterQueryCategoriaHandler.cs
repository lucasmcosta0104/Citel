using AutoMapper;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Application.Query;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class ObterQueryCategoriaHandler : IRequestHandler<ObterQueryCategoria, List<Categoria>>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public ObterQueryCategoriaHandler(IMediator mediator, IRepository<Categoria> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Categoria>> Handle(ObterQueryCategoria request, CancellationToken cancellationToken)
        {
            try
            {
                return _repository.
                    GetAll(cancellationToken).Result.
                    Where(x => String.IsNullOrWhiteSpace(request.Categoria) || x.Nome.Contains(request.Categoria)).
                    ToList();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
                return new List<Categoria>();
            }
        }
    }
}
