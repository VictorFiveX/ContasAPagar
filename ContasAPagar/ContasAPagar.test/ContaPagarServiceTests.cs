using ContasAPagar.Application.DTOs;
using ContasAPagar.Application.Services;
using ContasAPagar.Domain.Entities;
using ContasAPagar.Infrastructure.Data;
using ContasAPagar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

public class ContaPagarServiceTests
{
    [Fact]
    public async Task Deve_Calcular_Atraso_Com_Multa_E_Juros()
    {
        var options = new DbContextOptionsBuilder<DBConnectionContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new DBConnectionContext(options);

        var repository = new ContaRepository(context);
        var service = new ContaAPagarService(repository);

        var conta = new ContaDTO(
            "Conta de Luz",
            100,
            DateTime.Now.AddDays(-4),
            DateTime.Now
        );

        var result = await service.CalcularContaAsync(conta);

        Assert.True(result.ValorCorrigido > 100);
        Assert.Equal(4, result.DiasAtraso);
    }
}