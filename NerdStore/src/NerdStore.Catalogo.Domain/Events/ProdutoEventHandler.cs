using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    class ProdutoEventHandler : INotificationHandler<ProdutoBaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoBaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
           var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);
        }
    }
}
