using NerdStore.Core.Communication;
using NerdStore.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, VendasContext context)
        {
            var domainEntities = context.ChangeTracker.Entries<Entity>().Where(x => x.Entity.Eventos != null && x.Entity.Eventos.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.Eventos.ToList());

            domainEntities.ToList().ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents.Select(async (domainEvent) =>
            {
                await mediator.PublicarEvento(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}
