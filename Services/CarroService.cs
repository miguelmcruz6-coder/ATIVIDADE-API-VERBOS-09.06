using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models;

namespace Aula_09._06._2026.Services
{
    public class CarroService
    {
        private static Random random = new();

        // Função para Popular a lista com 3 clientes
        public async void PopularLista(List<Carro> carros)
        {
            for (int i = 0; i < 3; i++)
            {
                Carro carro = new();
                carro.Marca = $"Aleatorio N°{carros.Count}";
                carro.Modelo = $"Aleatorio N°{carros.Count}";
                carro.Placa = $"{PlacaAleatorio(carros)}";
                carro.Ano = AnoAleatorio(carros);
                carros.Add(carro);
            }
        }

        // Função para Procurar um filme por:
        // Título
        // Classificação
        // Duração
        // ID
        public int ProcurarCarro(List<Carro> carros, string marca, string modelo, int ano, string placa)
        {
            int local = -1;
            for (int i = 0; i < carros.Count; i++)
            {
                if ((marca == carros[i].Marca && modelo == carros[i].Modelo && ano == carros[i].Ano) || placa == carros[i].Placa)
                {
                    local = i;
                    break;

                }
            }
            return local;
        }

        // Função para Escrever um item da lista
        public string MostrarUm(List<Carro> carros, int local)
        {
            string resposta = $"Marca: {carros[local].Marca}\nModelo: {carros[local].Modelo}\nPlaca: {carros[local].Placa}\nAno: {carros[local].Ano}";
            return resposta;
        }

        // Função para Mostrar a Lista
        public string MostrarLista(List<Carro> carros)
        {
            string lista = "";
            for (int i = 0; i < carros.Count; i++)
            {
                lista += $"{MostrarUm(carros, i)}\n\n";
            }
            return lista;
        }

        // Função para Criar um ID Único
        public int AnoAleatorio(List<Carro> pessoas)
        {
            int ano = random.Next(1890, 2026);
            while (true)
            {
                if (ProcurarCarro(pessoas, "", "", ano, "") == -1)
                {
                    break;
                }
                else
                {
                    ano = random.Next(1890, 2026);
                }
            }
            return ano;
        }

        // Função para Criar um ID Único
        public string PlacaAleatorio(List<Carro> pessoas)
        {
            string placa = "";
            while (true)
            {
                placa = "";
                for (int i = 0; i < 3; i++)
                {
                    placa += LetraAleatoria();
                }
                placa += $"{random.Next(1, 9)}{LetraAleatoria()}";
                placa += $"{random.Next(1, 9)}{random.Next(1, 9)}";
                if (ProcurarCarro(pessoas, "", "", 0, placa) == -1)
                {
                    break;
                }
            }
            return placa;
        }

        public string LetraAleatoria()
        {
            string letra = "ABCDEFGHIJ";
            int posicaoLetra = random.Next(1, 11);
            letra = letra.Substring(posicaoLetra, posicaoLetra + 1);
            return letra;
        }
    }
}