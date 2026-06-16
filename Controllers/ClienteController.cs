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
            Console.WriteLine("Atividade 1");
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
            Console.WriteLine("Atividade 7");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, 0, 0);
            if (local == -1)
            {
                Cliente cliente = new();
                cliente.Nome = nome;
                cliente.Id = clienteService.IdAleatorio(pessoasDataBase.pessoas);
                pessoasDataBase.pessoas.Add(cliente);
                return Created();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("CadastrarFuncionario")]
        public IActionResult CadastrarFuncionario(string nome)
        {
            Console.WriteLine("Atividade 7");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, 0, 0);
            if (local == -1)
            {
                Funcionario funcionario = new();
                funcionario.Nome = nome;
                funcionario.Id = clienteService.IdAleatorio(pessoasDataBase.pessoas);
                pessoasDataBase.pessoas.Add(funcionario);
                return Created();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("AlterarPorId")]
        public IActionResult AlterarId(string nome, int id, string novoNome)
        {
            Console.WriteLine("Atividade 14");
            if (id <= 100000 || id >= 1000000)
            {
                return NotFound();
            }
            else
            {
                int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, nome, id, 1);
                if (local != -1)
                {
                    pessoasDataBase.pessoas[local].Nome = novoNome;
                    string resposta = "Nome trocado com sucesso!";
                    return Ok(resposta);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpDelete("DeletarCliente")]
        public IActionResult DeletarPorId(int id)
        {
            Console.WriteLine("Atividade 20");
            int local = clienteService.ProcurarCliente(pessoasDataBase.pessoas, "", id, 1);
            if (local != -1)
            {
                string resposta = $"Removendo {pessoasDataBase.pessoas[local].Nome} da Lista...\nCliente removido com sucesso!";
                pessoasDataBase.pessoas.Remove(pessoasDataBase.pessoas[local]);
                return Ok(resposta);
            }
            else
            {
                return NotFound();
            }
        }
    }
}