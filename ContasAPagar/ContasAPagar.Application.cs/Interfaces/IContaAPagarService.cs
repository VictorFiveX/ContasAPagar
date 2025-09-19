using ContasAPagar.Application.DTOs;
using ContasAPagar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Application.Interfaces
{
    public interface IContaAPagarService
    {
        Task<ContaEntities> CalcularContaAsync(ContaDTO conta);
        Task<List<ContaEntities>> ListarContasAsync();
    }
}
