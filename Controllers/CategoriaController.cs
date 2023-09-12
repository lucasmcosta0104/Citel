using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Query;
using Citel.Infra.Context;
using Citel.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IRepository<Categoria> _repository;

        public CategoriaController(ApplicationDbContext context, IMediator mediator, IRepository<Categoria> repository)
        {
            _context = context;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _mediator.Send(new ObterQueryCategoria { Categoria = string.Empty }));
        }

        [HttpPost, ActionName("CadastraCategoria")]
        public async Task<IActionResult> CadastraCategoria([Bind("Nome,Descricao")] CadastraCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet, ActionName("ObterCategoria")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpGet, ActionName("ObterCategorias")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(cancellationToken));
        }

        [HttpPut, ActionName("EditarCategoria")]
        public async Task<IActionResult> Put(EditaCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeletaCategoriaCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
