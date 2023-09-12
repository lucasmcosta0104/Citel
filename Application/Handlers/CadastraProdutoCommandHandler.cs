using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class CadastraProdutoCommandHandler : IRequestHandler<CadastraProdutoCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public CadastraProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CadastraProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Add(_mapper.Map<Produto>(request), cancellationToken);
                await _mediator.Publish(_mapper.Map<ProdutoCriadoNotification>(request));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
