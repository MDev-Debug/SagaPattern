using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Data;

public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
    }
}