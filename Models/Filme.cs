using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_09._06._2026.Models
{
    public class Filme
    {
        public string Titulo { get; set; } = string.Empty;
        public string Classificacao { get; set; } = string.Empty;
        public int Duracao { get; set; }
        public int Id { get; set; }
    }
}