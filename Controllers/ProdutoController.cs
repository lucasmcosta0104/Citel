using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Query;
using Citel.Infra.Context;
using Citel.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Citel.Controllers
{
    public partial class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutoController(ApplicationDbContext context, IMediator mediator, IRepository<Produto> repository)
        {
            _context = context;
            _mediator = mediator;
            _repository = repository;
        }

        // GET: Produto
        public async Task<IActionResult> Index(int id)
        {
            ViewData["CategoriaId"] = new SelectList(await _mediator.Send(new ObterQueryCategoria { Categoria = ""}), "Id", "Nome");
            return View(await _mediator.Send(new ObterQueryProduto { Produto = string.Empty, IdCategoria = id}));
        }

        [HttpPost, ActionName("CadastraProduto")]
        public async Task<IActionResult> Post([Bind("Nome,Descricao,Preco,CategoriaId")] CadastraProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut, ActionName("EditarProduto")]
        public async Task<IActionResult> Put(EditaProdutoCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet, ActionName("ObterProduto")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _repository.Get(id, cancellationToken));
        }

        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeletaProdutoCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
