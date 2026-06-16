using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.DataBase;
using Aula_09._06._2026.Models;
using Aula_09._06._2026.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aula_09._06._2026.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        LivroDataBase dataBase = new();
        LivroService services = new();

        [HttpGet("Listar")]
        public IActionResult ListarLivros(bool popular)
        {
            if(popular) services.PopularLista(dataBase.livros);

            string resposta = services.MostrarLista(dataBase.livros);

            if(resposta == "")
            {
                return NotFound();
            }
            else
            {
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
        }

        [HttpPost("AdicionarLivro")]
        public IActionResult AdicionarLivro(string titulo, int paginas)
        {
            int local = services.ProcurarLivro(dataBase.livros, titulo, paginas, 0);
            if(local == -1)
            {
                Livro livro = new();
                livro.Titulo = titulo;
                livro.Paginas = paginas;
                livro.Id = services.IdAleatorio(dataBase.livros);
                dataBase.livros.Add(livro);
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("EditarLivro")]
        public IActionResult EditarLivro(string novoTitulo, int novasPaginas, int idSelecionado)
        {
            int local = services.ProcurarLivro(dataBase.livros, "", 0, idSelecionado);
            if(local != -1)
            {
                dataBase.livros[local].Titulo = novoTitulo;
                dataBase.livros[local].Paginas = novasPaginas;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeletarLivro")]
        public IActionResult DeletarLivro(string titulo, int paginas, int id)
        {
            int local = services.ProcurarLivro(dataBase.livros, titulo, paginas, id);
            if(local != -1)
            {
                dataBase.livros.Remove(dataBase.livros[local]);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}