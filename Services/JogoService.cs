using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;

namespace Aula_09._06._2026.Services
{
    public class JogoService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 jogos
        public void PopularLista(List<Jogo> jogos)
        {
            for (int i = 0; i < 3; i++)
            {
                Jogo jogo = new();
                jogo.Titulo = $"Aleatorio N°{jogos.Count}";
                jogo.Plataforma = "Computador";
                jogo.Categoria = CategoriaAleatoria();
                jogos.Add(jogo);
            }
        }

        // Função para Procurar um jogo por:
        // Título e Categoria e Platafornma
        public int ProcurarJogo(List<Jogo> jogos, string titulo, string categoria, string plataforma)
        {
            int local = -1;
            if (titulo == "" && categoria == "" && plataforma == "")
            {
                return -2;
            }
            else
            {
                for (int i = 0; i < jogos.Count; i++)
                {
                    if (titulo == jogos[i].Titulo && categoria == jogos[i].Categoria && plataforma == jogos[i].Plataforma)
                    {
                        local = i;
                        break;

                    }
                }
                return local;
            }
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<Jogo> jogos, int local)
        {
            string resposta = $"Título: {jogos[local].Titulo}\nCategoria: {jogos[local].Categoria}\nPlataforma: {jogos[local].Plataforma}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Jogo> jogos)
        {
            string lista = "";
            for (int i = 0; i < jogos.Count; i++)
            {
                lista += $"{MostrarUm(jogos, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public string CategoriaAleatoria()
        {
            int ano = random.Next(0, 2026);
            string categoria = "";
            switch (ano)
            {
                case 0:
                    categoria = "Terror";
                    break;
                case 1:
                    categoria = "Ação";
                    break;
                case 2:
                    categoria = "Aventura";
                    break;
                case 3:
                    categoria = "RPG";
                    break;
                case 4:
                    categoria = "Corrida";
                    break;
                default:
                    categoria = "Não Definido";
                    break;
            }
            return categoria;
        }
    }
}