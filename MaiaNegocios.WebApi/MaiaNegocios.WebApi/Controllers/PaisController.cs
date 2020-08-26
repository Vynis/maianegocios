using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaiaNegocios.Domain;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private readonly IPaisRepository _paisRepository;

        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _paisRepository.ObterTodos();

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
                var results = await _paisRepository.ObterPorId(id);

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
                var results = await _paisRepository.Buscar(x => x.Name.Equals(nome));

                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Pais model)
        {
            try
            {
                _paisRepository.Adicionar(model);

                if (await _paisRepository.SaveChangesAsync())
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
        public async Task<IActionResult> Put(int paisId, Pais model)
        {
            try
            {

                var pais = await _paisRepository.ObterPorId(paisId);

                if (pais == null)
                    return NotFound();

                _paisRepository.Atualizar(model);

                if (await _paisRepository.SaveChangesAsync())
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
        public async Task<IActionResult> Delete(int paisId)
        {
            try
            {

                var pais = await _paisRepository.ObterPorId(paisId);

                if (pais == null)
                    return NotFound();

                _paisRepository.Remover(pais);

                if (await _paisRepository.SaveChangesAsync())
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
