using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Domain.Entities
{
    [Table("Contas")]
    public class ContaEntities
    {
        public ContaEntities( string nome, decimal valorOriginal, DateTime dataVencimento, DateTime dataPagamento, decimal valorCorrigido, int diasAtraso)
        {
            Nome = nome;
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            ValorCorrigido = valorCorrigido;
            DiasAtraso = diasAtraso;
        }

        [Key]
        [Column("id_conta")]
        public int Id { get; private set; }

        [Column("nome_conta")]
        public string Nome { get; private set; }

        [Column("Valor_original")]
        public decimal ValorOriginal { get; private set; }

        [Column("Data_vencimento")]
        public DateTime DataVencimento { get; private set; }

        [Column("Data_pagamento")]
        public DateTime DataPagamento { get; private set; }

        [Column("Valor_corrigido")]
        public decimal ValorCorrigido { get;  set; }

        [Column("Dias_atraso")]
        public int DiasAtraso { get;  set; }
    }
}
