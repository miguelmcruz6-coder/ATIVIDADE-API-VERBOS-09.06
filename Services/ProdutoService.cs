using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aula_09._06._2026.Services
{
    public class ProdutoService
    {
        private static Random random = new();

        // Função para Popular uma lista com 3 produtos
        public void PopularLista(List<Produto> produtos)
        {
            for (int i = 0; i < 3; i++)
            {
                Produto produto = new();
                produto.Nome = $"Rosa {i + 1}";
                produto.Id = IdAleatorio(produtos);
                produto.Preco = (499 / 100);
                produto.Estoque = 1;
                produtos.Add(produto);
            }
        }

        // Função para Procurar um item
        public int ProcurarProduto(List<Produto> produtos, string nome, decimal preco, int id)
        {
            int local = -1;
            if(nome == "" && preco == 0 && id == 0)
            {
                return -2;
            }
            for (int i = 0; i < produtos.Count; i++)
            {
                if ((nome == produtos[i].Nome && preco == produtos[i].Preco) || id == produtos[i].Id)
                {
                    local = i;
                    break;
                }
            }
            return local;
        }

        // Função para Escrever um item
        public string MostrarUm(List<Produto> produtos, int local)
        {
            string resposta = $"Nome: {produtos[local].Nome}\nPreço: {produtos[local].Preco}\nID: {produtos[local].Id}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Produto> produtos)
        {
            string lista = "";
            for (int i = 0; i < produtos.Count; i++)
            {
                lista += $"{MostrarUm(produtos, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int IdAleatorio(List<Produto> produtos)
        {
            int id = random.Next(100000, 1000000);
            while (true)
            {
                if (ProcurarProduto(produtos, "", -10, id) == -1)
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