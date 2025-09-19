using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Application.DTOs
{
    public class ContaDTO
    {
        public ContaDTO(string nome, decimal valorOriginal, DateTime dataVencimento, DateTime dataPagamento)
        {
            Nome = nome;
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
        }

        public string Nome { get;  set; }

        public decimal ValorOriginal { get;  set; }

        public DateTime DataVencimento { get;  set; }

        public DateTime DataPagamento { get;  set; }

    }
}
