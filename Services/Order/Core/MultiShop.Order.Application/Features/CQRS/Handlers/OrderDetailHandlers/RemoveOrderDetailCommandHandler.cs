using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);

            await repository.DeleteAsync(values);
        }
    }
}
