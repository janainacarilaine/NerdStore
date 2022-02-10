﻿using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoBaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }
        public ProdutoBaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
