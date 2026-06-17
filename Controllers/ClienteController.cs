using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.DataBase;
using Aula_09._06._2026.Models.Pessoas;
using Aula_09._06._2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aula_09._06._2026.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private PessoasDataBase pessoasDataBase = new();
        private ClienteService clienteService = new();

        [HttpGet("ListarClientes")]
        public IActionResult Listar(bool popular)
        {
            Console.WriteLine("Atividade 3");
            if (popular)
            {
                clienteService.PopularLista(pessoasDataBase.pessoas);
            }

            string resposta = clienteService.MostrarLista(pessoasDataBase.pessoas);

            if (resposta == "")
            {
                return NoContent();
            }
            else
            {
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
        }

        [HttpPost("CadastrarCliente")]
        public IActionResult CadastrarCliente(string nome)
        {
            Console.WriteLine("Atividade 8");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, 0, 0);
            switch (local)
            {
                case -1:
                    Cliente cliente = new();
                    cliente.Nome = nome;
                    cliente.Id = clienteService.IdAleatorio(pessoasDataBase.pessoas);
                    pessoasDataBase.pessoas.Add(cliente);
                    return Created();

                default:
                    return BadRequest();
            }
        }

        [HttpPost("CadastrarFuncionario")]
        public IActionResult CadastrarFuncionario(string nome)
        {
            Console.WriteLine("Atividade 12");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, 0, 0);
            switch (local)
            {
                case -1:
                    Funcionario funcionario = new();
                    funcionario.Nome = nome;
                    funcionario.Id = clienteService.IdAleatorio(pessoasDataBase.pessoas);
                    pessoasDataBase.pessoas.Add(funcionario);
                    return Created();

                default:
                    return BadRequest();
            }
        }

        [HttpPut("AlterarPorId")]
        public IActionResult AlterarId(string nome, int id, string novoNome)
        {
            Console.WriteLine("Atividade 15");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, id, 1);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    pessoasDataBase.pessoas[local].Nome = novoNome;
                    return NoContent();
            }
        }

        [HttpDelete("DeletarCliente")]
        public IActionResult DeletarPorId(int id)
        {
            Console.WriteLine("Atividade 20");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, "", id, 1);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    pessoasDataBase.pessoas.Remove(pessoasDataBase.pessoas[local]);
                    return NoContent();
            }
        }
    }
}