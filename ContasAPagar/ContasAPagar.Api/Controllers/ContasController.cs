using ContasAPagar.Application.DTOs;
using ContasAPagar.Application.Interfaces;
using ContasAPagar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ContasController : Controller
{
    private readonly IContaAPagarService _service;

    public ContasController(IContaAPagarService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost("/conta/adicionar")]
    public async Task<IActionResult> AddConta([FromBody] ContaDTO conta)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var result = await _service.CalcularContaAsync(conta);
            return CreatedAtAction(nameof(AddConta), result);
        }
        catch (DbUpdateException dbEx)
        {
            return BadRequest(new
            {
                Mensagem = "Erro ao salvar a conta no banco de dados.",
                Detalhes = dbEx.InnerException?.Message ?? dbEx.Message
            });
        }
        catch (ArgumentException argEx)
        {
            return BadRequest(new { Mensagem = argEx.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Mensagem = "Ocorreu um erro interno no servidor.",
                Detalhes = ex.Message
            });
        }
    }

    [HttpGet("/conta/consultar")]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var contas = await _service.ListarContasAsync();
            return Ok(contas);
        }
        catch (DbUpdateException dbEx)
        {
            return BadRequest(new
            {
                Mensagem = "Erro ao consultar as contas no banco de dados.",
                Detalhes = dbEx.InnerException?.Message ?? dbEx.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Mensagem = "Ocorreu um erro interno no servidor.",
                Detalhes = ex.Message
            });
        }
    }
}
