using Application;
using Domain.Enum;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly PedidoSaga _pedidoSaga;

    public PedidosController(IPedidoRepository pedidoRepository, PedidoSaga pedidoSaga)
    {
        _pedidoRepository = pedidoRepository;
        _pedidoSaga = pedidoSaga;
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido()
    {
        var pedido = new Pedido
        {
            Status = PedidoStatus.PedidoEfetuado,
            DataCriacao = DateTime.UtcNow
        };

        var id = await _pedidoRepository.AddAsync(pedido);
        return Ok(id);
    }

    [HttpGet]
    public IActionResult Teste()
    {
        var env = Environment.GetEnvironmentVariable("SERVER");
        return Ok(env);
    }

    [HttpPut("{id}/processar")]
    public async Task<IActionResult> ProcessarPedido(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
            return NotFound();

        _pedidoSaga.ProcessarProximoEstado(pedido);
        await _pedidoRepository.UpdateAsync(pedido);

        return Ok(pedido);
    }
}
