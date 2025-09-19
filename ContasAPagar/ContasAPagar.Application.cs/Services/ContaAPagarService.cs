using ContasAPagar.Application.DTOs;
using ContasAPagar.Application.Interfaces;
using ContasAPagar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContasAPagar.Application.Services
{
    public class ContaAPagarService : IContaAPagarService
    {
        private readonly IContaARepository _contaRepository;

        public ContaAPagarService(IContaARepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<ContaEntities> CalcularContaAsync(ContaDTO conta)
        {
            int diasAtraso = (conta.DataPagamento - conta.DataVencimento).Days;
            if (diasAtraso < 0) diasAtraso = 0;

            decimal multa = 0;
            decimal jurosDia = 0;

            if (diasAtraso > 0 && diasAtraso <= 3)
            {
                multa = 0.02m;
                jurosDia = 0.001m;
            }
            else if (diasAtraso > 3 && diasAtraso <= 5)
            {
                multa = 0.03m;
                jurosDia = 0.002m;
            }
            else if (diasAtraso > 5)
            {
                multa = 0.05m;
                jurosDia = 0.003m;
            }
            var valorCorrigido = conta.ValorOriginal + (conta.ValorOriginal * multa) + (conta.ValorOriginal * jurosDia * diasAtraso);

            ContaEntities contaCalculada = new ContaEntities(
                conta.Nome,
                conta.ValorOriginal,
                conta.DataVencimento,
                conta.DataPagamento,
                valorCorrigido,
                diasAtraso
            );

            return await _contaRepository.AdicionarAsync(contaCalculada);
        }

        public async Task<List<ContaEntities>> ListarContasAsync()
        {
            return await _contaRepository.ListarAsync();
        }
    }
}
