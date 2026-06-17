using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.DataBase;
using Aula_09._06._2026.Models;
using Aula_09._06._2026.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Aula_09._06._2026.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static ProdutoDataBase produtoDataBase = new();
        private static ProdutoService produtoService = new();


        [HttpGet("ListaProdutos")]
        public IActionResult Listar(bool popular)
        {
            Console.WriteLine("Atividade 1");
            if (popular)
            {
                produtoService.PopularLista(produtoDataBase.produtos);
            }

            string resposta = produtoService.MostrarLista(produtoDataBase.produtos);

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

        [HttpGet("ProcurarId")]
        public IActionResult ProcurarId(int id)
        {
            Console.WriteLine("Atividade 2");
            if (id <= 100000 || id >= 1000000)
            {
                return NoContent();
            }
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, "", 0, id);
            if (local != -1)
            {
                string resposta = produtoService.MostrarUm(produtoDataBase.produtos, local);
                return Ok(resposta);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("MaiorQue100")]
        public IActionResult MaiorQue100()
        {
            Console.WriteLine("Atividade 5");
            string resposta = "";
            for (int i = 0; i < produtoDataBase.produtos.Count; i++)
            {
                if (produtoDataBase.produtos[i].Preco > 100)
                {
                    resposta += produtoService.MostrarUm(produtoDataBase.produtos, i) + "\n\n";
                }
            }
            resposta = resposta.Substring(0, resposta.Length - 1);
            return Ok(resposta);
        }

        [HttpGet("ProcurarNome")]
        public IActionResult ProcurarNome(string nome, int preco, int id)
        {
            Console.WriteLine("Atividade 6");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, nome, preco, id);
            if (local != -1)
            {
                string resposta = produtoService.MostrarUm(produtoDataBase.produtos, local);
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(string nome, decimal preco)
        {
            Console.WriteLine("Atividade 7");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, nome, preco, 0);
            if (local == -1)
            {
                Produto produto = new();
                produto.Nome = nome;
                produto.Preco = preco;
                produto.Id = produtoService.IdAleatorio(produtoDataBase.produtos);
                produtoDataBase.produtos.Add(produto);
                return Created();
            }
            else if(local == -2)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("AlterarNome")]
        public IActionResult AlterarNome(int id, string nomeNovo)
        {
            Console.WriteLine("Atividade 13");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, "", 0, id);

            if(local == -2)
            {
                return BadRequest();
            }
            else if (local != -1)
            {
                produtoDataBase.produtos[local].Nome = nomeNovo;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("AlterarPreco")]
        public IActionResult AlterarPreco(string nome, decimal precoAntigo, decimal precoNovo)
        {
            Console.WriteLine("Atividade 14");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, nome, precoAntigo, 0);
            if (local != -1)
            {
                produtoDataBase.produtos[local].Preco = precoNovo;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("AlterarEstoque")]
        public IActionResult AlterarEstoque(string nome, int id, int novoEstoque)
        {
            Console.WriteLine("Atividade 18");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, nome, 0, id);
            if(local != -1)
            {
                produtoDataBase.produtos[local].Estoque = novoEstoque;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeletarProduto")]
        public IActionResult DeletarPorId(int id)
        {
            Console.WriteLine("Atividade 19");
            int local = produtoService.ProcurarProduto(produtoDataBase.produtos, "", 0, id);
            if (local != -1)
            {
                produtoDataBase.produtos.Remove(produtoDataBase.produtos[local]);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}