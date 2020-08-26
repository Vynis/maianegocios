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
    public class PlanoController : Controller
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _planoRepository.ObterTodos();

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
                var results = await _planoRepository.ObterPorId(id);

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
                var results = await _planoRepository.Buscar(x => x.Name.Equals(nome));

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Plano model)
        {
            try
            {
                _planoRepository.Adicionar(model);

                if (await _planoRepository.SaveChangesAsync())
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
        public async Task<IActionResult> Put(int planoId, Plano model)
        {
            try
            {

                var plano = await _planoRepository.ObterPorId(planoId);

                if (plano == null)
                    return NotFound();

                _planoRepository.Atualizar(model);

                if (await _planoRepository.SaveChangesAsync())
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
        public async Task<IActionResult> Delete(int planoId)
        {
            try
            {

                var plano = await _planoRepository.ObterPorId(planoId);

                if (plano == null)
                    return NotFound();

                _planoRepository.Remover(plano);

                if (await _planoRepository.SaveChangesAsync())
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
