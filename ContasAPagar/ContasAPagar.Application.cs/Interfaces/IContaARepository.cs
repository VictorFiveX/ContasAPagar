using ContasAPagar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Application.Interfaces
{
    public interface IContaARepository
    {
        Task<ContaEntities> AdicionarAsync(ContaEntities conta);
        Task<List<ContaEntities>> ListarAsync();

    }
}
