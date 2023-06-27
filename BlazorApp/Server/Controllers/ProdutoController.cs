using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.DAOs;
using Server.Controllers.Extensoes;
using BlazorApp.Shared.DOs;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IList<ProdutoDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/AtletaRecord
        [HttpGet("mestre/{idMestre}")]
        public async Task<ActionResult<IList<ProdutoDO>>> GetPorIdMestre(string idMestre)
        {
            return Ok((await dao.RetornarPorIdMestreAsync(idMestre)).ToDO());
        }


        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<ProdutoDO>> Post(ProdutoDO objDO)
        {
            if (objDO == null)
                return Problem("O Produto que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();
            // objeto.Validade.ToString("yyyy-MM-dd");

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProdutoDO novoProdutoDO)
        {
            if (id != novoProdutoDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoProdutoDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private ProdutoDAO dao = new ProdutoDAO();
    }
}