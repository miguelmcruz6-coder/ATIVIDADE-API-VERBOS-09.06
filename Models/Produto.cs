using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_09._06._2026.Models
{
    public class Produto
    {
        public string Nome { get; set; } = string.Empty;
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}