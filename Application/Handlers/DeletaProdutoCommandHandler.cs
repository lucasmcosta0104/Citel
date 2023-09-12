using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class DeletaProdutoCommandHandler : IRequestHandler<DeletaProdutoCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public DeletaProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeletaProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoNotification = _mapper.Map<ProdutoExcluidoNotification>(await _repository.Get(request.Id, cancellationToken));
                await _repository.Delete(request.Id, cancellationToken);
                await _mediator.Publish(produtoNotification);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
