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
    public class AlunoController : ControllerBase
    {
        private AlunoDataBase alunoDataBase = new();
        private AlunoService alunoService = new();

        [HttpGet("ListarAlunos")]
        public IActionResult ListarAlunos(bool popular)
        {
            Console.WriteLine("Atividade 4");
            if (popular)
            {
                alunoService.PopularLista(alunoDataBase.alunos);
            }
            
            string resposta = alunoService.MostrarLista(alunoDataBase.alunos);

            if(resposta != "") 
            {
                resposta = resposta.Substring(0, resposta.Length - 1);
                return Ok(resposta);
            }
            else 
            {
                return NoContent();
            }
        }

        [HttpPost("CadastrarAluno")]
        public IActionResult CadastrarAluno(string nome)
        {
            Console.WriteLine("Atividade 9");
            Aluno aluno = new();
            aluno.Nome = nome;
            aluno.Id = alunoService.IdAleatorio(alunoDataBase.alunos);
            alunoDataBase.alunos.Add(aluno);
            string resposta = "Novo aluno criado\n";
            resposta += alunoService.MostrarUm(alunoDataBase.alunos, alunoDataBase.alunos.Count - 1);
            return Ok(resposta);
        }
        
        [HttpPost("AtualizarAluno")]
        public IActionResult AtualizarAluno(string nome, int id)
        {
            Console.WriteLine("Atividade 16");
            int local = alunoService.ProcurarAluno(alunoDataBase.alunos, "", id);
            if(local != -1)
            {
                alunoDataBase.alunos[local].Nome = nome;
                string resposta = "Nome trocado com sucesso\n";
                resposta += alunoService.MostrarUm(alunoDataBase.alunos, local);
                return Ok(resposta);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost("DeletarAluno")]
        public IActionResult DeletarAluno(int id)
        {
            Console.WriteLine("Atividade 21");
            int local = alunoService.ProcurarAluno(alunoDataBase.alunos, "", id);
            if(local != -1)
            {
                alunoDataBase.alunos.Remove(alunoDataBase.alunos[local]);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}