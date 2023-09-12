using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class EditaCategoriaCommandHandler : IRequestHandler<EditaCategoriaCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public EditaCategoriaCommandHandler(IMediator mediator, IRepository<Categoria> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(EditaCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _repository.Get(request.Id, cancellationToken);
                await _repository.Edit(_mapper.Map<EditaCategoriaCommand, Categoria>(request, categoria), cancellationToken);
                await _mediator.Publish(_mapper.Map<EditaCategoriaNotification>(request));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
