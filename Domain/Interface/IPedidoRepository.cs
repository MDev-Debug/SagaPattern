using Domain.Models;

namespace Domain.Interface;

public interface IPedidoRepository
{
    Task<Pedido> GetByIdAsync(int id);
    Task UpdateAsync(Pedido pedido);
    Task<int> AddAsync(Pedido pedido);
}
