using Domain.Enum;
using Domain.Interface;
using Domain.Models;

namespace Application;

public class AguardandoPagamentoStrategy : IAguardandoPagamentoStrategy
{
    public void Processar(Pedido pedido)
    {
        if (pedido.Status != PedidoStatus.AguardandoPagamento)
            throw new InvalidOperationException("Estado inválido para o processamento.");

        pedido.Status = PedidoStatus.PedidoPago;
        pedido.DataAtualizacao = DateTime.UtcNow;
    }
}
