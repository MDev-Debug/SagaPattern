using Domain.Enum;
using Domain.Interface;
using Domain.Models;

namespace Application;
public class PedidoSaga
{
    private readonly IPedidoEfetuadoStrategy _pedidoEfetuadoStrategy;
    private readonly IAguardandoPagamentoStrategy _aguardandoPagamentoStrategy;
    private readonly ILogService _logService;

    public PedidoSaga(IPedidoEfetuadoStrategy pedidoEfetuadoStrategy,
                      IAguardandoPagamentoStrategy aguardandoPagamentoStrategy,
                      ILogService logService)
    {
        _pedidoEfetuadoStrategy = pedidoEfetuadoStrategy;
        _aguardandoPagamentoStrategy = aguardandoPagamentoStrategy;
        _logService = logService;
    }

    public void ProcessarProximoEstado(Pedido pedido)
    {
        try
        {
            _logService.LogInfo($"Processando pedido {pedido.Id} com status {pedido.Status}");
            var strategy = ObterStrategyPorStatus(pedido.Status);

            strategy.Processar(pedido);
        }
        catch (Exception ex)
        {
            _logService.LogError($"Erro ao processar pedido {pedido.Id}", ex);
            throw;
        }
    }

    private IProcessamentoPedidoStrategy ObterStrategyPorStatus(PedidoStatus status)
    {
        return status switch
        {
            PedidoStatus.PedidoEfetuado => _pedidoEfetuadoStrategy,
            PedidoStatus.AguardandoPagamento => _aguardandoPagamentoStrategy,
            _ => throw new InvalidOperationException($"Nenhuma estratégia encontrada para o status {status}.")
        };
    }
}

