using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class EditaProdutoCommandHandler : IRequestHandler<EditaProdutoCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public EditaProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(EditaProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _repository.Get(request.Id, cancellationToken);
                await _repository.Edit(_mapper.Map<EditaProdutoCommand, Produto>(request, produto), cancellationToken);
                await _mediator.Publish(_mapper.Map<EditaProdutoNotification>(request));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
