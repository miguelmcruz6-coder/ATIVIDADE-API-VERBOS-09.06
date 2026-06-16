using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_09._06._2026.Models.Pessoas
{
    public interface IPessoa
    {
        public string Nome { get; set; }
        public int Id { get; set; }
    }
}