using Domain.Models;

namespace Domain.Interface;

public interface IProcessamentoPedidoStrategy
{
    void Processar(Pedido pedido);
}
