using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler
        (IRepository<Ordering> repository)
        : IRequestHandler<RemoveOrderingCommand>
    {
        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);

            await repository.DeleteAsync(values);
        }
    }
}
