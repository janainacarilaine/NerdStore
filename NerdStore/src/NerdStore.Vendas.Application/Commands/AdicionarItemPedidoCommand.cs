using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(r => r.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido.");

            RuleFor(r => r.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido.");

             RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto não foi informado.");

             RuleFor(r => r.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade mínima de um ítem é 1.");

             RuleFor(r => r.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade máxima de um ítem é 15.");

             RuleFor(r => r.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("O valor do ítem precisa ser maior que 0.");
                
        }
    }
}
