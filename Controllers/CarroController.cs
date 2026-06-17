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
    public class CarroController : ControllerBase
    {
        CarroDataBase dataBase = new();
        CarroService services = new();

        [HttpGet("Listar")]
        public IActionResult ListarCarros(bool popular)
        {
            if (popular) services.PopularLista(dataBase.carros);

            string resposta = services.MostrarLista(dataBase.carros);

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

        [HttpPost("AdicionarLivro")]
        public IActionResult AdicionarCarro(string marca, string modelo, int ano, string placa)
        {
            int local = services.ProcurarCarro(dataBase.carros, marca, modelo, ano, placa);
            if (local == -1)
            {
                Carro carro = new();
                carro.Marca = marca;
                carro.Modelo = modelo;
                if (ano > 1890 && ano < 2027)
                {
                    carro.Ano = services.AnoAleatorio();
                }
                else
                {
                    carro.Ano = ano;
                }

                if(placa.Length != 7)
                {
                    carro.Placa = services.PlacaAleatorio(dataBase.carros);
                }
                else
                {
                    carro.Placa = placa;
                }
                dataBase.carros.Add(carro);
                return Created();
            }
            else if (local == -2)
            {
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("EditarLivro")]
        public IActionResult EditarCarro(string novaMarca, string novoModelo, int novoAno, string placaSelecionada)
        {
            int local = services.ProcurarCarro(dataBase.carros, "", "", 0, placaSelecionada);
            if (local != -1)
            {
                dataBase.carros[local].Marca = novaMarca;
                dataBase.carros[local].Modelo = novoModelo;
                switch (novoAno)
                {
                    case 0:
                        dataBase.carros[local].Ano = services.AnoAleatorio();
                        break;
                    default:
                        dataBase.carros[local].Ano = novoAno;
                        break;
                }
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeletarLivro")]
        public IActionResult DeletarCarro(string marca, string modelo, int ano, string placa)
        {
            int local = services.ProcurarCarro(dataBase.carros, marca, modelo, ano, placa);
            if (local != -1)
            {
                dataBase.carros.Remove(dataBase.carros[local]);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}