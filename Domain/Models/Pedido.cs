using Domain.Enum;

namespace Domain.Models;

public class Pedido
{
    public int Id { get; set; }
    public PedidoStatus Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
