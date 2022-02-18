using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Pagamentos.Business
{
    public class Transacao : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public EStatusTransacao StatusTransacao { get; set; }

        public Pagamento Pagamento { get; set; }
    }
}