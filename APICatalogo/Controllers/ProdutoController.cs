using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext contexto)
        {
            _context = contexto;
        }


        //ignora o api/NomeControlador/primeiro e chama /primeiro somente
        //[HttpGet("primeiro")]
        [HttpGet("/primeiro")]
        [HttpGet("{valor:alpha:length(5)}")]
        public ActionResult<Produto> Get2(string valor)
        {
            var teste = valor;

            return _context.Produtos.FirstOrDefault();
        }


        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Produto>>> Getasync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public  async Task<ActionResult<Produto>> Get([FromQuery]int id, string nome)
        {
            var nomeProduto = nome;
            var produtos =  await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produtos == null)
            {
                return NotFound();
            }
            return produtos;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            //if(!ModelState.IsValid)
            //{
            //  return BadRequest(ModelState);

            //}
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);
            if (produto is null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }

    }
}
