using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.DataBase;
using Aula_09._06._2026.Models;
using Aula_09._06._2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aula_09._06._2026.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        FilmeDataBase dataBase = new();
        FilmeService services = new();

        [HttpGet("MostrarLista")]
        public IActionResult MostrarLista(bool popular)
        {
            Console.WriteLine("Atividade 24");
            if (popular) services.PopularLista(dataBase.filmes);

            string resposta = services.MostrarLista(dataBase.filmes);

            if (resposta != "")
            {
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("CadastrarFilme")]
        public IActionResult CadastrarFilme(string titulo, string classificacao, int duracao)
        {
            Console.WriteLine("Atividade 25");
            int local = services.ProcurarFilme(dataBase.filmes, titulo, classificacao, duracao, 0);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    Filme filme = new();
                    filme.Titulo = titulo;
                    filme.Classificacao = classificacao;
                    filme.Duracao = duracao;
                    filme.Id = dataBase.filmes.Count + 1;
                    dataBase.filmes.Add(filme);
                    return Created();
            }
        }

        [HttpPut("EditarFilme")]
        public IActionResult EditarFilme(int id, string novoTitulo, string novaClassificacao, int novaDuracao)
        {
            Console.WriteLine("Atividade 26");
            int local = services.ProcurarFilme(dataBase.filmes, "", "", 0, id);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    dataBase.filmes[local].Titulo = novoTitulo;
                    dataBase.filmes[local].Classificacao = novaClassificacao;
                    dataBase.filmes[local].Duracao = novaDuracao;
                    return NoContent();
            }
        }

        [HttpDelete("DeletarFilme")]
        public IActionResult DeletarFilme(int id)
        {
            Console.WriteLine("Atividade 27");
            int local = services.ProcurarFilme(dataBase.filmes, "", "", 0, id);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    dataBase.filmes.Remove(dataBase.filmes[local]);
                    return NoContent();
            }
        }
    }
}