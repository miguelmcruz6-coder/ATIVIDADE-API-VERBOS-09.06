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
    public class JogoController : ControllerBase
    {
        JogoDataBase dataBase = new();
        JogoService services = new();

        [HttpGet("Listar")]
        public IActionResult ListarJogos(bool popular)
        {
            if (popular) services.PopularLista(dataBase.jogos);

            string resposta = services.MostrarLista(dataBase.jogos);

            if (resposta == "")
            {
                return NotFound();
            }
            else
            {
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
        }

        [HttpPost("AdicionarJogo")]
        public IActionResult AdicionarJogo(string titulo, string categoria, string plataforma)
        {
            int local = services.ProcurarJogo(dataBase.jogos, titulo, categoria, plataforma);
            switch (local)
            {
                case -1:
                    Jogo jogo = new();
                    jogo.Titulo = titulo;
                    jogo.Categoria = categoria;
                    jogo.Plataforma = plataforma;
                    dataBase.jogos.Add(jogo);
                    return Created();

                default:
                    dataBase.jogos.Remove(dataBase.jogos[local]);
                    return BadRequest();
            }
        }

        [HttpPut("EditarJogo")]
        public IActionResult EditarJogo(string titulo, string categoria, string plataforma, string novotitulo, string novacategoria, string novaplataforma)
        {
            int local = services.ProcurarJogo(dataBase.jogos, titulo, categoria, plataforma);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    dataBase.jogos[local].Titulo = novotitulo;
                    dataBase.jogos[local].Categoria = novacategoria;
                    dataBase.jogos[local].Plataforma = novaplataforma;
                    return NoContent();
            }
        }

        [HttpDelete("DeletarJogo")]
        public IActionResult DeletarJogo(string titulo, string Plataforma, string categoria)
        {
            int local = services.ProcurarJogo(dataBase.jogos, titulo, Plataforma, categoria);
            switch (local)
            {
                case -2:
                    return BadRequest();

                case -1:
                    return NotFound();

                default:
                    dataBase.jogos.Remove(dataBase.jogos[local]);
                    return NoContent();
            }
        }
    }
}