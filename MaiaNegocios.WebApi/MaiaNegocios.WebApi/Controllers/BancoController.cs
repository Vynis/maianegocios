using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaiaNegocios.Repository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaiaNegocios.WebApi.Controllers
{
    [ApiController]
    [Route("api/banco")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoController(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        [HttpGet("buscar-todos-bancos")]
        [AllowAnonymous]
        public async Task<IActionResult> BuscarTodosBancos()
        {
            try
            {
                var listaBancos = await _bancoRepository.ObterTodos();

                return Response(listaBancos);

            }
            catch (Exception ex)
            {

                return ResponseErro(ex);
            }
        }

    }
}