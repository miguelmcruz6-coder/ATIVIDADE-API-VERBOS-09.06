using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula_09._06._2026.Models.Pessoas;

namespace Aula_09._06._2026.DataBase
{
    public class PessoasDataBase
    {
        public List<IPessoa> pessoas = new()
        {
            new Cliente {Nome = "cliente"},
            new Funcionario {Nome = "funcionario"}
        };
    }
}