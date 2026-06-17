using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;

namespace Aula_09._06._2026.Services
{
    public class FilmeService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 clientes
        public void PopularLista(List<Filme> filmes)
        {
            for (int i = 0; i < 3; i++)
            {
                int numero = filmes.Count + 1;
                Filme filme = new();
                filme.Titulo = $"Terror N°{numero}";
                filme.Classificacao = "Terror";
                filme.Duracao = TempoAleatorio(filmes);
                filme.Id = numero;
                filmes.Add(filme);
            }
        }

        // Função para Procurar um filme por:
        // Título
        // Classificação
        // Duração
        // ID
        public int ProcurarFilme(List<Filme> filmes, string titulo, string classificacao, int duracao, int id)
        {
            int local = -1;
            for (int i = 0; i < filmes.Count; i++)
            {
                if ((titulo == filmes[i].Titulo && classificacao == filmes[i].Classificacao && duracao == filmes[i].Duracao) || id == filmes[i].Id)
                {
                    local = i;
                    break;
                    
                }
            }
            return local;
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<Filme> filmes, int local)
        {
            string resposta = $"Título: {filmes[local].Titulo}\nClassificação: {filmes[local].Classificacao}\nDuração: {filmes[local].Duracao}\nID: {filmes[local].Id}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Filme> pessoas)
        {
            string lista = "";
            for (int i = 0; i < pessoas.Count; i++)
            {
                lista += $"{MostrarUm(pessoas, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int TempoAleatorio(List<Filme> pessoas)
        {
            int tempo = random.Next(1, 4);
            return tempo;
        }
    }
}