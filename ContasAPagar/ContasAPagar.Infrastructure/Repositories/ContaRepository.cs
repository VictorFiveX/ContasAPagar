using ContasAPagar.Application.Interfaces;
using ContasAPagar.Domain.Entities;
using ContasAPagar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasAPagar.Infrastructure.Repositories
{
    public class ContaRepository : IContaARepository
    {
        private readonly DBConnectionContext _context;

        public ContaRepository(DBConnectionContext context)
        {
            _context = context;
        }

        public async Task<ContaEntities> AdicionarAsync(ContaEntities conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<List<ContaEntities>> ListarAsync()
        {
            return await _context.Contas.ToListAsync();
        }
    }
}
