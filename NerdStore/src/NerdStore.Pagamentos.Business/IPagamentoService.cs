using NerdStore.Core.DomainObjects.DTOs;
using System.Threading.Tasks;

namespace NerdStore.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}