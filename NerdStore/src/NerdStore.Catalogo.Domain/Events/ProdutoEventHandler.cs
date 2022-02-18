using MediatR;
using NerdStore.Core.Communication;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler :
        INotificationHandler<ProdutoBaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>,
        INotificationHandler<PedidoProcessamentoCanceladoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
        }

        public async Task Handle(ProdutoBaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);
        }

        public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);
            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total,
                            message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));

            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
            }
        }

        public async Task Handle(PedidoProcessamentoCanceladoEvent message, CancellationToken cancellationToken)
        {
            await _estoqueService.ReporListaProdutosPedido(message.ProdutosPedido);
        }
    }
}
