using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;
using Aula_09._06._2026.Models.Pessoas;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aula_09._06._2026.Services
{
    public class AlunoService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 alunos
        public void PopularLista(List<Aluno> alunos)
        {
            for (int i = 0; i < 3; i++)
            {
                Aluno aluno = new();
                aluno.Nome = $"Cliente {i + 1}";
                aluno.Id = IdAleatorio(alunos);
                alunos.Add(aluno);
            }
        }

        // Função para Procurar um aluno
        public int ProcurarAluno(List<Aluno> alunos, string nome, int id)
        {
            int local = -1;
            if(nome == "" && id == 0)
            {
                return -2;
            }
            for (int i = 0; i < alunos.Count; i++)
            {
                if (nome == alunos[i].Nome || id == alunos[i].Id)
                {
                    local = i;
                    break;
                }
            }
            return local;
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<Aluno> alunos, int local)
        {
            string resposta = $"Nome: {alunos[local].Nome}\nID: {alunos[local].Id}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Aluno> alunos)
        {
            string lista = "";
            for (int i = 0; i < alunos.Count; i++)
            {
                lista += $"{MostrarUm(alunos, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int IdAleatorio(List<Aluno> alunos)
        {
            int id = random.Next(100000, 1000000);
            while (true)
            {
                if (ProcurarAluno(alunos, "", id) == -1)
                {
                    break;
                }
                else
                {
                    id = random.Next(100000, 1000000);
                }
            }
            return id;
        }
    }
}