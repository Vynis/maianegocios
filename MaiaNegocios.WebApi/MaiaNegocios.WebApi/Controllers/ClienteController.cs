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
    public class ClienteController : ControllerBase
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

                return Response(results);
            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _clienteRepository.ObterPorId(id);

                return Response(results);
            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }

        }


        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var results = await _clienteRepository.Buscar(x => x.Name.Equals(nome));

                return Response(results);
            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                var response = await _clienteRepository.Adicionar(model);

                if (response)
                  return  Response("Adicionado com sucesso!");

                return Response("Erro ao adicionar", false);

            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }

        }


        [HttpPut]
        public async Task<IActionResult> Put(int clienteId, Cliente model)
        {
            try
            {

                var cliente = await _clienteRepository.ObterPorId(clienteId);

                if (cliente == null)
                    return Response("Cliente nao encontrado", false);

                var response = await _clienteRepository.Atualizar(model);

                if (response)
                    return Response("Atualizado com sucesso!");

                return Response("Erro ao adicionar", false);

            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int clientId)
        {
            try
            {

                var cliente = await _clienteRepository.ObterPorId(clientId);

                if (cliente == null)
                    return Response("Cliente nao encontrado", false);

                var response =  await _clienteRepository.Remover(cliente);

                if (response)
                    return Response("Excluido com sucesso!");

                return Response("Erro ao excluir", false);

            }
            catch (Exception ex)
            {
                return ResponseErro(ex);
            }

        }
    }
}
