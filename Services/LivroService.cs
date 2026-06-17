using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;

namespace Aula_09._06._2026.Services
{
    public class LivroService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 livros
        public void PopularLista(List<Livro> livros)
        {
            for (int i = 0; i < 3; i++)
            {
                Livro livro = new();
                livro.Titulo = $"Terror N°{livros.Count}";
                livro.Paginas = random.Next(1, 91);
                livro.Id = IdAleatorio(livros);
                livros.Add(livro);
            }
        }

        // Função para Procurar um livro por:
        // Título e Páginas
        // ID
        public int ProcurarLivro(List<Livro> livros, string titulo, int paginas, int id)
        {
            int local = -1;
            if(titulo == "" && paginas == 0 && id == 0)
            {
                return -2;
            }
            for (int i = 0; i < livros.Count; i++)
            {
                if ((titulo == livros[i].Titulo && paginas == livros[i].Paginas) || id == livros[i].Id)
                {
                    local = i;
                    break;
                    
                }
            }
            return local;
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<Livro> livros, int local)
        {
            string resposta = $"Título: {livros[local].Titulo}\nNúmero de Páginas: {livros[local].Paginas}\nID: {livros[local].Id}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Livro> pessoas)
        {
            string lista = "";
            for (int i = 0; i < pessoas.Count; i++)
            {
                lista += $"{MostrarUm(pessoas, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int IdAleatorio(List<Livro> pessoas)
        {
            int id = random.Next(100000, 1000000);
            while (true)
            {
                if (ProcurarLivro(pessoas, "", 0, id) == -1)
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