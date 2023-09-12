using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class CadastraCategoriaCommandHandler : IRequestHandler<CadastraCategoriaCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CadastraCategoriaCommandHandler(IMediator mediator, IRepository<Categoria> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CadastraCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Add(_mapper.Map<Categoria>(request), cancellationToken);
                await _mediator.Publish(_mapper.Map<CategoriaCriadoNotification>(request));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
