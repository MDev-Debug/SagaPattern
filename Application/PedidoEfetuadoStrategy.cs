using Domain.Enum;
using Domain.Interface;
using Domain.Models;

namespace Application;

public class PedidoEfetuadoStrategy : IPedidoEfetuadoStrategy
{
    public void Processar(Pedido pedido)
    {
        if (pedido.Status != PedidoStatus.PedidoEfetuado)
            throw new InvalidOperationException("Estado inválido para o processamento.");

        pedido.Status = PedidoStatus.AguardandoPagamento;
        pedido.DataAtualizacao = DateTime.UtcNow;
    }
}
