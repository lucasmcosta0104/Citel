﻿using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;
using Citel.Interface;
using MediatR;

namespace Citel.Application.Handlers
{
    public class DeletaCategoriaCommandHandler : IRequestHandler<DeletaCategoriaCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public DeletaCategoriaCommandHandler(IMediator mediator, IRepository<Categoria> repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeletaCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaNotification = _mapper.Map<CategoriaExcluidoNotification>(await _repository.Get(request.Id, cancellationToken));
                await _repository.Delete(request.Id, cancellationToken);
                await _mediator.Publish(categoriaNotification);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Message = ex.Message, PilhaErro = ex.StackTrace ?? String.Empty });
            }
        }
    }
}
