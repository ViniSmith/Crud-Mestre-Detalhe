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
    public class EstoqueController : ControllerBase
    {
        // GET: api/Atleta
        [HttpGet]
        public async Task<ActionResult<IList<EstoqueDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/Atleta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/Atleta
        [HttpPost]
        public async Task<ActionResult<EstoqueDO>> Post(EstoqueDO objDO)
        {
            if (objDO == null)
                return Problem("O Estoque que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Atleta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EstoqueDO novoEstoqueDO)
        {
            if (id != novoEstoqueDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoEstoqueDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Atleta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private EstoqueDAO dao = new EstoqueDAO();
    }
}