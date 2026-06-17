using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;
using Aula_09._06._2026.Models.Pessoas;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aula_09._06._2026.Services
{
    public class ClienteService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 clientes
        public void PopularLista(List<IPessoa> pessoas)
        {
            for (int i = 0; i < 3; i++)
            {
                Cliente cliente = new();
                cliente.Nome = $"Cliente {i + 1}";
                cliente.Id = IdAleatorio(pessoas);
                pessoas.Add(cliente);
            }
        }

        // Função para Procurar uma pessoa onde:
        // 0 é o geral
        // 1 é um Cliente
        // 2 é um Funcionário
        public int ProcurarCliente(List<IPessoa> pessoas, string nome, int id, int classe)
        {
            int local = -1;
            for (int i = 0; i < pessoas.Count; i++)
            {
                if (nome == pessoas[i].Nome || id == pessoas[i].Id)
                {
                    if (classe == 1 && pessoas[i] is Cliente)
                    {
                        local = i;
                        break;
                    }
                    else if (classe == 2 && pessoas[i] is Funcionario)
                    {
                        local = i;
                        break;
                    }
                    else if (classe == 0)
                    {
                        local = i;
                        break;
                    }
                }
            }
            return local;
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<IPessoa> pessoas, int local)
        {
            string resposta = $"Nome: {pessoas[local].Nome}\nID: {pessoas[local].Id}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<IPessoa> pessoas)
        {
            string lista = "";
            for (int i = 0; i < pessoas.Count; i++)
            {
                lista += $"{MostrarUm(pessoas, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int IdAleatorio(List<IPessoa> pessoas)
        {
            int id = random.Next(100000, 1000000);
            while (true)
            {
                if (ProcurarCliente(pessoas, "", id, 0) == -1)
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