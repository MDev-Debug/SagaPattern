using Domain.Interface;
using Domain.Models;
using Infra.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly PedidoContext _context;

    public PedidoRepository(PedidoContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido.Id;
    }

    public async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task UpdateAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }
}
