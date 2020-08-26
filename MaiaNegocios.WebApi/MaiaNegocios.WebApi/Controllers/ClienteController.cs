using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaiaNegocios.Domain.Models;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _clienteRepository.ObterTodos();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _clienteRepository.ObterPorId(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }


        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var results = await _clienteRepository.Buscar(x => x.Name.Equals(nome));

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                _clienteRepository.Adicionar(model);

                if (await _clienteRepository.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

            return BadRequest();

        }


        [HttpPut]
        public async Task<IActionResult> Put(int clienteId, Cliente model)
        {
            try
            {

                var cliente = await _clienteRepository.ObterPorId(clienteId);

                if (cliente == null)
                    return NotFound();

                _clienteRepository.Atualizar(model);

                if (await _clienteRepository.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int clientId)
        {
            try
            {

                var cliente = await _clienteRepository.ObterPorId(clientId);

                if (cliente == null)
                    return NotFound();

                _clienteRepository.Remover(cliente);

                if (await _clienteRepository.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

            return BadRequest();

        }
    }
}
