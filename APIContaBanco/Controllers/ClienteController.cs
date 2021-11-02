using APIContaBanco.Context;
using APIContaBanco.Models;
using APIContaBanco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Controllers
{
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IUnityOfWork _uof;

        public ClienteController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await _uof.clienteRepository.GetAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> Get(long id)
        {
            var cliente = await _uof.clienteRepository.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            await _uof.clienteRepository.InsertAsync(cliente);
            await _uof.CommitAsync();
            return new CreatedAtRouteResult("GetCliente", new { id = cliente.Id}, cliente);
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _uof.clienteRepository.Update(cliente);
            await _uof.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(long id)
        {
            var cliente = await _uof.clienteRepository.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _uof.clienteRepository.Delete(cliente);
            await _uof.CommitAsync();

            return Ok(cliente);
        }
    }
}
